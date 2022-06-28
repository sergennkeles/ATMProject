using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task SaveChangeAsync();
        void SaveChange();
    }
}
