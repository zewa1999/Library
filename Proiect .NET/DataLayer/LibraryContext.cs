// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/// <summary>
/// The DataMapper namespace.
/// </summary>
namespace Library.DataLayer.DataMapper
{
    using Library.DomainLayer;
    using Library.DomainLayer.Person;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The library context class used to generate the database.
    /// </summary>
    public class LibraryContext : DbContext
    {
        /// <summary>
        /// Gets or sets or set the Librarians table.
        /// </summary>
        /// <value>The librarians.</value>
        public DbSet<Librarian> Librarians { get; set; }

        /// <summary>
        /// Gets or sets or set the Accounts table.
        /// </summary>
        /// <value>The accounts.</value>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Gets or sets or set the Borrowers table.
        /// </summary>
        /// <value>The borrowers.</value>
        public DbSet<Borrower> Borrowers { get; set; }

        /// <summary>
        /// Gets or sets or set the Authors table.
        /// </summary>
        /// <value>The authors.</value>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets or set the Books table.
        /// </summary>
        /// <value>The books.</value>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets or set the Borrow table.
        /// </summary>
        /// <value>The borrow.</value>
        public DbSet<Borrow> Borrow { get; set; }

        /// <summary>
        /// Gets or sets or set the Domains table.
        /// </summary>
        /// <value>The domains.</value>
        public DbSet<Domain> Domains { get; set; }

        /// <summary>
        /// Gets or sets or set the Editions table.
        /// </summary>
        /// <value>The editions.</value>
        public DbSet<Edition> Editions { get; set; }

        /// <summary>
        /// Gets or sets or set the Properties table.
        /// </summary>
        /// <value>The properties.</value>
        public DbSet<Properties> Properties { get; set; }

        /// <summary>
        /// Method used to configure the options for the context of the database.
        /// </summary>
        /// <param name="optionsBuilder">The optionsBuilder used to configure properties of the server.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=LibraryDatabase");
        }
    }
}