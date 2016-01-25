using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_4_3
{
    class PhoneContext : DbContext
    {
        static PhoneContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
        public PhoneContext()
            : base("EF_lesson_4_4")
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
