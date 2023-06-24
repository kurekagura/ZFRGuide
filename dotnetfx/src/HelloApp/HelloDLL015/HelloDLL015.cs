using System;
public class HelloDLL015
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL015)}");
        var lib = new HelloDLL016();
        lib.Say();
    }
}