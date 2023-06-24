using System;
public class HelloDLL001
{
    public void Say()
    {
        Console.WriteLine($"Hello World in {typeof(HelloDLL001)}");
        var lib = new HelloDLL002();
        lib.Say();
    }
}