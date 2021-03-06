// <auto-generated />
using System;
using Enaza.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Enaza.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20211121181953_InitialUserGroups")]
    partial class InitialUserGroups
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Enaza.Models.UserGroupModel", b =>
                {
                    b.Property<int>("UserGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserGroupId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Enaza.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserStateId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("UserStateId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Enaza.Models.UserStateModel", b =>
                {
                    b.Property<int>("UserStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserStateId");

                    b.ToTable("UserStates");
                });

            modelBuilder.Entity("Enaza.Models.UserModel", b =>
                {
                    b.HasOne("Enaza.Models.UserGroupModel", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enaza.Models.UserStateModel", "UserState")
                        .WithMany("Users")
                        .HasForeignKey("UserStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");

                    b.Navigation("UserState");
                });

            modelBuilder.Entity("Enaza.Models.UserGroupModel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Enaza.Models.UserStateModel", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
