namespace Company.Interfaces
{
    using System;
 
    public interface IProject
    {
        string ProjectName { get; set; }

        string Details { get; set; }

        DateTime StDate { get; set; }

        void CloseProject();
    }
}