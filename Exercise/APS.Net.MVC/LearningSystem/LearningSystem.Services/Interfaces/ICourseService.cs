using LearningSystem.Models.ViewModels.Courses;

namespace LearningSystem.Services.Interfaces
{
	public interface ICourseService
	{
		CourseDetailsVm GetDetailsById(int id);
	}
}