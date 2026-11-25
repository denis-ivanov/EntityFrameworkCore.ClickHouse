using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Numerics;
using System.Threading;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

internal sealed class ClickHouseQueryTestValueGeneratorSelector(ValueGeneratorSelectorDependencies dependencies)
    : RelationalValueGeneratorSelector(dependencies)
{
    protected override ValueGenerator? FindForType(IProperty property, ITypeBase typeBase, Type clrType)
    {
        if (property.IsPrimaryKey()
            && property.ValueGenerated == ValueGenerated.OnAdd
            && !typeBase.IsMappedToJson()
            && property.GetDefaultValueSql() == null
            && !property.TryGetDefaultValue(out _))
        {
            if (clrType == typeof(int))
            {
                return new QueryKeyGenerator<int>();
            }

            if (clrType == typeof(long))
            {
                return new QueryKeyGenerator<long>();
            }
        }

        return base.FindForType(property, typeBase, clrType);
    }

    private sealed class QueryKeyGenerator<TKey> : ValueGenerator<TKey>
        where TKey : INumberBase<TKey>
    {
        private long _key;

        public override bool GeneratesTemporaryValues => false;

        public override TKey Next(EntityEntry entry)
            => TKey.CreateChecked(Interlocked.Increment(ref _key));
    }
}
