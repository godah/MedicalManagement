using Chamaliun.MedicalManagement.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Chamaliun.MedicalManagement.Infra.Entity
{
    public class UfMap : EntityTypeConfiguration<Uf>
    {
        public UfMap()
        {
            ToTable("Uf");
            //PrimareKey
            HasKey(pk => pk.Id);

            //Properties
            Property(s => s.Sigla)
                .IsRequired()
                .HasMaxLength(2).IsFixedLength()
                .HasColumnName("Sigla");

            Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Estado");

            Property(ce => ce.CodigoEstado)
                .IsRequired()
                .HasColumnName("CodigoEstado");
        }
    }
}
