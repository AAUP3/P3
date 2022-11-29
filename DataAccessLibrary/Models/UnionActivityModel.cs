using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class UnionActivityModel
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
