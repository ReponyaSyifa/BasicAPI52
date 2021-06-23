using API.Contexts;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContexts, Employees, string>
    {
        private readonly MyContexts myContexts;
        public EmployeeRepository(MyContexts myContexts) : base(myContexts)
        {
            this.myContexts = myContexts;
        }

        public int Register(RegisterVm registerVm)
        {
            try
            {
                int hasil = 1;
                var cekNIK = myContexts.Employees.SingleOrDefault(e => e.NIK == registerVm.NIK);
                var cekEmail = myContexts.Employees.SingleOrDefault(e => e.Email == registerVm.Email);
                if (cekNIK == null && cekEmail == null)
                {
                    Employees emp = new Employees();
                    emp.NIK = registerVm.NIK;
                    emp.FirstName = registerVm.FirstName;
                    emp.LastName = registerVm.LastName;
                    emp.PhoneNumber = registerVm.PhoneNumber;
                    emp.BirthDate = registerVm.BirthDate;
                    emp.Genders = (Models.Gender)registerVm.Genders;
                    emp.Salary = registerVm.Salary;
                    emp.Email = registerVm.Email;
                    myContexts.Employees.Add(emp);
                    myContexts.SaveChanges();

                    Accounts accounts = new Accounts();
                    accounts.NIK = registerVm.NIK;
                    accounts.Password = HashingPassword.HashPassword(registerVm.Password);
                    myContexts.Accounts.Add(accounts);
                    myContexts.SaveChanges();

                    Educations edu = new Educations();
                    edu.Degree = registerVm.Degree;
                    edu.GPA = registerVm.GPA;
                    edu.UniversitiesId = registerVm.UniId;
                    myContexts.Educations.Add(edu);
                    myContexts.SaveChanges();

                    Profilings profil = new Profilings();
                    profil.NIK = registerVm.NIK;
                    profil.EducationsId = edu.EducationId;
                    myContexts.Profilings.Add(profil);
                    myContexts.SaveChanges();

                    hasil = 4;
                }
                else if (cekNIK != null && cekEmail == null)
                {
                    hasil = 1; // nik sudah ada

                }
                else if (cekNIK == null && cekEmail != null)
                {
                    hasil = 2; //email sudah ada
                }
                else if (cekNIK != null && cekEmail != null)
                {
                    hasil = 3; //NIK & email sudah ada
                }
                return hasil;

            }
            catch (DbUpdateException)
            {
                return 0; // gagal daftar
            }
        }
    }    
}
