using System.Collections.Generic;
using ForumSystem.Data.Models;
using ForumSystem.Services.Mapping;

namespace ForumSystem.Web.ViewModels.Categories
{

    public class PostInCategoryVewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCounts { get; set; }
    }
}
