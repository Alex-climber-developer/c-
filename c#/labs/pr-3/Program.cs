using System.Runtime.InteropServices;
using System.IO.Enumeration;
using System.Text;
//       1. Какое максимальное поколение объектов в ходе выполнения
//              программы было выявлено? ----2
//              Сколько их в C# всего? -----3(2st - last)

//       2. Что будет, если закомментировать строчку GC.Collect(0);
//              Изменится ли вывод программы, если да, то как и почему?
//              изменится  - ранее мы очищали сначала до 0вкл и после при надобности до 2го 
//              сейчас вывода 3 а очистка идет одна (а значит 2 вывода первых будут одинаковы)

//       3. Что будет, если закомментировать строчку GC.Collect(2);
//        Изменится ли вывод программы, если да, то как и почему?
//              да   теперь мы очищаем один раз до 0 поколения 

//       4. Измените параметр метода GC.GetTotalMemory() с true на false.
//       На что это влияет?
//              true = перед возвратом этот метод может дождаться выполнения сборки мусора; 

//       5. В методе MakeSomeGarbage() добавьте к объекту vt создание еще 
//       одного любого объекта, например класса StringBuilder. Что изменилось в выводе программы?
//              Создавая стрингбилдер меньше 1024 байт (в параметре) результат не меняктся
//              1024 и больше результат на 40 байт отличается после и до очистки поколений- загадка

// using System.IO;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// namespace GarbageCollectorInCSharp
// {
//     class GCProgram
//     {
//         private const long maxGarbage = 1000;
//         static void Main()
//         {
//             GCProgram myGCCol = new GCProgram();
//             Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);
//             myGCCol.MakeSomeGarbage();
//             Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
//             Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));
//             GC.Collect(0);
//             Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
//             Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));
//             GC.Collect(2);
//             Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
//             Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));
//             Console.Read();
//         }
//         void MakeSomeGarbage()
//         {
//             Version vt;
//             for (int i = 0; i < maxGarbage; i++)
//             {
//                 vt = new Version();
//             }
//         }
//     }
// }



// Вариант 8
// Отсортировать слова в файлах по количеству букв.
// Изменить порядок слов в файле на обратный.

// Написать класс-для работы с данной библиотекой: 
// при создании объекта класса, он открывает файл по переданному конструктору в качестве параметра пути и хранит дескриптор файла всё 
// время жизни объекта.
// Созданный класс должен содержать
//  конструктор, принимающий 
// два параметра: путь к файлу и режим открытия файла.
// Созданный класс должен закрывать связанный файл при вызове 
// метода Dispose, либо финализации. Созданный класс не должен 
// предусматривать повторное открытие файла.
// Предусмотреть обработку всех возможных исключений при работе с файлом.
// В качестве тестовых файлов преподаватель выдаст заранее подготовленные файлы, содержащие набор отдельных слов, с возможными повторения.
// Написать программу для тестирования созданного класса, которая должна выполнять указанные в варианте операции.Программа 
// должна содержать меню, со следующими функциями: открыть файлы,
// получить количество слов в файлах, а также указанные в варианте 
// действия над файлами.
// Если не сказано иного, то изменяться должны те же файлы, что и 
// были предоставлены.
// Использовать иные методы работы с файлом кроме библиотеки 
// запрещено!
// using stream.FileStream;
using System;
using System.Runtime.InteropServices;
public class Program
{
    [DllImport("file64.dll")]
    static extern IntPtr open(string path, bool read);
    [DllImport("file64.dll")]
    static extern void close(IntPtr file);
    [DllImport("file64.dll")]
    static extern bool read(IntPtr file, int num, StringBuilder word);
    [DllImport("file64.dll")]
    public static extern void write(IntPtr file, string text);
    [DllImport("file64.dll")]
    static extern int length(IntPtr file);

