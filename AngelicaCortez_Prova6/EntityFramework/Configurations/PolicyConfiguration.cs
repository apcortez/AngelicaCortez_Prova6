using AngelicaCortez_Prova6.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelicaCortez_Prova6.EntityFramework.Configurations
{
    class PolicyConfiguration: IEntityTypeConfiguration<Policy>
        {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policies");
            builder.HasKey(p => p.Id); //chiave primaria
            builder.Property(p => p.PolicyNumber)
            .IsRequired();
            builder.Property(p => p.ExpirationDate);
            builder.Property(p => p.MonthlyInstallment);
            builder.Property(p => p.Type);
            
        }
    }
    
}
