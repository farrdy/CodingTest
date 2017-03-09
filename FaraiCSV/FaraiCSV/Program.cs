using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaraiCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            string[] allLines = File.ReadAllLines(Path.Combine(path,"data.csv"));

            var query = (from line in allLines.Skip(1)
                         let data = line.Split(',')
                         let v = data[2].ParseAddress()

                         select new Contact
                         {
                             FirstName = data[0],
                             LastName = data[1],
                             Address = new Address
                             {
                                 Number = v.Number,
                                 StreetName = v.StreetName
                             },
                             PhoneNumber = data[3]

                         });

            Console.WriteLine("------------ORIGINAL CSV DATA----------------");
            foreach (var item in query)
            {

                Console.WriteLine(string.Format("{0} {1} {2} {3} {4}", item.FirstName, item.LastName, item.Address.Number, item.Address.StreetName, item.PhoneNumber));

            }
            Console.WriteLine("-----------NAME FREQUENCIES----------");
            //Generating frequencies  for firstname and lastname 

            var freq = query
                       .Select(i => i.FirstName)
                       .Concat(query.Select(i => i.LastName))
                       .GroupBy(i => i)
                       .Select(i => new { PersonName = i.Key, Count = i.Count() })
                       .OrderByDescending(i => i.Count)
                       .ThenBy(i => i.PersonName);

            foreach (var item in freq)
            {
                Console.WriteLine("{0} {1}", item.PersonName, item.Count);
            }


            //write to namefreq text file
            string savedpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            
            using (StreamWriter sw = new StreamWriter(Path.Combine(savedpath, "namefreq.txt")))
            {

                foreach (var item in freq)
                {
                    sw.WriteLine("{0}, {1}", item.PersonName, item.Count);
                }
            }

            Console.WriteLine("Name frequencies  saved to this folder :{0}", Path.Combine(savedpath, "namefreq.txt"));
           
            //Generating Address list

            List<Address> listadd = new List<Address>();
            foreach (var item in query)
            {
                listadd.Add(item.Address);
            }
             listadd.Sort();

            foreach (var item in listadd)
            {
                Console.WriteLine("{0} {1}", item.Number, item.StreetName);
            }
          
            //Generate Adress list file ordered by streetname
            using (StreamWriter sw = new StreamWriter(Path.Combine(savedpath, "addressList.txt")))
            {

                foreach (var item in listadd)
                {
                    sw.WriteLine("{0}, {1}", item.Number, item.StreetName);
                }
            }
            Console.WriteLine("addresses ordered  saved to this folder :{0}", Path.Combine(savedpath, "addressList.txt"));
            Console.ReadKey();


        }
    }
}
