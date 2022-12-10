// вопросы:
//       1. Какое максимальное поколение объектов в ходе выполнения
//      программы было выявлено? ----2
//       Сколько их в C# всего? -----3(2st - last)
//       2. Что будет, если закомментировать строчку GC.Collect(0);
//        Изменится ли вывод программы, если да, то как и почему?
// изменится  - ранее мы очищали сначала до 0вкл и после при надобности до 2го 
//              сейчас вывода 3 а очистка идет одна (а значит 2 вывода первых будут одинаковы)

//       3. Что будет, если закомментировать строчку GC.Collect(2);
//        Изменится ли вывод программы, если да, то как и почему?
//              да   теперь мы очищаем один раз до 0 поколения 
//       4. Измените параметр метода GC.GetTotalMemory() с true на false.
//       На что это влияет?
//              true = перед возвратом этот метод может дождаться выполнения сборки мусора; 
//       5. В методе MakeSomeGarbage() добавьте к объекту vt создание еще 
//       одного любого объекта, например класса StringBuilder. Что изменилось в выводе программы?
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GarbageCollectorInCSharp
{
    class GCProgram
    {
        private const long maxGarbage = 1000;
        static void Main()
        {
            GCProgram myGCCol = new GCProgram();
            Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);
            myGCCol.MakeSomeGarbage();
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));
            GC.Collect(0);
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));
            GC.Collect(2);
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));
            Console.Read();
        }
        void MakeSomeGarbage()
        {
            Version vt;
            for (int i = 0; i < maxGarbage; i++)
            {
                vt = new Version();
            }
            StringBuilder st = new StringBuilder();
        }
    }
}



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

// [DllImport("file64.dll")]
// public static extern IntPtr open(string path, bool read);
// [DllImport("file64.dll")]
// public static extern void close(IntPtr file);
// [DllImport("file64.dll")]
// public static extern bool read(IntPtr file, int num, StringBuilder word);
// [DllImport("file64.dll")]
// public static extern void write(IntPtr file, string text);
// [DllImport("file64.dll")]
// public static extern int length(IntPtr file);
