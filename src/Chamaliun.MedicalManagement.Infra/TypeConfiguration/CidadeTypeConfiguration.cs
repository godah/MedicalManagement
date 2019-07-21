using Chamaliun.Common.Entity;
using Chamaliun.MedicalManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chamaliun.MedicalManagement.Infra.TypeConfiguration
{
    class CidadeTypeConfiguration : ChamaliunEntityAbstractConfig<Cidade>
    {
        protected override void ConfigFields()
        {
            Property(pk => pk.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Descricao)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("Descricao");

            Property(u => u.UfId)
                .IsRequired()
                .HasColumnName("UfId");
        }

        protected override void ConfigForeignKey()
        {
            HasRequired(pu => pu.Uf)
                .WithMany()
                .HasForeignKey(fk => fk.UfId)
                .WillCascadeOnDelete(false);
        }

        protected override void ConfigPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigTable()
        {
            ToTable("TLB_Cidade");
        }
    }
}
