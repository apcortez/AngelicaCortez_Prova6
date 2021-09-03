using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6.Core.Models
{
    public class Policy
    {
        //[Key]
        public int Id { get; set; }
        //[Required]
        public int PolicyNumber { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ExpirationDate { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public _Type Type { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


        public string Print()
        {
            return $"Polizza N.{PolicyNumber} \nScadenza:{ExpirationDate.ToString("dd/MM/yyyy")} \nRate mensili da: {MonthlyInstallment} Euro \nTipo: {Type}\n";
        }
    }

    public enum _Type
    {
        RC_Auto,
        Furto,
        Vita
    }
}
