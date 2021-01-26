using System.Collections.Generic;
using ClickHouse.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickHouse.EntityFrameworkCore.Migrations.Internal
{
    public class ClickHouseMigrationsAnnotationProvider : MigrationsAnnotationProvider
    {
        public ClickHouseMigrationsAnnotationProvider(MigrationsAnnotationProviderDependencies dependencies)
            : base(dependencies)
        {
        }

        /*
        public override IEnumerable<IAnnotation> For(IEntityType entityType)
        {
            foreach (var annotation in entityType.GetAnnotations())
            {
                if (annotation.Name.StartsWith(ClickHouseAnnotationNames.Prefix))
                {
                    yield return annotation;
                }
            }
        }
        */
    }
}
