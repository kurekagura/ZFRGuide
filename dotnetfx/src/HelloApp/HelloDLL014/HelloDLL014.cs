using System;
public class HelloDLL014
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL014)}");
        var lib = new HelloDLL015();
        lib.Say();
    }
}