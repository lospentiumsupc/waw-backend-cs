using System.Globalization;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace WAW.API.Tests.Hooks;

[Binding]
public sealed class SharedHooks {
  [BeforeTestRun]
  public static void BeforeTestRun() {
    DateTimeValueRetriever.DateTimeStyles = DateTimeStyles.AssumeUniversal;
  }
}
