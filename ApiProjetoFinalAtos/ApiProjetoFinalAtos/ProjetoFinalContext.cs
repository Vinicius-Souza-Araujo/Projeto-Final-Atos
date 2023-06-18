using System;
using System.Collections.Generic;
using ApiProjetoFinalAtos.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoFinalAtos;

public partial class ProjetoFinalContext : DbContext
{
    public ProjetoFinalContext()
    {
    }

    public ProjetoFinalContext(DbContextOptions<ProjetoFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<ItensPedido> ItensPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ProjetoFinal;User ID=atos;Password=senha123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F7FFF069A");

            entity.ToTable("categorias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ativo");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<ItensPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__itens_pe__3213E83F6B0A00F3");

            entity.ToTable("itens_pedidos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkPedido).HasColumnName("fk_pedido");
            entity.Property(e => e.FkProduto).HasColumnName("fk_produto");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.FkPedidoNavigation).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.FkPedido)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__itens_ped__fk_pe__412EB0B6");

            entity.HasOne(d => d.FkProdutoNavigation).WithMany(p => p.ItensPedidos)
                .HasForeignKey(d => d.FkProduto)
                .HasConstraintName("FK__itens_ped__fk_pr__4222D4EF");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pedidos__3213E83FBB4A21B7");

            entity.ToTable("pedidos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Andamento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("andamento");
            entity.Property(e => e.Cliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cliente");
            entity.Property(e => e.DataHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataHora");
            entity.Property(e => e.Mesa).HasColumnName("mesa");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__produtos__3213E83FF14F7156");

            entity.ToTable("produtos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ativo");
            entity.Property(e => e.FkCategoria).HasColumnName("fk_categoria");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.FkCategoriaNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.FkCategoria)
                .HasConstraintName("FK__produtos__ativo__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
