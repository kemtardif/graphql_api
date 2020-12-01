using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class cindy_okino_warehouseContext : DbContext
    {
        public cindy_okino_warehouseContext()
        {
        }

        public cindy_okino_warehouseContext(DbContextOptions<cindy_okino_warehouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }
        public virtual DbSet<DimCustomer> DimCustomers { get; set; }
        public virtual DbSet<FactContact> FactContacts { get; set; }
        public virtual DbSet<FactElevator> FactElevators { get; set; }
        public virtual DbSet<FactIntervention> FactInterventions { get; set; }
        public virtual DbSet<FactQuote> FactQuotes { get; set; }
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=codeboxx-postgresql.cq6zrczewpu2.us-east-1.rds.amazonaws.com;Database=kemtardifPSQL;Username=codeboxx;Password=Codeboxx1!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArInternalMetadatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("ar_internal_metadata_pkey");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnType("character varying")
                    .HasColumnName("key");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasColumnType("character varying")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<DimCustomer>(entity =>
            {
                entity.ToTable("dim_customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountElevator).HasColumnName("amount_elevator");

                entity.Property(e => e.CompanyName)
                    .HasColumnType("character varying")
                    .HasColumnName("company_name");

                entity.Property(e => e.CpyContactEmail)
                    .HasColumnType("character varying")
                    .HasColumnName("cpy_contact_email");

                entity.Property(e => e.CpyContactName)
                    .HasColumnType("character varying")
                    .HasColumnName("cpy_contact_name");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("creation_date");

                entity.Property(e => e.CustomerCity)
                    .HasColumnType("character varying")
                    .HasColumnName("customer_city");
            });

            modelBuilder.Entity<FactContact>(entity =>
            {
                entity.ToTable("fact_contacts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyName)
                    .HasColumnType("character varying")
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.ProjectName)
                    .HasColumnType("character varying")
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<FactElevator>(entity =>
            {
                entity.ToTable("fact_elevators");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingCity)
                    .HasColumnType("character varying")
                    .HasColumnName("building_city");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("character varying")
                    .HasColumnName("building_id");

                

                entity.Property(e => e.CommissioningDate)
                    .HasColumnType("date")
                    .HasColumnName("commissioning_date");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("character varying")
                    .HasColumnName("customer_id");

                entity.Property(e => e.SerialNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("serial_number");
            });

            modelBuilder.Entity<FactIntervention>(entity =>
            {
                entity.ToTable("fact_intervention");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatteryId).HasColumnName("battery_id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.ElevatorId).HasColumnName("elevator_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EndDateIntervention).HasColumnName("end_date_intervention");

                entity.Property(e => e.Report).HasColumnName("report");

                entity.Property(e => e.Result)
                    .HasColumnType("character varying")
                    .HasColumnName("result");

                entity.Property(e => e.StartDateIntervention).HasColumnName("start_date_intervention");

                entity.Property(e => e.Status)
                    .HasColumnType("character varying")
                    .HasColumnName("status");

            });

            modelBuilder.Entity<FactQuote>(entity =>
            {
                entity.ToTable("fact_quotes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountElevator).HasColumnName("amount_elevator");

                entity.Property(e => e.CompanyName)
                    .HasColumnType("character varying")
                    .HasColumnName("company_name");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("schema_migrations_pkey");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnType("character varying")
                    .HasColumnName("version");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
