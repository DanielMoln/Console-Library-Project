using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Novel : Book
    {
        [Description("fejezet")]
        public int Chapter { get; set; }
    }
}
