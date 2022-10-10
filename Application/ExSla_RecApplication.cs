using _0_Framework.Application;
using AccountManagement.Application.Contracts.ExSlaRec;
using Domin.ExSlaRecAgg;
using System.Collections.Generic;

namespace Application
{
    public class ExSlaRecApplication : IExSlaRecApplication
    {
        private readonly IExSlaRecRepository _exsla_RecRepository;
        private readonly IAuthHelper ـauthHelper;

        public ExSlaRecApplication(IAuthHelper ـauthHelper, IExSlaRecRepository exsla_RecRepository)
        {
            this.ـauthHelper = ـauthHelper;
            _exsla_RecRepository = exsla_RecRepository;
        }

        public OperationResult Create(ExSlaRecCreate command)
        {
            var Operation = new OperationResult();
            decimal AmountType = decimal.Parse(command.Amount.ToString());
            decimal Amount = decimal.Round(AmountType, 2);
            int userid = ـauthHelper.CurrentAccountId();
            var exsla_Rec = new ExSlaRec(command.Date, command.Description, command.By, command.Type, Amount, command.Money_Id,
                command.Employee_Id, command.PayBox_Id, userid);
            _exsla_RecRepository.Create(exsla_Rec);
            _exsla_RecRepository.SaveChanges();
            return Operation.Succedded();
        }

        public OperationResult Edit(ExSlaRecEdit command)
        {
            var operation = new OperationResult();
            var exsla_Rec = _exsla_RecRepository.Get(command.Id);
            if (exsla_Rec == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                decimal AmountType = decimal.Parse(command.Amount.ToString());
                decimal Amount = decimal.Round(AmountType, 2);
                int userid = ـauthHelper.CurrentAccountId();
                exsla_Rec.Edit(command.Date, command.Description, command.By, command.Type, Amount, command.Money_Id, command.Employee_Id,
                    command.PayBox_Id, userid);
                _exsla_RecRepository.SaveChanges();
                return operation.Succedded();
            }
        }

        public ExSlaRecEdit GetDetails(int id)
        {
            return _exsla_RecRepository.GetDetails(id);
        }
        public void Remove(int id)
        {
            var exsla_Rec = _exsla_RecRepository.Get(id);
            exsla_Rec.Remove();
            _exsla_RecRepository.SaveChanges();
        }
        public void Activate(int id)
        {
            var exsla_Rec = _exsla_RecRepository.Get(id);
            exsla_Rec.Activate();
            _exsla_RecRepository.SaveChanges();
        }

        public List<ExSlaRecViewModel> GetViewModel()
        {
            return _exsla_RecRepository.GetExSlaRec();
        }
    }
}