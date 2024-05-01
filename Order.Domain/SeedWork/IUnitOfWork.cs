using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    //transactionların sonlandığı yer. (dbconstext in en son  savechange yaptığı bütün işlemler gibi)
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
