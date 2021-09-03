using AngelicaCortez_Prova6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6.Core.Interfaces
{
    interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByFiscalCode(string cf);
        void Update(Policy policy);
        
    }
}
