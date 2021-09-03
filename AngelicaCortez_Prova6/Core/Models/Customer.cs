using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6.Core.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(16),MinLength(16)]
        public string FiscalCode { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }

        public List<Policy> Policies { get; set; } = new List<Policy>();

        public string Print()
        {
            return $"Codice Fiscale: {FiscalCode} \nNome: {FirstName} \nCognome: {LastName}\n";
        }
    }
}
