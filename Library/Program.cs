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
            // var -t csak akkor lehet használni, ha pontosan megtudja állapítani az értékét
            // ez nem lehetséges var a; de ez jó var a = 1;
            string sor = _SetTextWidthLength("Cím", _GetMaxLength()) 
                + _SetTextWidthLength("| Szerző", _GetMaxLength("author")) + "| Mennyiség:";
            Console.WriteLine(sor);
            for (int i = 0; i < sor.Length; i++, Console.Write("-")) ;
            Console.WriteLine();

            foreach (var o in _opus)
            {
                Console.WriteLine(
                    _SetTextWidthLength(""+o.Key.Title, _GetMaxLength()) +
                    _SetTextWidthLength("| "+o.Key.Author, _GetMaxLength("author")) +
                    _SetTextWidthLength("| "+o.Value, 6)
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

        /// <summary>
        /// Ez egy dokumentáció ahány paraméterem van annyit fog beleirni
        /// Házi feladat: kiegészíteni a metódust a Type osztály segítségével
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private static int _GetMaxLength(string field)
        {
            /*
              GetMaxLength metódust ugy alakitsuk at, hogy a type osztajt hasznalva dinamikusan keresse ki az attributumokat
              ha nem letezik a property akkor dobjon egy hibat
              keresse ki az adott propertyt és adja vissza az értékét
             
             */

            int length = 0;
            foreach (var item in _opus)
            {
                if (field == "title")
                {
                    // ezeket cseréljem majd ki, csekkoljam le a fieldet 
                    // fieldet keresem meg a type osztállyal
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
        }

        private static int _GetMaxLength()
        { 
            return _GetMaxLength("title");
        }

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