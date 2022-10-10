using _0_Framework.Application;
using AccountManagement.Application.Contracts.In_Out_Inventory;
using Domin.In_Out_InventoryAgg;
using System.Collections.Generic;

namespace Application
{
    public class In_Out_InventoryApplication : IIn_Out_InventoryApplication
    {

        private readonly IIn_Out_InventoryRepository _in_Out_InventoryRepository;
        private readonly IAuthHelper ـauthHelper;
        private readonly IFileUploader _fileUploader;
        public In_Out_InventoryApplication(IIn_Out_InventoryRepository in_Out_InventoryRepository, IAuthHelper authHelper, IFileUploader fileUploader)
        {
            _in_Out_InventoryRepository = in_Out_InventoryRepository;
            ـauthHelper = authHelper;
            _fileUploader = fileUploader;
        }

        public void Activate(int id)
        {
            var resalt = _in_Out_InventoryRepository.Get(id);
            resalt.Activate();
            _in_Out_InventoryRepository.SaveChanges();
        }

        public OperationResult Create(CreateIn_Out_Inventory command)
        {
            var Operation = new OperationResult();
            if (_in_Out_InventoryRepository.Exists(x => x.Details == command.Details))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                decimal SumType = decimal.Parse(command.Sum.ToString());
                decimal Sum = decimal.Round(SumType, 2);

                int userid = ـauthHelper.CurrentAccountId();

                var Path = "Expenses";
                var name = command.Date.Slugify() + command.Amount + command.Sum;
                var picturePath = _fileUploader.Upload(command.Ph_Invoice, Path, name);

                var resalt = new In_Out_Inventory(command.Date, command.Details, command.By, command.Amount, Sum,
                    command.Type, picturePath, command.MoneyId, command.InventoryId, userid);
                _in_Out_InventoryRepository.Create(resalt);
                _in_Out_InventoryRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(In_Out_InventoryEdit command)
        {
            var operation = new OperationResult();
            var resalt = _in_Out_InventoryRepository.Get(command.Id);
            if (resalt == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_in_Out_InventoryRepository.Exists(x => x.Details == command.Details && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    decimal SumType = decimal.Parse(command.Sum.ToString());
                    decimal Sum = decimal.Round(SumType, 2);

                    int userid = ـauthHelper.CurrentAccountId();

                    var Path = "Expenses";
                    var name = command.Date.Slugify() + command.Amount + command.Sum;
                    var picturePath = _fileUploader.Upload(command.Ph_Invoice, Path, name);

                    resalt.Edit(command.Date, command.Details, command.By, command.Amount, Sum, command.Type,
                        picturePath, command.MoneyId, command.InventoryId, userid);
                    _in_Out_InventoryRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public In_Out_InventoryEdit GetDetails(int id)
        {
            return _in_Out_InventoryRepository.GetDetails(id);
        }

        public List<In_Out_InventoryViewModel> GetIn_Out_Inventory()
        {
            return _in_Out_InventoryRepository.GetIn_Out_Inventory();
        }

        public void Remove(int id)
        {
            var resalt = _in_Out_InventoryRepository.Get(id);
            resalt.Remove();
            _in_Out_InventoryRepository.SaveChanges();
        }
        public In_Out_InventoryPhoto GetPhoto(int id)
        {
            return _in_Out_InventoryRepository.GetPhoto(id);
        }
    }
}