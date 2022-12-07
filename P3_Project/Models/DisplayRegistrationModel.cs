using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Project.Models
{
    public class DisplayRegistrationModel
    {
        [Required(ErrorMessage = "Indtast venligst flyets registreringsnummer.")]
        public string? FlightRegistrationNumber { get; set; }

        [Required(ErrorMessage = "Indtast venligst flyets type.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Indtast venligst flyets MTOW.")]
        public int MaxTakeoffWeight { get; set; }

        [Required(ErrorMessage = "Indtast venligst flyveklub.")]
        public string Club { get; set; }

        [Required(ErrorMessage ="Indtast venligst en start distination.")]
        public string StartDestination { get; set; }
        
        //[Required(ErrorMessage ="Indtast venligst et gyldigt navn.")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Indtast venligst en Email addresse.")]
        //[EmailAddress(ErrorMessage = "Dette er ikke en gyldig Email addresse.")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Indtast venligst et mobilnummer.")]
        //[Phone(ErrorMessage = "Dette er ikke et mobilnummer.")]
        public string Phonenumber { get; set; }
        
        //[Required(ErrorMessage ="Vælg en deltager rolle.")]
        public string ParticipantType { get; set; }

        public int UnionActivityID { get; set; }
    }
}
