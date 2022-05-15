using Microsoft.EntityFrameworkCore;
using Portal.Application.Common;
using Portal.Application.Users.Commands.EditUser;
using Portal.Application.Users.Contracts;
using Portal.Domain.Users;
using Portal.EF;
using Portal.EF.Users.Repositories;
using Portal.Extentions;
using Portal.Extentions.Common;
using Portal.Test.Factories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Test.Builders.Users
{
    internal class EditUserBuilder
    {
        private EFInMemoryDatabase _dbMemory;
        private EFdbApplication _db;
        private UserRepository _repository;
        private RoleRepository _roleRepository;
        private UnitOfWork _UnitOfWork;
        private CancellationToken _cancellToken;
        private Guid _userId = Guid.Empty;
        //-----------------------------------------
        private string _mobile = "9107066676";
        private Guid _roleId = Guid.Empty;
        //-----------------------------------------
        public EditUserBuilder()
        {
            _dbMemory = new EFInMemoryDatabase();
            _db = _dbMemory.CreateDataContext<EFdbApplication>();
            _repository = new EFUserRepository(_db);
            _roleRepository = new EFRoleRepository(_db);
            _UnitOfWork = new EFUnitOfWork(_db);
            _cancellToken = new CancellationToken();
           

        }

        public EditUserBuilder WithRoleId(Guid roleId)
        {
            _roleId = roleId;
            return this;
        }
        
        public EditUserDto Arrange()
        {
            _roleId = RoleFactory.GenerateRole(_db).Id;
            var user = UserFactory.GenerateUser(_db, _mobile,_roleId);
            _userId = user.Id;
            var editUser = UserFactory.GenerateEditUserDto(_roleId);
            _db.SaveChanges();
            var roles = _db.Roles.ToList();
            return editUser;
        }

        public async Task<OperationResult<EditUserResponseDto>> Act()
        {
            var request = new EditUserCommand(_userId, Arrange());
            var handler = new EditUserCommandHandler(_repository);
            var response = await handler.Handle(request, _cancellToken);
            await _UnitOfWork.CommitAsync();
            return response;

        }

        public async Task<User> FindById()
        {
            return await _db.Users.FirstAsync();
        }
        


    }
}
