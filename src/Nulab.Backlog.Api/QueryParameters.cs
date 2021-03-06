namespace Nulab.Backlog.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class QueryParameters
    {
        private static readonly string Separator = "&";

        private readonly List<(string key, object value)> _parameters = new List<(string key, object value)>();

        public override string ToString()
        {
            if (_parameters.All(x=> x.value == null)) return string.Empty;
            
            var parameter = ToKeyValuePairs().Select(x => $"{x.Key}={x.Value}").ToArray();

            if (!parameter.Any()) return string.Empty;

            return $"?{string.Join(Separator, parameter)}";
        }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var parameters = _parameters.Where(Valid).ToArray();
            foreach (var (key, value) in parameters)
            {
                var type = value.GetType();

                // yield return の仕様で else if がなくなると挙動が変わる。
                // これはこの形がベスト。
                if (value is bool)
                {
                    yield return new KeyValuePair<string, string>(key, value.ToString().ToLower());
                }
                else if (value is DateTime)
                {
                    yield return new KeyValuePair<string, string>(key, $"{value:yyyy-MM-dd}");
                }
                else if (type.IsArray && type.GetElementType() == typeof(int))
                {
                    // 配列の場合は array[0]=1&array[1]=2&array[3]=9 のようにクエリパラメータを指定しなければならない。
                    var items = (value as int[]).Select((x, i) => new { index = i, value = x }).ToArray();
                    foreach (var item in items)
                    {
                        yield return new KeyValuePair<string, string>($"{key}[{item.index}]", $"{item.value}");
                    }
                }
                else
                {
                    yield return new KeyValuePair<string, string>(key, value.ToString());
                }
            }
        }
        
        private bool Valid((string key, object value) parameter)
        {
            if (parameter.value is null) return false;
            if (parameter.value is string value && string.IsNullOrEmpty(value)) return false;

            return true;
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

        public QueryParameters Add((string key, object value) parameter)
        {
            _parameters.Add(parameter);
            return this;
        }
    }
}