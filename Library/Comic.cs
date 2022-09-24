using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Comic : Journal
    {
        [Description("kategória")]
        public ECategory Category { get; set; }
    }
}
