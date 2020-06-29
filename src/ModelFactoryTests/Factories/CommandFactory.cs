using ModelFactoryTests.Models;

namespace ModelFactoryTests.Factories
{
  internal static class CommandFactory
  {
    internal static void BasicBuildOne(Command cmd)
    {
      cmd.HowTo = "Do Something";
      cmd.Platform = "Some Platform";
      cmd.CommandLine = "Some Command";
    }
  }
}
