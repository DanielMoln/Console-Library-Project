using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum EGenre
    {
        [Description("Dráma")]
        Drama,
        [Description("Akció")]
        Action,
        [Description("Kaland")]
        Adventures,
        [Description("Romantikus")]
        Romantic,
        [Description("Természet")]
        Nature,
        [Description("Dokumentum")]
        Document,
        [Description("Szkifi")]
        Scifi,
        [Description("Fantázia")]
        Fantasy,
        Thriller,
        Horror,
        [Description("Családi")]
        Family
    }
}
