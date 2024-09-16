﻿using BMW_GarageWebApi.Domain.Enum;
using BMW_GarageWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.DAL.Data
{
    public static class DataForTableDB
    {
        public static CarRecord[] CreateCarRecord()
        {
            return
            [
                new CarRecord
                {
                    Id = 1,
                    FullName = "Давенко Сергій Вікторович",
                    DateOfVisit = new DateOnly(2024, 02, 11),
                    StatusCarRecord = StatusCarRecord.NotConfirmed,
                    Email = "sergidavenko12@gmail.com",
                    PhoneNumber = "+48 456 346 641",
                    EmployeeId = 1,
                    Description = "Замена свечей зажигания"
                },
                new CarRecord
                {
                    Id = 2,
                    FullName = "Коваленко Сергій Єрвандович",
                    DateOfVisit = new DateOnly(2024, 09, 19),
                    StatusCarRecord = StatusCarRecord.NotConfirmed,
                    Email = "sergikovalenko99@gmail.com",
                    PhoneNumber = "+48 471 399 075",
                    EmployeeId = 2,
                    Description = "Диагностика системы зажигания"
                },
                new CarRecord
                {
                    Id = 3,
                    FullName = "Діванек Ігор Сергійович",
                    DateOfVisit = new DateOnly(2024, 09, 23),
                    StatusCarRecord = StatusCarRecord.NotConfirmed,
                    Email = "divangood123@gmail.com",
                    PhoneNumber = "+48 212 564 980",
                    EmployeeId = 3,
                    Description = "Исправление геометрии кузова"
                }
            ];        
        }
        public static CarRepair[] CreateCarRepair()
        {
            return
            [
               new CarRepair
               {
                   Id = 1,
                   TypeOfCarRepair = "Діагностика кондиціонера",
                   PriceMin = 700,
                   PriceMax = 900
               },
               new CarRepair
               {
                   Id = 2,
                   TypeOfCarRepair = "Діагностика ДВЗ",
                   PriceMin = 400,
                   PriceMax = 1000
               },
               new CarRepair
               {
                   Id = 3,
                   TypeOfCarRepair = "Комп'ютерна діагностика",
                   PriceMin = 800,
                   PriceMax = 1000
               }
            ];
        }
        public static Employee[] CreateEmployee()
        {
            return
            [
                new Employee
                {
                    Id = 1,
                    FullName = "Жежеря Сергій Вікторович",
                    DateOfBirth = new DateOnly(1998, 06, 16),
                    DateOfHiring = new DateOnly(2021, 02, 11),
                    Gender = Gender.Male,
                    Email = "sergizezeria147@gmail.com",
                    PhoneNumber = "+48 456 346 641",
                    Position = "Автомеханік",
                    ImageUrl = "",
                    Notes = "Досконале володіння діагностичними інструментами та обладнанням для виявлення та вирішення широкого кола автомобільних проблем"
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Рубаков Сергій Єрвандович",
                    DateOfBirth = new DateOnly(1991, 05, 15),
                    DateOfHiring = new DateOnly(2021, 02, 11),
                    Gender = Gender.Male,
                    Email = "rub4iksergo@gmail.com",
                    PhoneNumber = "+48 116 287 743",
                    Position = "Автомеханік",
                    ImageUrl = "",
                    Notes = "Відмінні комунікативні навички, надання чітких пояснень щодо ремонту та технічного обслуговування клієнтам"
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Гладкий Ігор Сергійович",
                    DateOfBirth = new DateOnly(1998, 06, 11),
                    DateOfHiring = new DateOnly(2021, 02, 12),
                    Gender = Gender.Male,
                    Email = "gladkoua@gmail.com",
                    PhoneNumber = "+48 688 966 121",
                    Position = "Автомеханік",
                    ImageUrl = "",
                    Notes = "здатність швидко й ефективно усувати проблеми, забезпечуючи мінімальний час простою для клієнтів"
                }
            ];
        }
    }
}
