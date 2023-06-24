using System;
public class HelloDLL017
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL017)}");
        var lib = new HelloDLL018();
        lib.Say();
    }
}