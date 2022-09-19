using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Magazine : Journal
    {
        public bool AvailableOnline { get; set; }
        public string? OnlineURL { get; set; }
        public string? EditorialStaff { get; set; }
    }
}
