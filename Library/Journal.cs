using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class Journal : Opus
    {
        [Description("gyakoriság")]
        public int Commoneess { get; set; }
        [Description("nyelvezet")]
        public string Language { get; set; }
        [Description("műfaj")]
        public EGenre Genre { get; set; }
    }
}
