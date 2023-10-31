namespace ProcessorFactoryPOC.Validators
{
    public static class TypeValidator
    {
        public static bool CanBeCastedAs<T>(object obj) => obj is T;
        public static void GenerateException<T>(object obj) => throw new InvalidCastException($"Cannot cast {obj?.GetType().Name} to {typeof(T).Name}");

        public static T ConvertTo<T>(object obj)
        {
            if (CanBeCastedAs<T>(obj))
            {
                return (T)obj;
            }
            else if (obj is not null && obj.GetType().IsAnonymousType())
            {
                return ConvertAnonymousTypeTo<T>(obj);
            }
            else
            {
                GenerateException<T>(obj);
                return default; //unreachable line of code. 
            }
        }


        private static T ConvertAnonymousTypeTo<T>(object _obj)
        {
            Type targetType = typeof(T);
            var propertyDict = _obj.GetType()
                .GetProperties()
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(_obj));

            T result = Activator.CreateInstance<T>();

            foreach (var prop in targetType.GetProperties())
            {
                if (propertyDict.ContainsKey(prop.Name))
                {
                    prop.SetValue(result, propertyDict[prop.Name]);
                }
            }

            return result;
        }
    }


    public static class TypeExtensions
    {
        public static bool IsAnonymousType(this Type type)
        {
            return type.IsClass &&
                   type.IsSealed &&
                   type.BaseType == typeof(object) &&
                   type.Name.StartsWith("<>") &&
                   type.Name.Contains("AnonymousType");
        }
    }

}
