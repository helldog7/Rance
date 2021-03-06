using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;

namespace Rance.Tools
{
    /// <summary>
    /// 反射工具集
    /// </summary>
	public static class ReflectionUtilities
	{
		#region Get FieldInfo

        /// <summary>
        /// 獲取所有FieldInfo
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>FieldInfo列表</returns>
		public static FieldInfo[] GetAllFieldInfo(Type type)
		{
			return GetFieldsLimitToParentType(type, typeof(object), true);
		}

        /// <summary>
        /// 獲取FieldInfo列表,只獲取至parent type
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <returns>FieldInfo列表</returns>
		public static FieldInfo[] GetFieldsLimitToParentType(Type type, Type parentType)
		{
			return GetFieldsLimitToParentType(type, parentType, false);
		}


        /// <summary>
        /// 獲取FieldInfo列表,只獲取至parent type(不包括parent type)
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <returns>FieldInfo列表</returns>
        public static FieldInfo[] GetFieldsLimitLessToParentType( Type type, Type parentType )
        {
            return GetFieldsLimitLessToParentType(type, parentType, false);
        }

        /// <summary>d
        /// 獲取FieldInfo列表,只獲取至parent type
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <param name="suppressExceptions">是否不抛出異常</param>
        /// <returns>FieldInfo列表</returns>
		public static FieldInfo[] GetFieldsLimitToParentType(Type type, Type parentType, bool suppressExceptions)
		{
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            if (parentType == null)
            {
                throw new ArgumentException("parentType不能為空");
            }

			if (type != parentType && !type.IsSubclassOf(parentType))
			{
				if (!suppressExceptions)
                    throw new ArgumentException(string.Format("父类:{0},子类{1},错误", type, parentType));
				return null;
			}

			List<FieldInfo> result = new List<FieldInfo>();
			List<string> keyList = new List<string>();
            List<Type> typeList = getTypeListLimitToParent(type, parentType);
			while (true)
			{
				FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
                    if (!typeList.Contains(fieldInfo.DeclaringType))
                    {
                        continue;
                    }

					if (!keyList.Contains(fieldInfo.Name))
					{
						result.Add(fieldInfo);
						keyList.Add(fieldInfo.Name);
					}
				}

				if (type == parentType)
				{
					break;
				}
				else
				{
					type = type.BaseType;
				}

				if (type == null)
				{
					break;
				}
			}

			return result.ToArray();
		}

