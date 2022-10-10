using _0_Framework.Application;
using AccountManagement.Application.Contracts.Person;
using Domin.PersonAgg;
using Domin.Sla_RecAgg;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class PersonApplication : IPersonApplication
    {
        private readonly IPersonRepository _personRepository;
        private readonly ISla_RecRepository _sla_RecRepository;
        private readonly IAuthHelper ـauthHelper;
        public PersonApplication(IPersonRepository personRepository, IAuthHelper ـauthHelper, ISla_RecRepository sla_RecRepository)
        {
            _personRepository = personRepository;
            this.ـauthHelper = ـauthHelper;
            _sla_RecRepository = sla_RecRepository;
        }
        public OperationResult Create(PersonCreate command)
        {
            var Operation = new OperationResult();
            if (_personRepository.Exists(x => x.Name == command.Name))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var person = new Person(command.Name, command.Company, command.Phone, command.Address, command.Money_Id, userid);
                _personRepository.Create(person);
                _personRepository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(PersonEdit command)
        {
            var operation = new OperationResult();
            var person = _personRepository.Get(command.Id);
            if (person == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_personRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    person.Edit(command.Name, command.Company, command.Phone, command.Address, command.Money_Id, userid);
                    _personRepository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public PersonEdit GetDetails(int id)
        {
            return _personRepository.GetDetails(id);
        }

        public List<PersonViewModel> GetPerson()
        {
            return _personRepository.GetPerson();
        }
        public void Remove(int id)
        {
            var money = _personRepository.Get(id);
            money.Remove();
            _personRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var money = _personRepository.Get(id);
            money.Activate();
            _personRepository.SaveChanges();
        }

        public OperationResult Total_Rest()
        {
            var operation = new OperationResult();

            var person = _personRepository.GetPerson();
            foreach (var I_person in person)
            {
                decimal sr_false = _sla_RecRepository.GetSla_Rec()
                        .Where(x => x.Status == true && x.Type == false && x.Person_Id == I_person.Id && x.Money_Id == I_person.Money_Id).Sum(x => x.Amount);

                decimal sr_true = _sla_RecRepository.GetSla_Rec()
                        .Where(x => x.Status == true && x.Type == true && x.Person_Id == I_person.Id && x.Money_Id == I_person.Money_Id).Sum(x => x.Amount);

                var edit_person = _personRepository.Get(I_person.Id);
                decimal total = sr_true - sr_false;
                edit_person.Edit(total);
                _personRepository.SaveChanges();
            }

            return operation.Succedded();
        }
    }
}
