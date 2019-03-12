using System;
using System.Reflection;

public static class GetNonPublicMember
{
    // For .Net
    public static object ByPropertyName(object instance, string nameOfMember)
    {
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        Type type = instance.GetType();
        PropertyInfo propertyInfo = type.GetProperty(nameOfMember, bindingFlags); //以指定的條件搜尋屬性
        return propertyInfo.GetValue(instance, null); //得到此 instance 的指定屬性
    }

    // For .NetCore
    public static object ByPropertyName(Type type, object instance, string fieldName)
    {
        BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Static;
        FieldInfo field = type.GetField(fieldName, bindFlags);
        return field.GetValue(instance);
    }
}