using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Magazine : Journal
    {
        [Description("raktáron")]
        public bool AvailableOnline { get; set; }
        [Description("online elérhetőség")]
        public string? OnlineURL { get; set; }
        [Description("szerkesztő")]
        public string? EditorialStaff { get; set; }
    }
}
