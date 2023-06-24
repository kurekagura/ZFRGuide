using System;
public class HelloDLL004
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL004)}");
        var lib = new HelloDLL005();
        lib.Say();
    }
}