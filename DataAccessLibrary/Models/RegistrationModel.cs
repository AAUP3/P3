using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class RegistrationModel
    {
        public string? FlightRegistrationNumber { get; set; }
        public string Type { get; set; }
        public int MaxTakeoffWeight { get; set; }
        public string Club { get; set; }
        public string StartDestination { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phonenumber { get; set; }
        public string ParticipantType { get; set; }
        public int UnionActivityID { get; set; }
        public string UserId { get; set; }
        public string Information1  { get; set; }
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
