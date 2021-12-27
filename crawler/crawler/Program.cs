using FluentScheduler;
using System;


namespace crawler 
{
    class Program  
    {
        static void Main(string[] args) 
        {
            JobManager.Initialize(new Configuracao());
            Console.ReadLine();
        }
    }
}