    static void Main()
    {
        Test();
        Console.ReadLine();
    }
    private static void Test()
    {
        lib_intPtr_worker lib = null;
        try
        {
            while (menu(ref lib)) { }
        }
        finally
        {
            if (lib != null)
            {
                lib.Dispose();
            }
        }
    }
    public static bool menu(ref lib_intPtr_worker libWork)
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("[0] exit");
        Console.WriteLine("[1] open file");
        Console.WriteLine("[2] count words");
        Console.WriteLine("[3] sort words");
        Console.WriteLine("[4] reverse");
        Console.Write("\r\nSelect an option: ");
        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Enter PATH: ");
                string path = Console.ReadLine();
                Console.Write("Enter MODE(1,0): ");
                bool mode = int.Parse(Console.ReadLine()) == 1 ? true : false;
                libWork = lib_intPtr_worker.creator(path, mode);
                break;
            case "2":
                if (libWork != null) Console.WriteLine($"Count words: {length(libWork.fp)}");
                else Console.WriteLine("Firstly use option [1]");
                break;
            case "3":
                if (libWork != null) libWork.sort();
                else Console.WriteLine("Firstly use option [1]");
                break;
            case "4":
                if (libWork != null) libWork.reverse();
                else Console.WriteLine("Firstly use option [1]");
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
    public class lib_intPtr_worker : IDisposable
    {
        public string path;
        public IntPtr fp;
        public List<StringBuilder> listWords = null;
        public static lib_intPtr_worker instanse = null;
        private lib_intPtr_worker(string Filename, bool mode)
        {
            var path = Path.Combine(Environment.CurrentDirectory, Filename);
            fp = open(path, mode);
            if (fp == null) Console.WriteLine("Error open file");
            this.path = path;
            // this.mode = mode;
        }
        public static lib_intPtr_worker creator(string path, bool mode)
        {
            bool is_ok = false;
            if (instanse == null)
            {
                instanse = new lib_intPtr_worker(path, mode);
                // check_exceptions();
            }
            else Console.WriteLine("object was created yet");
            return instanse;
        }
        public void Dispose()
        {
            print();
            close(this.fp);
            Console.Beep();
        }
        // public bool check_exceptions()
        // {
        //     bool is_ok = true;
        //     if (fp == null) { Console.WriteLine("Error open file"); is_ok = false; }
        //     return is_ok;
        // }
        public void sort()
        {
            int num = 1;
            StringBuilder word = new StringBuilder();
            listWords = new List<StringBuilder>();
            while (read(fp, num++, word))
            {
                listWords.Add(word);
                word = new StringBuilder();
            }
            // foreach (var el in listWords) Console.WriteLine($"{el}");

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[1] small -> big");
            Console.WriteLine("[2] big -> small");
            Console.Write("\r\nSelect an option: ");
            System.Text.StringBuilder[] sorted_list = null;
            switch (Console.ReadLine())
            {
                case "1":
                    sorted_list = listWords.OrderBy(a => a.Length).ToArray();
                    break;
                case "2":
                    sorted_list = listWords.OrderByDescending(a => a.Length).ToArray();
                    break;
                default:
                    Console.WriteLine("ERROR option");
                    break;
            }
            List<StringBuilder> new_list = new List<StringBuilder>(sorted_list);
            listWords.Clear();
            listWords = new_list;
            // foreach (var el in listWords) Console.WriteLine($"{el}");
        }
        public void reverse()
        {
            int num = length(fp);
            StringBuilder word = new StringBuilder();
            listWords = new List<StringBuilder>();
            read(fp, num--, word);
            while (num != -1)
            {
                listWords.Add(word);
                word = new StringBuilder();
                read(fp, num--, word);
            }
        }
        private void print()
        {
            close(this.fp);
            fp = open(path, false);
            if (fp == null) Console.WriteLine("Error open file");
            else
            {
                string new_data = String.Join(" ", listWords);
                write(fp, new_data);
            }
        }
    }
}

