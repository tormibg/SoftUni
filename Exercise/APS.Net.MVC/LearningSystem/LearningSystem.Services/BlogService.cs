using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Services
{
	public class BlogService : Service, IBlogService
	{
		public IEnumerable<ArticleVm> GetAllArticles()
		{
			IEnumerable<Article> articles = this.Contex.Articles;
			IEnumerable<ArticleVm> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);
			return vms;
		}

		public void AddNewArticle(AddArticleBm bind, string userName)
		{
			ApplicationUser currentUser = this.Contex.Users.FirstOrDefault(u => u.UserName == userName);
			Article vm = Mapper.Map<AddArticleBm, Article>(bind);
			vm.Author = currentUser;
			vm.PublishDate = DateTime.Now;
			this.Contex.Articles.Add(vm);
			this.Contex.SaveChanges();
		}
	}
}