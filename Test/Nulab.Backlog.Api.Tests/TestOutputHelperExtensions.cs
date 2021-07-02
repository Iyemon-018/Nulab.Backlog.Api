namespace Nulab.Backlog.Api.Tests
{
    using System;
    using Xunit.Abstractions;

    internal static class TestOutputHelperExtensions
    {
        public static void WriteLine<T>(this ITestOutputHelper self
                                      , BacklogResponse<T> response)
        {
            self.WriteLine($"Header:{response.RateLimiting}");
            self.WriteLine($"Content:{Environment.NewLine}{response.Content.ToJson()}");
        }
    }
}