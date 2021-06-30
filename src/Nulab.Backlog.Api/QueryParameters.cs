namespace Nulab.Backlog.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class QueryParameters
    {
        private static readonly string Separator = "&";

        private readonly List<(string key, object value)> _parameters = new List<(string key, object value)>();

        public override string ToString()
        {
            if (_parameters.All(x=> x.value == null)) return string.Empty;

            var parameter = _parameters.Where(Valid).Select(ToValue).ToArray();

            if (!parameter.Any()) return string.Empty;

            return $"?{string.Join(Separator, parameter)}";
        }

        private bool Valid((string key, object value) parameter)
        {
            if (parameter.value is null) return false;
            if (parameter.value is string value && string.IsNullOrEmpty(value)) return false;

            return true;
        }

        private string ToValue((string key, object value) parameter)
        {
            var type = parameter.value.GetType();

            if (parameter.value is bool) return $"{parameter.key}={parameter.value.ToString().ToLower()}";

            if (parameter.value is DateTime) return $"{parameter.key}={parameter.value:yyyy/MM/dd}";

            // 配列の場合は array[0]=1&array[1]=2&array[3]=9 のようにクエリパラメータを指定しなければならない。
            if (type.IsArray && type.GetElementType() == typeof(int))
                return string.Join(Separator, ((int[]) parameter.value).Select((x, i) => ToValue(($"{parameter.key}[{i}]", x))));

            return $"{parameter.key}={parameter.value}";
        }

        public static QueryParameters Build(string name, object value)
        {
            return new QueryParameters().Add(name, value);
        }

        public QueryParameters Add(string name, object value)
        {
            _parameters.Add((name, value));
            return this;
        }

        public void Add((string key, object value) parameter)
        {
            _parameters.Add(parameter);
        }
    }
}