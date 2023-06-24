using System;
public class HelloDLL007
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL007)}");
        var lib = new HelloDLL008();
        lib.Say();
    }
}