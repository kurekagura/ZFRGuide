using System;
public class HelloDLL010
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL010)}");
        var lib = new HelloDLL011();
        lib.Say();
    }
}