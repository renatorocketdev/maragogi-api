namespace AppMaragogiAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppMaragogiDB : DbContext
    {
        public AppMaragogiDB()
            : base("name=AppMaragogiDB")
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<CategoriasMaragogi> CategoriasMaragogi { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<FotoComentario> FotoComentario { get; set; }
        public virtual DbSet<HistoriaMaragogi> HistoriaMaragogi { get; set; }
        public virtual DbSet<Praias> Praias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>()
                .Property(e => e.MainCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<Categorias>()
                .Property(e => e.SubCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriasMaragogi>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriasMaragogi>()
                .Property(e => e.UrlVideo)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriasMaragogi>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriasMaragogi>()
                .Property(e => e.Localizacao)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriasMaragogi>()
                .Property(e => e.Categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Comentario>()
                .Property(e => e.NomeUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Comentario>()
                .Property(e => e.TextoComentario)
                .IsUnicode(false);

            modelBuilder.Entity<Comentario>()
                .Property(e => e.Empresa)
                .IsUnicode(false);

            modelBuilder.Entity<Comentario>()
                .Property(e => e.Categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Comentario>()
                .Property(e => e.Nota)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.NomeEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Telefone1Empresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Telefone2Empresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Facebook)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Instagram)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Site)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.SobreEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Carac1)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Carac2)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Carac3)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Carac4)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Serv1)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Serv2)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Serv3)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Serv4)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Nota)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.MainCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.SubCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Video)
                .IsUnicode(false);

            modelBuilder.Entity<FotoComentario>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<FotoComentario>()
                .Property(e => e.DataComentario)
                .IsUnicode(false);

            modelBuilder.Entity<FotoComentario>()
                .Property(e => e.Empresa)
                .IsUnicode(false);

            modelBuilder.Entity<FotoComentario>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<FotoComentario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.UrlVideo)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.Populacao)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.Clima)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.DistanciaMaceio)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.DistanciaRecife)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.Acesso)
                .IsUnicode(false);

            modelBuilder.Entity<HistoriaMaragogi>()
                .Property(e => e.Localizacao)
                .IsUnicode(false);

            modelBuilder.Entity<Praias>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Praias>()
                .Property(e => e.UrlVideo)
                .IsUnicode(false);

            modelBuilder.Entity<Praias>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Praias>()
                .Property(e => e.Localizacao)
                .IsUnicode(false);
        }
    }
}
