namespace Company.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IDeveloper
    {
        IList<Project> Projects { get; set; }

        void AddProjects(IList<Project> projects);


    }
}