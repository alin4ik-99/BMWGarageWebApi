using BMW_GarageWebApi.Domain.Enum;
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
                    FullName = "Davenko Serhii Viktorovych",
                    DateOfVisit = new DateOnly(2024, 02, 11),
                    StatusCarRecord = StatusCarRecord.NotConfirmed,
                    Email = "sergidavenko12@gmail.com",
                    PhoneNumber = "+48 456 346 641",
                    EmployeeId = 1,
                    Description = "Replacing spark plugs",
                    ApplicationUserId = "0b667fc3-6855-40fb-859a-779947f7c03f"
                },
                new CarRecord
                {
                    Id = 2,
                    FullName = "Kovalenko Serhiy Yervandovych",
                    DateOfVisit = new DateOnly(2024, 09, 19),
                    StatusCarRecord = StatusCarRecord.NotConfirmed,
                    Email = "sergikovalenko99@gmail.com",
                    PhoneNumber = "+48 471 399 075",
                    EmployeeId = 2,
                    Description = "Ignition system diagnostics",
                    ApplicationUserId = "0b667fc3-6855-40fb-859a-779947f7c03f"
                },
                new CarRecord
                {
                    Id = 3,
                    FullName = "Divanek Igor Serhiyovich",
                    DateOfVisit = new DateOnly(2024, 09, 23),
                    StatusCarRecord = StatusCarRecord.NotConfirmed,
                    Email = "divangood123@gmail.com",
                    PhoneNumber = "+48 212 564 980",
                    EmployeeId = 3,
                    Description = "Body geometry correction",
                    ApplicationUserId = "0b667fc3-6855-40fb-859a-779947f7c03f"
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
                   TypeOfCarRepair = "Diagnostics of the air conditioner",
                   PriceMin = 700,
                   PriceMax = 900
               },
               new CarRepair
               {
                   Id = 2,
                   TypeOfCarRepair = "Diagnostics of the Far Eastern Branch",
                   PriceMin = 400,
                   PriceMax = 1000
               },
               new CarRepair
               {
                   Id = 3,
                   TypeOfCarRepair = "Comparative Diagnostics",
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
                    FullName = "Zhezherya Serhiy Viktorovich",
                    DateOfBirth = new DateOnly(1998, 06, 16),
                    DateOfHiring = new DateOnly(2021, 02, 11),
                    Gender = Gender.Male,
                    Email = "sergizezeria147@gmail.com",
                    PhoneNumber = "+48 456 346 641",
                    Position = "mechanic",
                    ImageUrl = "",
                    Notes = "Completion of the use of diagnostic tools and facilities for the manifestation and solution of a wide range of automotive problems"
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Rubakov Serhiy Erandovich",
                    DateOfBirth = new DateOnly(1991, 05, 15),
                    DateOfHiring = new DateOnly(2021, 02, 11),
                    Gender = Gender.Male,
                    Email = "rub4iksergo@gmail.com",
                    PhoneNumber = "+48 116 287 743",
                    Position = "mechanic",
                    ImageUrl = "",
                    Notes = "Direct communication of navicciations, detailed explanations of repair and technical maintenance of clients"
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Gladkyi Igor Serhiyovich",
                    DateOfBirth = new DateOnly(1998, 06, 11),
                    DateOfHiring = new DateOnly(2021, 02, 12),
                    Gender = Gender.Male,
                    Email = "gladkoua@gmail.com",
                    PhoneNumber = "+48 688 966 121",
                    Position = "mechanic",
                    ImageUrl = "",
                    Notes = "The ability to resolve issues quickly and efficiently, ensuring minimal downtime for customers"
                }
            ];
        }
    }
}
