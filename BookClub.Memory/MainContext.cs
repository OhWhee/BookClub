using BookClub.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace BookClub.Memory
{
    public class MainContext : DbContext
{
        public MainContext(DbContextOptions<MainContext> opt) : base(opt)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookUsers> BookUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

           // builder.Entity<User>().Property(e => e.UserId);

            builder.Entity<BookUsers>()
                   .HasKey(bu => new { bu.BookId, bu.UserId });
            
            builder.Entity<BookUsers>()
                    .HasOne(bu => bu.Book)
                    .WithMany(b => b.BookUsers)
                    .HasForeignKey(bu => bu.BookId);
            
            builder.Entity<BookUsers>()
                    .HasOne(bu => bu.User)
                    .WithMany(u => u.BookUsers)
                    .HasForeignKey(bu => bu.UserId);

        }
        internal async Task<T> AddAndSaveAsync<T>(T obj, CancellationToken cancellationToken = default) where T : class
        {
            await Set<T>().AddAsync(obj, cancellationToken);
            await SaveChangesAsync(cancellationToken);
            return obj;
        }

        internal async Task<T> UpdateEntityAsync<T>(T entity, CancellationToken cancellationToken = default)
            where T : new()
        {
            try
            {
                Update(entity);
                await SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                return default;
            }
        }
    }
}