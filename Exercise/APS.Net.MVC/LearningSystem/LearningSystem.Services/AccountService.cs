using LearningSystem.Models.EntityModels;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
	public class AccountService : Service, IAccountService
	{
		public void CreateStudent(ApplicationUser user)
		{
			Student student = new Student();
			ApplicationUser currentUser = this.Contex.Users.Find(user.Id);
			student.User = currentUser;
			this.Contex.Students.Add(student);
			this.Contex.SaveChanges();
		}
	}
}