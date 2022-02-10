using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples {

    class Program {

        static void Main(string[] args) {

            int[] ints = new int[] {
            869,   842,    861,    672,    757,    144,    397,    110,    109,    111,
            104,    348,    551,    624,    141,    887,    792,    395,    281,    737,
            612,    740,    574,    313,    672,    404,    523,    507,    843,    164,
            233,    115,    338,    905,    378,    761,    169,    666,    354,    453,
            501,    469,    406,    948,    417,    149,    909,    334,    321,    645,
            370,    933,    483,    770,    681,    631,    108,    151,    726,    876,
            869,    464,    827,    678,    240,    971,    903,    709,    380,    246,
            733,    915,    503,    474,    445,    866,    152,    447,    560,    387,
            726,    314,    477,    523,    483,    452,    250,    966,    677,    442,
            841,    278,    406,    787,    710,    769,    570,    145,    555,    774
        };



            List<Customer> customers = new List<Customer>() {
                new Customer(){Id = 1, Name = "MAX", Sales = 1000},
                new Customer(){Id = 2, Name = "PG", Sales = 100000000 },
                new Customer(){Id = 3, Name = "Microsoft", Sales = 500000},
                new Customer(){Id = 4, Name = "Amazon", Sales = 104560 },
                new Customer(){Id = 5, Name = "Google", Sales = 111000 }
            };
            List<Order> orders = new List<Order>() { 
                new Order(){Id = 1, Description = "1st order", 
                    Total = 1000, CustomerId = 2 },
                new Order(){Id = 2, Description = "2nd order",
                    Total = 2000, CustomerId = 5 },
                new Order(){Id = 3, Description = "3rd order",
                    Total = 3000, CustomerId = 1 },
            };

            var customerOrders = from o in orders
                                 join c in customers
                                 on o.CustomerId equals c.Id
                                 orderby o.Total descending
                                 select new {
                                     o.Id, o.Description,
                                     Amount = o.Total,
                                     Customer = c.Name
                                 };
            foreach (var co in customerOrders) {
            Console.WriteLine($"{co.Id, -5}{co.Description, -30}" +
                $"{co.Amount, 7:c}{co.Customer, 25}");
            }

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
            // aslo written like below int total = numbers.Sum();
            Console.WriteLine($"Total is {numbers.Sum()}");

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
