using SimpleCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SimpleCrudApp.DAL
{
    public class Initializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            var employees = new List<Employee>
            {
                new Employee() {EmployeeId = 1, FirstName = "Jan", LastName = "Kowalski", Position = "Developer", Salary = 5600, Address = "Różana 7", Code = "60-104", City = "Poznań", Age = 26, Email = "jan@kowalski.com", PhoneNumber = "201-232-122"},
                new Employee() {EmployeeId = 2, FirstName = "Karol", LastName = "Ryba", Position = "Senior Developer", Salary = 9000, Address = "Kaliska 18", Code = "60-104", City = "Poznań", Age = 29, Email = "karol@ryba.com", PhoneNumber = "852-963-741"},
                new Employee() {EmployeeId = 3, FirstName = "Ryszard", LastName = "Nowak", Position = "Scrum Master", Salary = 11000, Address = "Mickiewicza 8/15", Code = "60-104", City = "Poznań", Age = 27, Email = "ryszard@nowak.com", PhoneNumber = "123-456-789"},
                new Employee() {EmployeeId = 4, FirstName = "Paweł", LastName = "Myszka", Position = "Junior Developeer", Salary = 3200, Address = "Zielona 193", Code = "60-104", City = "Poznań", Age = 23, Email = "pawel@myszka.com", PhoneNumber = "999-888-777"},
                new Employee() {EmployeeId = 5, FirstName = "Agnieszka", LastName = "Lapek", Position = "Architekt", Salary = 10000, Address = "Reja 9", Code = "60-104", City = "Poznań", Age = 30, Email = "agnieszka@lapek.com", PhoneNumber = "555-456-654"}
            };

            employees.ForEach(e => context.Employees.AddOrUpdate(e));
            context.SaveChanges();
        }
    }
}