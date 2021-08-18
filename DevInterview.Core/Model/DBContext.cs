using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aeroporti> Aeroporti { get; set; }
        public virtual DbSet<CategorieMerchi> CategorieMerchi { get; set; }
        public virtual DbSet<ControlloMerchi> ControlloMerchi { get; set; }
        public virtual DbSet<Esiti> Esiti { get; set; }
        public virtual DbSet<MotivazioniRevisione> MotivazioniRevisioni { get; set; }
        public virtual DbSet<Passeggeri> Passeggeri { get; set; }
        public virtual DbSet<PuntiControlli> PuntiControlli { get; set; }
        public virtual DbSet<RevisioniControlli> RevisioniControlli { get; set; }
        public virtual DbSet<Stati> Stati { get; set; }
        public virtual DbSet<TipiDocumenti> TipiDocumenti { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }
        public virtual DbSet<Viaggi> Viaggi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-BDSRIF9\\SQLEXPRESS;Initial Catalog=ambiente_test;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aeroporti>(entity =>
            {
                entity.ToTable("aeroporti");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdNazione).HasColumnName("id_nazione");

                entity.Property(e => e.Indirizzo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("indirizzo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdNazioneNavigation)
                    .WithMany(p => p.Aeroporti)
                    .HasForeignKey(d => d.IdNazione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stato");
            });

            modelBuilder.Entity<CategorieMerchi>(entity =>
            {
                entity.ToTable("categorie_merchi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<ControlloMerchi>(entity =>
            {
                entity.ToTable("controllo_merchi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(255)
                    .HasColumnName("descrizione");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdEsito).HasColumnName("id_esito");

                entity.Property(e => e.IdViaggio).HasColumnName("id_viaggio");

                entity.Property(e => e.Quantita).HasColumnName("quantita");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.ControlloMerchi)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_controllo_merchi_categorie_merchi");

                entity.HasOne(d => d.IdEsitoNavigation)
                    .WithMany(p => p.ControlloMerchi)
                    .HasForeignKey(d => d.IdEsito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_controllo_merchi_esiti");

                entity.HasOne(d => d.IdViaggioNavigation)
                    .WithMany(p => p.ControlloMerchi)
                    .HasForeignKey(d => d.IdViaggio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_viaggio_merche_controlli");
            });

            modelBuilder.Entity<Esiti>(entity =>
            {
                entity.ToTable("esiti");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Esito)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("esito");
            });

            modelBuilder.Entity<MotivazioniRevisione>(entity =>
            {
                entity.ToTable("motivazioni_revisione");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Motivazione)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("motivazione");
            });

            modelBuilder.Entity<Passeggeri>(entity =>
            {
                entity.ToTable("passeggeri");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cognome)
                    .HasMaxLength(128)
                    .HasColumnName("cognome");

                entity.Property(e => e.IdNazione).HasColumnName("id_nazione");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(128)
                    .HasColumnName("nome");

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("numero_documento");

                entity.HasOne(d => d.IdNazioneNavigation)
                    .WithMany(p => p.Passeggeri)
                    .HasForeignKey(d => d.IdNazione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_passeggeri_stati");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Passeggeri)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_passeggeri_tipi_documenti");
            });

            modelBuilder.Entity<PuntiControlli>(entity =>
            {
                entity.ToTable("punti_controlli");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(128)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<RevisioniControlli>(entity =>
            {
                entity.ToTable("revisioni_controlli");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdControllo).HasColumnName("id_controllo");

                entity.Property(e => e.IdMotivazione).HasColumnName("id_motivazione");

                entity.Property(e => e.IdUtente).HasColumnName("id_utente");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("note");

                entity.HasOne(d => d.IdControlloNavigation)
                    .WithMany(p => p.RevisioniControlli)
                    .HasForeignKey(d => d.IdControllo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_revisioni_controlli_controlli");

                entity.HasOne(d => d.IdMotivazioneNavigation)
                    .WithMany(p => p.RevisioniControlli)
                    .HasForeignKey(d => d.IdMotivazione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_revisioni_controlli_motivazioni_revisione");

                entity.HasOne(d => d.IdUtenteNavigation)
                    .WithMany(p => p.RevisioniControlli)
                    .HasForeignKey(d => d.IdUtente)
                    .HasConstraintName("FK_revisioni_controlli_utenti");
            });

            modelBuilder.Entity<Stati>(entity =>
            {
                entity.ToTable("stati");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LaIso31661Alpha2)
                    .HasMaxLength(2)
                    .HasColumnName("la_iso_3166_1_alpha_2");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("nome");

                entity.Property(e => e.SiglaIso31661Alpha3)
                    .HasMaxLength(3)
                    .HasColumnName("sigla_iso_3166_1_alpha_3");

                entity.Property(e => e.SiglaNumerica)
                    .HasMaxLength(4)
                    .HasColumnName("sigla_numerica");
            });

            modelBuilder.Entity<TipiDocumenti>(entity =>
            {
                entity.ToTable("tipi_documenti");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Utenti>(entity =>
            {
                entity.ToTable("utenti");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cognome)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("cognome");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Viaggi>(entity =>
            {
                entity.ToTable("viaggi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataFine)
                    .HasColumnType("datetime")
                    .HasColumnName("data_fine");

                entity.Property(e => e.DataInizio)
                    .HasColumnType("datetime")
                    .HasColumnName("data_inizio")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DazioDoganale).HasColumnName("dazio_doganale");

                entity.Property(e => e.IdADestinazione).HasColumnName("id_a_destinazione");

                entity.Property(e => e.IdAProvenienza).HasColumnName("id_a_provenienza");

                entity.Property(e => e.IdPasseggero).HasColumnName("id_passeggero");

                entity.Property(e => e.IdPuntoControllo).HasColumnName("id_punto_controllo");

                entity.Property(e => e.IdUtente).HasColumnName("id_utente");

                entity.Property(e => e.Motivazione)
                    .HasMaxLength(255)
                    .HasColumnName("motivazione");

                entity.HasOne(d => d.IdADestinazioneNavigation)
                    .WithMany(p => p.ViaggiIdADestinazioneNavigations)
                    .HasForeignKey(d => d.IdADestinazione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_controlli_aeroporti_destinazione");

                entity.HasOne(d => d.IdAProvenienzaNavigation)
                    .WithMany(p => p.ViaggiIdAProvenienzaNavigations)
                    .HasForeignKey(d => d.IdAProvenienza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_controlli_aeroporti_provenienza");

                entity.HasOne(d => d.IdPasseggeroNavigation)
                    .WithMany(p => p.Viaggi)
                    .HasForeignKey(d => d.IdPasseggero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_controlli_passeggeri");

                entity.HasOne(d => d.IdPuntoControlloNavigation)
                    .WithMany(p => p.Viaggi)
                    .HasForeignKey(d => d.IdPuntoControllo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_controlli_punti_controlli");

                entity.HasOne(d => d.IdUtenteNavigation)
                    .WithMany(p => p.Viaggi)
                    .HasForeignKey(d => d.IdUtente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_controlli_utenti");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
