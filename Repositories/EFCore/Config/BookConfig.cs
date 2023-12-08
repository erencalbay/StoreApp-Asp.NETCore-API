using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
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
