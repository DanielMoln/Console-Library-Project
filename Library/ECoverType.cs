using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum ECoverType
    {
        [Description("Kemény")]
        Hard = 1,
        [Description("Puha")]
        Soft
    }
}
