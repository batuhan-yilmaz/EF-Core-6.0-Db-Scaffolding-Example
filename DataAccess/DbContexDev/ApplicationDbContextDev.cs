using Entities.EntityDev;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public partial class ApplicationDbContextDev : DbContext
    {
        public ApplicationDbContextDev()
        {
        }

        public ApplicationDbContextDev(DbContextOptions<ApplicationDbContextDev> options)
            : base(options)
        {
        }

        public virtual DbSet<AlfabetikSiraliUrunlerListesi> AlfabetikSiraliUrunlerListesis { get; set; } = null!;
        public virtual DbSet<AyrintiliSatisDetaylari> AyrintiliSatisDetaylaris { get; set; } = null!;
        public virtual DbSet<BitenUrunlerListesi> BitenUrunlerListesis { get; set; } = null!;
        public virtual DbSet<Bolge> Bolges { get; set; } = null!;
        public virtual DbSet<Bolgeler> Bolgelers { get; set; } = null!;
        public virtual DbSet<Faturalar> Faturalars { get; set; } = null!;
        public virtual DbSet<HerUcAylikSatislar> HerUcAylikSatislars { get; set; } = null!;
        public virtual DbSet<Kategoriler> Kategorilers { get; set; } = null!;
        public virtual DbSet<KategorilereGore1997YiliSatislari> KategorilereGore1997YiliSatislaris { get; set; } = null!;
        public virtual DbSet<KategorilereGoreSatislar> KategorilereGoreSatislars { get; set; } = null!;
        public virtual DbSet<KategorilereGoreUrunler> KategorilereGoreUrunlers { get; set; } = null!;
        public virtual DbSet<MusteriDemographic> MusteriDemographics { get; set; } = null!;
        public virtual DbSet<Musteriler> Musterilers { get; set; } = null!;
        public virtual DbSet<Nakliyeciler> Nakliyecilers { get; set; } = null!;
        public virtual DbSet<OrtalamaMaliyetinUzerindekiUrunler> OrtalamaMaliyetinUzerindekiUrunlers { get; set; } = null!;
        public virtual DbSet<OzetCeyrekSatislar> OzetCeyrekSatislars { get; set; } = null!;
        public virtual DbSet<OzetYillikSatislar> OzetYillikSatislars { get; set; } = null!;
        public virtual DbSet<Personeller> Personellers { get; set; } = null!;
        public virtual DbSet<SatisAltToplamlari> SatisAltToplamlaris { get; set; } = null!;
        public virtual DbSet<SatisDetaylari> SatisDetaylaris { get; set; } = null!;
        public virtual DbSet<Satislar> Satislars { get; set; } = null!;
        public virtual DbSet<SatislarSorgusu> SatislarSorgusus { get; set; } = null!;
        public virtual DbSet<SatislarinToplamMiktari> SatislarinToplamMiktaris { get; set; } = null!;
        public virtual DbSet<SehirlereGoreMusteriVeTedarikciler> SehirlereGoreMusteriVeTedarikcilers { get; set; } = null!;
        public virtual DbSet<Tedarikciler> Tedarikcilers { get; set; } = null!;
        public virtual DbSet<Urunler> Urunlers { get; set; } = null!;
        public virtual DbSet<_1997YiliUrunSatislari> _1997YiliUrunSatislaris { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConnectionContextDev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlfabetikSiraliUrunlerListesi>(entity =>
            {
                entity.ToView("Alfabetik Sirali Urunler Listesi");
            });

            modelBuilder.Entity<AyrintiliSatisDetaylari>(entity =>
            {
                entity.ToView("Ayrintili Satis Detaylari");
            });

            modelBuilder.Entity<BitenUrunlerListesi>(entity =>
            {
                entity.ToView("Biten Urunler Listesi");

                entity.Property(e => e.UrunId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Bolge>(entity =>
            {
                entity.HasKey(e => e.BolgeId)
                    .IsClustered(false);

                entity.Property(e => e.BolgeId).ValueGeneratedNever();

                entity.Property(e => e.BolgeTanimi).IsFixedLength();
            });

            modelBuilder.Entity<Bolgeler>(entity =>
            {
                entity.HasKey(e => e.TerritoryId)
                    .IsClustered(false);

                entity.Property(e => e.TerritoryTanimi).IsFixedLength();

                entity.HasOne(d => d.Bolge)
                    .WithMany(p => p.Bolgelers)
                    .HasForeignKey(d => d.BolgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bolgeler_Bolge");
            });

            modelBuilder.Entity<Faturalar>(entity =>
            {
                entity.ToView("Faturalar");

                entity.Property(e => e.MusteriId).IsFixedLength();
            });

            modelBuilder.Entity<HerUcAylikSatislar>(entity =>
            {
                entity.ToView("Her Uc Aylik Satislar");

                entity.Property(e => e.MusteriId).IsFixedLength();
            });

            modelBuilder.Entity<KategorilereGore1997YiliSatislari>(entity =>
            {
                entity.ToView("Kategorilere Gore 1997 Yili Satislari");
            });

            modelBuilder.Entity<KategorilereGoreSatislar>(entity =>
            {
                entity.ToView("Kategorilere Gore Satislar");
            });

            modelBuilder.Entity<KategorilereGoreUrunler>(entity =>
            {
                entity.ToView("Kategorilere Gore Urunler");
            });

            modelBuilder.Entity<MusteriDemographic>(entity =>
            {
                entity.HasKey(e => e.MusteriTypeId)
                    .IsClustered(false);

                entity.Property(e => e.MusteriTypeId).IsFixedLength();
            });

            modelBuilder.Entity<Musteriler>(entity =>
            {
                entity.Property(e => e.MusteriId).IsFixedLength();

                entity.HasMany(d => d.MusteriTypes)
                    .WithMany(p => p.Musteris)
                    .UsingEntity<Dictionary<string, object>>(
                        "MusteriMusteriDemo",
                        l => l.HasOne<MusteriDemographic>().WithMany().HasForeignKey("MusteriTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MusteriMusteriDemo"),
                        r => r.HasOne<Musteriler>().WithMany().HasForeignKey("MusteriId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MusteriMusteriDemo_Musteriler"),
                        j =>
                        {
                            j.HasKey("MusteriId", "MusteriTypeId").IsClustered(false);

                            j.ToTable("MusteriMusteriDemo");

                            j.IndexerProperty<string>("MusteriId").HasMaxLength(5).HasColumnName("MusteriID").IsFixedLength();

                            j.IndexerProperty<string>("MusteriTypeId").HasMaxLength(10).HasColumnName("MusteriTypeID").IsFixedLength();
                        });
            });

            modelBuilder.Entity<OrtalamaMaliyetinUzerindekiUrunler>(entity =>
            {
                entity.ToView("Ortalama Maliyetin Uzerindeki Urunler");
            });

            modelBuilder.Entity<OzetCeyrekSatislar>(entity =>
            {
                entity.ToView("Ozet Ceyrek Satislar");
            });

            modelBuilder.Entity<OzetYillikSatislar>(entity =>
            {
                entity.ToView("Ozet Yillik Satislar");
            });

            modelBuilder.Entity<Personeller>(entity =>
            {
                entity.HasOne(d => d.BagliCalistigiKisiNavigation)
                    .WithMany(p => p.InverseBagliCalistigiKisiNavigation)
                    .HasForeignKey(d => d.BagliCalistigiKisi)
                    .HasConstraintName("FK_Personeller_Personeller");

                entity.HasMany(d => d.Territories)
                    .WithMany(p => p.Personels)
                    .UsingEntity<Dictionary<string, object>>(
                        "PersonelBolgeler",
                        l => l.HasOne<Bolgeler>().WithMany().HasForeignKey("TerritoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PersonelBolgeler_Bolgeler"),
                        r => r.HasOne<Personeller>().WithMany().HasForeignKey("PersonelId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PersonelBolgeler_Personeller"),
                        j =>
                        {
                            j.HasKey("PersonelId", "TerritoryId").IsClustered(false);

                            j.ToTable("PersonelBolgeler");

                            j.IndexerProperty<int>("PersonelId").HasColumnName("PersonelID");

                            j.IndexerProperty<string>("TerritoryId").HasMaxLength(20).HasColumnName("TerritoryID");
                        });
            });

            modelBuilder.Entity<SatisAltToplamlari>(entity =>
            {
                entity.ToView("Satis Alt Toplamlari");
            });

            modelBuilder.Entity<SatisDetaylari>(entity =>
            {
                entity.HasKey(e => new { e.SatisId, e.UrunId })
                    .HasName("PK_Order_Details");

                entity.Property(e => e.Miktar).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Satis)
                    .WithMany(p => p.SatisDetaylaris)
                    .HasForeignKey(d => d.SatisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Satislar");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SatisDetaylaris)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Urunler");
            });

            modelBuilder.Entity<Satislar>(entity =>
            {
                entity.Property(e => e.MusteriId).IsFixedLength();

                entity.Property(e => e.NakliyeUcreti).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.Satislars)
                    .HasForeignKey(d => d.MusteriId)
                    .HasConstraintName("FK_Satislar_Musteriler");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.Satislars)
                    .HasForeignKey(d => d.PersonelId)
                    .HasConstraintName("FK_Satislar_Personeller");

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Satislars)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Satislar_Nakliyeciler");
            });

            modelBuilder.Entity<SatislarSorgusu>(entity =>
            {
                entity.ToView("Satislar Sorgusu");

                entity.Property(e => e.MusteriId).IsFixedLength();
            });

            modelBuilder.Entity<SatislarinToplamMiktari>(entity =>
            {
                entity.ToView("Satislarin Toplam Miktari");
            });

            modelBuilder.Entity<SehirlereGoreMusteriVeTedarikciler>(entity =>
            {
                entity.ToView("Sehirlere Gore Musteri ve Tedarikciler");
            });

            modelBuilder.Entity<Urunler>(entity =>
            {
                entity.Property(e => e.BirimFiyati).HasDefaultValueSql("((0))");

                entity.Property(e => e.EnAzYenidenSatisMikatari).HasDefaultValueSql("((0))");

                entity.Property(e => e.HedefStokDuzeyi).HasDefaultValueSql("((0))");

                entity.Property(e => e.YeniSatis).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Urunlers)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Urunler_Kategoriler");

                entity.HasOne(d => d.Tedarikci)
                    .WithMany(p => p.Urunlers)
                    .HasForeignKey(d => d.TedarikciId)
                    .HasConstraintName("FK_Urunler_Tedarikciler");
            });

            modelBuilder.Entity<_1997YiliUrunSatislari>(entity =>
            {
                entity.ToView("1997 Yili Urun Satislari");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
