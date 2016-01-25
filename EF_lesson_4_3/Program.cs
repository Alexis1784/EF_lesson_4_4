using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
 
                var phones = db.Phones.Join(db.Companies, // второй набор
                    p => p.CompanyId, // свойство-селектор объекта из первого набора
                    c => c.Id, // свойство-селектор объекта из второго набора
                    (p, c) => new // результат
                    {
                        Name = p.Name,
                        Company = c.Name,
                        Price = p.Price
                    });
                foreach (var p in phones)
                    Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);

                Console.WriteLine("phones2:");
                var phones2 = from p in db.Phones
                             join c in db.Companies on p.CompanyId equals c.Id
                             select new { Name = p.Name, Company = c.Name, Price = p.Price };
                foreach (var p in phones)
                    Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);
            }
            Console.ReadLine();
        }
    }
}
