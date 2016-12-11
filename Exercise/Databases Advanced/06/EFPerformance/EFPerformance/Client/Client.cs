using System;
using System.Diagnostics;
using System.Linq;
using DATA;

namespace Client
{
    class Client
    {
        static void Main()
        {
            var context = new AdsContext();
            var watch = new Stopwatch();
            watch.Start();
            //SelectAllAds(context);
            //SelectAllAdsInclude(context);
            //PlayWithToList(context);
            //PlayWithToListOptimized(context);
            //SelectAll(context);
            SelectOnlyTitle(context);
            watch.Stop();
            Console.WriteLine($"------------ {watch.Elapsed} -----------");
        }

        private static void SelectOnlyTitle(AdsContext context)
        {
            var titles = context.Ads.Select(c => c.Title);
            foreach (var title in titles)
            {
                Console.WriteLine($"{title}");
            }
        }

        private static void SelectAll(AdsContext context)
        {
            var all = context.Ads;
            foreach (var ad in all)
            {
                Console.WriteLine($"{ad.Title}");
            }         
        }

        private static void PlayWithToListOptimized(AdsContext context)
        {
            context.Ads.SqlQuery("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
            var ads =
                context.Ads
                    .Where(c => c.AdStatus.Status == "Published")
                    .Select(
                        c =>
                            new
                            {
                                AdTitle = c.Title,
                                AdCategoryName = c.Category.Name,
                                AdTownName = c.Town.Name,
                                AdDate = c.Date
                            }).OrderBy(c => c.AdDate);
            foreach (var ad in ads)
            {
                Console.WriteLine($"{ad.AdTitle} {ad.AdCategoryName} {ad.AdTownName} {ad.AdDate}");
            }
        }

        private static void PlayWithToList(AdsContext context)
        {
            context.Ads.SqlQuery("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
            var ads =
                context.Ads.ToList()
                    .Where(c => c.AdStatus?.Status == "Published")
                    .Select(
                        c =>
                            new
                            {
                                AdTitle = c.Title,
                                AdCategoryName = c.Category?.Name,
                                AdTownName = c.Town?.Name,
                                AdDate = c.Date
                            })
                    .ToList()
                    .OrderBy(c => c.AdDate);
            foreach (var ad in ads)
            {
                Console.WriteLine($"{ad.AdTitle} {ad.AdCategoryName} {ad.AdTownName} {ad.AdDate}");
            }
        }

        private static void SelectAllAdsInclude(AdsContext context)
        {
            var ads = context.Ads.Include("AdStatus").Include("Category").Include("Town").Include("AspNetUser");
            foreach (var ad in ads)
            {
                Console.WriteLine($"{ad.Title} - {ad.AdStatus?.Status} - {ad.Category?.Name} - {ad.Town?.Name} - {ad.AspNetUser?.Name}");
            }
        }

        private static void SelectAllAds(AdsContext context)
        {
            var ads = context.Ads;
            foreach (var ad in ads)
            {
                Console.WriteLine($"{ad.Title} - {ad.AdStatus?.Status} - {ad.Category?.Name} - {ad.Town?.Name} - {ad.AspNetUser?.Name}");
            }
        }
    }
}
