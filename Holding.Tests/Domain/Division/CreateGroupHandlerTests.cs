using Holding.Company.Domain.Division.Queries;
using Holding.Company.Domain.Division.UseCases.Commands;
using Holding.Company.Domain.Division.UseCases.Handlers;

namespace Holding.Tests.Domain.Division;

[TestClass]
public class CreateGroupHandlerTests
{
    private IGroupRepository _repository;
    private readonly CreateGroupHandler _sut;
    private string _companyId;

    public CreateGroupHandlerTests()
    {
        _repository = Helper.GetRequiredService<IGroupRepository>();
        _sut = new CreateGroupHandler(_repository);
        _companyId = Guid.NewGuid().ToString();
    }
    
    [TestMethod]
    public async Task ShouldCreateGroupIsInvalid()
    {
        // Arrange
        var command = new CreateGroupCommand(_companyId, "");
    
        // Act
        var result = await _sut.Handle(command, CancellationToken.None);
    
        // Assert
        Assert.AreEqual(result.Success, false);
    }
}