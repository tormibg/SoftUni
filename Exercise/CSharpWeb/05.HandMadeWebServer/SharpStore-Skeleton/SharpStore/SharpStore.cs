using SimpleHttpServer;

namespace SharpStore
{
    internal class SharpStore
    {
        private static void Main()
        {
            var routes = RouteConfig.GetList();

            //var context = new SharpStoreContext();
            //var knive = context.Knives.ToList();

            //var kn = new Knive()
            //{
            //    Name = "test 1",
            //    Price = (SqlMoney) 123.12,
            //    ImageUrl = $"http://www.mwgco.com/mm5/graphics/00000001/CRKT_knives_Mini_My_Tighe.jpg"
            //};
            //context.Knives.Add(kn);
            //context.SaveChanges();

            //Console.WriteLine(knive.Count);

            var server = new HttpServer(8081, routes);
            server.Listen();
        }
    }
}