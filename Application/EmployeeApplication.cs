using _0_Framework.Application;
using AccountManagement.Application.Contracts.Employee;
using Domin.EmployeeAgg;
using Domin.ExSlaRecAgg;
using Domin.SalaryAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IExSlaRecRepository _exsla_RecRepository;
        private readonly ISalaryRepository _salaryRepository;
        private readonly IAuthHelper ـauthHelper;
        public EmployeeApplication(IEmployeeRepository employeeRepository, IAuthHelper ـauthHelper, IExSlaRecRepository exsla_RecRepository,
            ISalaryRepository salaryRepository)
        {
            _employeeRepository = employeeRepository;
            this.ـauthHelper = ـauthHelper;
            _exsla_RecRepository = exsla_RecRepository;
            _salaryRepository = salaryRepository;
        }

        public OperationResult Create(EmployeeCreate command)
        {
            var Operation = new OperationResult();
            if (_employeeRepository.Exists(x => x.FullName == command.FullName))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var employee = new Employee(command.FullName, command.Phone, command.Address, command.Salary, command.Money_Id, userid, command.Date);
                _employeeRepository.Create(employee);
                _employeeRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(EmployeeEdit command)
        {
            var operation = new OperationResult();
            var employee = _employeeRepository.Get(command.Id);
            if (employee == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_employeeRepository.Exists(x => x.FullName == command.FullName && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    employee.Edit(command.FullName, command.Phone, command.Address, command.Salary, command.Money_Id, userid, command.Date);
                    _employeeRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public EmployeeEdit GetDetails(int id)
        {
            return _employeeRepository.GetDetails(id);
        }

        public List<EmployeeViewModel> GetEmployee()
        {
            return _employeeRepository.GetEmployee();
        }
        public void Remove(int id)
        {
            var employee = _employeeRepository.Get(id);
            employee.Remove();
            _employeeRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var employee = _employeeRepository.Get(id);
            employee.Activate();
            _employeeRepository.SaveChanges();
        }

        public OperationResult Total_Rest()
        {
            var operation = new OperationResult();

            var employeeaccess = _employeeRepository.GetEmployee().Where(x => x.Status == true && x.Access == true).ToList();
            string date = DateTime.Now.ToFarsi();
            var year = Convert.ToInt32(date.Substring(0, 4));
            var month = Convert.ToInt32(date.Substring(5, 2));
            foreach (var access in employeeaccess)
            {
                string shopdate = access.Date;
                if (shopdate != null)
                {
                    var years = Convert.ToInt32(shopdate.Substring(0, 4));
                    var months = Convert.ToInt32(shopdate.Substring(5, 2));
                    if (year == years)
                    {
                        for (int i = months; i < month; i++)
                        {
                            if (_salaryRepository.Exists
                                    (x => x.Money_Id == access.Money_Id && x.Year == year && x.Month == month && x.Employee_Id == access.Id))
                            {

                            }
                            else
                            {
                                var salarypay = new Salary(access.Money_Id, access.Id, year, i, access.Salary);
                                _salaryRepository.Create(salarypay);
                                _salaryRepository.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        for (int y = years; y < year; y++)
                        {
                            for (int i = months; i < 13; i++)
                            {
                                if (_salaryRepository.Exists
                                    (x => x.Money_Id == access.Money_Id && x.Year == year && x.Month == month && x.Employee_Id == access.Id))
                                {

                                }
                                else
                                {
                                    var salarypay = new Salary(access.Money_Id, access.Id, y, i, access.Salary);
                                    _salaryRepository.Create(salarypay);
                                    _salaryRepository.SaveChanges();
                                }
                            }
                            months = 1;
                        }
                    }
                    var resultemployee = _employeeRepository.Get(access.Id);
                    resultemployee.Edit(date);
                    _employeeRepository.SaveChanges();
                }
            }

            var employee = _employeeRepository.GetEmployee();
            foreach (var I_employee in employee)
            {
                decimal sr_false = _exsla_RecRepository.GetExSlaRec()
                        .Where(x => x.Status == true && x.Type == false && x.Employee_Id == I_employee.Id).Sum(x => x.Amount);

                decimal sr_true = _exsla_RecRepository.GetExSlaRec()
                        .Where(x => x.Status == true && x.Type == true && x.Employee_Id == I_employee.Id).Sum(x => x.Amount);

                decimal salary = _salaryRepository.GetViewModel()
                        .Where(x => x.Status == true && x.Employee_Id == I_employee.Id && x.Money_Id == I_employee.Money_Id).Sum(x => x.Month_Salary);

                var edit_person = _employeeRepository.Get(I_employee.Id);
                decimal stotal = sr_true + salary;
                decimal total = stotal - sr_false;
                edit_person.Edit(total);
                _employeeRepository.SaveChanges();
            }

            return operation.Succedded();
        }

        public void AccessTrue(int id)
        {
            var employee = _employeeRepository.Get(id);
            employee.AccessTrue();
            _employeeRepository.SaveChanges();
        }

        public void AccessFalse(int id)
        {
            var employee = _employeeRepository.Get(id);
            employee.AccessFalse();
            _employeeRepository.SaveChanges();
        }
    }
}