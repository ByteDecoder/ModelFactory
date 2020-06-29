![.NET Core](https://github.com/ByteDecoder/ModelFactory/workflows/.NET%20Core/badge.svg?branch=master)

# ModelFactory

Easy way to create Models for use in Test Suites

Targeted to .Net Core 3.1

## Installation

Install the [ModelFactory NuGet Package](https://www.nuget.org/packages/ModelFactory).

### Package Manager Console

```
Install-Package ModelFactory
```

### .NET Core CLI

```
dotnet add package ModelFactory
```

## Examples and usage

An easy way to define data for models is creating in your test project, internal static classes that define custom data for
your models, and then create instances of these model data templates for testing, minimizing code duplication, extensibility and 
maintainability via the ModelFactory.

You can create a single instance or a collection of a given type **T**

```csharp

public class Command
{
  public int Id { get; set; }
  public string HowTo { get; set; }
  public string Platform { get; set; }
  public string CommandLine { get; set; }
}

internal static class CommandFactory
{
  internal static void BasicBuildOne(Command cmd)
  {
    cmd.HowTo = "Do Something";
    cmd.Platform = "Some Platform";
    cmd.CommandLine = "Some Command";
  }
}

// Now, creating model instances with ModelFactory

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

// Also, you can define inline the model data as well
var model = ModelFactory<Command>.Create(m =>
  {
    m.Id = 666;
    m.HowTo = "UPDATED";
    m.Platform = "UPDATED";
    m.CommandLine = "UPDATED";
  });

```

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/ByteDecoder/ModelFactory.


Copyright (c) 2020 [Rodrigo Reyes](https://twitter.com/bytedecoder) released under the MIT license
