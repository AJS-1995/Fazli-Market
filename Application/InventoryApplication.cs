using _0_Framework.Application;
using AccountManagement.Application.Contracts.Inventory;
using Domin.InventoryAgg;
using System.Collections.Generic;

namespace Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IAuthHelper ـauthHelper;
        public InventoryApplication(IInventoryRepository inventoryRepository, IAuthHelper ـauthHelper)
        {
            _inventoryRepository = inventoryRepository;
            this.ـauthHelper = ـauthHelper;
        }
        public OperationResult Create(CreateInventory command)
        {
            var Operation = new OperationResult();
            if (_inventoryRepository.Exists(x => x.Name == command.Name))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var inventory = new Inventory(command.Name, command.Location, userid);
                _inventoryRepository.Create(inventory);
                _inventoryRepository.SaveChanges();
                return Operation.Succedded();
            }
        }
        public OperationResult Edit(InventoryEdit command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.Get(command.Id);
            if (inventory == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_inventoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    inventory.Edit(command.Name, command.Location, userid);
                    _inventoryRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }
        public InventoryEdit GetDetails(int id)
        {
            return _inventoryRepository.GetDetails(id);
        }
        public List<InventoryViewModel> GetInventory()
        {
            return _inventoryRepository.GetInventory();
        }
        public void Remove(int id)
        {
            var money = _inventoryRepository.Get(id);
            money.Remove();
            _inventoryRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var money = _inventoryRepository.Get(id);
            money.Activate();
            _inventoryRepository.SaveChanges();
        }
    }
}