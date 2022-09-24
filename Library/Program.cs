using System.ComponentModel;
using System.Reflection;

namespace Library
{
    internal class Program
    {
        //static List<Opus> _ops = new List<Opus>();
        static Dictionary<Opus, object> _opus = new Dictionary<Opus, object>();

        private static void Main(string[] args)
        {
            // showing hungarian letters
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Adding Novels
            _opus.Add(new Novel()
            {
                Title = "Kincskereső kisködmön",
                Author = "Móra Ferenc",
                Chapter = 24,
                CoverType = ECoverType.Soft,
                Expenditure = 1,
                Genre = EGenre.Family,
                ISBN = "273723654238426766835642",
                Pages = 174,
            }, 5);

            _opus.Add(new Novel()
            {
                Title = "Rómeo és Júlia",
                Author = "Williem Shakespeare",
                Chapter = 1,
                CoverType = ECoverType.Soft,
                Expenditure = 1,
                Genre = EGenre.Drama,
                ISBN = "234399876664738483746638",
                Pages = 174,
            }, 3);

            _opus.Add(new Comic()
            {
                Title = "Garfield",
                Author = "Jim Davis",
                Genre = EGenre.Family,
                Commoneess = 7,
                Expenditure = 1,
                Pages = 8,
                Language = "hu"
            }, 3);
            #endregion

            do
            {
                Menu();
                Console.Write("Kérem válasszon a menüből: ");
                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Listing();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Add();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Remove();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        return;
                        Console.WriteLine("Bye bye");
                        break;

                    default:

                        break;
                }
            } while (true);
        }

        public static void Listing()
        {
            Console.WriteLine("\n\nJelenlegi művek:");
            int maxTitleLength = _GetMaxLength("Title");
            int maxAuthorLength = _GetMaxLength("Author");
            int maxExpenditureLength = _GetMaxLength("Expenditure");
            int maxPagesLength = _GetMaxLength("Pages");

            string sor = _SetTextWidthLength("Cím", maxTitleLength) +
                         _SetTextWidthLength("| Szerző", maxAuthorLength) + 
                         _SetTextWidthLength("| Kiadás:", maxExpenditureLength) +
                         _SetTextWidthLength("| Oldalak:", maxPagesLength);

            Console.WriteLine(sor);

            for (int i = 0; i < sor.Length; i++, Console.Write("-")) ;
            Console.WriteLine();

            foreach (var o in _opus)
            {
                Console.WriteLine(
                    _SetTextWidthLength(""+o.Key.Title, maxTitleLength) +
                    _SetTextWidthLength("| "+o.Key.Author, maxAuthorLength) +
                    _SetTextWidthLength("| "+o.Key.Expenditure, maxExpenditureLength) +
                    _SetTextWidthLength("| "+o.Key.Pages, maxPagesLength)
                );
            }
        }

        private static string _SetTextWidthLength(string text, int maxLength)
        {
            for (int i = text.Length; i < maxLength+2; i++)
            {
                text += " ";
            }
            return text;
        }

        private static int _GetMaxLength(string propertyName)
        {
            int length = 0;
            foreach (var o in _opus)
            {
                int attrLength = (o.Key.GetType().GetProperty(propertyName)?.GetValue(o.Key, null) + "").Length;
                if(attrLength > length)
                {
                    length = attrLength;
                }
            }
            if (length == 1) length += 10;
            return length;
        }

        private static int _GetMaxLength(object obj, string propertyName = "Title")
        {
            if (obj == null) return 0;
            if (propertyName == null) return 0;
            int length = (obj.GetType().GetProperty(propertyName)
                        .GetValue(obj, null) + "").Length;

            /* for enough space */
            if (length == 1) length += 10;

            return length;
        }

        #region oldGetMaxLength
        /*private static int _GetMaxLength(string field)
        {
            int length = 0;
            foreach (var item in _opus)
            {
                if (field == "title")
                {
                    if (item.Key.Title.Length > length)
                    {
                        length = item.Key.Title.Length;
                    }
                }
                if (field == "author")
                {
                    if (item.Key.Author.Length > length)
                    {
                        length = item.Key.Author.Length;
                    }
                }
            }
            return length;
        }*/
        #endregion

