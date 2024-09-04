﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Context;

public class HospitalContext : DbContext
{
    public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
