using AutoMapper;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
	public class CourseService : Service, ICourseService
	{
		public CourseDetailsVm GetDetailsById(int id)
		{
			Course course = this.Contex.Courses.Find(id);
			if (course == null)
			{
				return null;
			}
			CourseDetailsVm vm = Mapper.Map<Course, CourseDetailsVm>(course);
			return vm;
		}
	}
}