using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Rance.Tools
{
    /// <summary>
    /// Member Factory
    /// </summary>
    public static class MemberFactory
    {
        private static Dictionary<FieldInfo, Field> fieldCache = new Dictionary<FieldInfo, Field>();
        private static Dictionary<PropertyInfo, Property> propertyCache = new Dictionary<PropertyInfo, Property>();

        private static object syncObj = new object();

        /// <summary>
        /// 獲取Member
        /// </summary>
        /// <param name="fieldInfo">FieldInfo</param>
        /// <returns>封裝的Member</returns>
        public static Field GetField( FieldInfo fieldInfo )
        {
            if (fieldInfo == null)
            {
                throw new ArgumentException("fieldInfo不能為空");
            }

            lock (syncObj)
            {
                if (fieldCache.ContainsKey(fieldInfo))
                {
                    return fieldCache[fieldInfo];
                }
                else
                {
                    Field field = new Field(fieldInfo);
                    fieldCache.Add(fieldInfo, field);

                    return field;
                }
            }
        }

        /// <summary>
        /// 獲取Member
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo</param>
        /// <returns>封裝的Member</returns>
        public static Property GetProperty( PropertyInfo propertyInfo )
        {
            if (propertyInfo == null)
            {
                throw new ArgumentException("propertyInfo不能為空");
            }

            lock (syncObj)
            {
                if (propertyCache.ContainsKey(propertyInfo))
                {
                    return propertyCache[propertyInfo];
                }
                else
                {
                    Property property = new Property(propertyInfo);
                    propertyCache.Add(propertyInfo, property);

                    return property;
                }
            }
        }

        /// <summary>
        /// 獲取Member
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="propertyOrFieldName">property or field name</param>
        /// <returns>封裝的Member</returns>
        public static IMember GetMember(Type type, string propertyOrFieldName)
        {
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            if (propertyOrFieldName == null)
            {
                throw new ArgumentException("propertyOrFieldName不能為空");
            }

            FieldInfo fieldInfo = ReflectionUtilities.GetFieldInfo(type, propertyOrFieldName);
            if (fieldInfo != null)
            {
                return GetField(fieldInfo);
            }
            else
            {
                PropertyInfo propertyInfo = ReflectionUtilities.GetPropertyInfo(type, propertyOrFieldName);

                if (propertyInfo != null)
                {
                    return GetProperty(propertyInfo);
                }
                else
                {
                    throw new Exception(string.Format("Type:{0} 扽俶:{1} 羶衄梑善", type, propertyOrFieldName));
                }
            }
        }
    }
}
