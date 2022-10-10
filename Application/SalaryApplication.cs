using _0_Framework.Application;
using AccountManagement.Application.Contracts.Salary;
using Domin.SalaryAgg;
using System.Collections.Generic;

namespace Application
{
    public class SalaryApplication : ISalaryApplication
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryApplication(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public OperationResult Create(SalaryCreate command)
        {
            var operation = new OperationResult();
            var rent = new Salary(command.Money_Id, command.Employee_Id, (int)command.Year, (int)command.Month, command.Month_Salary);
            _salaryRepository.Create(rent);
            _salaryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(SalaryEdit command)
        {
            var operation = new OperationResult();
            var salary = _salaryRepository.Get(command.Id);
            salary.Edit(command.Money_Id, command.Employee_Id, (int)command.Year, (int)command.Month, command.Month_Salary);
            _salaryRepository.SaveChanges();
            return operation.Succedded();
        }

        public SalaryEdit GetDetails(int id)
        {
            return _salaryRepository.GetDetails(id);
        }

        public List<SalaryViewModel> GetViewModel()
        {
            return _salaryRepository.GetViewModel();
        }
        public void Remove(int id)
        {
            var result = _salaryRepository.Get(id);
            result.Remove();
            _salaryRepository.SaveChanges();
        }
        public void Activate(int id)
        {
            var result = _salaryRepository.Get(id);
            result.Activate();
            _salaryRepository.SaveChanges();
        }
    }
}