using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete;
using DataAccess.Abstract;


namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            InMemoryProductDal abc = new InMemoryProductDal();
            Console.WriteLine(abc.GetById(1)); 
        }        
       


    }
}
