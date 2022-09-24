using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum ESubject
    {
        [Description("Történelmi")]
        Historical = 1,
        [Description("Természeti")]
        Natural,
        [Description("Geológikus")]
        Geological,
        [Description("Matematikai")]
        Mathematics
    }
}
