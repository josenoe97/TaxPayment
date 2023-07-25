using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using TaxPayment.Entities;
using TaxPayment.Entities.Exceptions;

namespace TaxPayment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> listPayer = new List<TaxPayer>();

            try
            {
                Console.Write("Enter the number of tax payers: ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"Tax payer #{i} data: ");

                    Console.Write("Individual or company (i/c)? ");
                    char ch = char.Parse(Console.ReadLine().ToUpper());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    if (ch == 'I')
                    {
                        Console.Write("Health expenditures: ");
                        double heathExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        listPayer.Add(new Individual(name, anualIncome, heathExpenditures));
                    }
                    else if (ch == 'C')
                    {
                        Console.Write("Number of employees: ");
                        int numberEmployees = int.Parse(Console.ReadLine());

                        listPayer.Add(new Company(name, anualIncome, numberEmployees));
                    }
                }

            }
            catch (DomainException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}" );
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");

            double sumTax = 0;

            foreach (TaxPayer payer in listPayer) 
            {
                Console.WriteLine($"{payer.Name}: $ {payer.Tax().ToString("F2", CultureInfo.InvariantCulture)}");
                sumTax += payer.Tax();
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL TAXES: $ {sumTax.ToString("F2" , CultureInfo.InvariantCulture)}");
        }
    }
}
