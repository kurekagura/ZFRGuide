using System;
public class HelloDLL018
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL018)}");
        var lib = new HelloDLL019();
        lib.Say();
    }
}