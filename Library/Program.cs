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
                        return;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Add();
                        return;
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Remove();
                        return;
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.WriteLine("Bye bye");
                        return;
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

            #region class variables
            /* Title = "Kincskereső kisködmön",
                Author = "Móra Ferenc",
                Chapter = 24,
                CoverType = ECoverType.Soft,
                Expenditure = 1,
                Genre = EGenre.Family,
                ISBN = "273723654238426766835642",
                Pages = 174, */
            #endregion

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
                int attrLength = (o.Key.GetType().GetProperty(propertyName).GetValue(o.Key, null) + "").Length;
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

        /*private static int _GetMaxLength()
        { 
            return _GetMaxLength("title");
        }*/

        public static void Add()
        {

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
    }
}