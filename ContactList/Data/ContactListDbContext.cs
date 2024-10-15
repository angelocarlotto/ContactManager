using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data;

public class Contact
{
    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime DateAdded { get; set; }
    [ValidateNever]
    public Category Category { get; set; }
    public int CategoryId { get; set; }

    //public string Slug => GenerateSlug($"{FirstName} {LastName}");

    //// Helper method to generate a slug
    //private string GenerateSlug(string name)
    //{
    //    return name.ToLower()
    //               .Replace(" ", "-")
    //               .Replace(".", "")
    //               .Replace(",", "")
    //               .Replace("'", "")
    //               .Replace("?", "")
    //               .Replace("!", "");
    //}

}

public class Category
{
    public int CategoryId { get; set; }
    public string Description { get; set; }
}
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
            new Contact { ContactId = 2, FirstName = "Jane", LastName = "Smith", Phone = "+99999999999", Email = "jane@example.com", CategoryId = 2, DateAdded = DateTime.Now}
        );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
