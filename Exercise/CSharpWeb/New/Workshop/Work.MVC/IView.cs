namespace Work.MVC
{
    public interface IView
    {
        string GetHtml(object model, string user);
    }
}
