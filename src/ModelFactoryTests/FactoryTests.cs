using System.Linq;
using ByteDecoder.ModelFactory;
using ModelFactoryTests.Factories;
using ModelFactoryTests.Models;
using Xunit;

namespace ModelFactoryTests
{
  public class FactoryTests
  {
    [Fact]
    public void Create_ShouldCreateModel_WhenDataIsProvided()
    {
      // Arrange
      // Act
      var model = ModelFactory<Command>.Create(m =>
      {
        m.Id = 666;
        m.HowTo = "UPDATED";
        m.Platform = "UPDATED";
        m.CommandLine = "UPDATED";
      });

      // Assert
      Assert.NotNull(model);
      Assert.Equal("UPDATED", model.HowTo);
    }

    [Fact]
    public void Create_ShouldCreateModel_WhenMethodIsProvided()
    {
      // Arrange
      // Act
      var model = ModelFactory<Command>.Create(CommandFactory.BasicBuildOne);


      // Assert
      Assert.NotNull(model);
      Assert.Equal("Do Something", model.HowTo);
    }

    [Fact]
    public void Create_ShouldCreateCollection_WhenMethodIsProvided()
    {
      // Arrange
      // Act
      var models = ModelFactory<Command>.Create(2, CommandFactory.BasicBuildOne);


      // Assert
      Assert.NotNull(models);
      Assert.Equal(2, models.Count());
    }
  }
}
