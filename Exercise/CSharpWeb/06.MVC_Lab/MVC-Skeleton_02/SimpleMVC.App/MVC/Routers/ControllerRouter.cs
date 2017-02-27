using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleMVC.App.Extensions;
using SimpleMVC.App.MVC.Attributes.Methods;
using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.MVC.Routers
{
    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        private HttpRequest request;
        private HttpResponse response;

        private string[] controllerActionParams;
        private string[] controllerActions;

        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
            this.request = new HttpRequest();
            this.response = new HttpResponse();
        }

        public HttpResponse Handle(HttpRequest request)
        {
            this.request = request;
            this.response = new HttpResponse();
            this.ParseInput();

            MethodInfo method = this.GetMethod();
            Controller controller = this.GetController();

            IInvocable actionResult = (IInvocable)this.GetMethod().Invoke(this.GetController(), this.methodParams);

            if (string.IsNullOrEmpty(this.response.Header.Location))
            {
                string content = actionResult.Invoke();

                this.response.StatusCode = ResponseStatusCode.Ok;
                this.response.ContentAsUTF8 = content;


            }

            this.ClearRequestParameters();
            return response;
        }

        private void ClearRequestParameters()
        {
            this.postParams = new Dictionary<string, string>();
            this.getParams = new Dictionary<string, string>();
        }

        private void ParseInput()
        {
            string url = WebUtility.UrlDecode(this.request.Url);
            string query = string.Empty;
            if (this.request.Url.Contains("?"))
            {
                query = this.request.Url.Split('?')[1];
            }
            this.controllerActionParams = url.Split('?');
            this.controllerActions = controllerActionParams[0].Split(new char[] { '/' },
                StringSplitOptions.RemoveEmptyEntries);
            this.controllerActionParams = query.Split('&');

            // Get Parameters
            if (controllerActionParams.Length >= 1)
            {
                foreach (var controllerActionParam in this.controllerActionParams)
                {
                    if (controllerActionParam.Contains("="))
                    {
                        string[] keyValue = controllerActionParam.Split('=');
                        this.getParams.Add(keyValue[0], keyValue[1]);
                    }
                }
            }

            //Post parameters
            string postParameters = request.Content;
            if (postParameters != null)
            {
                postParameters = WebUtility.UrlDecode(postParameters);
                string[] pairs = postParameters.Split('&');
                foreach (var pair in pairs)
                {
                    string[] keyValue = pair.Split('=');
                    this.postParams.Add(keyValue[0], keyValue[1]);
                }
            }

            this.InitRequestMethod();
            this.InitControllerName();
            this.InitActionName();

            MethodInfo method = this.GetMethod();
            if (method == null)
            {
                throw new NotSupportedException("No such method");
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            this.methodParams = new object[parameters.Count()];

            int index = 0;
            foreach (ParameterInfo parameter in parameters)
            {
                if (parameter.ParameterType.IsPrimitive) // || parameter.ParameterType == typeof(string)
                {
                    object value = this.getParams[parameter.Name];
                    this.methodParams[index] = Convert.ChangeType(value, parameter.ParameterType);
                    index++;
                }
                else if (parameter.ParameterType == typeof(HttpRequest))
                {
                    this.methodParams[index] = this.request;
                    index++;
                }
                else if (parameter.ParameterType == typeof(HttpResponse))
                {
                    this.methodParams[index] = this.response;
                    index++;
                }
                else if (parameter.ParameterType == typeof(HttpSession))
                {
                    this.methodParams[index] = this.request.Session;
                    index++;
                }
                else
                {
                    Type bindingModelType = parameter.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);
                    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name], property.PropertyType));
                    }

                    this.methodParams[index] = Convert.ChangeType(bindingModel, bindingModelType);
                    index++;
                }
            }
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;
            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo.GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && this.requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }
            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            return this.GetController().GetType().GetMethods().Where(c => c.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerType =
                $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ControllerFolder}.{this.controllerName}";

            var controller = (Controller)Activator.CreateInstance(Type.GetType(controllerType));

            return controller;
        }

        private void InitActionName()
        {
            this.actionName = this.controllerActions[this.controllerActions.Length - 1].ToUpperFirst();
        }

        private void InitControllerName()
        {
            this.controllerName = this.controllerActions[this.controllerActions.Length - 2].ToUpperFirst() +
                                  MvcContext.Current.ControllerSuffix;
        }

        private void InitRequestMethod()
        {
            this.requestMethod = this.request.Method.ToString();
        }
    }
}