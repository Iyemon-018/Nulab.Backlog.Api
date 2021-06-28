namespace Nulab.Backlog.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class QueryParameters
    {
        private readonly List<(string key, object value)> _parameters = new List<(string key, object value)>();

        public override string ToString()
        {
            if (_parameters.All(x=> x.value == null)) return string.Empty;

            var parameter = _parameters.Where(Valid).Select(x => $"{x.key}={ToValue(x.value)}").ToArray();

            if (!parameter.Any()) return string.Empty;

            return $"?{string.Join("&", parameter)}";
        }

        private bool Valid((string key, object value) parameter)
        {
            if (parameter.value is null) return false;
            if (parameter.value is string value && string.IsNullOrEmpty(value)) return false;

            return true;
        }

        private string ToValue(object value)
        {
            var type = value.GetType();

            if (value is bool) return $"{value.ToString().ToLower()}";
            if (value is DateTime) return $"{value:yyyy/MM/dd}";
            if (type.IsArray && type.GetElementType() == typeof(int)) return $"[{string.Join(",", (int[])value)}]";
            return value.ToString();
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