﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;

namespace BusinessLogic.ORALogic
{
    public class EmployeeLogic
    {
        private EmployeeRepository repository = new EmployeeRepository();
        public void AddEmployee(EmployeeVM Employee)
        {
            repository.AddEmployee(Employee);
        }

        public EmployeeVM Login(EmployeeVM Employee)
        {
            foreach(EmployeeVM value in repository.GetAllEmployees())
            {
                if(value.EmployeeNumber == Employee.EmployeeNumber)
                {
                    if (value.Password == Employee.Password)
                    {
                        return value;
                    }
                }
            }
            return null;
        }

        public List<EmployeeVM> ViewAllEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeVM GetEmployeeByEmployeeID(int employeeID)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeVM updatedEmployee)
        {
            throw new NotImplementedException();
        }

        public void DieableEmployee(int employeeID)
        {
            throw new NotImplementedException();
        }
    }
}