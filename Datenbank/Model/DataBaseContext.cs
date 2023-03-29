﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank.Model;

public class DataBaseContext : DbContext
{
    public DbSet<Kunde> Kunde { get; set; }

    public DbSet<Ansprechpartner> Ansprechpartner { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=test;user=user;password=password");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Kunde>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Betrieb).IsRequired();
            entity.Property(e => e.Straße).IsRequired();
            entity.Property(e => e.Ort).IsRequired();
            entity.Property(e => e.PLZ).IsRequired();
        });
            

        modelBuilder.Entity<Ansprechpartner>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Vorname).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.EMail).IsRequired();
            entity.Property(e => e.Telefon).IsRequired();
            entity.HasOne(e => e.Kunde)
            .WithOne(i => i.Ansprechpartner)
            .HasForeignKey<Kunde>(b => b.AnsprechId);
        });
    }
}