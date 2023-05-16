
using System;

class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string resulte = spy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(resulte);
    }
}

