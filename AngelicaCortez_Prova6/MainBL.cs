using AngelicaCortez_Prova6.Core.Interfaces;
using AngelicaCortez_Prova6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6
{
    class MainBL
    {
        private ICustomerRepository _clientRepo;
        private IPolicyRepository _policyRepo;
        public MainBL(ICustomerRepository clientRepository, IPolicyRepository policyRepository)
        {
            _clientRepo = clientRepository;
            _policyRepo = policyRepository;
        }

        internal void InsertCustomer(Customer customer)
        {
            
            if (customer == null) throw new ArgumentNullException();

            _clientRepo.Insert(customer);
        }

        internal Customer GetByFiscalCode(string codicefiscale)
        {
            
            if (string.IsNullOrEmpty(codicefiscale)) throw new ArgumentNullException();
            var customer = _clientRepo.GetByFiscalCode(codicefiscale);
            return customer;

        }

        internal void InsertPolicy(Policy policy)
        {
            if (policy == null) throw new ArgumentNullException();
            _policyRepo.Insert(policy);
            
        }

        internal void UpdateCustomer(Policy policy)
        {
            if (policy == null) throw new ArgumentNullException();
            _policyRepo.Update(policy);
        }

        internal List<Customer> FetchCustomers()
        {
            return _clientRepo.Fetch();
        }

        internal List<Policy> GetByType(_Type type)
        {
            return _policyRepo.FilterByType(type);
        }

        internal void UpdateCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();
            _clientRepo.Update(customer);
        }
    }
}
