using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book : Opus
    {
        public ECoverType CoverType { get; set; }
        public string ISBN { get; set; } // Nemzetközileg elfogadott azonosítója
        public EGenre Genre { get; set; }
    }
}
