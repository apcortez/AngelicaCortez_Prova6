using AngelicaCortez_Prova6.Core.Interfaces;
using AngelicaCortez_Prova6.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6.EntityFramework.Repositories
{
    class EFPolicyRepository : IPolicyRepository
    {
        private readonly CustomerContext clientCtx;

        public EFPolicyRepository()
        {
            clientCtx = new CustomerContext();
        }
        public void Delete(Policy t)
        {
            throw new NotImplementedException();
        }

        public List<Policy> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Policy> FilterByType(_Type type)
        {
            if (type < 0)
                return null;

            return clientCtx.Policies.Include(p => p.Customer).Where(p => p.Type == type).ToList();

        }

        public Policy GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Policy policy)
        {
            if (policy == null) throw new ArgumentNullException();

            try
            {

                clientCtx.Policies.Add(policy);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.StackTrace);
            }
        }

        public void Update(Policy policy)
        {
              if (policy == null) throw new ArgumentNullException();

            try
            {

                clientCtx.Policies.Add(policy);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.StackTrace);
            }
        }
    }
}
