﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Models.ViewModels.Users;

namespace LearningSystem.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			CongigerMappings();
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		private void CongigerMappings()
		{
			Mapper.Initialize(expression =>
			{
				expression.CreateMap<Course, CourseVm>();
				expression.CreateMap<Course, CourseDetailsVm>();
				expression.CreateMap<ApplicationUser, ProfileVm>();
				expression.CreateMap<Course, UserCourseVm>();
				expression.CreateMap<ApplicationUser, UserEditVm>();
				expression.CreateMap<Article, ArticleVm>();
				expression.CreateMap<ApplicationUser, ArticleAuthorVm>();
				expression.CreateMap<AddArticleBm, Article>();
				expression.CreateMap<Student, AdminPageUserVm>()
					.ForMember(vm => vm.Name,
						configurationExpression => configurationExpression.MapFrom(student => student.User.Name));
			});
		}
	}
}
