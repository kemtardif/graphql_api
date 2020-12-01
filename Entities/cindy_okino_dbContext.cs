using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class cindy_okino_dbContext : DbContext
    {
        public cindy_okino_dbContext()
        {
        }

        public cindy_okino_dbContext(DbContextOptions<cindy_okino_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }
        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingsDetail> BuildingsDetails { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Elevator> Elevators { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("server=codeboxx.cq6zrczewpu2.us-east-1.rds.amazonaws.com;port=3306;database=kemtardifMSQL;uid=codeboxx;password=Codeboxx1!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Address1)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Address2)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("address2")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Country)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("country")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Entite)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("entite")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullStreetAddress)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("full_street_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("postal_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeAddress)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("type_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ArInternalMetadatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("key")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("value")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId, "index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId, "index_batteries_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.CertOpe)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cert_ope")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateCommissioning)
                    .HasColumnType("date")
                    .HasColumnName("date_commissioning");

                entity.Property(e => e.DateLastInspection)
                    .HasColumnType("date")
                    .HasColumnName("date_last_inspection");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.Information)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("information")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeBuilding)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("type_building")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId, "index_buildings_on_address_id");

                entity.HasIndex(e => e.CustomerId, "index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("address_id");

                entity.Property(e => e.AdmContactMail)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("adm_contact_mail")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdmContactName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("adm_contact_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdmContactPhone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("adm_contact_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.TectContactEmail)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("tect_contact_email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TectContactName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("tect_contact_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TectContactPhone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("tect_contact_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<BuildingsDetail>(entity =>
            {
                entity.ToTable("buildings_details");

                entity.HasIndex(e => e.BuildingId, "index_buildings_details_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.InfoKey)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("info_key")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("value")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingsDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_2f1b3cc9c4");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId, "index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AmountFloorsServed)
                    .HasColumnType("int(11)")
                    .HasColumnName("amount_floors_served");

                entity.Property(e => e.BatteryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("battery_id");

                entity.Property(e => e.Information)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("information")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeBuilding)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("type_building")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId, "index_customers_on_address_id");

                entity.HasIndex(e => e.UserId, "index_customers_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("address_id");

                entity.Property(e => e.CompanyName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("company_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CpyContactEmail)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cpy_contact_email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CpyContactName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cpy_contact_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CpyContactPhone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cpy_contact_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CpyDescription)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cpy_description")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("date")
                    .HasColumnName("date_create");

                entity.Property(e => e.StaMail)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("sta_mail")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StaName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("sta_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StaPhone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("sta_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId, "index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CertOpe)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cert_ope")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ColumnId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("column_id");

                entity.Property(e => e.DateCommissioning)
                    .HasColumnType("date")
                    .HasColumnName("date_commissioning");

                entity.Property(e => e.DateLastInspection)
                    .HasColumnType("date")
                    .HasColumnName("date_last_inspection");

                entity.Property(e => e.Information)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("information")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Model)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("model")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SerialNumber)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("serial_number")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeBuilding)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("type_building")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId, "index_employees_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("first_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("last_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("title")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.HasIndex(e => e.CustomerId, "index_leads_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AttachedFile)
                    .HasColumnType("mediumblob")
                    .HasColumnName("attached_file");

                entity.Property(e => e.CompanyName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("company_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Department)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("department")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("full_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnType("text")
                    .HasColumnName("message")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NameAttachedFile)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name_attached_file")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("phone_number")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("project_description")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("project_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_da25e077a0");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AppsQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("apps_qty");

                entity.Property(e => e.BasementsQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("basements_qty");

                entity.Property(e => e.BuildingType)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("building_type")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BusinessQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("business_qty");

                entity.Property(e => e.CompanyName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("company_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.ElevatorNeeded)
                    .HasColumnType("int(11)")
                    .HasColumnName("elevator_needed");

                entity.Property(e => e.ElevatorsQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("elevators_qty");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FloorsQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("floors_qty");

                entity.Property(e => e.Game)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("game")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HoursActivity)
                    .HasColumnType("int(11)")
                    .HasColumnName("hours_activity");

                entity.Property(e => e.OccupantsFloorsQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("occupants_floors_qty");

                entity.Property(e => e.ParkingsQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("parkings_qty");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_price");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Name, "index_roles_on_name");

                entity.HasIndex(e => new { e.Name, e.ResourceType, e.ResourceId }, "index_roles_on_name_and_resource_type_and_resource_id");

                entity.HasIndex(e => new { e.ResourceType, e.ResourceId }, "index_roles_on_resource_type_and_resource_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResourceId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("resource_id");

                entity.Property(e => e.ResourceType)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("resource_type")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("version")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("email")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("encrypted_password")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("remember_created_at");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("reset_password_sent_at");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("reset_password_token")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("users_roles");

                entity.HasIndex(e => e.RoleId, "index_users_roles_on_role_id");

                entity.HasIndex(e => e.UserId, "index_users_roles_on_user_id");

                entity.HasIndex(e => new { e.UserId, e.RoleId }, "index_users_roles_on_user_id_and_role_id");

                entity.Property(e => e.RoleId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("role_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
