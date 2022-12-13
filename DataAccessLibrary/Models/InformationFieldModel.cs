using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class InformationFieldModel
    {
        //public int Number { get; set; }
        public string Name { get; set; }
        public InformationFieldModel(string name)
        {
            Name = name;
        }
    }
}
