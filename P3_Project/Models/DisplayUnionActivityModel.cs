﻿namespace P3_Project.Models
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
    }
}
