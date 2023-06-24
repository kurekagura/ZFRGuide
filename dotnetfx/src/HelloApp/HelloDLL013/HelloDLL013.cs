using System;
public class HelloDLL013
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL013)}");
        var lib = new HelloDLL014();
        lib.Say();
    }
}