using System;
using System.Linq;
using LearningSystem.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearningSystem.Data.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<LearningSystemContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(LearningSystemContext context)
		{
			if (!context.Roles.Any(role => role.Name == "Student"))
			{
				var store = new RoleStore<IdentityRole>(context);
				var manager = new RoleManager<IdentityRole>(store);
				var role = new IdentityRole("Student");
				manager.Create(role);
			}
			if (!context.Roles.Any(role => role.Name == "Admin"))
			{
				var store = new RoleStore<IdentityRole>(context);
				var manager = new RoleManager<IdentityRole>(store);
				var role = new IdentityRole("Admin");
				manager.Create(role);
			}
			if (!context.Roles.Any(role => role.Name == "Trainer"))
			{
				var store = new RoleStore<IdentityRole>(context);
				var manager = new RoleManager<IdentityRole>(store);
				var role = new IdentityRole("Trainer");
				manager.Create(role);
			}
			if (!context.Roles.Any(role => role.Name == "BlogAuthor"))
			{
				var store = new RoleStore<IdentityRole>(context);
				var manager = new RoleManager<IdentityRole>(store);
				var role = new IdentityRole("BlogAuthor");
				manager.Create(role);
			}

			context.Courses.AddOrUpdate(course => course.Name, new Course[]
			{
				new Course()
				{
					Name = "Programming Basics C#",
					Description = "Софтуерният университет, организира курсa \"Programming Basics\" с езика C#! Обучението е безплатно и подходящо за напълно начинаещи, като дава начални умения по програмиране с езика C#, необходими за всички технологични специалности в СофтУни.",
					StartDate = new DateTime(2017,05,20),
					EndtDate = new DateTime(2017,07,21)
				},
				new Course()
				{
					Name = "C# MVC Frameworks - ASP.NET - март 2017",
					Description = "Курсът \"ASP.NET MVC\" ще ви научи как се изграждат съвременни уеб приложения с архитектурата Model-View-Controller, използвайки HTML5, бази данни, Entity Framework и други технологии. Изучава се технологичната платформа ASP.NET, нейните компоненти и архитектура, създаването на MVC уеб приложения, дефинирането на модели, изгледи и частични изгледи с Razor view engine, дефиниране на контролери, работа с бази данни и интеграция с Entity Framework, LINQ и SQL Server. Курсът включа и по-сложни теми като работа с потребители, роли и сесии, използване на AJAX, кеширане, сигурност на уеб приложенията, уеб сокети и SignalR и работа с библиотеки от MVC контроли. Включват се няколко практически лабораторни упражнения (лабове) и работилници за изграждане на цялостни, пълнофункционални ASP.NET MVC уеб приложения. Курсът включва работа по екипен проект за изграждане на уеб приложение и завършва с практически изпит по уеб разработка с ASP.NET MVC.",
					StartDate = new DateTime(2017,03,05),
					EndtDate = new DateTime(2017,05,05)
				},
				new Course()
				{
					Name = "Software Technologies - февруари 2017",
					Description = "Курсът \"Software Technologies\" дава начални познания по най-използваните софтуерни технологии в практиката и позволява на студентите да се ориентират кои технологии им харесват, за да ги изучават по-задълбочено. Изучават се базови концепции от front-end и back-end разработката. Курсът се състои от четири части: HTML5 разработка (HTML + CSS + JavaScript + AJAX + REST), PHP уеб разработка (PHP + MySQL), C# уеб разработка (ASP.NET MVC + Entity Framework + SQL Server) и Java уеб разработка (Java + Spring MVC + Hibernate + MySQL).",
					StartDate = new DateTime(2017,02,27),
					EndtDate = new DateTime(2017,04,29)
				}, 
			});
		}
	}
}
