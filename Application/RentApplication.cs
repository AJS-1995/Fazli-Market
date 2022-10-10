using _0_Framework.Application;
using AccountManagement.Application.Contracts.Rent;
using Domin.RentAgg;
using System.Collections.Generic;

namespace Application
{
    public class RentApplication : IRentApplication
    {
        private readonly IRentRepository _rentRepository;

        public RentApplication(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public OperationResult Create(RentCreate command)
        {
            var operation = new OperationResult();
            var rent = new Rent(command.Year, command.Month_1, command.Month_2, command.Month_3, command.Month_4,
                command.Month_5, command.Month_6, command.Month_7, command.Month_8, command.Month_9, command.Month_10,
                command.Month_11, command.Month_12, command.Shop_Id, command.Money_Id, command.ForRent_Id);
            _rentRepository.Create(rent);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Edit(command.Year, command.Month_1, command.Month_2, command.Month_3, command.Month_4,
                command.Month_5, command.Month_6, command.Month_7, command.Month_8, command.Month_9, command.Month_10,
                command.Month_11, command.Month_12, command.Shop_Id, command.Money_Id, command.ForRent_Id);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Month1(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month1(command.Month_1);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month2(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month2(command.Month_2);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month3(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month3(command.Month_3);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month4(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month4(command.Month_4);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month5(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month5(command.Month_5);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month6(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month6(command.Month_6);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month7(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month7(command.Month_7);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month8(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month8(command.Month_8);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month9(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month9(command.Month_9);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month10(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month10(command.Month_10);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month11(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month11(command.Month_11);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Month12(RentEdit command)
        {
            var operation = new OperationResult();
            var rent = _rentRepository.Get(command.Id);
            rent.Month12(command.Month_12);
            _rentRepository.SaveChanges();
            return operation.Succedded();
        }
        public RentEdit GetDetails(int id)
        {
            return _rentRepository.GetDetails(id);
        }

        public List<RentViewModel> GetViewModel()
        {
            return _rentRepository.GetViewModel();
        }
        public void Remove(int id)
        {
            var result = _rentRepository.Get(id);
            result.Remove();
            _rentRepository.SaveChanges();
        }
        public void Activate(int id)
        {
            var result = _rentRepository.Get(id);
            result.Activate();
            _rentRepository.SaveChanges();
        }
    }
}