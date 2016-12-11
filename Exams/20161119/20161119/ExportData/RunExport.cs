using System.IO;
using System.Linq;
using System.Xml.Linq;
using MassDefect;
using Newtonsoft.Json;

namespace ExportData
{
    class RunExport
    {
        private const string XmlFile = "../../../../datasets/anomalies.xml";
        private const string AnomalyJson = "../../../../datasets/persons.json";
        private const string TopAnomalyJson = "../../../../datasets/top-anomaly.json";
        private const string PlanetJson = "../../../../datasets/planets.json";

        static void Main()
        {
            var context = new MassDefectContext();

            ExportPlanetsWichAreNotAnomalyOrigins(context);
            ExportPersonWichHaveNotBeenVictims(context);
            ExportTopAnomaly(context);
            ExportDataToXml(context);

        }

        private static void ExportDataToXml(MassDefectContext context)
        {
            //var exportedAnomalies =
            //    context.Anomalies.Where(a => a.OriginPlanet.SolarSystemId == 1 && a.TeleportPlanet.SolarSystemId == 1).OrderBy(a => a.Id)
            //        .Select(a => new
            //        {
            //            id = a.Id,
            //            originPlanetName = a.OriginPlanet.Name,
            //            teleportPlanetName = a.TeleportPlanet.Name,
            //            victimsAll = a.Persons
            //        });

            var exportedAnomalies = context.Anomalies
                    .Select(a => new
                    {
                        id = a.Id,
                        originPlanetName = a.OriginPlanet.Name,
                        teleportPlanetName = a.TeleportPlanet.Name,
                        victimsAll = a.Persons
                    });

            exportedAnomalies = exportedAnomalies.OrderBy(e => e.id);

            var xmlDocument = new XElement("anomalies");

            foreach (var exportedAnomaly in exportedAnomalies)
            {
                var anomalyNode = new XElement("anomaly");
                anomalyNode.Add(new XAttribute("id", exportedAnomaly.id));
                anomalyNode.Add(new XAttribute("origin-planet", exportedAnomaly.originPlanetName));
                anomalyNode.Add(new XAttribute("teleport-planet", exportedAnomaly.teleportPlanetName));

                var victimsNode = new XElement("victims");

                foreach (var person in exportedAnomaly.victimsAll)
                {
                    var victimNode = new XElement("victim");
                    victimNode.Add(new XAttribute("name", person.Name));
                    victimsNode.Add(victimNode);
                }

                anomalyNode.Add(victimsNode);
                xmlDocument.Add(anomalyNode);
            }
            xmlDocument.Save(XmlFile);
        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var exportedAnomaly = context.Anomalies.OrderByDescending(a => a.Persons.Count).Take(1).Select(anom => new
            {
                id = anom.Id,
                originPlanet = new { name = anom.OriginPlanet.Name },
                teleportPlanet = new { name = anom.TeleportPlanet.Name },
                victimsCount = anom.Persons.Count
            });

            var anomalyJson = JsonConvert.SerializeObject(exportedAnomaly, Formatting.Indented);
            File.WriteAllText(TopAnomalyJson, anomalyJson);
        }

        private static void ExportPersonWichHaveNotBeenVictims(MassDefectContext context)
        {
            var exportedPerson = context.Persons.Where(p => !p.Anomalies.Any()).Select(person => new
            {
                name = person.Name,
                homeplanet = new { name = person.Name }

            });

            var personJson = JsonConvert.SerializeObject(exportedPerson, Formatting.Indented);
            File.WriteAllText(AnomalyJson, personJson);
        }

        private static void ExportPlanetsWichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var exportedPlanets = context.Planets.Where(p => !p.OriginAnomalies.Any()).Select(planet => new
            {
                name = planet.Name
            });

            var planetJson = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            File.WriteAllText(PlanetJson, planetJson);
        }
    }
}
