namespace Wpf_DB.Database
{
    public class SqlParameter
    {
        private string _parameterName;
        private object _value;

        public string ParameterName => _parameterName;
        public object Value => _value;

        public SqlParameter(string parameterName, object value)
        {
            _parameterName = parameterName;
            _value = value;
        }
    }
}