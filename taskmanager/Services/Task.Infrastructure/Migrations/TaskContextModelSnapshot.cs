﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.Infrastructure.Persistance;

namespace Task.Infrastructure.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Task.Domain.Entities.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("Task.Domain.Entities.Dependent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeKey")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeKey");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("Task.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Task.Domain.Entities.EmployeeBenefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BenefitKey")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("DependentCost")
                        .HasColumnType("real");

                    b.Property<float>("EmployeeCost")
                        .HasColumnType("real");

                    b.Property<int>("EmployeeKey")
                        .HasColumnType("int");

                    b.Property<float>("TotalCost")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BenefitKey");

                    b.HasIndex("EmployeeKey");

                    b.ToTable("EmployeeBenefits");
                });

            modelBuilder.Entity("Task.Domain.Entities.EmployeePayroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Deduction")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmployeeKey")
                        .HasColumnType("int");

                    b.Property<decimal>("GrossAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeKey")
                        .IsUnique();

                    b.ToTable("EmployeePayrolls");
                });

            modelBuilder.Entity("Task.Domain.Entities.Dependent", b =>
                {
                    b.HasOne("Task.Domain.Entities.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("EmployeeKey")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Task.Domain.Entities.EmployeeBenefit", b =>
                {
                    b.HasOne("Task.Domain.Entities.Benefit", "Benefit")
                        .WithMany("EmployeeBenefits")
                        .HasForeignKey("BenefitKey")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Task.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeBenefits")
                        .HasForeignKey("EmployeeKey")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Benefit");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Task.Domain.Entities.EmployeePayroll", b =>
                {
                    b.HasOne("Task.Domain.Entities.Employee", "Employee")
                        .WithOne("EmployeePayroll")
                        .HasForeignKey("Task.Domain.Entities.EmployeePayroll", "EmployeeKey")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Task.Domain.Entities.Benefit", b =>
                {
                    b.Navigation("EmployeeBenefits");
                });

            modelBuilder.Entity("Task.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Dependents");

                    b.Navigation("EmployeeBenefits");

                    b.Navigation("EmployeePayroll");
                });
#pragma warning restore 612, 618
        }
    }
}
