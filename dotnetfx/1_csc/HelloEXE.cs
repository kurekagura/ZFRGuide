using System;
class HelloEXE
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World in EXE");
        HelloDLL lib = new HelloDLL();
        lib.Say();
    }
}