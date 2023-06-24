using System;
public class HelloDLL008
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL008)}");
        var lib = new HelloDLL009();
        lib.Say();
    }
}