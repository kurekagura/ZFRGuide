using System;
public class HelloDLL002
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL002)}");
        var lib = new HelloDLL003();
        lib.Say();
    }
}