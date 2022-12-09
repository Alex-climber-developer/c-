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

using Internal;
using System;

class Program
{
    static void Main(string[] args)
    {
        Cat cat1 = new Cat(100, 'm', 11, "catcat");
        cat1.Play();
    }
}

class Cat
{
    public int Years; public char Gender;
    public string Name; public float Weight;
    private int hungry_level = 0, mood = 0, playful_level = 0;
    private bool isLife = 1;
    public Cat(float weight, char gender, int years, string name)
    {
        if (weight <= 0 || years <= 0) throw new Exception("ERROR value!");
        else
        {
            Years = years;
            Weight = weight;
        }

        Gender = gender;
        Name = name;
        Timer timer1 = new Timer
        {
            Interval = 2000
        };
        timer1.Enabled = true;
        timer1.Tick += new System.EventHandler(OnTimerEvent);
    }
    public void Play()
    {
        int x = 50, max = 100, min = 0, flag = 1, your_temps = 0, my_temps = 1;
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
            output = Console.Readline();
            if (output.ToLower() == "more")
            {
                if (x == 99)
                {
                    Console.WriteLine("Мяу\n you very old for this!\n");
                    flag = 0;
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
                    flag = 0;
                }
                else
                {
                    my_temps++;
                    int tmp = x;
                    x = (x + min) / 2;
                    max = tmp;
                }
            }
            else
            {
                Console.WriteLine("Мяу\n Error value!\n");
                flag = 0;
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
                x = (int)Console.Readline();
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

    static private void Broke_view()
    {
        Console.WriteLine("!-__-!");
    }

    public void Stroke()
    {
        Console.WriteLine("mmmmmmmrrrrr");
        mood += (mood / Math.Abs(mood));
    }

    public void Feed()
    {
        Console.WriteLine("thank you it was delicious !");
        hungry_level -= 150;
        if (Gender == 'm') Weight += 0.1;
        else Weight += 0.2;
    }
    private void Bioritms()
    {
        if (Gender == 'm') hungry_level += 2;
        else hungry_level++;
        if (Years < 5) playful_level += 2;
        else playful_level++;

        if ((hungry_level + playful_level) > 0 &&
            (hungry_level + playful_level) % 120 == 0) mood--;    // каждые 60сек если голодный и не игранный --mood
        else if ((hungry_level + playful_level) < 0 &&
            (hungry_level + playful_level) % 60 == 0) mood++;     // каждые 30сек если не голоден и игран то ++mood

        if (Gender == 'm') Weight -= 0.002;
        else Weight -= 0.001;   // при весе в кило в среднем (м или ж) кошак через 20 минут без кормежки умрет

        if (mood < 0) Weight += mood * 0.005;
        if (Weight < 0.1) isLife = 0;

    }
    private void OnTimerEvent(object sender, EventArgs e)
    {
        Bioritms();
    }
}




