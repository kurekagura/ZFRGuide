using System;
public class HelloDLL012
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL012)}");
        var lib = new HelloDLL013();
        lib.Say();
    }
}