using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AplicationCore.Entities;

namespace Infrastructure.Data
{
    public class FYHomeContext : DbContext
    {
        public FYHomeContext(DbContextOptions<FYHomeContext> options) : base(options)
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<RecordFilter> RecordFilter { get; set; }
        public DbSet<ResidencialProperty> ResidencialProperty { get; set; }
        public DbSet<TypeResidencialProperty> TypeResidencialProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>(ConfigureAddress);
            builder.Entity<Favorite>(ConfigureFavorite);
            builder.Entity<Person>(ConfigurePerson);
            builder.Entity<Photo>(ConfigurePhoto);
            builder.Entity<RecordFilter>(ConfigureRecordFilter);
            builder.Entity<ResidencialProperty>(ConfigureResidencialProperty);
            builder.Entity<TypeResidencialProperty>(ConfigureTypeResidencialProperty);

        }

        private void ConfigureAddress(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.Property(p => p.AddressId)
                .ForSqlServerUseSequenceHiLo("AddressId")
                .IsRequired();
        }
        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");

            builder.Property(p => p.FavoriteId)
                .ForSqlServerUseSequenceHiLo("FavoriteId")
                .IsRequired();
        }
        private void ConfigurePerson(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.Property(p => p.PersonId)
                .ForSqlServerUseSequenceHiLo("PersonId")
                .IsRequired();
        }
        private void ConfigurePhoto(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photo");

            builder.Property(p => p.PhotoId)
                .ForSqlServerUseSequenceHiLo("PhotoId")
                .IsRequired();
        }
        private void ConfigureRecordFilter(EntityTypeBuilder<RecordFilter> builder)
        {
            builder.ToTable("RecordFilter");

            builder.Property(p => p.RecordFilterId)
                .ForSqlServerUseSequenceHiLo("RecordFilterId")
                .IsRequired();
        }
        private void ConfigureResidencialProperty(EntityTypeBuilder<ResidencialProperty> builder)
        {
            builder.ToTable("ResidencialProperty");

            builder.Property(p => p.ResidencialPropertyId)
                .ForSqlServerUseSequenceHiLo("ResidencialPropertyId")
                .IsRequired();
        }
        private void ConfigureTypeResidencialProperty(EntityTypeBuilder<TypeResidencialProperty> builder)
        {
            builder.ToTable("TypeResidencialProperty");

            builder.Property(p => p.TypeResidencialPropertyId)
                .ForSqlServerUseSequenceHiLo("TypeResidencialPropertyId")
                .IsRequired();
        }

    }
}
