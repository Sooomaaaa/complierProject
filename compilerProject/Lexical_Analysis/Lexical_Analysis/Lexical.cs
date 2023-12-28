using System;
using System.IO;

class Lexical
{

    static bool isKeyword(string keyword)
    {
        string[] keywords = {"abstract", "as", "base", "bool", "break", "byte", "case", "catch",
                             "char", "checked", "class", "const", "continue", "decimal", "default", "delegate",
                             "do", "double", "else", "enum", "event", "explicit", "extern",
                             "false", "finally", "fixed", "float", "for",
                             "foreash", "goto", "if ", "implicit","in", "int", "interface", "internal",
                             "is ", "long", "namespace","new", "null","Console","WriteLine",
                             "override", "private", "protected ","ReadLine","object", "operator", "out",
                             "public" ,"ref","return","sealed","short","sizeof","static","string","System",
                             "struct","switch","this","throw","true","typeof","using","var","virtual",
                             "void","volatile","while" };

        for (int i = 0; i < keywords.Length; ++i)
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
        char token;
        char[] Test = new char[200];
        char[] operators = "<>|&!*-+%=".ToCharArray();
        char[] specialChar =".(){}[];,".ToCharArray();
        char[] numercalConstant = "0123456789".ToCharArray();
        char[] comment = "*/".ToCharArray();

        
        StreamReader fin = new StreamReader("E:/FCI/My_Project/compilerProject/inputForTest.txt"); 

        while (!fin.EndOfStream)
        {
            token = (char)fin.Read();

            for (int i = 0; i < specialChar.Length; i++)
            {
                if (token == specialChar[i])
                    Console.WriteLine(token + " => Special Character");
            }
            for (int i = 0; i < operators.Length;i++)
            {
                if (token == operators[i])
                    Console.WriteLine(token + "=> Operator");
            }
            for (int i = 0; i<numercalConstant.Length; i++)
            {
                if (token == numercalConstant[i])
                    Console.WriteLine(token + " =>Numercal Constant ");
            }
            for (int i = 0; i <comment.Length;i++)
            {
                if (token == comment[i])
                    Console.WriteLine(token + " => Comment");
            }
            if (char.IsLetterOrDigit(token))
            {
                Test[x++] = token;
            }
             if ((token == ' ') && (x != 0))
            {
                string identifier = new string(Test, 0, x);
                x = 0;
                if (isKeyword(identifier))
                    Console.WriteLine(identifier + " => keyword");
                else
                    Console.WriteLine(identifier + " => identifier");
            }
            
        }

        fin.Close();
    }
}