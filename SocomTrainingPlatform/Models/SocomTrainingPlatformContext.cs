using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SocomTrainingPlatform.Models
{
    public partial class SocomTrainingPlatformContext : DbContext
    {
        public SocomTrainingPlatformContext()
        {
        }

        public SocomTrainingPlatformContext(DbContextOptions<SocomTrainingPlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<BerthingImage> BerthingImages { get; set; }
        public virtual DbSet<BerthingWork> BerthingWorks { get; set; }
        public virtual DbSet<Excercise> Excercises { get; set; }
        public virtual DbSet<ExcerciseBrief> ExcerciseBriefs { get; set; }
        public virtual DbSet<ExcerciseLocation> ExcerciseLocations { get; set; }
        public virtual DbSet<ExcerciseNote> ExcerciseNotes { get; set; }
        public virtual DbSet<ExcerciseType> ExcerciseTypes { get; set; }
        public virtual DbSet<InsertImage> InsertImages { get; set; }
        public virtual DbSet<InsertPoint> InsertPoints { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationFile> LocationFiles { get; set; }
        public virtual DbSet<LocationNote> LocationNotes { get; set; }
        public virtual DbSet<LocationUsageDate> LocationUsageDates { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<MeetingImage> MeetingImages { get; set; }
        public virtual DbSet<Mou> Mous { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<PocLocation> PocLocations { get; set; }
        public virtual DbSet<PocOrganization> PocOrganizations { get; set; }
        public virtual DbSet<PointOfContact> PointOfContacts { get; set; }
        public virtual DbSet<SubOrganization> SubOrganizations { get; set; }
        public virtual DbSet<Support> Supports { get; set; }
        public virtual DbSet<SupportDocument> SupportDocuments { get; set; }
        public virtual DbSet<SupportImage> SupportImages { get; set; }
        public virtual DbSet<Target> Targets { get; set; }
        public virtual DbSet<TargetImage> TargetImages { get; set; }
        public virtual DbSet<TrainingArea> TrainingAreas { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=RCR-LR0DJVRF\\SQLEXPRESS;Initial Catalog=SocomTrainingPlatform;Integrated Security=True;Trusted_Connection=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BerthingImage>(entity =>
            {
                entity.ToTable("BerthingImage");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ImageFile).IsRequired();

                entity.HasOne(d => d.BerthingWork)
                    .WithMany(p => p.BerthingImages)
                    .HasForeignKey(d => d.BerthingWorkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BerthingImage_BerthingWork");
            });

            modelBuilder.Entity<BerthingWork>(entity =>
            {
                entity.ToTable("BerthingWork");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Grid).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.BerthingWorks)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BerthingWork_Location");
            });

            modelBuilder.Entity<Excercise>(entity =>
            {
                entity.ToTable("Excercise");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ExcerciseType)
                    .WithMany(p => p.Excercises)
                    .HasForeignKey(d => d.ExcerciseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Excercise_ExcerciseType");
            });

            modelBuilder.Entity<ExcerciseBrief>(entity =>
            {
                entity.ToTable("ExcerciseBrief");

                entity.Property(e => e.DateStamp).HasColumnType("date");

                entity.Property(e => e.FileData).IsRequired();

                entity.Property(e => e.FileTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Excercise)
                    .WithMany(p => p.ExcerciseBriefs)
                    .HasForeignKey(d => d.ExcerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExcerciseBrief_Excercise");
            });

            modelBuilder.Entity<ExcerciseLocation>(entity =>
            {
                entity.HasKey(l => new { l.ExcerciseId, l.LocationId });

                entity.ToTable("ExcerciseLocation");

                entity.HasOne(d => d.Excercise)
                    .WithMany()
                    .HasForeignKey(d => d.ExcerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExcerciseLocation_Excercise");

                entity.HasOne(d => d.Location)
                    .WithMany()
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExcerciseLocation_Location");
            });

            modelBuilder.Entity<ExcerciseNote>(entity =>
            {
                entity.ToTable("ExcerciseNote");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DateStamp).HasColumnType("date");

                entity.Property(e => e.Subject).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.CustomUser)
                    .WithMany(p => p.ExcerciseNotes)
                    .HasForeignKey(d => d.CustomUserId)
                    .HasConstraintName("FK_ExcerciseNote_User");

                entity.HasOne(d => d.Excercise)
                    .WithMany(p => p.ExcerciseNotes)
                    .HasForeignKey(d => d.ExcerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExcerciseNote_Excercise");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExcerciseNotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ExcerciseNote_AspNetUsers");
            });

            modelBuilder.Entity<ExcerciseType>(entity =>
            {
                entity.ToTable("ExcerciseType");

                entity.Property(e => e.ExcerciseDescription).HasMaxLength(250);

                entity.Property(e => e.ExcerciseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.ExcerciseTypes)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK_ExcerciseType_Organization");
            });

            modelBuilder.Entity<InsertImage>(entity =>
            {
                entity.ToTable("InsertImage");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).IsRequired();

                entity.HasOne(d => d.InsertPoint)
                    .WithMany(p => p.InsertImages)
                    .HasForeignKey(d => d.InsertPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InsertImage_InsertPoint");
            });

            modelBuilder.Entity<InsertPoint>(entity =>
            {
                entity.ToTable("InsertPoint");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Grid).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.InsertPoints)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InsertPoint_Location");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Mou)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.MouId)
                    .HasConstraintName("FK_Location_Mou");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK_Location_Organization");

                entity.HasOne(d => d.TrainingArea)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.TrainingAreaId)
                    .HasConstraintName("FK_Location_TrainingArea");
            });

            modelBuilder.Entity<LocationFile>(entity =>
            {
                entity.ToTable("LocationFile");

                entity.Property(e => e.FileData).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationFiles)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationFile_Location");
            });

            modelBuilder.Entity<LocationNote>(entity =>
            {
                entity.ToTable("LocationNote");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Subject).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.CustomUser)
                    .WithMany(p => p.LocationNotes)
                    .HasForeignKey(d => d.CustomUserId)
                    .HasConstraintName("FK_LocationNote_User");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationNotes)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationNote_Location");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LocationNotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_LocationNote_AspNetUsers");
            });

            modelBuilder.Entity<LocationTypes>(entity =>
            {
                entity.ToTable("LocationTypes");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationTypess)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InsertPoint_Location");
            });

            modelBuilder.Entity<LocationUsageDate>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationUsageDates)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationUsageDates_Location");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.ToTable("Meeting");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Grid).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meeting_Location");
            });

            modelBuilder.Entity<MeetingImage>(entity =>
            {
                entity.ToTable("MeetingImage");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ImageFile).IsRequired();

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.MeetingImages)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingImage_Meeting");
            });

            modelBuilder.Entity<Mou>(entity =>
            {
                entity.ToTable("Mou");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.FileType).HasMaxLength(10);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.lastName)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PocLocation>(entity =>
            {
                entity.HasKey(l => new { l.LocationId, l.PocId });

                entity.ToTable("PocLocation");

                entity.HasOne(d => d.Location)
                    .WithMany()
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PocLocation_Location");

                entity.HasOne(d => d.Poc)
                    .WithMany()
                    .HasForeignKey(d => d.PocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PocLocation_PointOfContact");
            });

            modelBuilder.Entity<PocOrganization>(entity =>
            {
                entity.ToTable("PocOrganization");

                entity.Property(e => e.OrgName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PointOfContact>(entity =>
            {
                entity.ToTable("PointOfContact");

                entity.Property(e => e.EmailAddress).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.HasOne(d => d.Mou)
                    .WithMany(p => p.PointOfContacts)
                    .HasForeignKey(d => d.MouId)
                    .HasConstraintName("FK_PointOfContact_Mou");

                entity.HasOne(d => d.PocOrg)
                    .WithMany(p => p.PointOfContacts)
                    .HasForeignKey(d => d.PocOrgId)
                    .HasConstraintName("FK_PointOfContact_PocOrganization");
            });

            modelBuilder.Entity<SubOrganization>(entity =>
            {
                entity.ToTable("SubOrganization");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.SubOrganizations)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubOrganization_Organization");
            });

            modelBuilder.Entity<Support>(entity =>
            {
                entity.ToTable("Support");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Grid).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Supports)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Support_Location");
            });

            modelBuilder.Entity<SupportDocument>(entity =>
            {
                entity.ToTable("SupportDocument");

                entity.Property(e => e.DateStamp).HasColumnType("date");

                entity.Property(e => e.FileData).IsRequired();

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Excercise)
                    .WithMany(p => p.SupportDocuments)
                    .HasForeignKey(d => d.ExcerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupportDocument_Excercise");
            });

            modelBuilder.Entity<SupportImage>(entity =>
            {
                entity.ToTable("SupportImage");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).IsRequired();

                entity.HasOne(d => d.Support)
                    .WithMany(p => p.SupportImages)
                    .HasForeignKey(d => d.SupportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupportImage_Support");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.ToTable("Target");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Grid).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Targets)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Target_Location");
            });

            modelBuilder.Entity<TargetImage>(entity =>
            {
                entity.ToTable("TargetImage");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ImageFile).IsRequired();

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.TargetImages)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TargetImage_Target");
            });

            modelBuilder.Entity<TrainingArea>(entity =>
            {
                entity.ToTable("TrainingArea");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rank).HasMaxLength(100);

                entity.Property(e => e.Unit).HasMaxLength(100);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK_User_Organization");

                entity.HasOne(d => d.SubOrg)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SubOrgId)
                    .HasConstraintName("FK_User_SubOrganization");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
