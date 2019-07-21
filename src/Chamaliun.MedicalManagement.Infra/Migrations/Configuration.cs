using Chamaliun.MedicalManagement.Infra.Data.ORM.EF;
using System;
using System.Data.Entity.Migrations;

namespace Chamaliun.MedicalManagement.Infra.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<MMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MMDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            //iniciar nosso banco de produção
        }
    }
}
