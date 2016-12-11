using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MassDefect.DTOs;
using MassDefect.Models;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MassDefect
{
    class RunImport
    {
        private const string ErrorMsg = "Error: Invalid data.";
        private const string SolarSystemPath = "../../../../datasets/solar-systems.json";
        private const string StarsPath = "../../../../datasets/stars.json";
        private const string PlanetsPath = "../../../../datasets/planets.json";
        private const string PersonsPath = "../../../../datasets/persons.json";
        private const string AnomaliesPath = "../../../../datasets/anomalies.json";
        private const string AnomalyVictimsPath = "../../../../datasets/anomaly-victims.json";
        private const string XmlPath = "../../../../datasets/new-anomalies.xml";
        static void Main()
        {

            var context = new MassDefectContext();
            context.Database.Initialize(true);
            ImportSolarSystems();
            ImportStars();
            ImportPlanet();
            ImportPersons();
            ImportAnomilies();
            ImportAnomalyVictims();
            ImportFromXml();
        }

        private static void ImportFromXml()
        {
            var xml = XDocument.Load(XmlPath);
            var anomalies = xml.XPathSelectElements("anomalies/anomaly");

            var context = new MassDefectContext();

            foreach (var xElement in anomalies)
            {
                ImportNewAnomalyAndVictims(xElement, context);
            }
            context.SaveChanges();
        }

        private static void ImportNewAnomalyAndVictims(XElement anomalyNode, MassDefectContext context)
        {
            var originPlanetName = anomalyNode.Attribute("origin-planet");
            var teleportPlanetName = anomalyNode.Attribute("teleport-planet");

            if (originPlanetName == null || teleportPlanetName == null)
            {
                Console.WriteLine(ErrorMsg);
                return;
            }

            Anomalie anomalyEntity = new Anomalie
            {
                OriginPlanet = GetHomePlanetByName(originPlanetName.Value, context),
                TeleportPlanet = GetHomePlanetByName(teleportPlanetName.Value, context)
            };

            if (anomalyEntity.OriginPlanet.Name == null || anomalyEntity.TeleportPlanet.Name == null)
            {
                Console.WriteLine(ErrorMsg);
                return;
            }

            var victims = anomalyNode.XPathSelectElements("victims/victim");
            foreach (var xElement in victims)
            {
                ImportVictim(xElement, context, anomalyEntity);
            }
        }

        private static void ImportVictim(XElement victimNode, MassDefectContext context, Anomalie anomalyEntity)
        {
            var name = victimNode.Attribute("name");
            if (name == null)
            {
                Console.WriteLine(ErrorMsg);
                return;
            }

            Person personEntity = GetPersonByName(name.Value, context);

            if (personEntity.Name == null)
            {
                Console.WriteLine(ErrorMsg);
                return;
            }

            anomalyEntity.Persons.Add(personEntity);
            context.Anomalies.Add(anomalyEntity);
            Console.WriteLine($"Successfully imported anomaly.");
        }

        private static void ImportAnomalyVictims()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(AnomalyVictimsPath);
            var anomalyVictims = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimDTO>>(json);

            foreach (var anomalyVictimDto in anomalyVictims)
            {
                if (anomalyVictimDto.Id == null || anomalyVictimDto.Person == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;    
                }
                var anomalyEntity = GetAnomalyById(anomalyVictimDto.Id, context);
                var personEnitity = GetPersonByName(anomalyVictimDto.Person, context);

                if (anomalyEntity == null || personEnitity == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }

                anomalyEntity.Persons.Add(personEnitity);
            }
            context.SaveChanges();
        }

        private static Person GetPersonByName(string person, MassDefectContext context)
        {
            var result =  context.Persons.FirstOrDefault(p => p.Name.Equals(person));
            if (result == null)
            {
                result = new Person();
            }
            return result;
        }

        private static Anomalie GetAnomalyById(int id, MassDefectContext context)
        {
            var result =  context.Anomalies.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                result = new Anomalie();
            }
            return result;
        }

        private static void ImportAnomilies()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(AnomaliesPath);
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDTO>>(json);

            foreach (var anomalyDto in anomalies)
            {
                if (anomalyDto.OriginPlanet == null || anomalyDto.TeleportPlanet == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }
                Anomalie anomalieEntity = new Anomalie
                {
                    OriginPlanet = GetHomePlanetByName(anomalyDto.OriginPlanet, context),
                    TeleportPlanet = GetHomePlanetByName(anomalyDto.TeleportPlanet, context)
                };
                if (anomalieEntity.OriginPlanet.Name == null || anomalieEntity.TeleportPlanet.Name == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }
                context.Anomalies.Add(anomalieEntity);
                Console.WriteLine($"Successfully imported anomaly.");
            }
            context.SaveChanges();
        }

        private static void ImportPersons()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PersonsPath);
            var persons = JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(json);

            foreach (var personDto in persons)
            {
                if (personDto.Name == null || personDto.HomePlanet == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }
                Person entityPerson = new Person
                {
                    Name = personDto.Name,
                    HomePlanet = GetHomePlanetByName(personDto.HomePlanet, context)
                };
                if (entityPerson.HomePlanet.Name == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }
                context.Persons.Add(entityPerson);
                Console.WriteLine($"Successfully imported Person {entityPerson.Name}.");
            }
            context.SaveChanges();
        }

        private static Planet GetHomePlanetByName(string personDtoHomePlanet, MassDefectContext context)
        {
            var result = context.Planets.FirstOrDefault(pl => pl.Name.Equals(personDtoHomePlanet));
            if (result == null)
            {
                result = new Planet();
            }
            return result;
        }

        private static void ImportPlanet()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PlanetsPath);
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDTO>>(json);

            foreach (var planetDto in planets)
            {
                if (planetDto.Name == null || planetDto.SolarSystem == null || planetDto.Sun == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }
                var planetEntity = new Planet
                {
                    Name = planetDto.Name,
                    Sun = GetSunByName(planetDto.Sun, context),
                    SolarSystem = GetSolarSystemByName(planetDto.SolarSystem, context)
                };
                if (planetEntity.SolarSystem.Name == null || planetEntity.Sun.Name == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }
                context.Planets.Add(planetEntity);
                Console.WriteLine($"Successfully imported Planet {planetEntity.Name}.");
            }
            context.SaveChanges();
        }

        private static Star GetSunByName(string planetDtoSun, MassDefectContext context)
        {
            var result =  context.Stars.FirstOrDefault(s => s.Name.Equals(planetDtoSun));
            if (result == null)
            {
                result = new Star();
            }
            return result;
        }

        private static void ImportStars()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(StarsPath);
            var starts = JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(json);

            foreach (var starDto in starts)
            {
                if (starDto.Name == null || starDto.SolarSystem == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }

                var starEntity = new Star
                {
                    Name = starDto.Name,
                    SolarSystem = GetSolarSystemByName(starDto.SolarSystem, context)
                };

                if (starEntity.SolarSystem.Name == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }
                context.Stars.Add(starEntity);
                Console.WriteLine($"Successfully imported Star {starEntity.Name}.");
            }
            context.SaveChanges();
        }

        private static SolarSystem GetSolarSystemByName(string starDtoSolarSystem, MassDefectContext context)
        {
            var result =  context.SolarSystems.FirstOrDefault(ss => ss.Name.Equals(starDtoSolarSystem));
            if (result == null)
            {
                result = new SolarSystem();
            }
            return result;
        }

        private static void ImportSolarSystems()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(SolarSystemPath);
            var solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(json);

            foreach (var solarSystemDto in solarSystems)
            {
                if (solarSystemDto.Name == null)
                {
                    Console.WriteLine(ErrorMsg);
                    continue;
                }
                var solarSystemsEntity = new SolarSystem { Name = solarSystemDto.Name };
                context.SolarSystems.Add(solarSystemsEntity);
                Console.WriteLine($"Successfully imported Solar System {solarSystemDto.Name}.");
            }

            context.SaveChanges();
        }
    }
}
