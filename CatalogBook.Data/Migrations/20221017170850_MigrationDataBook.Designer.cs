// <auto-generated />
using System;
using CatalogBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatalogBook.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221017170850_MigrationDataBook")]
    partial class MigrationDataBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CatalogBook.Data.Author", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DeleteRecord")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = new Guid("342e3c92-4bce-4037-839c-5ea6baed5804"),
                            DeleteRecord = false,
                            Name = "М. Флеонов"
                        },
                        new
                        {
                            ID = new Guid("23d04b00-2a00-4e5c-b7c8-0aa772d73b9a"),
                            DeleteRecord = false,
                            Name = "Дж. Рихтер"
                        },
                        new
                        {
                            ID = new Guid("d73d3244-0c0e-4644-a0e9-4dd8c963ba8d"),
                            DeleteRecord = false,
                            Name = "Р. Ривест"
                        });
                });

            modelBuilder.Entity("CatalogBook.Data.Book", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Cover")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("DeleteRecord")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("YearIssue")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = new Guid("6fb2f2c6-5286-4a4d-b02a-f0340da405dc"),
                            AuthorId = new Guid("342e3c92-4bce-4037-839c-5ea6baed5804"),
                            DeleteRecord = false,
                            Description = "Хорошая книга для начинающих",
                            ISBN = "123-123-123",
                            Title = "Библия Delphi",
                            YearIssue = new DateTime(2000, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("b735e892-21a6-4a2f-b798-b53901bd6919"),
                            AuthorId = new Guid("342e3c92-4bce-4037-839c-5ea6baed5804"),
                            DeleteRecord = false,
                            Description = "Отличная книга по SQL даже сейчас!",
                            ISBN = "555-555-555",
                            Title = "Библия SQL",
                            YearIssue = new DateTime(2000, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("243c40d5-7818-4c46-8069-fe0a43da149c"),
                            AuthorId = new Guid("23d04b00-2a00-4e5c-b7c8-0aa772d73b9a"),
                            DeleteRecord = false,
                            Description = "Программирование на платформе Microsof .Net Framework 4.5 на языке C#",
                            ISBN = "978-5-4461-1102-2",
                            Title = "CLR via C#",
                            YearIssue = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = new Guid("292ea292-cc97-4aef-ac27-f528e2801cb2"),
                            AuthorId = new Guid("d73d3244-0c0e-4644-a0e9-4dd8c963ba8d"),
                            DeleteRecord = false,
                            Description = "Книга представляет собой перевод учебника по курсу построения и анализа эффективных алгоритмов.",
                            ISBN = "5-900916-37-5",
                            Title = "Алгоритмы, посторение и анализ",
                            YearIssue = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CatalogBook.Data.Book", b =>
                {
                    b.HasOne("CatalogBook.Data.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");
                });
#pragma warning restore 612, 618
        }
    }
}
