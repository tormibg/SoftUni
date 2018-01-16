using System;
using System.ComponentModel;

namespace LearningSystem.Models.ViewModels.Courses
{
	public class CourseDetailsVm
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		[DisplayName("Start Date :")]
		public DateTime StartDate { get; set; }

		[DisplayName("End Date :")]
		public DateTime EndtDate { get; set; }
	}
}