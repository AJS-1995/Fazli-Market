using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.RoleAgg;
using Domin.AccountAgg;
using System.Collections.Generic;

namespace Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _authHelper = authHelper;
            _roleRepository = roleRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public AccountViewModel GetAccountBy(int id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel()
            {
                Fullname = account.Fullname,
                Mobile = account.Mobile
            };
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();
            var user = _accountRepository.GetAccounts();
            if(user.Count != 0)
            {
                if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);

                var password = _passwordHasher.Hash(command.Password);

                var user_id = _authHelper.CurrentAccountId();

                var logoPath = "Users";
                var logoname = command.Fullname.Slugify();
                var picturePath = _fileUploader.Upload(command.ProfilePhoto, logoPath, logoname);

                var account = new Account(command.Fullname, command.Username, password, command.Mobile, user_id,
                    command.RoleId, picturePath);
                _accountRepository.Create(account);
            }
            else
            {
                

                var Admin = new Role("مدیر سیستم",1);
                _roleRepository.Create(Admin);
                _roleRepository.SaveChanges();

                var Accountant = new Role("حسابدار",1);
                _roleRepository.Create(Accountant);
                _roleRepository.SaveChanges();

                var Viewer = new Role("بیننده",1);
                _roleRepository.Create(Viewer);
                _roleRepository.SaveChanges();

                var password = _passwordHasher.Hash("Admin");

                var account = new Account("عبدالجبار سروری", "Admin", password, "+ (93) 70-3662737", 0, Admin.Id, "Users/Admin.png");
                _accountRepository.Create(account);
            }
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var user_id = _authHelper.CurrentAccountId();

            var logoPath = "Users";
            var logoname = command.Fullname.Slugify();
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, logoPath, logoname);

            account.Edit(command.Fullname, command.Username, command.Mobile, user_id, command.RoleId, picturePath);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditAccount GetDetails(int id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
            {
                return operation.Failed(ApplicationMessages.WrongUserNam);
            }
            else
            {
                var result = _passwordHasher.Check(account.Password, command.Password);
                if (!result.Verified)
                {
                    return operation.Failed(ApplicationMessages.WrongUserPass);
                }
                else
                {
                    var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname, account.Username, account.Mobile);
                    _authHelper.Signin(authViewModel);

                    return operation.Succedded();
                }
            }
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Remove(int id)
        {
            var money = _accountRepository.Get(id);
            money.Remove();
            _accountRepository.SaveChanges();
        }

        public void Activate(int id)
        {
            var money = _accountRepository.Get(id);
            money.Activate();
            _accountRepository.SaveChanges();
        }
    }
}