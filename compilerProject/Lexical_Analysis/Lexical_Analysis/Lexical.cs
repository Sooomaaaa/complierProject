using System;
using System.IO;

class Lexical
{

    static bool isKeyword(string keyword)
    {
        string[] keywords = {"auto", "break", "main", "case", "char", "const", "continue", "default",
                             "do", "double", "else", "enum", "extern", "float", "for", "goto",
                             "if", "int", "long", "register", "return", "short", "signed",
                             "sizeof", "static", "struct", "switch", "union",
                             "unsigned", "void", "volatile", "while"};

        for (int i = 0; i < 32; ++i)
        {
            if (string.Equals(keywords[i], keyword))
            {  
                return true;
            }
        }

        return false;
    }
   
    static void Main()
    {
        int x = 0;
        char Char;
        char[] Test = new char[15];
        char[] operators = "/*-+%=".ToCharArray();
        char[] specialChar = "(){}[]<>,".ToCharArray();
        char[] numercalConstant = "0123456789".ToCharArray();
        
        StreamReader fin = new StreamReader("E:/FCI/My_Project/compilerProject/inputForTest.txt"); 

        if (fin == null)
        {
            Console.WriteLine("Fill is  Empty");
            Environment.Exit(0);
        }

        while (!fin.EndOfStream)
        {
            Char = (char)fin.Read();
            
            for (int i = 0; i < 6; i++)
            {
                if (Char == operators[i])
                    Console.WriteLine(Char + " is operator");
                else if (Char == specialChar[i])
                    Console.WriteLine(Char + " is specialCharacter");
            }
            for (int i = 0; i < 9; i++)
            {
                if (Char == numercalConstant[i])
                    Console.WriteLine(Char + " is numercalConstant");

            }
            if (char.IsLetterOrDigit(Char))
            {
                Test[x++] = Char;
            }
            else if ((Char == ' ' || Char == '\n') && (x != 0))
            {
                string identifier = new string(Test, 0, x);

                x = 0;
                
                if (isKeyword(identifier))
                    Console.WriteLine(identifier + " is keyword");
                else
                    Console.WriteLine(identifier + " is identifier");
 
            }
            
        }

        fin.Close();
    }
}