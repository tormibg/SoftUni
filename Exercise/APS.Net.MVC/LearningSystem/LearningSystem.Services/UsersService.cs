using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LearningSystem.Models.BindingModels.Users;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
	public class UsersService : Service, IUsersService
	{
		public Student GetStudentByName(string userName)
		{
			var user = this.Contex.Users.FirstOrDefault(u => u.UserName == userName);
			Student student = this.Contex.Students.FirstOrDefault(st => st.User.Id == user.Id);
			return student;
		}

		public void EnrollStudentInCourse(int courseId, Student student)
		{
			Course course = this.Contex.Courses.Find(courseId);
			student.Courses.Add(course);
			this.Contex.SaveChanges();
		}

		public ProfileVm GetProfileVm(string userName)
		{
			ApplicationUser currentUser = this.Contex.Users.FirstOrDefault(u => u.UserName == userName);
			ProfileVm vm = Mapper.Map<ApplicationUser, ProfileVm>(currentUser);
			Student currentStudent = this.Contex.Students.FirstOrDefault(student => student.User.Id == currentUser.Id);
			vm.EnrolledCourses = Mapper.Map<IEnumerable<Course>, IEnumerable<UserCourseVm>>(currentStudent.Courses);
			return vm;
		}

		public UserEditVm GetUserEditVm(string userName)
		{
			ApplicationUser user = this.Contex.Users.FirstOrDefault(u => u.UserName == userName);
			UserEditVm vm = Mapper.Map<ApplicationUser, UserEditVm>(user);
			return vm;
		}

		public void EditUser(UserEditBm bind, string userName)
		{
			ApplicationUser user = this.Contex.Users.FirstOrDefault(u => u.UserName == userName);
			user.Name = bind.Name;
			user.Email = bind.Email;
			this.Contex.SaveChanges();
		}
	}
}