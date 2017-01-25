using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDUsingWebApi.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        bool Add(Employee student);
        bool Delete(int id);
        bool Update(Employee student);
    }
}

