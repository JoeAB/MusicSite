﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicData.DataAccess;

namespace MusicData.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190220172853_Albums")]
    partial class Albums
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicData.Entities.Album", b =>
                {
                    b.Property<int>("albumID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("dollarPrice");

                    b.Property<string>("name");

                    b.Property<DateTime?>("releaseDate");

                    b.HasKey("albumID");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicData.Entities.Artist", b =>
                {
                    b.Property<int>("artistID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<DateTime?>("endingDate");

                    b.Property<string>("name");

                    b.Property<DateTime>("startingDate");

                    b.HasKey("artistID");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            artistID = 1,
                            description = "Popular K-pop girl group",
                            name = "TWICE",
                            startingDate = new DateTime(2015, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MusicData.Entities.Genre", b =>
                {
                    b.Property<int>("genreID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("genreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MusicData.Entities.Song", b =>
                {
                    b.Property<int>("songID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("dollarPrice");

                    b.Property<string>("filePath");

                    b.Property<string>("name");

                    b.Property<DateTime?>("releaseDate");

                    b.Property<int?>("songArtistartistID");

                    b.Property<int?>("songGenregenreID");

                    b.HasKey("songID");

                    b.HasIndex("songArtistartistID");

                    b.HasIndex("songGenregenreID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MusicData.Entities.SongToAlbumMapping", b =>
                {
                    b.Property<int>("songToAlbumID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("albumID");

                    b.Property<int?>("songID");

                    b.HasKey("songToAlbumID");

                    b.HasIndex("albumID");

                    b.HasIndex("songID");

                    b.ToTable("SongToAlbumMappings");
                });

            modelBuilder.Entity("MusicData.Entities.Song", b =>
                {
                    b.HasOne("MusicData.Entities.Artist", "songArtist")
                        .WithMany()
                        .HasForeignKey("songArtistartistID");

                    b.HasOne("MusicData.Entities.Genre", "songGenre")
                        .WithMany()
                        .HasForeignKey("songGenregenreID");
                });

            modelBuilder.Entity("MusicData.Entities.SongToAlbumMapping", b =>
                {
                    b.HasOne("MusicData.Entities.Album", "album")
                        .WithMany()
                        .HasForeignKey("albumID");

                    b.HasOne("MusicData.Entities.Song", "song")
                        .WithMany()
                        .HasForeignKey("songID");
                });
#pragma warning restore 612, 618
        }
    }
}
