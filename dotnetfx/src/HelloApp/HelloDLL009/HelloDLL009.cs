using System;
public class HelloDLL009
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL009)}");
        var lib = new HelloDLL010();
        lib.Say();
    }
}