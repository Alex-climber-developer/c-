// Vариант 8. Кошки.
// Класс для первой части – шотландская вислоухая.

// Варианты свойств: 
//    -вес, -пол, -возраст, -имя.

// Варианты методов: 
//    -поиграть, -покормить, погладить, получить 
//    осуждающий взгляд от кошки (статический).

// Возможные классы иерархии: 
//     кошки (базовый), мейн кун, 
//      персидская, сфинкс (хотя это такая себе кошка).

// Возможный интерфейс:
//    IHasFourLeg,
// дополнительный класс –
//    капибара.

using System;             // for all
using System.Threading;   // for Timer
using System.Reflection;  // for ReflectedType
using System.Diagnostics; // for StackFrame


class Program
{
    static void Main(string[] args)
    {
        int task_num = -1;
        while (task_num != 0)
        {
            Console.Clear();
            Console.WriteLine("TASK menu:");
            Console.WriteLine("0- Exit Program");
            Console.WriteLine("1- task 1");
            Console.WriteLine("2- task 2");
            Console.WriteLine("3- task 3");
            try { task_num = Convert.ToInt32(Console.ReadLine()); }
            catch (System.FormatException) { continue; }
            if (task_num > 3 || task_num < 0)
            {
                Console.WriteLine("Мяу\n Error value!\n"); continue;
            }
            switch (task_num)
            {
                case 0:
                    Console.WriteLine("Мяу\n\n\t\tPROGRAM FINISHED\n\n"); break;
                case 1:
                    task1(); break;
                case 2:
                    task2(); break;
                case 3:
                    task3(); break;
                default: break;
            }

        }
    }
    public static void task1()
    {
        int act = 8, num_cat = -1;

        Scotish n = new Scotish(10, 'm', 19, "cat1");
        Scotish h = new Scotish();
        Scotish k = new Scotish("school");
        Scotish h_copy = new Scotish(1.23, 'm', 0, "1");
        Scotish[] cats = new Scotish[] { n, h, k, h_copy };
        Console.WriteLine("Кошка умерла, вы слишком жестоко обращались со своим питомцем\n Хах - шутка, я еще тут");

        for (; h.Health != 0 && n.Health != 0 && act != 10;)
        {
            Console.WriteLine("\n\nmenu:");
            Console.WriteLine("0- Add params for cat");
            Console.WriteLine("1- Feed");
            Console.WriteLine("2- Hit");
            Console.WriteLine("3- Stroke");
            Console.WriteLine("4- Play");
            Console.WriteLine("5- (STATIC)Broke_view");
            Console.WriteLine("6- cat + cat1");
            Console.WriteLine("7- cat == cat1 ?");
            Console.WriteLine("8- print()");
            Console.WriteLine("9- ToString(cat)");
            Console.WriteLine("10- exit\n");
            try { act = Convert.ToInt32(Console.ReadLine()); }
            catch (System.FormatException) { continue; }
            if (act > 10 || act < 0)
            {
                Console.WriteLine("Мяу\n Error value!\n"); continue;
            }
            if (act != 6 && act != 7 && act != 5 && act != 10)
            {
                Console.WriteLine("Num of Cat in list");
                for (int i = 0; i < cats.Length; i++) Console.WriteLine($"Cat № {i} - {cats[i].Name}");
                try { num_cat = Convert.ToInt32(Console.ReadLine()); }
                catch (System.FormatException) { continue; }
                if (num_cat >= cats.Length || num_cat < 0) { Console.WriteLine("Мяу\n Error value!\n"); continue; }
            }
            switch (act)
            {
                case 0:
                    Console.Write("Gender: ");
                    try
                    {
                        cats[num_cat].Gender = Convert.ToChar(Console.ReadLine());
                    }
                    catch
                    {
                        Console.Write("TYPE ERROR");
                        break;

                    }
                    Console.Write("Name: ");
                    cats[num_cat].Name = Console.ReadLine();

                    Console.Write("Years: ");
                    cats[num_cat].Years = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Weight(не точка а запятая после целой части): ");
                    cats[num_cat].Weight = Convert.ToDouble(Console.ReadLine());
                    break;
                case 1:
                    if (cats[num_cat].Health < 10)
                    {
                        cats[num_cat].Health++;
                        Console.WriteLine("Здоровье кошки увеличилось, теперь оно равно {0}\n", cats[num_cat].Health);
                    }
                    else
                    {
                        Console.WriteLine("Здоровье кошки максимально\n");
                    }
                    break;
                case 2:
                    if (cats[num_cat].Health > 0)
                    {
                        cats[num_cat].Health--;
                        Console.WriteLine("Здоровье кошки уменьшилось, теперь оно равно {0}\n", cats[num_cat].Health);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Кошка умерла, вы слишком жестоко обращались со своим питомцем\n");
                        break;
                    }
                    break;
                case 3:
                    cats[num_cat].Stroke(); break;
                case 4:
                    cats[num_cat].Play(); break;
                case 5:
                    Cat.Broke_view(); break;
                case 6:
                    h = h + n;
                    h.Print();
                    break;
                case 7:
                    if (h == n) Console.WriteLine("h = n\n");
                    else if (h == h_copy) Console.WriteLine($"{h.Name} = {h_copy.Name}\n");
                    else Console.WriteLine($"{h.Name}!= {h_copy.Name} != {n.Name}\n");
                    break;
                case 8:
                    cats[num_cat].Print(); break;
                case 9:
                    Console.WriteLine($"{cats[num_cat].ToString()}"); break;
                case 10: Console.WriteLine("\t\t\t---------------GO IN MAIN MENU-----------------\n"); break;
                default: break;
            }
        }

    }
    public static void task2()
    {
        MainCun mc = null;
        Perside pers = null;
        Scotish scot = null;
        Sfinks sf = null;
        bool show = true;

        bool menu_t2()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Create");
            Console.WriteLine("[2] All methods");
            Console.WriteLine("[3] Show name");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    bool bad_create = true;
                    while (bad_create) bad_create = NewObj();
                    return true;

                case "2":
                    DoAllMethods();
                    Console.WriteLine("Press any key");
                    Console.ReadLine();
                    return true;

                case "3":
                    Console.Clear();
                    if (mc is not null)
                        mc.print_name();
                    if (pers is not null)
                        pers.print_name();
                    if (scot is not null)
                        scot.print_name();
                    if (sf is not null)
                        sf.print_name();
                    Console.WriteLine("Press any key");
                    Console.ReadLine();
                    return true;
                case "0":
                    Console.WriteLine("\t\t\t---------------GO IN MAIN MENU-----------------\n");
                    return false;
                default:
                    Console.WriteLine("Error...");
                    return true;
            }
        }
        bool NewObj()
        {
            // MainCun mc, Perside pers, Scotish scot, Sfinks sf
            // Console.Clear();
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Add Scotish");
            Console.WriteLine("2) Add MainCun");
            Console.WriteLine("3) Add Perside");
            Console.WriteLine("4) Add Sfinks");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    scot = new Scotish();
                    return true;
                case "2":
                    mc = new MainCun();
                    return true;
                case "3":
                    pers = new Perside();
                    return true;
                case "4":
                    sf = new Sfinks();
                    return true;
                case "0":
                    Console.WriteLine("Exit");
                    return false;
                default:
                    Console.WriteLine("Error...");
                    return true;
            }
        }
        void DoAllMethods()
        {
            Console.Clear();
            if (mc is not null)
            {
                Console.WriteLine("\n\t\tmc methods");
                mc.Play();
                mc.Calmness();
                mc.Corner_ear();
                mc.Stroke();
            }
            if (pers is not null)
            {
                Console.WriteLine("\n\t\tpers methods");
                pers.Name_why();
                pers.View();
                pers.Feed();
            }
            if (scot is not null)
            {
                Console.WriteLine("\n\t\tscot methods");
                scot.View();
                scot.True_Scotish();
                scot.Play();
            }

            if (sf is not null)
            {
                Console.WriteLine("\n\t\tsf methods");
                sf.View();
                sf.Lion();
                sf.Hit();
            }
        }
        while (show) show = menu_t2();
    }
    public static void task3()
    {
        List<IHasFourLeg> list = new List<IHasFourLeg>();
        bool showMenu = true;
        bool NewObj(ref List<IHasFourLeg> list)
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Add Scotish");
            Console.WriteLine("2) Add MainCun");
            Console.WriteLine("3) Add Perside");
            Console.WriteLine("4) Add Sfinks");
            Console.WriteLine("5) Add Capibar");

            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    list.Add(new Scotish());
                    Console.WriteLine($" You add {((Scotish)list[^1]).ToString()}");
                    return true;
                case "2":
                    list.Add(new MainCun());
                    Console.WriteLine($" You add {((MainCun)list[^1]).ToString()}");
                    return true;
                case "3":
                    list.Add(new Perside());
                    Console.WriteLine($" You add {((Perside)list[^1]).ToString()}");
                    return true;
                case "4":
                    list.Add(new Sfinks());
                    Console.WriteLine($" You add {((Sfinks)list[^1]).ToString()}");
                    return true;
                case "5":
                    list.Add(new Capibar());
                    Console.WriteLine($" You add {((Capibar)list[^1]).ToString()}");
                    return true;
                case "0":
                    Console.WriteLine("Exit.");
                    return false;
                default:
                    Console.WriteLine("Error...");
                    return true;
            }
        }
        bool Menu_t3(ref List<IHasFourLeg> list)
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Show all list");
            Console.WriteLine("3) Do interfase methods");
            Console.WriteLine("4) Function(interfase)");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    bool off_on = true;
                    while (off_on) off_on = NewObj(ref list);
                    Console.ReadLine();
                    return true;
                case "2":
                    int i = 1;
                    foreach (var item in list)
                    {
                        Console.WriteLine($"{i}) {item}");
                        i++;
                    }
                    Console.WriteLine("Press any key");
                    Console.ReadLine();
                    return true;
                case "3":
                    Console.WriteLine("Enter the animal number in the list: ");
                    int k = Convert.ToInt32(Console.ReadLine());
                    if (k > 0 && k <= list.Count)
                    {
                        Console.WriteLine($"You Stability");
                        list[k - 1].Stability();

                        Console.WriteLine($"You Speed");
                        list[k - 1].Speed();
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                    Console.ReadLine();
                    return true;
                case "4":
                    Console.WriteLine("Enter the animal number in the list: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 0 && num <= list.Count)
                    {
                        Console.WriteLine($"GetInfo:");
                        GetInfo(list[num - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                    Console.ReadLine();
                    return true;
                case "0":
                    Console.WriteLine("Exit.");
                    Console.ReadLine();
                    return false;
                default:
                    Console.WriteLine("Error...");
                    Console.ReadLine();
                    return true;
            }
        }
        void GetInfo(IHasFourLeg obj)
        {
            Console.WriteLine("\tstability:");
            obj.Stability();
            Console.WriteLine("\tspeed:");
            obj.Speed();
            Console.WriteLine("\tI'm a good!");
        }

        while (showMenu) showMenu = Menu_t3(ref list);
    }

}

abstract class Cat : IHasFourLeg
{
    internal int hungry_level = 0, mood = 0, playful_level = 0;
    public string type { get; } = "CAT";
    internal bool isLife = true;
    internal Timer _timer = null;
    public int Years { get; set; }
    public char Gender { get; set; }
    public string Name { get; set; }
    public double Weight { get; set; }
    public int Health = 10;
    public Cat(double weight, char gender, int years, string name)
    {
        if (weight < 0 || years < 0) throw new Exception("ERROR value: too mach light or yaung!");
        else
        {
            Years = years;
            Weight = weight;
        }

        Gender = gender;
        Name = name;

        _timer = new Timer(TimerCallback, null, 0, 2000);
    }
    public Cat()
    {
        Years = 0; Gender = 'm';
        Name = "1234"; Weight = 1.23;
        _timer = new Timer(TimerCallback, null, 0, 2000);

    }
    public Cat(string stereotip)
    {
        if (stereotip == "school")
        {
            Years = 15; Gender = 'm';
            Name = "scholer"; Weight = 60;
        }
        else if (stereotip == "vyz")
        {
            Years = 20; Gender = 'w';
            Name = "university"; Weight = 70;
        }
        else if (stereotip == "work")
        {
            Years = 35; Gender = 'm';
            Name = "worker"; Weight = 80;
        }
        else if (stereotip == "alife")
        {
            Years = 90; Gender = 'w';
            Name = "deather"; Weight = 50;
        }
        else
        {
            Years = -1; Gender = '-';
            Name = "-"; Weight = 0;
        }
        _timer = new Timer(TimerCallback, null, 0, 2000);

    }
    ~Cat()
    {
        Console.WriteLine("IS it a Death?");
        Console.WriteLine("--Yeas, it is..");
        // Dispose();
    }

    // public void Dispose()
    // {
    //     // Никаких Dispose(true) и никаких вызовов GC.SuppressFinalize()
    //     DisposeManagedResources();
    // }

    // // Никаких параметров, этот метод должен освобождать только неуправляемые ресурсы
    // protected virtual void DisposeManagedResources()
    // {
    //     _timer.Change(Timeout.Infinite, Timeout.Infinite);

    // }

    public static bool operator ==(Cat cat1, Cat cat2)
    {
        if (cat1.Name == cat2.Name && cat1.Years == cat2.Years) return true;
        else return false;
    }
    public static bool operator !=(Cat cat1, Cat cat2) => (cat1.Name != cat2.Name || cat1.Years != cat2.Years);
    public static Cat operator +(Cat cat1, Cat cat2)
    {
        cat1.Weight += cat2.Weight;
        cat1.Years += cat2.Years;
        cat1.Name = "COMBO";
        return cat1;
    }

    public override string ToString()
    {
        return (Weight.ToString() + " " + Gender.ToString() + " " + Years.ToString() + " " + Name.ToString());
        // Console.WriteLine($"\n{Weight} {Gender} {Years} {Name}");
    }

    public virtual void print_name()
    {
        // var stacktrace = new StackTrace();
        // var prevframe = stacktrace.GetFrame(1);
        // var method = prevframe.GetMethod();
        // Console.WriteLine($"Вызывающий класс: {method.ReflectedType.Name}");
        Console.WriteLine("print_name: Cat");
    }

    public void Print()
    {
        Console.WriteLine($"\n\nWeight = {Weight}");
        Console.WriteLine($"Name = {Name}");
        Console.WriteLine($"Gender = {Gender}");
        Console.WriteLine($"Years = {Years}");
        Console.WriteLine($"playful_level = {playful_level}");
        Console.WriteLine($"hungry_level = {hungry_level}");
        Console.WriteLine($"isLife = {isLife}");
        Console.WriteLine($"mood = {mood}");
        Console.WriteLine($"health = {Health}\n");
    }
    public virtual void View()
    {
        Console.WriteLine("\t\t____Cat.View()_____");
        Console.WriteLine("My Fase");
    }
    public virtual void Play()
    {
        Console.WriteLine("\t\t____Cat.Play()_____");
        Console.WriteLine("1 2 3 4 5 i'll go seek");
    }
    static public void Broke_view()
    {
        Console.WriteLine("\t\t____Cat.Broke_view()_____");
        Console.WriteLine("!-__-!");
    }
    public void Stroke()
    {
        Console.WriteLine("\t\t____Cat.Stroke()_____");
        Console.WriteLine("mmmmmmmrrrrr");
        if (mood == 0) mood++;
        else mood += (mood / Math.Abs(mood));
    }
    public void Hit()
    {
        Console.WriteLine("\t\t____Cat.Hit()_____");
        Console.WriteLine("mrzzzzzzzzzzzzzz");
        mood -= 1;
    }
    public void Stability()
    {
        Console.WriteLine("\t\t____Cat.Stability()_____");
        Console.WriteLine("I has 4 legs - i am stability");
    }
    public void Speed()
    {
        double speed = Math.Abs(Years * 3 - Weight * 0.1);
        Console.WriteLine("\t\t____Cat.Speed()_____");
        Console.WriteLine($"i can run. my speed = {speed} km/h");
    }
    public void Feed()
    {
        Console.WriteLine("\t\t____Cat.Feed()_____");
        Console.WriteLine("thank you it was delicious !");
        hungry_level -= 150;
        if (Gender == 'm') Weight += 0.1;
        else Weight += 0.2;
    }
    internal void Bioritms()
    {
        if (isLife)
        {
            // Console.WriteLine($"cat = {Gender}");
            if (Gender == 'm') hungry_level += 2;
            else hungry_level++;
            // Console.WriteLine($"hungry_level = {hungry_level}");

            if (Years < 5) playful_level += 2;
            else playful_level++;
            // Console.WriteLine($"playful_level = {playful_level}");
            if ((hungry_level + playful_level) > 0 &&
                (hungry_level + playful_level) % 120 == 0) { mood--; }    // каждые 60сек если голодный и не игранный --mood
            else if ((hungry_level + playful_level) < 0 &&
                (hungry_level + playful_level) % 60 == 0) mood++;     // каждые 30сек если не голоден и игран то ++mood
                                                                      // Console.WriteLine($"mood = {mood}");

            if (Gender == 'm') Weight -= 0.002;
            else Weight -= 0.001;   // при весе в кило в среднем (м или ж) кошак через 20 минут без кормежки умрет

            if (mood < 0) Weight += mood * 0.005;
            if (Weight < 0.1) isLife = false;
        }
        else if (Weight != 0.2)
        {
            Weight = 0.2;
            Broke_view();
            Console.WriteLine($"he did try...; But {Name} die");
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
    internal void TimerCallback(Object? o)
    {
        Bioritms();
    }
}
class Scotish : Cat
{
    public bool is_alcogolic = false;
    public override void View()
    {
        if (is_alcogolic)
        {
            Console.WriteLine("\t\t____Scotish.Surprized_view()_____");
            Console.WriteLine("\t\t^      ^");
            Console.WriteLine("\t\t  *   * ");
            Console.WriteLine("\t\t---  ---");
        }
        else
        {
            Console.WriteLine("\t\t____Scotish.Surprized_view()_____");
            Console.WriteLine("\t\t^      ^");
            Console.WriteLine("\t\t  0   0 ");
            Console.WriteLine("\t\t--- U ---");
            Console.WriteLine("\t\t---  ---");
        }

    }
    public void True_Scotish()
    {
        Console.WriteLine("\t\t____Scotish.True_Scotish()_____");
        Console.Write("\t\t-Where my whiskey???");
        Console.Write("\t\t--For you only Whiscas");
    }
    public override void Play()
    {
        Console.WriteLine("\t\t____Scotish.Play()_____");
        int x = 50, max = 100, min = 0, your_temps = 0, my_temps = 1;
        bool flag = true;
        string output = "";

        Console.WriteLine("Мяу\n" +
        "We will play a little Game\n" +
        "I'll predict how old are you and vice versa\n" +
        "RULES:\n" +
        "the guesser calls the number\n" +
        "the second answers 'more' or 'less' or 'good'\n" +
        "who will guess for the least number of hints - won" +
        $"remember your num ({min} < num < {max})\n\n" +
        "so, start the Game\n");
        while (output.ToLower() != "good")
        {
            Console.WriteLine($"Are you {x} years?");
            output = Console.ReadLine();
            if (output.ToLower() == "more")
            {
                if (x == 99)
                {
                    Console.WriteLine("Мяу\n you very old for this!\n");
                    flag = false;
                    break;
                }
                else
                {
                    my_temps++;
                    int tmp = x;
                    x = (x + max) / 2;
                    min = tmp;
                }
            }
            else if (output.ToLower() == "less")
            {
                if (x == 1)
                {
                    Console.WriteLine("Мяу\n you baby!\n");
                    flag = false;
                }
                else
                {
                    my_temps++;
                    int tmp = x;
                    x = (x + min) / 2;
                    max = tmp;
                }
            }
            else if (output.ToLower() == "good") break;
            else
            {
                Console.WriteLine("Мяу\n Error value!\n");
                flag = false;
            }
        }

        if (flag)
        {
            x = 0;
            Console.WriteLine($"Your age is {x} years\n\n My resut = {my_temps} temps");
            Console.WriteLine("Мяу okay\n let's start !\n");

            while (Years != x)
            {
                Console.Write("My age is:  ");
                x = Convert.ToInt32(Console.ReadLine());
                your_temps++;
                if (Years < x)
                    Console.WriteLine("less");
                else if (Years > x)
                    Console.WriteLine("more");
            }
            Console.WriteLine($"My age is {x} years\n\n Your resut = {your_temps} temps");
            Console.WriteLine($"FINISH resut = \n\tYour: {your_temps}, My : {my_temps} temps");
            if (your_temps < my_temps) playful_level -= 500;
            else
            {
                playful_level -= 700;
            }
            if (Years > 18) Weight -= 0.2;
            else Weight -= 0.1;
        }
    }
    public Scotish(double weight, char gender, int years, string name)
    {
        if (weight < 0 || years < 0)
            throw new Exception("ERROR value: too mach light or yaung!");
        else
        {
            Years = years;
            Weight = weight;
        }

        Gender = gender;
        Name = name;

        _timer = new Timer(TimerCallback, null, 0, 2000);
    }
    public Scotish()
    {
        Years = 0; Gender = 'm';
        Name = "1234"; Weight = 1.23;
        _timer = new Timer(TimerCallback, null, 0, 2000);
    }
    public Scotish(string stereotip)
    {
        if (stereotip == "school")
        {
            Years = 15; Gender = 'm';
            Name = "scholer"; Weight = 60;
        }
        else if (stereotip == "vyz")
        {
            Years = 20; Gender = 'w';
            Name = "university"; Weight = 70;
        }
        else if (stereotip == "work")
        {
            Years = 35; Gender = 'm';
            Name = "worker"; Weight = 80;
        }
        else if (stereotip == "alife")
        {
            Years = 90; Gender = 'w';
            Name = "deather"; Weight = 50;
        }
        else
        {
            Years = -1; Gender = '-';
            Name = "-"; Weight = 0;
        }
        _timer = new Timer(TimerCallback, null, 0, 2000);

    }
    ~Scotish()
    {
        Console.WriteLine("IS it a Death?");
        Console.WriteLine("--Yeas, it is..");
        // Dispose();
    }

    public static bool operator ==(Scotish cat1, Scotish cat2)
    {
        if (cat1.Name == cat2.Name && cat1.Years == cat2.Years) return true;
        else return false;
    }
    public static bool operator !=(Scotish cat1, Scotish cat2) =>
        (cat1.Name != cat2.Name || cat1.Years != cat2.Years);
    public static Scotish operator +(Scotish cat1, Scotish cat2)
    {
        cat1.Weight += cat2.Weight;
        cat1.Years += cat2.Years;
        cat1.Name = "COMBO";
        return cat1;
    }
    public override void print_name() =>
            Console.WriteLine("print_name: Scotish");
}
class MainCun : Cat
{
    public MainCun()
    {
        Console.WriteLine("\t\t____MainCun.MainCun()_____");
        Years = 0; Gender = 'm';
        Name = "MainCun"; Weight = 1.78;
        _timer = new Timer(TimerCallback, null, 0, 2000);
    }
    public override void print_name() =>
        Console.WriteLine("print_name: MainCun");
    static public bool corner_ear = true;
    public override void Play()
    {
        Console.WriteLine("\t\t____MainCun.Play()_____");
        Console.WriteLine("I dont play the games");
    }
    public void Calmness()
    {
        Console.WriteLine("\t\t____MainCun.Calmness()_____");
        Console.WriteLine("I'm YODA");
    }
    public void Corner_ear()
    {
        Console.WriteLine("\t\t____MainCun.Corner_ear()_____");
        if (corner_ear) Console.WriteLine("I'm not a batman - cat");
    }
}
class Perside : Cat
{
    public Perside()
    {
        Console.WriteLine("\t\t____Perside.Perside()_____");
        Years = 0; Gender = 'm';
        Name = "pers"; Weight = 1.99;
        _timer = new Timer(TimerCallback, null, 0, 2000);
    }
    public override void print_name() =>
    Console.WriteLine("print_name: Perside");
    public void Name_why()
    {
        Console.WriteLine("\t\t____Perside.Name_why()_____");
        Console.WriteLine("\t-Your name is Persiphona?");
        Console.WriteLine("\t-Your name is Persida?");
        Console.WriteLine("\t-Are you from Persia?");
    }
    public override void View()
    {
        Console.WriteLine("\t\t____Perside.View()_____");
        Console.WriteLine("\t\t^      ^");
        Console.WriteLine("\t\t  0   0 ");
        Console.WriteLine("\t\t--- o ---");
        Console.WriteLine("\t\t--- ^---");
    }
    public bool long_wool = true;
}
sealed class Sfinks : Cat
{
    public Sfinks()
    {
        Console.WriteLine("\t\t____Sfinks.Sfinks()_____");
        Years = 0; Gender = 'w';
        Name = "Sf"; Weight = 11;
        _timer = new Timer(TimerCallback, null, 0, 2000);
    }
    public bool is_egipt = true;
    public override void View()
    {
        Console.WriteLine("\t\t____Sfinks.View()_____");
        Console.WriteLine("\t\t^      ^");
        Console.WriteLine("\t\t  0   0 ");
        Console.WriteLine("\t\t---___ ---");
        Console.WriteLine("\t\t---___---");
    }
    public void Lion()
    {
        Console.WriteLine("\t\t____Sfinks.Lion()_____");
        if (is_egipt) Console.WriteLine("i am a egypt lion!");
    }
    public override void print_name() =>
        Console.WriteLine("print_name: Sfinks");
}

interface IHasFourLeg
{
    void Stability();
    void Speed();
}
class Capibar : IHasFourLeg
{
    public int Years { get; set; }
    public char Gender { get; set; }
    public string Name { get; set; }
    public double Weight { get; set; }
    public Capibar()
    {
        Console.WriteLine("\t\t____Capibar.Capibar()_____");
        Years = 5; Gender = 'm';
        Name = "CAPIBAR"; Weight = 4.99;
    }
    public void Print_name() =>
        Console.WriteLine("print_name: Capibar");
    public void Stability()
    {
        Console.WriteLine("\t\t____Capibar.Stability()_____");
        Console.WriteLine("I has 4 legs - BUT i dont stability");
    }
    public void Bite()
    {
        Console.WriteLine("\t\t____Capibar.Bite()_____");

        if (Years < 5)
            Console.WriteLine("Nam Nam Nam");
        else
            Console.WriteLine("i am too old for this");
    }
    public void Speed()
    {
        double speed = Math.Abs(Years * 3 - Weight * 0.1);
        Console.WriteLine("\t\t____Capibar.Speed()_____");
        Console.WriteLine($"i can run. my speed = {speed} km/h");
    }
}

