using _0_Framework.Application;
using AccountManagement.Application.Contracts.Sla_Rec;
using Domin.Sla_RecAgg;
using System.Collections.Generic;

namespace Application
{
    public class Sla_RecApplication : ISla_RecApplication
    {
        private readonly ISla_RecRepository _sla_RecRepository;
        private readonly IAuthHelper ـauthHelper;

        public Sla_RecApplication(IAuthHelper ـauthHelper, ISla_RecRepository sla_RecRepository)
        {
            this.ـauthHelper = ـauthHelper;
            _sla_RecRepository = sla_RecRepository;
        }

        public OperationResult Create(Sla_RecCreate command)
        {
            var Operation = new OperationResult();
            if (_sla_RecRepository.Exists(x => x.N_Invoice == command.N_Invoice))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                decimal AmountType = decimal.Parse(command.Amount.ToString());
                decimal Amount = decimal.Round(AmountType, 2);
                int userid = ـauthHelper.CurrentAccountId();
                var sla_Rec = new SlaRec(command.Date, command.Description, command.By, command.Type, command.N_Invoice, Amount,
                    command.Money_Id, command.Person_Id, command.PayBox_Id, userid);
                _sla_RecRepository.Create(sla_Rec);
                _sla_RecRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(Sla_RecEdit command)
        {
            var operation = new OperationResult();
            var sla_Rec = _sla_RecRepository.Get(command.Id);
            if (sla_Rec == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_sla_RecRepository.Exists(x => x.N_Invoice == command.N_Invoice && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    decimal AmountType = decimal.Parse(command.Amount.ToString());
                    decimal Amount = decimal.Round(AmountType, 2);
                    int userid = ـauthHelper.CurrentAccountId();
                    sla_Rec.Edit(command.Date, command.Description, command.By, command.Type, command.N_Invoice, Amount,
                        command.Money_Id, command.Person_Id, command.PayBox_Id, userid);
                    _sla_RecRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public Sla_RecEdit GetDetails(int id)
        {
            return _sla_RecRepository.GetDetails(id);
        }
        public void Remove(int id)
        {
            var sla_Rec = _sla_RecRepository.Get(id);
            sla_Rec.Remove();
            _sla_RecRepository.SaveChanges();
        }
        public void Activate(int id)
        {
            var sla_Rec = _sla_RecRepository.Get(id);
            sla_Rec.Activate();
            _sla_RecRepository.SaveChanges();
        }

        public List<Sla_RecViewModel> GetViewModel()
        {
            return _sla_RecRepository.GetSla_Rec();
        }
    }
}