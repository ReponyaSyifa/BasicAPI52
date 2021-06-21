using API.Contexts;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class old_EmployeeRepository : IEmployeeRepository
    {
        //disini tempat bikin method non-void, yg punya nilai kembalian
        private readonly MyContexts myContexts;
        public old_EmployeeRepository(MyContexts myContexts)
        {
            this.myContexts = myContexts;
        }
        //model

        public IEnumerable<Employees> Get()
        {
            var employee = myContexts.Employees.ToList();
            return employee;
        }
        
        public int Delete(string nik)
        {
            var cari = myContexts.Employees.Find(nik);
            myContexts.Employees.Remove(cari);
            var save = myContexts.SaveChanges();
            return save;
        }

        public Employees Get(string nik)
        {
            var findAll = myContexts.Employees.Find(nik);
            return findAll;
        }

        public Employees GetById(string nik)
        {
            var findId = myContexts.Employees.Find(nik);
            return findId;
        }

        public int Insert(Employees employees)
        {
            myContexts.Employees.Add(employees);
            var insert = myContexts.SaveChanges();
            return insert;            
        }

        public int Update(Employees employees, string nik)
        {
            var findNik = GetById(nik);           

            if (employees.FirstName != null)
            { findNik.FirstName = employees.FirstName; }
            if (employees.LastName != null)
            { findNik.LastName = employees.LastName; }
            if (employees.Email != null)
            { findNik.Email = employees.Email; }
            if (employees.Salary != 0)
            { findNik.Salary = employees.Salary; }
            if (employees.PhoneNumber != null)
            { findNik.PhoneNumber = employees.PhoneNumber; }
            if (employees.BirthDate != null)
            { findNik.BirthDate = employees.BirthDate; }

            myContexts.Entry(findNik).State = EntityState.Modified;
            var update = myContexts.SaveChanges();
            return update;

        } //update = pakai entitysatetmodified
    }
}
