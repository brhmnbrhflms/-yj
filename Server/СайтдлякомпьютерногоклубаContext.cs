using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Компьютерный клуб сайт.Server
{
    public partial class СайтдлякомпьютерногоклубаContext : DbContext
    {
        public СайтдлякомпьютерногоклубаContext()
        {
        }

        public СайтдлякомпьютерногоклубаContext(DbContextOptions<СайтдлякомпьютерногоклубаContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Аренда> Арендаs { get; set; }
        public virtual DbSet<ДополнительныеУслуги> ДополнительныеУслугиs { get; set; }
        public virtual DbSet<Оплата> Оплатаs { get; set; }
        public virtual DbSet<Покупатель> Покупательs { get; set; }
        public virtual DbSet<РасположениеКлуба> РасположениеКлубаs { get; set; }
        public virtual DbSet<Услуга> Услугаs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Lab116-p;Database=Сайт для компьютерного клуба;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Аренда>(entity =>
            {
                entity.HasKey(e => e.ArendaId);

                entity.ToTable("Аренда");

                entity.Property(e => e.ArendaId)
                    .ValueGeneratedNever()
                    .HasColumnName("arenda_id");

                entity.Property(e => e.UslugaId).HasColumnName("usluga_id");

                entity.Property(e => e.ВремяАренды).HasColumnName("Время аренды");

                entity.Property(e => e.ВремяИДатаАренды).HasColumnName("Время и дата аренды");

                entity.Property(e => e.НомерКомпьютера).HasColumnName("Номер компьютера");

                entity.HasOne(d => d.Usluga)
                    .WithMany(p => p.Арендаs)
                    .HasForeignKey(d => d.UslugaId)
                    .HasConstraintName("FK_Аренда_Услуга");
            });

            modelBuilder.Entity<ДополнительныеУслуги>(entity =>
            {
                entity.HasKey(e => e.ExtraId);

                entity.ToTable("Дополнительные услуги");

                entity.Property(e => e.ExtraId)
                    .ValueGeneratedNever()
                    .HasColumnName("extra_id");

                entity.Property(e => e.UslugaId).HasColumnName("usluga_id");

                entity.Property(e => e.ВыделятьОтдельнуюКомнату)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Выделять отдельную комнату?")
                    .IsFixedLength(true);

                entity.Property(e => e.СколькоМониторовНужно).HasColumnName("Сколько мониторов нужно?");

                entity.HasOne(d => d.Usluga)
                    .WithMany(p => p.ДополнительныеУслугиs)
                    .HasForeignKey(d => d.UslugaId)
                    .HasConstraintName("FK_Дополнительные услуги_Услуга");
            });

            modelBuilder.Entity<Оплата>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Оплата");

                entity.Property(e => e.ClubId).HasColumnName("club_id");

                entity.Property(e => e.ExtraId).HasColumnName("extra_id");

                entity.Property(e => e.НомерКарты).HasColumnName("Номер карты");

                entity.Property(e => e.НомерТелефона).HasColumnName("Номер телефона");

                entity.HasOne(d => d.Club)
                    .WithMany()
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_Оплата_Расположение клуба");

                entity.HasOne(d => d.Extra)
                    .WithMany()
                    .HasForeignKey(d => d.ExtraId)
                    .HasConstraintName("FK_Оплата_Дополнительные услуги");
            });

            modelBuilder.Entity<Покупатель>(entity =>
            {
                entity.ToTable("Покупатель");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ДеньРожденияСегодня)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("День рождения сегодня?")
                    .IsFixedLength(true);

                entity.Property(e => e.Имя)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Фамилия)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<РасположениеКлуба>(entity =>
            {
                entity.HasKey(e => e.ClubId);

                entity.ToTable("Расположение клуба");

                entity.Property(e => e.ClubId)
                    .ValueGeneratedNever()
                    .HasColumnName("club_id");

                entity.Property(e => e.ArendaId).HasColumnName("arenda_id");

                entity.Property(e => e.Адрес)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Arenda)
                    .WithMany(p => p.РасположениеКлубаs)
                    .HasForeignKey(d => d.ArendaId)
                    .HasConstraintName("FK_Расположение клуба_Аренда");
            });

            modelBuilder.Entity<Услуга>(entity =>
            {
                entity.HasKey(e => e.UslugaId);

                entity.ToTable("Услуга");

                entity.Property(e => e.UslugaId)
                    .ValueGeneratedNever()
                    .HasColumnName("usluga_id");

                entity.Property(e => e.ArendaId).HasColumnName("arenda_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Услугаs)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_Услуга_Покупатель");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
