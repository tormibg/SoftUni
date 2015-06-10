using System;
using Company.Interfaces;

namespace Company.Models
{
    public class Project:IProject
    {
        //private string projectName;
        //private DateTime stDate;
        //private string details;
        //private State state;

        public Project(string projectName, DateTime stDate, string details, State state)
        {
            this.ProjectName = projectName;
            this.StDate = stDate;
            this.Details = details;
            this.State = state;
        }

        public string ProjectName { get; set; }
        public DateTime StDate { get; set; }
        public string Details { get; set; }
        public State State { get; set; }

        public void CloseProject()
        {
            this.State = State.Closed;
        }
    }
}
