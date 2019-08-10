using System;
//using System.Collections.Generic;

namespace CarreMagique
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Uti.Info("Program", "Main", "");
            

            
            Menu menu = new Menu();
            menu.MethodesMenuJeu();
            Console.WriteLine();
        }
    }

/*
     class Program
{
    static void Main(string[] args)
    {

        List<string> AuthorList = new List<string>();
        AuthorList.Add("Mahesh Chand");
        AuthorList.Add("Praveen Kumar");
        AuthorList.Add("Raj Kumar");
        AuthorList.Add("Nipun Tomar");
        AuthorList.Add("Mahesh Chand");
        AuthorList.Add("Dinesh Beniwal");
        foreach (var author in AuthorList)
        {
            Console.WriteLine(author);
        }
        Console.WriteLine("-------------");
        // Contains - Check if an item is in the list    
        if (AuthorList.Contains("Mahesh Chand"))
        {
            Console.WriteLine("Author found!");
        }

        // Find an item and replace it with new item  
        int idx = AuthorList.IndexOf("Nipun Tomar");
        if (idx >= 0)
        {
            AuthorList[idx] = "New Author";
        }
        Console.WriteLine("\nIndexOf ");
        foreach (var author in AuthorList)
        {
            Console.WriteLine(author);
        }
            Console.WriteLine();
    }
} 
*/
}
