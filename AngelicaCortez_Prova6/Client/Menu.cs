using AngelicaCortez_Prova6.Core.Models;
using AngelicaCortez_Prova6.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6.Client
{
    class Menu
    {
        private static MainBL mainBL = new MainBL(new EFCustomerRepository(), new EFPolicyRepository());
        internal static void Start()
        {
            bool continuare = true;
            Console.WriteLine("################# BENVENUTO! ################");
            do
            {
                Console.WriteLine();
                Console.WriteLine("#############################################");
                Console.WriteLine("Selezionare un operazione da eseguire:");
                Console.WriteLine("1 - Inserire un nuovo cliente");
                Console.WriteLine("2 - Inserire una polizza per un cliente esistente");
                Console.WriteLine("3 - Visualizza polizze di un cliente");
                Console.WriteLine("4 - Rinnovare una polizza");
                Console.WriteLine("5 - Visualizza clienti con polizza vita");
                Console.WriteLine("0 - Per uscire");
                Console.WriteLine("#############################################");

                Console.WriteLine();
                Console.WriteLine("Quale operazione vuoi scegliere?");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        InsertCustomer();
                        break;
                    case "2":
                        InsertPolicy();
                        break;
                    case "3":
                        ViewCustomerPolicies();
                        break;
                    case "4":
                        RenewPolicy();
                        break;
                    case "5":
                        ViewLifePolicy();
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci. A presto!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }

        private static void ViewLifePolicy()
        {
            _Type type = _Type.Vita;
            List<Policy> policies = mainBL.GetByType(type);
            foreach (var policy in policies)
            {
                Console.WriteLine($"Polizza N.{policy.Id} \n{policy.Customer.FirstName}, {policy.Customer.LastName}\n");
            }
        }

        private static void RenewPolicy()
        {
            List<Customer> customers = mainBL.FetchCustomers();
            int i = 1;
            Console.WriteLine("Seleziona un cliente tra quelle nella lista: ");
            foreach (var c in customers)
            {
                Console.WriteLine($"{i} - {c.Print()}");
                i++;
            }
            Console.WriteLine();

            bool isInt;
            int clienteScelto;
            do
            {
                Console.WriteLine("A quale cliente vuoi rinnovare la polizza?");

                isInt = int.TryParse(Console.ReadLine(), out clienteScelto);

            } while (!isInt || clienteScelto <= 0 || clienteScelto > customers.Count);
            Customer customer = customers.ElementAt(clienteScelto - 1);
            i = 1;
            Console.WriteLine("\nSeleziona la polizza da rinnovare: ");
            foreach (var policy in customer.Policies)
            {
                Console.WriteLine($"{i} - {policy.Print()}");
                Console.WriteLine();
                i++;
            }
            isInt = false;
            int polizzaScelto;
            do
            {
                Console.WriteLine("Quale polizza vuoi rinnovare?");

                isInt = int.TryParse(Console.ReadLine(), out polizzaScelto);

            } while (!isInt || polizzaScelto <= 0 || polizzaScelto > customer.Policies.Count);

            Policy policyToUpdate = customer.Policies.ElementAt(polizzaScelto - 1);
            policyToUpdate.ExpirationDate = InsertExpDate();
            mainBL.UpdateCustomer(policyToUpdate);

        }

        private static void ViewCustomerPolicies()
        {
            List<Customer> customers = mainBL.FetchCustomers();
            int i = 1;
            Console.WriteLine("Seleziona il cliente per visualizzare le sue polizze: ");
            foreach (var c in customers)
            {
                Console.WriteLine($"{i} - {c.Print()}");
                i++;
            }
            Console.WriteLine();

            bool isInt;
            int clienteScelto;
            do
            {
                Console.WriteLine("Quale cliente vuoi visualizzare");

                isInt = int.TryParse(Console.ReadLine(), out clienteScelto);

            } while (!isInt || clienteScelto <= 0 || clienteScelto > customers.Count);
            Customer customer = customers.ElementAt(clienteScelto - 1);
            foreach(var policy in customer.Policies)
            {
                Console.WriteLine(policy.Print());
            }

        }

        private static void InsertPolicy()
        {
            List<Customer> customers = mainBL.FetchCustomers();
            int i = 1;
            Console.WriteLine("Seleziona il cliente a cui inserire una nuova polizza: ");
            foreach (var c in customers)
            {
                Console.WriteLine($"{i} - {c.Print()}");
                i++;
            }
            Console.WriteLine();

            bool isInt;
            int clienteScelto;
            do
            {
                Console.WriteLine("Quale cliente?");

                isInt = int.TryParse(Console.ReadLine(), out clienteScelto);

            } while (!isInt || clienteScelto <= 0 || clienteScelto > customers.Count);
                Customer customer = customers.ElementAt(clienteScelto - 1);

                Policy policy = new Policy();
                policy.PolicyNumber = InsertPolicyNumber();
                policy.ExpirationDate = InsertExpDate();
                policy.MonthlyInstallment = InsertMInstallment();
                policy.Type = InsertType();
                customer.Policies.Add(policy);
                mainBL.UpdateCustomer(customer);
                mainBL.InsertPolicy(policy);
                

            
        }

        private static _Type InsertType()
        {
            bool isInt = false;
            int tipo = 0;
            do
            {
                Console.WriteLine("Inserisci il tipo di assicurazione: ");
                foreach (var t in Enum.GetValues(typeof(_Type)))
                {
                    Console.WriteLine($"{(int)t} - {(_Type)t}");
                }

                isInt = int.TryParse(Console.ReadLine(), out tipo);
            } while (!isInt || tipo < 0 || tipo > 2);
            return (_Type)tipo;
        }

        private static decimal InsertMInstallment()
        {
            decimal mensile;
            bool isDecimal;
            do
            {
                Console.WriteLine("Rata mensile:");

                isDecimal = decimal.TryParse(Console.ReadLine(), out mensile);

            } while (!isDecimal);
            return mensile;
        }

        private static DateTime InsertExpDate()
        {
            DateTime dt = new DateTime();
            bool isDate;
            do
            {
                Console.WriteLine("Data di scadenza: yyyy-mm-dd");

                isDate = DateTime.TryParse(Console.ReadLine(), out dt);

            } while (!isDate || dt < DateTime.Today);
            return dt;
        }

        private static int InsertPolicyNumber()
        {
            int numpolizza;
            bool isInt;
            do
            {
                Console.WriteLine("Numero polizza:");

                isInt = int.TryParse(Console.ReadLine(), out numpolizza);

            } while (!isInt);
            return numpolizza;
        }

        private static void InsertCustomer()
        {
            string codicefiscale = InsertFiscalCode();
            Customer customer = new Customer();
            if (GetCustomerByFiscalCode(codicefiscale) == null)
            {
                customer.FiscalCode = codicefiscale;
                customer.FirstName = InsertFirstName();
                customer.LastName = InsertLastName();
                customer.Policies = new List<Policy>();
                mainBL.InsertCustomer(customer);
            }
            else 
            { 
                Console.WriteLine("Il cliente che stai cercando di inserire è già presente nel database."); 
            }
        }

        private static Customer GetCustomerByFiscalCode(string codicefiscale)
        {
            var customer = mainBL.GetByFiscalCode(codicefiscale);
            return customer;
        }

        private static string InsertLastName()
        {
            string cognome = String.Empty;
            do
            {
                Console.WriteLine("Cognome: ");
                cognome = Console.ReadLine();

            } while (String.IsNullOrEmpty(cognome));
            return cognome;
        }

        private static string InsertFirstName()
        {
            string nome = String.Empty;
            do
            {
                Console.WriteLine("Nome: ");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));
            return nome;
        }

        private static string InsertFiscalCode()
        {
            string cf = String.Empty;
            do
            {
                Console.WriteLine("Codice fiscale: ");
                cf = Console.ReadLine();

            } while (String.IsNullOrEmpty(cf) || cf.Length != 16);
            return cf;
        }
    }
}