using System;
using System.Data.Entity.ModelConfiguration;

namespace Chamaliun.Common.Entity
{
    public abstract class ChamaliunEntityAbstractConfig<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public ChamaliunEntityAbstractConfig()
        {
            ConfigTable();
            ConfigFields();
            ConfigPrimaryKey();
            ConfigForeignKey();
        }

        protected abstract void ConfigForeignKey();

        protected abstract void ConfigPrimaryKey();

        protected abstract void ConfigFields();

        protected abstract void ConfigTable();
    }
}
