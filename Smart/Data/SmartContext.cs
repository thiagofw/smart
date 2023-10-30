using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Smart.Models;

namespace Smart.Data;

public partial class SmartContext : DbContext
{
    public SmartContext()
    {
    }

    public SmartContext(DbContextOptions<SmartContext> options)
        : base(options)
    {
    }
    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Contato> Contatos {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
