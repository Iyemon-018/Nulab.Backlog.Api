namespace Nulab.Backlog.Api.Tests
{
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class QueryParametersTest
    {
        private readonly ITestOutputHelper _outputHelper;

        public QueryParametersTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Test_ToString_初期状態()
        {
            // arrange
            var queryParameters = new QueryParameters();

            // act

            // assert
            queryParameters.ToString().Is(string.Empty);
        }

        [Fact]
        public void Test_ToString_型ごとのパラメータの変換結果()
        {
            // arrange
            var queryParameters = new QueryParameters();

            // act
            var actual = queryParameters.Add("key", 123)
                                        .Add("order", "desc")
                                        .Add("date", new DateTime(2021, 6, 28))
                                        .Add("array", new[] {1, 2, 3})
                                        .ToString();

            // assert
            actual.Is("?key=123&order=desc&date=2021/06/28&array=[1,2,3]");
        }

        [Fact]
        public void Test_ToString_valueがnull()
        {
            // arrange
            var  queryParameters = new QueryParameters();
            int? nullableValue   = null;

            // act
            var actual = queryParameters.Add("stringEmpty", string.Empty)
                                        .Add("nullValue", null)
                                        .Add("nullableValue", nullableValue)
                                        .ToString();

            // assert
            actual.Is(string.Empty);
        }
    }
}