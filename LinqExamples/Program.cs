using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples {

    class Program {

        static void Main(string[] args) {

            List<Customer> customers = new List<Customer>() {
                new Customer(){Id = 1, Name = "MAX", Sales = 1000},
                new Customer(){Id = 2, Name = "PG", Sales = 100000000 },
                new Customer(){Id = 3, Name = "Microsoft", Sales = 500000},
                new Customer(){Id = 4, Name = "Amazon", Sales = 104560 },
                new Customer(){Id = 5, Name = "Google", Sales = 111000 }
            };
            var orderedCustomers = from c in customers
                                   orderby c.Sales descending
                                   select new {
                                       c.Name, c.Sales
                                   };
            foreach(var c in orderedCustomers) {
                Console.WriteLine($"{c.Name}{c.Sales:c}");
            }

            int[] numbers = {23, 28, 225, 35, 500, 22, 15,
                                -63, 7, 88, 53, -1, 12, 17};

            var qnbrs = from n in numbers
                          where n < 200
                          orderby n
                          select n;


            int[] numLT200 = numbers.Where(t => t < 200).ToArray();
            //take all the numbers and see if theyre less than 200. t = less than 200 numbers
            int[] numGt50Lt100 = numbers.Where(nbr => nbr >= 50 && nbr <= 100).ToArray();
            
            int[] numbers2 = numbers
               .Where(n => n % 2 == 1)
               .OrderByDescending(x => x)
               .ToArray();
            foreach(int n1 in numbers2) {
                Console.WriteLine($"{n1}");
            }

            int total = 0;
            foreach(int n in numbers) {
                if(n % 2 == 1) { //if 'n' modulus by 2 has a remainder of 1 its an odd number.
                    total += n; //this will add up the odd numbers to total
                    Console.WriteLine($"{n} ");
                }
            }
            Console.WriteLine(total);
        }
    }
}
