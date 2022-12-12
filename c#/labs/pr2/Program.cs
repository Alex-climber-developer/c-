
// Вариант 8. Химические элементы.
// Коллекция – двусвязный список.
//           В начало, в конец,
//            в произвольное место
//             Из произвольного места
//              Сортировка
// Поля данных структуры:
//           название,
//           символическое обозначение
//           массу атома,
//           заряд ядра.
// Дополнительные пункты меню:
//          − вывести сведения о химическом элементе по его символическому названию;
//          − найти элемент с самой большой массой

// using System.Text.Json;
using Newtonsoft.Json;

public struct Data
{
    public Data(int z)
    {
        string _name = ""; string _symbol = "";
        float _gravity = 0; int _charge = 0;
        Console.WriteLine("Enter name: ");
        _name = Console.ReadLine() ?? " ";
        this.name = _name;

        Console.WriteLine("Enter symbol: ");
        _symbol = Console.ReadLine() ?? " ";
        if (_symbol.Length <= 2) this.symbol = _symbol;
        else this.symbol = " ";

        Console.WriteLine("Enter gravity: ");
        try
        {
            _gravity = float.Parse(Console.ReadLine());
            if (_gravity < 270 && _gravity > 0) this.gravity = _gravity;
            else this.gravity = 0;
        }
        catch (FormatException) { this.gravity = 0; }
        try
        {
            Console.WriteLine("Enter charge: ");
            _charge = int.Parse(Console.ReadLine());
            if (_charge < 111 && _charge > 0) this.charge = _charge;
            else this.charge = 0;
        }
        catch (FormatException) { this.charge = 0; }

    }
    public Data(string _name, string _symbol, float _gravity, int _charge)
    {
        this.name = _name;
        this.symbol = _symbol;
        this.gravity = _gravity;
        this.charge = _charge;
    }
    [Newtonsoft.Json.JsonProperty("elementName")]
    public string? name { get; set; }

    [Newtonsoft.Json.JsonProperty("elementChar")]
    public string? symbol { get; set; }

    [Newtonsoft.Json.JsonProperty("gravity")]
    public float gravity { get; set; }

    [Newtonsoft.Json.JsonProperty("elementNumb")]
    public int charge { get; set; }
    public string ToFormat()
    {
        return string.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|", this.name, this.symbol, this.gravity, this.charge);
    }
};

class Program
{
    static void Main(string[] args)
    {
        Data[] data = new Data[1024];

        Console.Write("Enter a Filename:  ");
        string Filename = Console.ReadLine() ?? "data.json";
        var path = Path.Combine(Environment.CurrentDirectory, Filename);
        if (!File.Exists(path))
        {
            string createText = "[]";
            File.WriteAllText(path, createText);
        }

        var json = File.ReadAllText(path);
        data = JsonConvert.DeserializeObject<Data[]>(json);
        LinkedList<Data> list = new LinkedList<Data>(data);

        while (menu(ref list)) { }
        info_to_file(list, path);
    }

