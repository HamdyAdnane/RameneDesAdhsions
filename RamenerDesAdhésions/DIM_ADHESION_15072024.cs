using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenerDesAdhésions
{
    public class DIM_ADHESION_15072024
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateNaissance { get; set; }
        public override string ToString()
        {
            return $"Nom :{Nom}    Prenom:{Prenom}    Date Naissance :{DateNaissance}";
        }
    }
}
