using Microsoft.EntityFrameworkCore;
using PartialView.Domein.Data;
using PartialView.Domein.Entities;
using PartialView.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Repositories
{
    public class PersonDAO : IPersonDAO
    {
        private readonly PersonDbContext _context;

        public PersonDAO(PersonDbContext context)//DI (dipendency injection)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<Person>> GetAllPersonsAsync(JobType type)
        {

            // => goes operator

            // Uitleg Lambda Expression
            // Expression lambda that has an expression as its body:
            //  (input-parameters) => expression

            // this  '=>' is the goes operator
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions

            // uitleg LINQ
            // https://www.tutorialsteacher.com/linq/linq-method-syntax

            return await _context.Persons.Where(p => p.Job == type).ToListAsync();

        }
    }
}
