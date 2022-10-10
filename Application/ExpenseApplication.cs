using _0_Framework.Application;
using AccountManagement.Application.Contracts.Expense;
using Domin.Expenses;
using System.Collections.Generic;

namespace Application
{
    public class ExpenseApplication : IExpenseApplication
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IAuthHelper ـauthHelper;
        private readonly IFileUploader _fileUploader;
        public ExpenseApplication(IExpenseRepository expenseRepository, IAuthHelper ـauthHelper, IFileUploader fileUploader)
        {
            _expenseRepository = expenseRepository;
            this.ـauthHelper = ـauthHelper;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(ExpenseCreate command)
        {
            var Operation = new OperationResult();
            if (_expenseRepository.Exists(x => x.N_Invoice == command.N_Invoice))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                decimal AmountType = decimal.Parse(command.Amount.ToString());
                decimal Amount = decimal.Round(AmountType, 2);

                int userid = ـauthHelper.CurrentAccountId();

                var Path = "Expenses";
                var name = command.Date.Slugify() + command.N_Invoice.Slugify();
                var picturePath = _fileUploader.Upload(command.Ph_Invoice, Path, name);

                var expense = new Expense(command.Description, command.Type, command.N_Invoice, Amount, command.Date,
                    picturePath, command.Id_Money, command.PayBox_Id, userid);
                _expenseRepository.Create(expense);
                _expenseRepository.SaveChanges();
                return Operation.Succedded();
            }
        }
        public OperationResult Edit(ExpenseEdit command)
        {
            var operation = new OperationResult();
            var expense = _expenseRepository.Get(command.Id);
            if (expense == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_expenseRepository.Exists(x => x.N_Invoice == command.N_Invoice && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    decimal AmountType = decimal.Parse(command.Amount.ToString());
                    decimal Amount = decimal.Round(AmountType, 2);

                    int userid = ـauthHelper.CurrentAccountId();
                    var Path = "Expenses";
                    var name = command.Date.Slugify() + command.N_Invoice.Slugify();
                    var picturePath = _fileUploader.Upload(command.Ph_Invoice, Path, name);

                    expense.Edit(command.Description, command.Type, command.N_Invoice, Amount, command.Date, picturePath,
                        command.Id_Money, command.PayBox_Id, userid);
                    _expenseRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public ExpenseEdit GetDetails(int id)
        {
            return _expenseRepository.GetDetails(id);
        }

        public List<ExpenseViewModel> GetExpense()
        {
            return _expenseRepository.GetExpense();
        }
        public void Activate(int id)
        {
            var resalt = _expenseRepository.Get(id);
            resalt.Activate();
            _expenseRepository.SaveChanges();
        }
        public void Remove(int id)
        {
            var resalt = _expenseRepository.Get(id);
            resalt.Remove();
            _expenseRepository.SaveChanges();
        }

        public ExpensePhoto GetPhoto(int id)
        {
            return _expenseRepository.GetPhoto(id);
        }
    }
}