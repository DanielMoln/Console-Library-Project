using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    // Mű osztály
    public abstract class Opus
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Expenditure { get; set; }
        public int Pages { get; set; }
    }
}
