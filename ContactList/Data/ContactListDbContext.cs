using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data;
public partial class ContactListDbContext : DbContext
{
    public ContactListDbContext()
    {
    }

    public ContactListDbContext(DbContextOptions<ContactListDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categorys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Category
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Description = "Family" },
            new Category { CategoryId = 2, Description = "Friends" },
            new Category { CategoryId = 3, Description = "Work" }
        );

        // Seed data for Contact
        modelBuilder.Entity<Contact>().HasData(
            new Contact { ContactId = 1, FirstName = "John", LastName = "Doe", Phone = "+12342345544", Email = "john@example.com", CategoryId = 1,DateAdded=DateTime.Now },
            new Contact { ContactId = 2, FirstName = "Jane", LastName = "Smith", Phone = "+99999999999", Email = "jane@example.com", CategoryId = 2, DateAdded = DateTime.Now},
            new Contact { ContactId = 3, FirstName = "Jane3", LastName = "Smith", Phone = "+99999999999", Email = "jane3@example.com", CategoryId = 2, DateAdded = DateTime.Now},
            new Contact { ContactId = 4, FirstName = "Jane4", LastName = "Smith", Phone = "+99999999999", Email = "jane4@example.com", CategoryId = 2, DateAdded = DateTime.Now},
            new Contact { ContactId = 5, FirstName = "Jane5", LastName = "Smith", Phone = "+99999999999", Email = "jane5@example.com", CategoryId = 2, DateAdded = DateTime.Now},
            new Contact { ContactId = 6, FirstName = "Jane6", LastName = "Smith", Phone = "+99999999999", Email = "jane6@example.com", CategoryId = 2, DateAdded = DateTime.Now},
            new Contact { ContactId = 7, FirstName = "Jane7", LastName = "Smith", Phone = "+99999999999", Email = "jane7@example.com", CategoryId = 2, DateAdded = DateTime.Now},
            new Contact { ContactId = 8, FirstName = "Jane8", LastName = "Smith", Phone = "+99999999999", Email = "jane8@example.com", CategoryId = 2, DateAdded = DateTime.Now},
            new Contact { ContactId = 9, FirstName = "Jane9", LastName = "Smith", Phone = "+99999999999", Email = "jane9@example.com", CategoryId = 2, DateAdded = DateTime.Now}
        );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
