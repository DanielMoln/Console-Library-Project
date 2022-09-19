using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class Journal : Opus
    {
        public int Commoneess { get; set; }
        public string Language { get; set; }
        public EGenre Genre { get; set; }
    }
}
