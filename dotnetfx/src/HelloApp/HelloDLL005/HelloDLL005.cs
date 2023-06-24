using System;
public class HelloDLL005
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL005)}");
        var lib = new HelloDLL006();
        lib.Say();
    }
}