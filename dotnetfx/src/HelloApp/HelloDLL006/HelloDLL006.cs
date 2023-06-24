using System;
public class HelloDLL006
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL006)}");
        var lib = new HelloDLL007();
        lib.Say();
    }
}