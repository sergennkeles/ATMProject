using ATMProject.Application.Interfaces.UnitOfWorks;
using ATMProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
           await  _context.SaveChangesAsync();
        }
    }
}