        public static void Add()
        {
            Opus opus = _CreateObject();
            if (opus == null)
            {
                return;
            }

            if (opus.GetType() ==  typeof (Novel))
            {
                Novel novel = (Novel) opus;

                /* Setting up properties */
                Console.WriteLine("Kiválasztott típús: regény");
                int genre = _RequestEnum(typeof(EGenre), "műfajt");
                novel.Genre = (EGenre) genre;
                _RequestParams(novel);
            } 
            else if (opus.GetType() == typeof (Encyclopedia))
            {
                Encyclopedia encyclopedia = (Encyclopedia) opus;

                /* Setting up properties */
                Console.WriteLine("Kiválasztott típús: enciklopédia");
                int genre = _RequestEnum(typeof(EGenre), "műfajt");
                encyclopedia.Genre = (EGenre)genre;
                _RequestParams(encyclopedia);
            }
            else if (opus.GetType() == typeof (Magazine))
            {
                Magazine magazine = (Magazine) opus;

                /* Setting up properties */
                Console.WriteLine("Kiválasztott típús: újság");
                int genre = _RequestEnum(typeof(EGenre), "műfajt");
                magazine.Genre = (EGenre)genre;
                _RequestParams (magazine);
            }
            else
            {
                Comic comic = (Comic) opus;

                /* Setting up properties */
                Console.WriteLine("Kiválasztott típús: képregény");
                int genre = _RequestEnum(typeof(EGenre), "műfajt");
                comic.Genre = (EGenre)genre;
                _RequestParams(comic);
            }
        }

        public static void Remove()
        {

        }

        private static void Menu()
        {
            Console.WriteLine("\n***** Könyvtár Kezelő Szoftver (2022) *****");
            Console.WriteLine();
            Console.WriteLine("Menü:");
            Console.WriteLine("1. Művek listázása");
            Console.WriteLine("2. Új mű rögzítése");
            Console.WriteLine("3. Mű törlése");
            Console.WriteLine("4. Kilépés a programból");
            Console.WriteLine("\n");
        }

        public static Opus _CreateObject()
        {
            do
            {
                Console.WriteLine("");
                Console.WriteLine("** Kategoria menü: ");
                Console.WriteLine("1. Regény");
                Console.WriteLine("2. Enciklopédia");
                Console.WriteLine("3. Újság");
                Console.WriteLine("4. Képregény");
                Console.WriteLine("5. Visszalépés az előző menübe");
                Console.Write("* Kérem válasszon az alábbiak közül: ");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine("");
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        /* regény */
                        return new Novel();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        /* enciklopédia */
                        return new Encyclopedia();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        /* újság */
                        return new Magazine();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        /* képregény */
                        return new Comic();
                        break;

                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Console.WriteLine("Vissza a menübe...");
                        return null;
                        break;

                    default:
                        break;
                }

            } while (true);
        }

        private static int _RequestEnum(Type t, string title)
        {
            // this utáni paramétereket kell csak átadni, mivel a this megadott paraméter maga az objektum amin keresztül meghivom, tehát ebben az esetben az e
            //e.GetDescription();
            do
            {
                Console.WriteLine($"*** Kérem válasszon {title}: ");
                List<int> enumValues = new List<int>();

                foreach (var item in Enum.GetValues(t))
                {
                    int poz = (int)item;
                    enumValues.Add(poz);
                    Console.WriteLine($"{poz}. {((Enum) item).GetDescription()}");
                }

                Console.Write("* Kérem válasszon: ");
                string input = Console.ReadLine();
                Console.WriteLine("");
                int number;
                if ( int.TryParse(input, out number))
                {
                    if (number == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        if (enumValues.Contains(number))
                        {
                            return number;
                        }
                    }
                }

                Console.WriteLine("Hibás adat, adja meg újra!");
            } while (true);
        }

        public static Opus _RequestParams(Opus o)
        {
            /* Szorgalmi: online available elérhető akkor kérje be csak az online urlt */

            PropertyInfo[] props = o.GetType().GetProperties();
            foreach (var item in props)
            {
                string propDescription = "";
                var description = item.CustomAttributes.SingleOrDefault(a => a.AttributeType == typeof(DescriptionAttribute));
                if (description == null)
                {
                    propDescription = item.Name;
                }
                else
                {
                    propDescription = description.ConstructorArguments[0].Value.ToString();
                }

                if ( item.PropertyType.BaseType == typeof(Enum))
                {
                    int res = _RequestEnum(item.PropertyType, $"{propDescription}");
                    item.SetValue(o, res);

                }
                else if (item.PropertyType == typeof(int))
                {
                    /* Getting data from the commandline */
                    Console.Write($"{propDescription}");
                    int res;
                    string inp;
                    do
                    {
                        Console.Write($"{propDescription}: ");
                        inp = Console.ReadLine();

                    } while (!int.TryParse(inp, out res));
                    item.SetValue(o, res);

                }
                else if (item.PropertyType == typeof(bool))
                {
                    /* Getting data from the commandline */
                    Console.Write($"{propDescription} (I/H)");
                    int res;
                    string inp;
                    do
                    {
                        Console.Write($"{propDescription}: ");
                        inp = Console.ReadLine();

                    } while (inp.ToLower() != "i" && inp.ToLower() != "h");
                    item.SetValue(o, (inp.ToLower() == "i"));

                }
                else
                {
                    string inp;
                    do
                    {
                        Console.Write($"{propDescription}: ");
                        inp = Console.ReadLine();

                    } while (string.IsNullOrEmpty(inp));
                    item.SetValue(o, inp);
                }
            }
            return o;
        }
    }
}