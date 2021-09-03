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
    class EFCustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext clientCtx;

        public EFCustomerRepository()
        {
            clientCtx = new CustomerContext();
        }

        public void Delete(Customer customerToDelete)
        {
            if (customerToDelete == null) throw new ArgumentNullException();

            try
            {
                var customer = clientCtx.Customers.Find(customerToDelete.Id);

                if (customer != null)
                    clientCtx.Customers.Remove(customerToDelete);

                clientCtx.SaveChanges();

          
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
        }

        public List<Customer> Fetch()
        {
            try
            {
                var customers= clientCtx.Customers.Include(c => c.Policies).ToList();
                return customers;
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }


        public Customer GetByFiscalCode(string cf)
        {

            if (string.IsNullOrEmpty(cf))
                return null;

            try
            {
                var customer = clientCtx.Customers.Where(c => c.FiscalCode == cf).FirstOrDefault();

                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetById(int? id)
        {
            if (id <= 0)
                return null;

            return clientCtx.Customers.Find(id);
        }

        public void Insert(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();

            try
            {

                clientCtx.Customers.Add(customer);

                clientCtx.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: "+ ex.Message);
            }
        }

        public void Update(Policy policy)
        {
            if (policy == null) throw new ArgumentNullException();

            try
            {
                clientCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
         
        }

        public void Update(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();

            try
            {
                clientCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
        }
    }
}
