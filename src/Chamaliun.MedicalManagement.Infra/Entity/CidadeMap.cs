using Chamaliun.MedicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamaliun.MedicalManagement.Infra.Entity
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidade");

            //PK
            HasKey(pk => pk.Id);

            //properties
            Property(d => d.Descricao)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("Descricao");

            Property(u => u.UfId)
                .IsRequired()
                .HasColumnName("UfId");

            //Relacionamento one to many
            HasRequired(pu => pu.Uf)
                .WithMany()
                .HasForeignKey(fk => fk.UfId)
                .WillCascadeOnDelete(false);


        }
    }
}
