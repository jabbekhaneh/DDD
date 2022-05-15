using FluentAssertions;
using Portal.Test.Builders.Users;
using Portal.Test.Factories;
using System.Threading.Tasks;
using Xunit;

namespace Portal.Test.Portal.Application.Test.Users.Command.EditUser;

public class EditUserTest
{
    private EditUserBuilder _builder;
    public EditUserTest()
    {
        _builder = new EditUserBuilder();
    }
    [Fact]
    private async Task Edit_user_success()
    {
        var arrange = _builder.Arrange();

        var actual = await _builder.Act();

        var expected =await _builder.FindById();
        expected.Firstname.Should().Be(arrange.Firstname);
        expected.Lastname.Should().Be(arrange.Lastname);
        expected.Email.Should().Be(arrange.Email);
        


    }
}
