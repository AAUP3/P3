using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool IsVisible { get; set; }
        public bool RequireName { get; set; }
        public bool RequireEmail { get; set; }
        public bool RequirePhonenumber { get; set; }
        public bool IsYearlyActivity { get; set; }
        public bool AllowRegistration { get; set; }
        public bool AllowGroupRegistration { get; set; }
        public string Information1 { get; set; }
        public string Information2 { get; set; }
        public string Information3 { get; set; }
        public string Information4 { get; set; }
        public string Information5 { get; set; }
        public string PInformation1 { get; set; }
        public string PInformation2 { get; set; }
        public string PInformation3 { get; set; }
        public string PInformation4 { get; set; }
        public string PInformation5 { get; set; }
    }
}
