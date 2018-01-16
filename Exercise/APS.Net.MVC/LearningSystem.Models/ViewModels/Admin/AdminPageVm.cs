﻿using System.Collections.Generic;
using LearningSystem.Models.ViewModels.Courses;

namespace LearningSystem.Models.ViewModels.Admin
{
	public class AdminPageVm
	{
		public IEnumerable<CourseVm> Courses { get; set; }

		public IEnumerable<AdminPageUserVm> Users { get; set; }
	}
}