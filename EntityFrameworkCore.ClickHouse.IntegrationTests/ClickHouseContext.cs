﻿using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq.Expressions;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests
{
    public class SimpleEntity
    {
        public int Id { get; set; }
            
        public string Text { get; set; }
    }

    public class ClickHouseContext : DbContext
    {
        public DbSet<SimpleEntity> SimpleEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SimpleEntity>().HasKey(e => e.Id);

            modelBuilder.Entity<SimpleEntity>()
                .HasMergeTreeEngine(new Expression<Func<SimpleEntity, object>>[]
                {
                    e => e.Id
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(TestContext.WriteLine);
            optionsBuilder.UseClickHouse("Host=localhost;Protocol=http;Port=8123;Database=" + TestContext.CurrentContext.Test.ClassName);
        }
    }
}