using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum ECategory
    {
        [Description("Szuperhős")]
        Superhero = 1,
        [Description("Vígjáték")]
        Comedy,
        [Description("Egyéb")]
        Other
    }
}
