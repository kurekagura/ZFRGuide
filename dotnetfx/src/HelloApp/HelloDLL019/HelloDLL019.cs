using System;
public class HelloDLL019
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL019)}");
        var lib = new HelloDLL020();
        lib.Say();
    }
}