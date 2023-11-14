﻿using ClickHouse.EntityFrameworkCore.Diagnostics.Internal;
using ClickHouse.EntityFrameworkCore.Infrastructure.Internal;
using ClickHouse.EntityFrameworkCore.Internal;
using ClickHouse.EntityFrameworkCore.Metadata.Conventions;
using ClickHouse.EntityFrameworkCore.Metadata.Internal;
using ClickHouse.EntityFrameworkCore.Migrations;
using ClickHouse.EntityFrameworkCore.Migrations.Internal;
using ClickHouse.EntityFrameworkCore.Query.Internal;
using ClickHouse.EntityFrameworkCore.Storage.Internal;
using ClickHouse.EntityFrameworkCore.Storage.ValueConversation;
using ClickHouse.EntityFrameworkCore.Update.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static class ClickHouseServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkClickHouse([NotNull] this IServiceCollection serviceCollection)
    {
        var builder = new EntityFrameworkRelationalServicesBuilder(serviceCollection)
            .TryAdd<LoggingDefinitions, ClickHouseLoggingDefinitions>()
            .TryAdd<IDatabaseProvider, DatabaseProvider<ClickHouseOptionsExtension>>()
            .TryAdd<IRelationalTypeMappingSource, ClickHouseTypeMappingSource>()
            .TryAdd<ISqlGenerationHelper, ClickHouseSqlGenerationHelper>()
            .TryAdd<IRelationalAnnotationProvider, ClickHouseAnnotationProvider>()
            .TryAdd<IMigrationsAnnotationProvider, ClickHouseMigrationsAnnotationProvider>()
            .TryAdd<IModelValidator, ClickHouseModelValidator>()
            .TryAdd<IProviderConventionSetBuilder, ClickHouseConventionSetBuilder>()
            .TryAdd<IUpdateSqlGenerator, ClickHouseUpdateSqlGenerator>()
            .TryAdd<IModificationCommandBatchFactory, ClickHouseModificationCommandBatchFactory>()
            .TryAdd<IRelationalConnection>(p => p.GetService<IClickHouseRelationalConnection>())
            .TryAdd<IMigrationsSqlGenerator, ClickHouseMigrationsSqlGenerator>()
            .TryAdd<IRelationalDatabaseCreator, ClickHouseDatabaseCreator>()
            .TryAdd<IHistoryRepository, ClickHouseHistoryRepository>()
            .TryAdd<IQueryCompiler, ClickHouseQueryCompiler>()
            //.TryAdd<IRelationalQueryStringFactory, ClickHouseQueryStringFactory>()

            // New Query Pipeline
            .TryAdd<IMethodCallTranslatorProvider, ClickHouseMethodCallTranslatorProvider>()
            .TryAdd<IMemberTranslatorProvider, ClickHouseMemberTranslatorProvider>()
            .TryAdd<IQuerySqlGeneratorFactory, ClickHouseQuerySqlGeneratorFactory>()
            .TryAdd<IQueryableMethodTranslatingExpressionVisitorFactory, ClickHouseQueryableMethodTranslatingExpressionVisitorFactory>()
            .TryAdd<IRelationalSqlTranslatingExpressionVisitorFactory, ClickHouseSqlTranslatingExpressionVisitorFactory>()
            .TryAdd<IValueConverterSelector, ClickHouseValueConverterSelector>()
            .TryAddProviderSpecificServices(
                b => b.TryAddScoped<IClickHouseRelationalConnection, ClickHouseRelationalConnection>());

        builder.TryAddCoreServices();

        return serviceCollection;
    }
}
