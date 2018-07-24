using Angular.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ANDRADE.DEV.CONTAS
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new ContasContext())
            {
                var teste = db.Transacoes;
            }  
        }
    }
}
