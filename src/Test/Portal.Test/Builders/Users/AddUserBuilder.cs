using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Portal.Application.Common;
using Portal.Application.Users.Commands.AddUser;
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

namespace Portal.Test.Portal.Application.Test.Users.Command.AddUser;

public class AddUserBuilder
{
    private EFInMemoryDatabase _dbMemory;
    private EFdbApplication _db;
    private UserRepository _repository;
    private RoleRepository _roleRepository;
    private UnitOfWork _UnitOfWork;
    private CancellationToken _cancellToken;
    //-----------------------------------------
    private string _mobile = "9107066676";
    private Guid _roleId = Guid.Empty;
    //-----------------------------------------
    public AddUserBuilder()
    {
        _dbMemory = new EFInMemoryDatabase();
        _db = _dbMemory.CreateDataContext<EFdbApplication>();
        _repository = new EFUserRepository(_db);
        _roleRepository = new EFRoleRepository(_db);
        _UnitOfWork = new EFUnitOfWork(_db);
        _cancellToken = new CancellationToken();
        _roleId = RoleFactory.GenerateRole(_db).Id;
    }
    

    public AddUserBuilder WithMobile(string mobile)
    {
        UserFactory.GenerateUser(_db,_mobile,_roleId);
        
        return this;
    }
    public AddUserBuilder WithRoleId(Guid roleId)
    {
        _roleId = roleId;
        return this;
    }
    public AddUserDto Arange()
    {
        var newUser = UserFactory.GenerateAddUserDto(_mobile,_roleId);
        _db.SaveChanges();
        return newUser;
    }

    public async Task<OperationResult<AddUserResponseDto>> Act()
    {
        var request = new AddUserCommand { User = Arange() };
        var handler = new AddUserCommandHandler(_repository, _roleRepository);
        var response = await handler.Handle(request, _cancellToken);
        await _UnitOfWork.CommitAsync();
        return response;

    }

    public async Task<User> FindUserById(Guid id)
    {
        return await _db.Users.FirstOrDefaultAsync(_ => _.Id == id);
    }

}
