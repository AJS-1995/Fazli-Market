using _0_Framework.Application;
using AccountManagement.Application.Contracts.ReceiptRent;
using Domin.ReceiptRentAgg;
using System.Collections.Generic;

namespace Application
{
    public class ReceiptRentApplication : IReceiptRentApplication
    {
        private readonly IReceiptRentRepository _receiptRentRepository;
        private readonly IAuthHelper ـauthHelper;

        public ReceiptRentApplication(IAuthHelper authHelper, IReceiptRentRepository receiptRentRepository)
        {
            ـauthHelper = authHelper;
            _receiptRentRepository = receiptRentRepository;
        }

        public void Activate(int id)
        {
            var result = _receiptRentRepository.Get(id);
            result.Activate();
            _receiptRentRepository.SaveChanges();
        }

        public OperationResult Create(ReceiptRentCreate command)
        {
            var Operation = new OperationResult();
            int userid = ـauthHelper.CurrentAccountId();
            var result = new ReceiptRent(command.By, command.ForRent_Id, command.Shop_Id, command.PayBox_Id, command.Shop_Amount, userid, command.Date, command.Years, command.Months);
            _receiptRentRepository.Create(result);
            _receiptRentRepository.SaveChanges();
            return Operation.Succedded();
        }

        public OperationResult Edit(ReceiptRentEdit command)
        {
            var operation = new OperationResult();
            var result = _receiptRentRepository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                result.Edit(command.By, command.ForRent_Id, command.Shop_Id, command.PayBox_Id, command.Shop_Amount, userid, command.Date, command.Years, command.Months);
                _receiptRentRepository.SaveChanges();

                return operation.Succedded();
            }
        }

        public ReceiptRentEdit GetDetails(int id)
        {
            return _receiptRentRepository.GetDetails(id);
        }

        public List<ReceiptRentViewModel> GetReceiptRent()
        {
            return _receiptRentRepository.GetReceiptRent();
        }

        public void Remove(int id)
        {
            var result = _receiptRentRepository.Get(id);
            result.Remove();
            _receiptRentRepository.SaveChanges();
        }
    }
}