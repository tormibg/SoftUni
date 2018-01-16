using LearningSystem.Models.BindingModels.Users;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;

namespace LearningSystem.Services.Interfaces
{
	public interface IUsersService
	{
		Student GetStudentByName(string userName);
		void EnrollStudentInCourse(int courseId, Student student);
		ProfileVm GetProfileVm(string userName);
		UserEditVm GetUserEditVm(string userName);
		void EditUser(UserEditBm bind, string userName);
	}
}