        /// <summary>d
        /// 獲取FieldInfo列表,只獲取至parent type(不包括parent type)
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <param name="suppressExceptions">是否不抛出異常</param>
        /// <returns>FieldInfo列表</returns>
        public static FieldInfo[] GetFieldsLimitLessToParentType( Type type, Type parentType, bool suppressExceptions )
        {
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            if (parentType == null)
            {
                throw new ArgumentException("parentType不能為空");
            }

            if (type != parentType && !type.IsSubclassOf(parentType))
            {
                if (!suppressExceptions)
                    throw new ArgumentException(string.Format("父类:{0},子类{1},错误", type, parentType));
                return null;
            }

            List<FieldInfo> result = new List<FieldInfo>();
            List<string> keyList = new List<string>();
            List<Type> typeList = getTypeListLimitLessToParent(type, parentType);
            while (true)
            {
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (FieldInfo fieldInfo in fields)
                {
                    if (!typeList.Contains(fieldInfo.DeclaringType))
                    {
                        continue;
                    }

                    if (!keyList.Contains(fieldInfo.Name))
                    {
                        result.Add(fieldInfo);
                        keyList.Add(fieldInfo.Name);
                    }
                }

                if (type == parentType)
                {
                    break;
                }
                else
                {
                    type = type.BaseType;
                }

                if (type == null)
                {
                    break;
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 獲取FieldInfo
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="fieldName">field name</param>
        /// <returns>指定FieldInfo</returns>
		public static FieldInfo GetFieldInfo(Type type, string fieldName)
		{
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            
			Type temp = type;

			while (temp != null)
			{
				FieldInfo[] fieldsInfo = temp.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fieldsInfo)
				{
					if (fieldInfo.Name == fieldName)
					{
						return fieldInfo;
					}
				}

				temp = temp.BaseType;
			}

			return null;
		}

		#endregion

		#region Get PropertyInfo

        /// <summary>
        /// 獲取所有PropertyInfo
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>PropertyInfo列表</returns>
		public static PropertyInfo[] GetAllPropertyInfo(Type type)
		{
			return GetPropertiesLimitToParentType(type, typeof(object), true);
		}

        /// <summary>
        /// 獲取PropertyInfo列表,只獲取至parent type
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <returns>PropertyInfo列表</returns>
		public static PropertyInfo[] GetPropertiesLimitToParentType(Type type, Type parentType)
		{
			return GetPropertiesLimitToParentType(type, parentType, false);
		}

        /// <summary>
        /// 獲取PropertyInfo列表,只獲取至parent type(不包括parent type)
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <returns>PropertyInfo列表</returns>
        public static PropertyInfo[] GetPropertiesLimitLessToParentType( Type type, Type parentType )
        {
            return GetPropertiesLimitLessToParentType(type, parentType, false);
        }

        /// <summary>
        /// 獲取PropertyInfo列表,只獲取至parent type
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <param name="suppressExceptions">是否不抛出異常</param>
        /// <returns>PropertyInfo列表</returns>
		public static PropertyInfo[] GetPropertiesLimitToParentType(Type type, Type parentType, bool suppressExceptions)
		{
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            if (parentType == null)
            {
                throw new ArgumentException("parentType不能為空");
            }

			if (type != parentType && !type.IsSubclassOf(parentType))
			{
				if (!suppressExceptions)
                    throw new ArgumentException(string.Format("父类:{0},子类{1},错误", type, parentType));
				return null;
			}

			List<PropertyInfo> result = new List<PropertyInfo>();
			List<string> keyList = new List<string>();
            List<Type> typeList = getTypeListLimitToParent(type, parentType);
            while (true)
			{
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
				foreach (PropertyInfo propertyInfo in properties)
				{
                    if (!typeList.Contains(propertyInfo.DeclaringType))
                    {
                        continue;
                    }

					if (!keyList.Contains(propertyInfo.Name))
					{
						result.Add(propertyInfo);
						keyList.Add(propertyInfo.Name);
					}
				}

				if (type == parentType)
				{
					break;
				}
				else
				{
					type = type.BaseType;
				}

				if (type == null)
				{
					break;
				}
			}

			return result.ToArray();
		}

        /// <summary>
        /// 獲取PropertyInfo列表,只獲取至parent type,不包括Parent Type
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <param name="suppressExceptions">是否不抛出異常</param>
        /// <returns>PropertyInfo列表</returns>
        public static PropertyInfo[] GetPropertiesLimitLessToParentType( Type type, Type parentType, bool suppressExceptions )
        {
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            if (parentType == null)
            {
                throw new ArgumentException("parentType不能為空");
            }

            if (type != parentType && !type.IsSubclassOf(parentType))
            {
                if (!suppressExceptions)
                    throw new ArgumentException(string.Format("父类:{0},子类{1},错误", type, parentType));
                return null;
            }

            List<PropertyInfo> result = new List<PropertyInfo>();
            List<string> keyList = new List<string>();
            List<Type> typeList = getTypeListLimitLessToParent(type, parentType);
            while (true)
            {
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (PropertyInfo propertyInfo in properties)
                {
                    if (!typeList.Contains(propertyInfo.DeclaringType))
                    {
                        continue;
                    }

                    if (!keyList.Contains(propertyInfo.Name))
                    {
                        result.Add(propertyInfo);
                        keyList.Add(propertyInfo.Name);
                    }
                }

                if (type == parentType)
                {
                    break;
                }
                else
                {
                    type = type.BaseType;
                }

                if (type == null)
                {
                    break;
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 獲取PropertyInfo
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="propertyName">property name</param>
        /// <returns>指定PropertyInfo</returns>
		public static PropertyInfo GetPropertyInfo(Type type, string propertyName)
		{
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            
			Type temp = type;

			while (temp != null)
			{
				PropertyInfo[] propertiesInfo = temp.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (PropertyInfo propertyInfo in propertiesInfo)
				{
					if (propertyInfo.Name == propertyName)
					{
						return propertyInfo;
					}
				}

				temp = temp.BaseType;
			}

			return null;
		}

		#endregion

        #region Get MethodInfo

        /// <summary>
        /// 獲取所有MethodInfo
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>MethodInfo列表</returns>
        public static MethodInfo[] GetAllMethodInfo(Type type)
        {
            return GetMethodsLimitToParentType(type, typeof(object), true);
        }

        /// <summary>
        /// 獲取MethodInfo列表,只獲取至parent type
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <returns>MethodInfo列表</returns>
        public static MethodInfo[] GetMethodsLimitToParentType(Type type, Type parentType)
        {
            return GetMethodsLimitToParentType(type, parentType, false);
        }

        /// <summary>
        /// 獲取MethodInfo列表,只獲取至parent type
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parentType">parent type</param>
        /// <param name="suppressExceptions">是否不抛出異常</param>
        /// <returns>MethodInfo列表</returns>
        public static MethodInfo[] GetMethodsLimitToParentType(Type type, Type parentType, bool suppressExceptions)
        {
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            if (parentType == null)
            {
                throw new ArgumentException("parentType不能為空");
            }

            if (type != parentType && !type.IsSubclassOf(parentType))
            {
                if (!suppressExceptions)
                    throw new ArgumentException(string.Format("Type:{0} Parent:{1} 错误", type, parentType));
                return null;
            }

            List<MethodInfo> result = new List<MethodInfo>();
            List<string> keyList = new List<string>();
            while (true)
            {
                MethodInfo[] properties = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (MethodInfo methodInfo in properties)
                {
                    StringBuilder keySB = new StringBuilder();
                    keySB.Append(methodInfo.Name);
                    foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
                    {
                        keySB.Append(string.Format("/{0}", parameterInfo.ParameterType));
                    }
                    string key = keySB.ToString();

                    if (!keyList.Contains(key))
                    {
                        result.Add(methodInfo);
                        keyList.Add(key);
                    }
                }

                if (type == parentType)
                {
                    break;
                }
                else
                {
                    type = type.BaseType;
                }

                if (type == null)
                {
                    break;
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 獲取MethodInfo
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="methodName">method name</param>
        /// <returns>指定MethodInfo</returns>
        public static MethodInfo GetMethodInfo(Type type, string methodName)
        {
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }

            Type temp = type;

            while (temp != null)
            {
                MethodInfo[] methodsInfo = temp.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                foreach (MethodInfo methodInfo in methodsInfo)
                {
                    if (methodInfo.Name == methodName && methodInfo.GetParameters().Length == 0)
                    {
                        return methodInfo;
                    }
                }

                temp = temp.BaseType;
            }

            return null;
        }

        /// <summary>
        /// 獲取MethodInfo
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="methodName">method name</param>
        /// <returns>指定MethodInfo</returns>
        public static MethodInfo[] GetMethodInfoWithoutParameter(Type type, string methodName)
        {
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            
            Type temp = type;

            List<MethodInfo> list = new List<MethodInfo>();

            while (temp != null)
            {
                MethodInfo[] methodsInfo = temp.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                foreach (MethodInfo methodInfo in methodsInfo)
                {
                    if (methodInfo.Name == methodName)
                    {
                        list.Add(methodInfo);
                    }
                }

                temp = temp.BaseType;
            }

            return list.ToArray();
        }

        /// <summary>
        /// 獲取MethodInfo
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="methodName">method name</param>
        /// <param name="parameterTypeList">參數類型列表</param>
        /// <returns>指定MethodInfo</returns>
        public static MethodInfo GetMethodInfo(Type type, string methodName , Type[] parameterTypeList)
        {
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            
            Type temp = type;

            while (temp != null)
            {
                MethodInfo[] methodsInfo = temp.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                foreach (MethodInfo methodInfo in methodsInfo)
                {
                    if (methodInfo.Name == methodName)
                    {
                        ParameterInfo[] parametersInfo = methodInfo.GetParameters();
                        if (parametersInfo.Length != parameterTypeList.Length)
                        {
                            continue;
                        }

                        for (int i = 0; i < parametersInfo.Length; i++)
                        {
                            if (parameterTypeList[i] != parametersInfo[i].ParameterType)
                            {
                                if (!parameterTypeList[i].IsSubclassOf(parametersInfo[i].ParameterType))
                                {
                                    if (!IsImplementFromInterface( parameterTypeList[i] ,parametersInfo[i].ParameterType))
                                    {
                                        goto continueForeachMethodInfo;
                                    }
                                }
                            }   
                        }

                        return methodInfo;

                    continueForeachMethodInfo:
                        continue;
                    }
                }

                temp = temp.BaseType;
            }

            return null;
        }
            
        #endregion

        #region Get Type

        /// <summary>
		/// Returns a property's type, dealing with
		/// Nullable(Of T) if necessary.
		/// </summary>
		/// <param name="propertyType">Type of the
		/// property as returned by reflection.</param>
		public static Type GetPropertyType(Type propertyType)
		{
            if (propertyType == null)
            {
                throw new ArgumentException("propertyType不能為空");
            }

			Type type = propertyType;
			if (type.IsGenericType &&
			  (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
				return Nullable.GetUnderlyingType(type);
			return type;
		}

		/// <summary>
		/// Returns the type of child object
		/// contained in a collection or list.
		/// </summary>
		/// <param name="listType">Type of the list.</param>
		public static Type GetChildItemType(Type listType)
		{
            if (listType == null)
            {
                throw new ArgumentException("listType不能為空");
            }

			Type result = null;
			if (listType.IsArray)
				result = listType.GetElementType();
			else
			{
				DefaultMemberAttribute indexer =
				  (DefaultMemberAttribute)System.Attribute.GetCustomAttribute(
				  listType, typeof(DefaultMemberAttribute));
				if (indexer != null)
					foreach (PropertyInfo prop in listType.GetProperties(
					  BindingFlags.Public |
					  BindingFlags.Instance |
					  BindingFlags.FlattenHierarchy))
					{
						if (prop.Name == indexer.MemberName)
							result = ReflectionUtilities.GetPropertyType(prop.PropertyType);
					}
			}
			return result;
		}

		#endregion

		#region Get MemerInfo（FieldInfo & PropertyInfo）

        /// <summary>
        /// 獲取所有Field
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
		public static Field[] GetFieldList(Type type)
		{
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }

			List<Field> array = new List<Field>();
			FieldInfo[] fieldInfoes = GetAllFieldInfo(type);
			foreach(FieldInfo fieldInfo in fieldInfoes)
			{
				Field field = MemberFactory.GetField(fieldInfo);
				array.Add(field);
			}
			return array.ToArray();
		}

        /// <summary>
        /// 獲取所有Property
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
		public static Property[] GetPropertyList(Type type)
		{
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }

			List<Property> array = new List<Property>();
			PropertyInfo[] propertyInfoes = GetAllPropertyInfo(type);
			foreach(PropertyInfo propertyInfo in propertyInfoes)
			{
                Property property = MemberFactory.GetProperty(propertyInfo);
				array.Add(property);
			}
			return array.ToArray();
		}

        /// <summary>
        /// 獲取所有Field和Property
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
		public static IList<IMember> GetMemberList(Type type)
		{
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }

			List<IMember> memberList = new List<IMember>();
			memberList.AddRange(GetFieldList(type));
			memberList.AddRange(GetPropertyList(type));
			return memberList;
		}

        /// <summary>
        /// 獲取Field or Property （同名 field 優先）
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="memberName">name</param>
        /// <returns></returns>
		public static IMember GetMember(Type type, string memberName)
		{
            if (type == null)
            {
                throw new ArgumentException("type不能為空");
            }
            if (memberName == null)
            {
                throw new ArgumentException("memberName不能為空");
            }

			FieldInfo fieldinfo = GetFieldInfo(type, memberName);
			if(fieldinfo != null)
			{
				return MemberFactory.GetField(fieldinfo);
			}

			PropertyInfo propertyInfo = GetPropertyInfo(type, memberName);
			if(propertyInfo != null)
			{
                return MemberFactory.GetProperty(propertyInfo);
			}


			return null;
		}		
		
		#endregion

		#region Inner Method

		private static List<Type> getTypeListLimitToParent( Type type, Type parentType )
        {
            List<Type> typeList = new List<Type>();

            Type currentType = type;
            while (currentType != null && (currentType.IsSubclassOf(parentType) || currentType == parentType))
            {
                typeList.Add(currentType);

                currentType = currentType.BaseType;
            }

            return typeList;
        }

        private static List<Type> getTypeListLimitLessToParent( Type type, Type parentType )
        {
            List<Type> typeList = new List<Type>();

            Type currentType = type;
            while (currentType != null && currentType.IsSubclassOf(parentType))
            {
                typeList.Add(currentType);

                currentType = currentType.BaseType;
            }

            return typeList;
        }

        #endregion

        #region Interface

        /// <summary>
        /// 是否從指定Inteface擴展
        /// </summary>
        /// <param name="objectType">object type</param>
        /// <param name="interfaceType">interface type</param>
        /// <returns></returns>
        public static bool IsImplementFromInterface( Type objectType, Type interfaceType )
        {
            Type[] interfaces = objectType.GetInterfaces();

            foreach (Type _interface in interfaces)
            {
                if (_interface == interfaceType)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
