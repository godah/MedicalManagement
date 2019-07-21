using Chamaliun.Common.Entity;
using Chamaliun.MedicalManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chamaliun.MedicalManagement.Infra.TypeConfiguration
{
    class UfTypeConfiguration : ChamaliunEntityAbstractConfig<Uf>
    {
        protected override void ConfigFields()
        {
            Property(pk => pk.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

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

        protected override void ConfigForeignKey()
        {
        }

        protected override void ConfigPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigTable()
        {
            ToTable("TLB_Uf");
        }
    }
}
