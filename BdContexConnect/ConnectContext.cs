using System;
using System.Collections.Generic;
using ConnectPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.BdContexConnect;

public partial class ConnectContext : DbContext
{
    public ConnectContext()
    {
    }

    public ConnectContext(DbContextOptions<ConnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contato> Contatos { get; set; }

    public virtual DbSet<ContatoFamiliar> ContatoFamiliars { get; set; }

    public virtual DbSet<ContatoPessoal> ContatoPessoals { get; set; }

    public virtual DbSet<ContatoProfissional> ContatoProfissionals { get; set; }

    public virtual DbSet<TipoContato> TipoContatos { get; set; }

    public virtual DbSet<TipoContatoFamiliar> TipoContatoFamiliars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConnectPlus_Moura;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.IdContato).HasName("PK__Contato__2AC4F064311B00BB");

            entity.Property(e => e.IdContato).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ContatoFamiliar>(entity =>
        {
            entity.HasKey(e => e.IdContatoFamiliar).HasName("PK__ContatoF__0E0C38C2ED502DFC");

            entity.Property(e => e.IdContatoFamiliar).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ContatoPessoal>(entity =>
        {
            entity.HasKey(e => e.IdContatoPessoal).HasName("PK__ContatoP__0B58C433F3353522");

            entity.Property(e => e.IdContatoPessoal).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ContatoProfissional>(entity =>
        {
            entity.HasKey(e => e.IdContatoProfissional).HasName("PK__ContatoP__1358E4107BED346E");

            entity.Property(e => e.IdContatoProfissional).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<TipoContato>(entity =>
        {
            entity.HasKey(e => e.IdTipoContato).HasName("PK__TipoCont__8D18FEBD294A9F85");

            entity.Property(e => e.IdTipoContato).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTipoContatoNavigation).WithOne(p => p.TipoContato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TipoConta__IdTip__75A278F5");
        });

        modelBuilder.Entity<TipoContatoFamiliar>(entity =>
        {
            entity.HasKey(e => e.IdContatoFamiliar).HasName("PK__TipoCont__0E0C38C21BCF6EA6");

            entity.Property(e => e.IdContatoFamiliar).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
