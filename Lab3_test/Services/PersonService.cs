using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3_test.Data;
using Lab3_test.Models;

namespace Lab3_test.Services
{
    public interface IPersonService
    {
        PersonModel getFirst();
        IList<PersonModel> getList(Func<PersonModel, bool> pred);
    }

    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext db;

        public PersonService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public PersonModel getFirst()
        {
            return db.Persons.First();
        }

        public IList<PersonModel> getList(Func<PersonModel, bool> pred)
        {
            return db.Persons.Where(pred).ToList();
        }


    }
}