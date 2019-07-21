using Chamaliun.Common.Entity;
using Chamaliun.MedicalManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chamaliun.MedicalManagement.Infra.TypeConfiguration
{
    class BairroTypeConfiguration : ChamaliunEntityAbstractConfig<Bairro>
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

            Property(cfk => cfk.CidadeId)
                .IsRequired()
                .HasColumnName("CidadeId");
        }

        protected override void ConfigForeignKey()
        {
            HasRequired(fkobj => fkobj.Cidade)
                .WithMany()
                .HasForeignKey(fk => fk.CidadeId)
                .WillCascadeOnDelete(false);
        }

        protected override void ConfigPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigTable()
        {
            ToTable("TLB_Bairro");
        }
    }
}
