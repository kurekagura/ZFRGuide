using System;
public class HelloDLL003
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL003)}");
        var lib = new HelloDLL004();
        lib.Say();
    }
}