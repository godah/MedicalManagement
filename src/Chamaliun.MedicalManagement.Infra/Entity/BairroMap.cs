using Chamaliun.MedicalManagement.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Chamaliun.MedicalManagement.Infra.Entity
{
    public class BairroMap:EntityTypeConfiguration<Bairro>
    {
        public BairroMap()
        {
            ToTable("Bairro");
            //PK
            HasKey(pk => pk.Id);

            //properties
            Property(d => d.Descricao)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("Descricao");

            Property(cfk => cfk.CidadeId)
                .IsRequired()
                .HasColumnName("CidadeId");

            //Relacionamento
            HasRequired(fkobj => fkobj.Cidade)
                .WithMany()
                .HasForeignKey(fk => fk.CidadeId)
                .WillCascadeOnDelete(false);
        }
    }
}
