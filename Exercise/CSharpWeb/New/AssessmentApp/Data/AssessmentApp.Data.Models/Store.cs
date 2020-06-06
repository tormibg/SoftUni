namespace AssessmentApp.Data.Models
{
    using AssessmentApp.Data.Common.Models;

    public class Store : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
