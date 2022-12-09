namespace P3_Project.Models
{
    public class DisplayUnionActivityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfActivity { get; set; }
        public TimeSpan ActivityDuration { get; set; }
        public bool IsVisible { get; set; }
        public bool ActivationState { get; set; }
        public bool RequireName { get; set; }
        public bool RequireEmail { get; set; }
        public bool RequirePhonenumber { get; set; }
        public string Information1 { get; set; }
        public string Information2 { get; set; }
        public string Information3 { get; set; }
        public string Information4 { get; set; }
        public string Information5 { get; set; }
    }
}
