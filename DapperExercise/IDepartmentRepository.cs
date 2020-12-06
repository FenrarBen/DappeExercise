using System;
using System.Collections.Generic;
using System.Text;

namespace DapperExercise
{
    interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
