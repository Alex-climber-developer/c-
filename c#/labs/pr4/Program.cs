// Определить количество элементов целочисленного массива А 
// (35), кратных 3 и не кратных 5 одновременно.
using System;
using System.Runtime.InteropServices;
public class Program
{
    [DllImport("file64.dll")]
    void count_check(int* arr, int len);

    [DllImport("file64.dll")]
    void print(int* arr, int len);

    [DllImport("file64.dll")]
    void scan(int* arr, int len);

    [DllImport("file64.dll")]
    // public static extern void write(IntPtr file, string text);
    // [DllImport("file64.dll")]
    static extern int length(IntPtr file);
    static void Main()
    {
        Console.ReadLine();
    }
}