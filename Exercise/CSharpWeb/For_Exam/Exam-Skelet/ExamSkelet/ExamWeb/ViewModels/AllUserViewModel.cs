using System.Collections;

namespace ExamWeb.ViewModels
{
    public class AllUserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        public override string ToString()
        {
            string template = $@"<tr>
					<td>{this.Id}</td>
					<td>{this.Username}</td>
					<td>{this.IsAdmin}</td>";

            return template;
        }
    }
}