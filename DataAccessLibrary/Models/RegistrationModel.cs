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
        public string FlightRegistrationNumber { get; set; }
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
    }
}
