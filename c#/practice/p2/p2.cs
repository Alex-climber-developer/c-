using System;
using System.Collections.Generic;

void f(ref int x) { x = 5; }
int x = 10;
Console.WriteLine(x);
f(ref x);
Console.WriteLine(x);
