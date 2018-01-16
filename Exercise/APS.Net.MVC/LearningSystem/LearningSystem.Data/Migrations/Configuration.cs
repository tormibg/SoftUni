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
					Description = "����������� �����������, ���������� ����a \"Programming Basics\" � ����� C#! ���������� � ��������� � ��������� �� ������� ���������, ���� ���� ������� ������ �� ������������ � ����� C#, ���������� �� ������ ������������ ������������ � �������.",
					StartDate = new DateTime(2017,05,20),
					EndtDate = new DateTime(2017,07,21)
				},
				new Course()
				{
					Name = "C# MVC Frameworks - ASP.NET - ���� 2017",
					Description = "������ \"ASP.NET MVC\" �� �� ����� ��� �� ��������� ���������� ��� ���������� � ������������� Model-View-Controller, ����������� HTML5, ���� �����, Entity Framework � ����� ����������. ������� �� �������������� ��������� ASP.NET, ������� ���������� � �����������, ����������� �� MVC ��� ����������, ������������ �� ������, ������� � �������� ������� � Razor view engine, ���������� �� ����������, ������ � ���� ����� � ���������� � Entity Framework, LINQ � SQL Server. ������ ������ � ��-������ ���� ���� ������ � �����������, ���� � �����, ���������� �� AJAX, ��������, ��������� �� ��� ������������, ��� ������ � SignalR � ������ � ���������� �� MVC ��������. �������� �� ������� ����������� ����������� ���������� (������) � ����������� �� ���������� �� ��������, ����������������� ASP.NET MVC ��� ����������. ������ ������� ������ �� ������ ������ �� ���������� �� ��� ���������� � �������� � ����������� ����� �� ��� ���������� � ASP.NET MVC.",
					StartDate = new DateTime(2017,03,05),
					EndtDate = new DateTime(2017,05,05)
				},
				new Course()
				{
					Name = "Software Technologies - �������� 2017",
					Description = "������ \"Software Technologies\" ���� ������� �������� �� ���-������������ ��������� ���������� � ���������� � ��������� �� ���������� �� �� ���������� ��� ���������� �� ��������, �� �� �� �������� ��-�����������. �������� �� ������ ��������� �� front-end � back-end ������������. ������ �� ������ �� ������ �����: HTML5 ���������� (HTML + CSS + JavaScript + AJAX + REST), PHP ��� ���������� (PHP + MySQL), C# ��� ���������� (ASP.NET MVC + Entity Framework + SQL Server) � Java ��� ���������� (Java + Spring MVC + Hibernate + MySQL).",
					StartDate = new DateTime(2017,02,27),
					EndtDate = new DateTime(2017,04,29)
				}, 
			});
		}
	}
}
