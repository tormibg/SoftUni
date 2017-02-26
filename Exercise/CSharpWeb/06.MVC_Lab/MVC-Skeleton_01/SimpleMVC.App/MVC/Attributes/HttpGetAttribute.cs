using SimpleMVC.App.MVC.Attributes.Methods;

namespace SimpleMVC.App.MVC.Attributes
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "GET";
        }
    }
}