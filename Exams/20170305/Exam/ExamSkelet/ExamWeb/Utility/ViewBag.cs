using System.Collections.Generic;

namespace SoftUniStore.App.Utility
{
    public static class ViewBag
    {
        public static Dictionary<string, dynamic> Bag = new Dictionary<string, dynamic>();

        public static dynamic GetUserName()
        {
            if (Bag.ContainsKey("fullname"))
            {
                return Bag["fullname"];
            }

            return null;
        }
    }
}
