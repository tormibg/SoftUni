using System.Collections.Generic;
using AutoMapper;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
	public class AdminServices : Service, IAdminServices
	{
		public AdminPageVm GetAdminPage()
		{
			IEnumerable<Course> courses = this.Contex.Courses;
			IEnumerable<Student> students = this.Contex.Students;

			IEnumerable<CourseVm> coursesVms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVm>>(courses);
			IEnumerable<AdminPageUserVm> usersVms = Mapper.Map<IEnumerable<Student>, IEnumerable<AdminPageUserVm>>(students);

			AdminPageVm vm = new AdminPageVm
			{
				Courses = coursesVms,
				Users = usersVms
			};

			return vm;
		}
	}
}