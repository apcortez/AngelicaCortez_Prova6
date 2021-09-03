using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Fetch();
        T GetById(int? id);
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
    }
}
