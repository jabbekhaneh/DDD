using FluentAssertions;
using Portal.Extentions.Common;
using Portal.Test.Factories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Portal.Test.Portal.Application.Test.Users.Command.AddUser;

public class AddUserTest
{
    private AddUserBuilder _builder; 
    public AddUserTest()
    {
        _builder=new AddUserBuilder();
    }

    [Fact]
    private async Task Add_user_success_property()
    {
        var arrange= _builder.Arange();

        var actual= await _builder.Act();

        var expected = await _builder.FindUserById(actual.Result.UserId);
        actual.IsSuccess.Should().BeTrue();
        expected.Firstname.Should().Be(arrange.Firsname);
        expected.Lastname.Should().Be(arrange.Lastname);
        expected.Mobile.Should().Be(arrange.Mobile);
    }
    [Fact]
    private async Task Add_user_exception_when_notfound_roleId()
    {
        var arrange = _builder.WithRoleId(Guid.NewGuid()).Arange();

        var actual = await _builder.Act();
        
        actual.IsSuccess.Should().BeFalse();
        actual.Status.Should().Be(ExceptionStatusCodeType.NotFoundRole);
    }
    [Fact]
    private async Task Add_user_exception_when_dublicate_mobile()
    {
        
        var arrange = _builder.WithMobile("9179159387").Arange();

        var actual = await _builder.Act();

        actual.IsSuccess.Should().BeFalse();
        actual.Status.Should().Be(ExceptionStatusCodeType.DublicateMobile);
    }
}
