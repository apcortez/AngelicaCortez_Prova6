using AngelicaCortez_Prova6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6.Core.Interfaces
{
    interface IPolicyRepository : IRepository<Policy>
    {
        List<Policy> FilterByType(_Type type);
    }
}
