﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //seed data
            builder.HasData(
                new Book { Id = 1, Title = "Iron Man", Price = 75 },
                new Book { Id = 2, Title = "Feeling", Price = 325 },
                new Book { Id = 3, Title = "Manchester By The Sea", Price = 25 }
                );
        }
    }
}
