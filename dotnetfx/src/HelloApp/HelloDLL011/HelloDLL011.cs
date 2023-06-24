using System;
public class HelloDLL011
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL011)}");
        var lib = new HelloDLL012();
        lib.Say();
    }
}