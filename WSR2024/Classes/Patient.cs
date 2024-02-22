using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSR2024.Models
{
    public partial class Patient
    {
        public string Name { get
            {
                return this.LastName + " " + this.FirstName + " " + this.Patronomic;
            } }
    }
}
