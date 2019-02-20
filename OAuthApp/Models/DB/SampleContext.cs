using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OAuthApp.Models.DB
{
    public partial class SampleContext : DbContext
    {
        public SampleContext()
        {
        }

        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleFeaturesMap> RoleFeaturesMap { get; set; }
        public virtual DbSet<UserLogIn> UserLogIn { get; set; }
        public virtual DbSet<UserQuestions> UserQuestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=A0107D;Database=Sample;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Features>(entity =>
            {
                entity.HasKey(e => e.FeatureId);

                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModificationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SubFeatureId).HasColumnName("SubFeatureID");

                entity.Property(e => e.UrlLink)
                    .HasColumnName("URL_Link")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.SubFeature)
                    .WithMany(p => p.InverseSubFeature)
                    .HasForeignKey(d => d.SubFeatureId)
                    .HasConstraintName("FK_Features_SubFeatureID");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModificationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModificationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleFeaturesMap>(entity =>
            {
                entity.Property(e => e.RoleFeaturesMapId).HasColumnName("RoleFeaturesMapID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModificationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleFeaturesMap)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleFeaturesMap_FEATURESID");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.RoleFeaturesMap)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleFeaturesMap_RoleID");
            });

            modelBuilder.Entity<UserLogIn>(entity =>
            {
                entity.Property(e => e.UserLogInId).HasColumnName("UserLogInID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModificationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogIn)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserLogIn_RoleID");
            });

            modelBuilder.Entity<UserQuestions>(entity =>
            {
                entity.HasKey(e => e.UserQuestionId);

                entity.Property(e => e.UserQuestionId).HasColumnName("UserQuestionID");

                entity.Property(e => e.Answer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModificationUser)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.UserLogInId).HasColumnName("UserLogInID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_UserQuestions_QuestionID");

                entity.HasOne(d => d.UserLogIn)
                    .WithMany(p => p.UserQuestions)
                    .HasForeignKey(d => d.UserLogInId)
                    .HasConstraintName("FK_UserQuestions_UserLogInID");
            });
        }
    }
}
