using System;

class Syntax
{
    static int i = 0;
    static char[] s = new char[10];

    static void Main()
    {
        Console.WriteLine(" Use this Grammar for Testing Your String : ");
        Console.WriteLine("S -> aYcZ/cZbX");
        Console.WriteLine("X -> b/a");
        Console.WriteLine("Y -> a/c");
        Console.WriteLine("Z -> d/e");
        Console.WriteLine("Enter your string");
        Console.ReadLine().ToCharArray().CopyTo(s, 0);

        S();
    }

    static void S()
    {
        if (s[i] == 'a')
        {
            i++;
            Y();
            if (s[i] == 'c')
            {
                i++;
                Z();
            }
            else
                Error();
        }
        else if (s[i] == 'c')
        {
            i++;
            Z();
            if (s[i] == 'b')
            {
                i++;
                X();
            }
            else
                Error();


        }
        Console.WriteLine("Accept");
    }

    static void X()
    {
        if (s[i] == 'b' || s[i] == 'a')
            i++;
        else
            Error();
    }

    static void Y()
    {
        if (s[i] == 'a' || s[i] == 'c')
            i++;
        else
            Error();
    }

    static void Z()
    {
        if (s[i] == 'd' || s[i] == 'e')
            i++;
        else
            Error();
    }
    static void Error()
    {
        Console.WriteLine("Reject");
        Environment.Exit(0);
    }
}