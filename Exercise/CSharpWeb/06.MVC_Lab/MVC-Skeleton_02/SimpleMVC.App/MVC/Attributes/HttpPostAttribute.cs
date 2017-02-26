using SimpleMVC.App.MVC.Attributes.Methods;

namespace SimpleMVC.App.MVC.Attributes
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "POST";
        }
    }
}