    public static void info_to_file(LinkedList<Data> list, string Filename)
    {
        string json_str = JsonConvert.SerializeObject(list);
        File.WriteAllText(Filename, json_str);
    }
    public static bool menu(ref LinkedList<Data> list)
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("[0] exit");
        Console.WriteLine("[1] print data");
        Console.WriteLine("[2] add new element");
        Console.WriteLine("[3] remove element");
        Console.WriteLine("[4] correct element");
        Console.WriteLine("[5] work with collection");
        Console.WriteLine("[6] sort the collection");
        Console.Write("\r\nSelect an option: ");
        switch (Console.ReadLine())
        {
            case "1":
                print(list);
                break;
            case "2":
                add(list);
                break;

            case "3":
                remove(list);
                break;

            case "4":
                correct(list);
                break;

            case "5":
                work(list);
                break;

            case "6":
                sort(ref list);
                break;

            case "0":
                Console.WriteLine("\t\t\t---------------PROGRAM FINISHED-----------------\n");
                return false;
            default:
                Console.WriteLine("Error...");
                break;

        }
        Console.WriteLine("Press any key");
        Console.ReadLine();
        return true;

    }
    public static void add(LinkedList<Data> list)
    {
        Console.WriteLine("[1] add in start");
        Console.WriteLine("[2] add in end");
        Console.WriteLine("[3] add in some place");
        Console.Write("\r\nSelect an option: ");
        var option = Console.ReadLine();
        Data element = new Data(1);
        switch (option)
        {
            case "1":
                list.AddFirst(element);
                break;
            case "2":
                list.AddLast(element);
                break;
            case "3":
                Console.Write("ADD. Enter index: ");
                int index = int.Parse(Console.ReadLine());
                int count = 0;
                var cur = list.First;
                if (index > list.Count - 1) Console.WriteLine("ERROR INDEX");
                else
                {
                    foreach (var elem in list)
                    {
                        if (count++ == index)
                        {
                            list.AddBefore(cur, element);
                            list.Remove(cur);
                            break;
                        }
                        cur = cur.Next;
                    }
                }
                break;
            default:
                Console.WriteLine("Error...");
                break;
        }
    }
    public static void remove(LinkedList<Data> list)
    {
        Console.WriteLine("[1] remove with element");
        Console.WriteLine("[2] remove with index");
        Console.Write("\r\nSelect an option: ");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                Data element = new Data(1);
                if (!list.Remove(element)) Console.WriteLine("ELEMENT NOT CONTAINS...");
                break;
            case "2":
                Console.Write("REMOVE. Enter index: ");
                int index = int.Parse(Console.ReadLine());
                int count = 0;
                var cur = list.First;
                if (index > list.Count - 1) Console.WriteLine("ERROR INDEX");
                else
                {
                    foreach (var elem in list)
                    {
                        if (count++ == index)
                        {
                            list.Remove(cur);
                            break;
                        }
                        cur = cur.Next;
                    }
                }
                break;
            default:
                Console.WriteLine("Error...");
                break;
        }
    }
    public static void correct(LinkedList<Data> list)
    {
        Console.Write("CORRECT. Enter index: ");
        int index = int.Parse(Console.ReadLine()), count = 0;
        var cur = list.First;
        if (index > list.Count - 1) Console.WriteLine("ERROR INDEX");
        else
        {
            foreach (var elem in list)
            {
                if (count++ == index)
                {
                    Data new_element = new Data(1);
                    list.AddBefore(cur, new_element);
                    list.Remove(cur);
                    break;
                }
                cur = cur.Next;
            }
        }
    }
    public static void work(LinkedList<Data> list)
    {

    }
    public static void sort(ref LinkedList<Data> list)
    {
        IOrderedEnumerable<Data> sort_list = null;
        bool up_direction = true;

        Console.WriteLine("[0] sort big - small");
        Console.WriteLine("[1] sort small -big");
        Console.Write("\r\nSelect an option: ");
        up_direction = Console.ReadLine() == "0" ? false : true;

        Console.WriteLine("[1] sort for gravity");
        Console.WriteLine("[2] sort for symbol");
        Console.WriteLine("[3] sort for charge");
        Console.Write("\r\nSelect an option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                if (up_direction)
                    sort_list = list.OrderBy(elem => elem.gravity);
                else
                    sort_list = list.OrderByDescending(elem => elem.gravity);
                break;
            case "2":
                if (up_direction)
                    sort_list = list.OrderBy(elem => elem.symbol);
                else
                    sort_list = list.OrderByDescending(elem => elem.symbol);
                break;
            case "3":
                if (up_direction)
                    sort_list = list.OrderBy(elem => elem.charge);
                else
                    sort_list = list.OrderByDescending(elem => elem.charge);
                break;
            default: break;
        }

        LinkedList<Data> new_list = new LinkedList<Data>(sort_list);
        list = new_list;
    }
    public static void print(LinkedList<Data> list)
    {
        Console.WriteLine("[1] print all");
        Console.WriteLine("[2] print with index");
        Console.Write("\r\nSelect an option: ");
        var option = Console.ReadLine();
        Console.Clear();
        switch (option)
        {
            case "1":
                if (list.First == null)
                    Console.WriteLine("List is Empty");
                else
                {
                    Console.WriteLine(string.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|", "elementName", "elementChar", "gravity", "elementNumb"));
                    Console.WriteLine("+---------------------------------------------------------------+");
                    foreach (var elem in list)
                        Console.WriteLine(elem.ToFormat());
                }
                break;
            case "2":
                Console.Write("PRINT. Enter index: ");
                int index = int.Parse(Console.ReadLine()), count = 0;
                var cur = list.First;
                Console.Clear();
                if (index > list.Count - 1) Console.WriteLine("ERROR INDEX");
                else
                {
                    Console.WriteLine(string.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|", "elementName", "elementChar", "gravity", "elementNumb"));
                    Console.WriteLine("+---------------------------------------------------------------+");
                    foreach (var elem in list)
                    {
                        if (count++ == index)
                        {
                            Console.WriteLine(elem.ToFormat());
                            break;
                        }
                        cur = cur.Next;
                    }
                }
                break;
            default:
                Console.WriteLine("Error...");
                break;
        }
    }
}
