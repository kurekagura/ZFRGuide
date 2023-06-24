using System;
class HelloEXE
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World in EXE");
        HelloDLL001 lib = new HelloDLL001();
        lib.Say();
        Console.WriteLine("Please enter key to exit.");
        Console.ReadLine();
    }
}