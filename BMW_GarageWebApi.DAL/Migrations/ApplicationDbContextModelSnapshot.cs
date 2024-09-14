﻿// <auto-generated />
using System;
using BMW_GarageWebApi.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BMW_GarageWebApi.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BMW_GarageWebApi.Domain.Models.CarRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfVisit")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusCarRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CarRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfVisit = new DateOnly(2024, 2, 11),
                            Description = "Замена свечей зажигания",
                            Email = "sergidavenko12@gmail.com",
                            EmployeeId = 1,
                            FullName = "Давенко Сергій Вікторович",
                            PhoneNumber = "+48 456 346 641",
                            StatusCarRecord = "NotConfirmed"
                        },
                        new
                        {
                            Id = 2,
                            DateOfVisit = new DateOnly(2024, 9, 19),
                            Description = "Диагностика системы зажигания",
                            Email = "sergikovalenko99@gmail.com",
                            EmployeeId = 2,
                            FullName = "Коваленко Сергій Єрвандович",
                            PhoneNumber = "+48 471 399 075",
                            StatusCarRecord = "NotConfirmed"
                        },
                        new
                        {
                            Id = 3,
                            DateOfVisit = new DateOnly(2024, 9, 23),
                            Description = "Исправление геометрии кузова",
                            Email = "divangood123@gmail.com",
                            EmployeeId = 3,
                            FullName = "Діванек Ігор Сергійович",
                            PhoneNumber = "+48 212 564 980",
                            StatusCarRecord = "NotConfirmed"
                        });
                });

            modelBuilder.Entity("BMW_GarageWebApi.Domain.Models.CarRepair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("PriceFrom")
                        .HasColumnType("float");

                    b.Property<double>("PriceTo")
                        .HasColumnType("float");

                    b.Property<string>("TypeOfCarRepair")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarRepairs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PriceFrom = 700.0,
                            PriceTo = 900.0,
                            TypeOfCarRepair = "Діагностика кондиціонера"
                        },
                        new
                        {
                            Id = 2,
                            PriceFrom = 400.0,
                            PriceTo = 1000.0,
                            TypeOfCarRepair = "Діагностика ДВЗ"
                        },
                        new
                        {
                            Id = 3,
                            PriceFrom = 800.0,
                            PriceTo = 1000.0,
                            TypeOfCarRepair = "Комп'ютерна діагностика"
                        });
                });

            modelBuilder.Entity("BMW_GarageWebApi.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfHiring")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateOnly(1998, 6, 16),
                            DateOfHiring = new DateOnly(2021, 2, 11),
                            Email = "sergizezeria147@gmail.com",
                            FullName = "Жежеря Сергій Вікторович",
                            Gender = "Male",
                            ImageUrl = "",
                            Notes = "Досконале володіння діагностичними інструментами та обладнанням для виявлення та вирішення широкого кола автомобільних проблем",
                            PhoneNumber = "+48 456 346 641",
                            Position = "Автомеханік"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateOnly(1991, 5, 15),
                            DateOfHiring = new DateOnly(2021, 2, 11),
                            Email = "rub4iksergo@gmail.com",
                            FullName = "Рубаков Сергій Єрвандович",
                            Gender = "Male",
                            ImageUrl = "",
                            Notes = "Відмінні комунікативні навички, надання чітких пояснень щодо ремонту та технічного обслуговування клієнтам",
                            PhoneNumber = "+48 116 287 743",
                            Position = "Автомеханік"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateOnly(1998, 6, 11),
                            DateOfHiring = new DateOnly(2021, 2, 12),
                            Email = "gladkoua@gmail.com",
                            FullName = "Гладкий Ігор Сергійович",
                            Gender = "Male",
                            ImageUrl = "",
                            Notes = "здатність швидко й ефективно усувати проблеми, забезпечуючи мінімальний час простою для клієнтів",
                            PhoneNumber = "+48 688 966 121",
                            Position = "Автомеханік"
                        });
                });

            modelBuilder.Entity("BMW_GarageWebApi.Domain.Models.CarRecord", b =>
                {
                    b.HasOne("BMW_GarageWebApi.Domain.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
