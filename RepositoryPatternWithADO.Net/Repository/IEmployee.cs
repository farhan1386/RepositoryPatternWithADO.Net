using RepositoryPatternWithADO.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithADO.Net.Repository
{
    public interface IEmployee
    {
        IList<Employee> GetEmployees();
        Employee GetEmployeeById(int? id);
        void InsertNew(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
