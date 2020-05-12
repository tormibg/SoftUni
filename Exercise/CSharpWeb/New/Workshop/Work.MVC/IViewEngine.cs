namespace Work.MVC
{
    public interface IViewEngine
    {
        string GetHtml(string templateHtml, object model, string user);
    }
}
