using EfCore.Models;
using System;

namespace EfCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();
            var categ = new Category
            {
                Name = "Mohamed"
            };

            _context.Categories.Add(categ);
            _context.SaveChanges();
        }
    }
}
