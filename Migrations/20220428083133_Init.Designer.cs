// <auto-generated />
using System;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MainProject.Migrations
{
    [DbContext(typeof(MainProjectContext))]
    [Migration("20220428083133_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MainProject.Models.ReimbursementData", b =>
                {
                    b.Property<int>("ReimbursementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ApprovedValue")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InternalNotes")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ReceiptAttached")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ReceiptImageLink")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ReimbursementType")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("RequestedBy")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RequestedPhase")
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RequestedValue")
                        .HasColumnType("int");

                    b.HasKey("ReimbursementID");

                    b.ToTable("ReimbursementDatas");
                });

            modelBuilder.Entity("MainProject.Models.SignUp", b =>
                {
                    b.Property<int>("SignUpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IsApprover")
                        .HasColumnType("int");

                    b.Property<string>("PanNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SignUpID");

                    b.ToTable("SignUps");
                });
#pragma warning restore 612, 618
        }
    }
}
