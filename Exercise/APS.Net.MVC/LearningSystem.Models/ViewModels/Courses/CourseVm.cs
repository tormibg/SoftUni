using System.ComponentModel;

namespace LearningSystem.Models.ViewModels.Courses
{
	public class CourseVm
	{
		public int Id { get; set; }

		[DisplayName("Name: ")]
		public string Name { get; set; }
	}
}