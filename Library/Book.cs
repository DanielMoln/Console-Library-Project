﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book : Opus
    {
        [Description("kötés")]
        public ECoverType CoverType { get; set; }
        public string ISBN { get; set; } // Nemzetközileg elfogadott azonosítója
        [Description("műfaj")]
        public EGenre Genre { get; set; }
    }
}
