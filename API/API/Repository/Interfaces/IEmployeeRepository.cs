using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    interface IEmployeeRepository
    {
        //isinya cuma method aja, ga ada code spesisifk
        //disini interface dr employee sbg class parent utk class EmployeeRepositorynya

        IEnumerable<Employees> Get();
        Employees Get(string nik);
        int Insert(Employees employees);
        int Update(Employees employees, string nik);
        int Delete(string nik);

        //beda penggunaan Ienumerable & model:
        //nilai kembalian datanya, kalo Ienumerable itu bentuknya list/collection layaknya foreach
        //kalo model, hanya kembali 1 data, mencari datanya berdasarkan primary key

    }
}
