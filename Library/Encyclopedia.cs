using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Encyclopedia : Book
    {
        public ESubject Subject { get; set; }
        public int version { get; set; }
    }
}
