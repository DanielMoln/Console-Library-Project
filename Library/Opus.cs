using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    // Mű osztály
    public abstract class Opus
    {
        [Description("szerző")]
        public string Author { get; set; }
        [Description("cím")]
        public string Title { get; set; }
        [Description("kiadás")]
        public int Expenditure { get; set; }
        [Description("oldalak")]
        public int Pages { get; set; }
    }
}
