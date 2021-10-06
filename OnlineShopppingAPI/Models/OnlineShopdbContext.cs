using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopppingAPI.Models
{
    public partial class OnlineShopdbContext : DbContext
    {
        public OnlineShopdbContext()
        {
        }

        public OnlineShopdbContext(DbContextOptions<OnlineShopdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<TblCart> TblCart { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblCompare> TblCompare { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblRetailer> TblRetailer { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblWishlist> TblWishlist { get; set; }
        public virtual DbSet<TypeOfUsers> TypeOfUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Admins__A9D105346C4CC9EE")
                    .IsUnique();

                entity.HasIndex(e => e.MobNo)
                    .HasName("UQ__Admins__FB9C10DB7A8FEA16")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobNo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__Admins__UserType__3A81B327");
            });

            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => e.Cartid)
                    .HasName("PK__tblCart__41663FC0E72731A5");

                entity.ToTable("tblCart");

                entity.Property(e => e.Cartid).HasColumnName("cartid");

                entity.Property(e => e.Cartquantity).HasColumnName("cartquantity");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblCart__product__571DF1D5");

                entity.HasOne(d => d.UseremailNavigation)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.Useremail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblCart__userema__5629CD9C");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("PK__tblCateg__23CDE59032A9BF7F");

                entity.ToTable("tblCategory");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Categorydescription).HasColumnName("categorydescription");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname");
            });

            modelBuilder.Entity<TblCompare>(entity =>
            {
                entity.ToTable("tblCompare");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblCompare)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblCompar__Produ__59FA5E80");

                entity.HasOne(d => d.UseremailNavigation)
                    .WithMany(p => p.TblCompare)
                    .HasForeignKey(d => d.Useremail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblCompar__usere__5AEE82B9");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK__tblOrder__080E3775DE3904FC");

                entity.ToTable("tblOrder");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date");

                entity.Property(e => e.Orderprice).HasColumnName("orderprice");

                entity.Property(e => e.Orderquantity).HasColumnName("orderquantity");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Retailerid).HasColumnName("retailerid");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("FK__tblOrder__produc__52593CB8");

                entity.HasOne(d => d.Retailer)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.Retailerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblOrder__retail__534D60F1");

                entity.HasOne(d => d.UseremailNavigation)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.Useremail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblOrder__userem__5165187F");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("PK__tblProdu__2D172D3261854A98");

                entity.ToTable("tblProduct");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Productbrand)
                    .HasColumnName("productbrand")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Productdescription).HasColumnName("productdescription");

                entity.Property(e => e.Productimage1).HasColumnName("productimage1");

                entity.Property(e => e.Productname).HasColumnName("productname");

                entity.Property(e => e.Productnotification)
                    .HasColumnName("productnotification")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Productprice).HasColumnName("productprice");

                entity.Property(e => e.Productquantity).HasColumnName("productquantity");

                entity.Property(e => e.Productstatus)
                    .HasColumnName("productstatus")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.Retailerid).HasColumnName("retailerid");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblProduc__categ__4E88ABD4");

                entity.HasOne(d => d.Retailer)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.Retailerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblProduc__retai__4D94879B");
            });

            modelBuilder.Entity<TblRetailer>(entity =>
            {
                entity.HasKey(e => e.Retailerid)
                    .HasName("PK__tblRetai__7A12C3E0C435344F");

                entity.ToTable("tblRetailer");

                entity.HasIndex(e => e.Aadhar)
                    .HasName("UQ__tblRetai__6C9F238ECF4444E2")
                    .IsUnique();

                entity.HasIndex(e => e.Gst)
                    .HasName("UQ__tblRetai__C51F7EFC9AEAF31E")
                    .IsUnique();

                entity.HasIndex(e => e.MobNo)
                    .HasName("UQ__tblRetai__FB9C10DB84D9E834")
                    .IsUnique();

                entity.HasIndex(e => e.Pan)
                    .HasName("UQ__tblRetai__C5709805DDDD0BB7")
                    .IsUnique();

                entity.HasIndex(e => e.Retaileremail)
                    .HasName("UQ__tblRetai__F3B103335BC20B75")
                    .IsUnique();

                entity.Property(e => e.Retailerid).HasColumnName("retailerid");

                entity.Property(e => e.Aadhar)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Approved)
                    .HasColumnName("approved")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.CompanyDetails)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gst)
                    .IsRequired()
                    .HasColumnName("GST")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobNo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Pan)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Retaileremail)
                    .IsRequired()
                    .HasColumnName("retaileremail")
                    .HasMaxLength(40);

                entity.Property(e => e.Retailername)
                    .IsRequired()
                    .HasColumnName("retailername")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Retailerpassword)
                    .IsRequired()
                    .HasColumnName("retailerpassword")
                    .HasMaxLength(40);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.TblRetailer)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__tblRetail__UserT__44FF419A");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.Useremail)
                    .HasName("PK__tblUser__870EAE60F3558B6C");

                entity.ToTable("tblUser");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Userpassword)
                    .IsRequired()
                    .HasColumnName("userpassword")
                    .HasMaxLength(20);

                entity.Property(e => e.Userphone)
                    .IsRequired()
                    .HasColumnName("userphone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__tblUser__UserTyp__3D5E1FD2");
            });

            modelBuilder.Entity<TblWishlist>(entity =>
            {
                entity.ToTable("tblWishlist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblWishlist)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblWishli__Produ__5DCAEF64");

                entity.HasOne(d => d.UseremailNavigation)
                    .WithMany(p => p.TblWishlist)
                    .HasForeignKey(d => d.Useremail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblWishli__usere__5EBF139D");
            });

            modelBuilder.Entity<TypeOfUsers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
