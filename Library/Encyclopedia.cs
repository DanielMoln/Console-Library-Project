using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Encyclopedia : Book
    {
        [Description("témakör")]
        public ESubject Subject { get; set; }
        [Description("verzió")]
        public int version { get; set; }
    }
}
