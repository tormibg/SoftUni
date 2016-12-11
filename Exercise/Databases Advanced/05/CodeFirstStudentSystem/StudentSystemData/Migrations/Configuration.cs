using System;
using System.Collections.Generic;
using StudentSystemModels;

namespace StudentSystemData.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemData.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentSystemData.StudentSystemContext";
        }

        protected override void Seed(StudentSystemData.StudentSystemContext context)
        {
            context.Courses.AddOrUpdate(course => course.Name,
                new Course()
                {
                    Name = "C#",
                    Description = "some sharp",
                    EndDate = new DateTime(2017, 2, 3),
                    Price = 2,
                    Homeworks = new List<Homework>()
                    {
                        new Homework()
                        {
                        Content = "C# homework",
                        ContentType = Homework.ContentOfType.Application,
                        SubmissionDate = DateTime.Today,
                        Student = new Student()
                        {
                            Names = "Pesho",
                            RegistredOn = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                        },
                        new Homework()
                        {
                           Content = "java homework",
                        ContentType = Homework.ContentOfType.Pdf,
                        SubmissionDate = DateTime.Today,
                        Student = new Student()
                        {
                            Names = "Stancho",
                            RegistredOn = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                        }
                    },
                    StartDate = DateTime.Today,
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Names = "Ivo",
                            RegistredOn = DateTime.Today,
                            PhoneNumber = "08869899899"
                        } ,
                         new Student()
                        {
                            Names = "Reni",
                            RegistredOn = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                    },
                    Resources = new List<Resource>()
                    {
                        new Resource()
                        {
                            Name = "rsrc",
                            ResourceType = Resource.ResourceOfType.Document,
                            Url = "usadl"
                        },
                        new Resource()
                        {
                             Name = "redasdas",
                             ResourceType = Resource.ResourceOfType.Document,
                             Url = "fsafasf"
                        }
                    }
                });
        }
    }
}
