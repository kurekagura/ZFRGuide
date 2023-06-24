using System;
public class HelloDLL016
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL016)}");
        var lib = new HelloDLL017();
        lib.Say();
    }
}