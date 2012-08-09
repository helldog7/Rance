using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

namespace Rance.Tools
{
	/// <summary>
	/// Provides methods to dynamically find and call methods.
	/// </summary>
	public static class MethodCaller
	{
		private const BindingFlags allLevelFlags = BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		private const BindingFlags oneLevelFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		private const BindingFlags ctorFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		#region Dynamic Method Cache

		private static Dictionary<MethodCacheKey, DynamicMethodHandle> _methodCache = new Dictionary<MethodCacheKey, DynamicMethodHandle>();

		private static DynamicMethodHandle GetCachedMethod(object obj, MethodInfo info, params object[] parameters)
		{
			MethodCacheKey key = new MethodCacheKey(obj.GetType().FullName, info.Name, GetParameterTypes(parameters));
			DynamicMethodHandle mh = null;
			if (!_methodCache.TryGetValue(key, out mh))
			{
				lock (_methodCache)
				{
					if (!_methodCache.TryGetValue(key, out mh))
					{
						//mh = new DynamicMethodHandle(info, parameters);
						mh = new DynamicMethodHandle(info);
						_methodCache.Add(key, mh);
					}
				}
			}
			return mh;
		}

		private static DynamicMethodHandle GetCachedMethod(object obj, string method, params object[] parameters)
		{
			MethodCacheKey key = new MethodCacheKey(obj.GetType().FullName, method, GetParameterTypes(parameters));
			DynamicMethodHandle mh = null;
			if (!_methodCache.TryGetValue(key, out mh))
			{
				lock (_methodCache)
				{
					if (!_methodCache.TryGetValue(key, out mh))
					{
						MethodInfo info = GetMethod(obj.GetType(), method, parameters);
						//mh = new DynamicMethodHandle(info, parameters);
						mh = new DynamicMethodHandle(info);
						_methodCache.Add(key, mh);
					}
				}
			}
			return mh;
		}

		#endregion

		#region Dynamic Constructor Cache

		private static Dictionary<Type, DynamicCtorDelegate> _ctorCache = new Dictionary<Type, DynamicCtorDelegate>();

		private static DynamicCtorDelegate GetCachedConstructor(Type objectType)
		{
			DynamicCtorDelegate result = null;
			if (!_ctorCache.TryGetValue(objectType, out result))
			{
				lock (_ctorCache)
				{
					if (!_ctorCache.TryGetValue(objectType, out result))
					{
						ConstructorInfo info =
						  objectType.GetConstructor(ctorFlags, null, Type.EmptyTypes, null);
						result = DynamicMethodHandlerFactory.CreateConstructor(info);
						_ctorCache.Add(objectType, result);
					}
				}
			}
			return result;
		}

		#endregion

		#region Create Instance

		/// <summary>
		/// Uses reflection to create an object using its 
		/// default constructor.
		/// </summary>
		/// <param name="objectType">Type of object to create.</param>
		public static object CreateInstance(Type objectType)
		{
			DynamicCtorDelegate ctor = GetCachedConstructor(objectType);
			if (ctor == null)
				throw new Exception(string.Format("Type:{0} 没有空构造函数", objectType));
			return ctor.Invoke();
		}

		#endregion

		private const BindingFlags propertyFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy;
		private const BindingFlags fieldFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		private static readonly Dictionary<MethodCacheKey, DynamicMemberHandle> _memberCache = new Dictionary<MethodCacheKey, DynamicMemberHandle>();

		internal static DynamicMemberHandle GetCachedProperty(Type objectType, string propertyName)
		{
			MethodCacheKey key = new MethodCacheKey(objectType.FullName, propertyName, GetParameterTypes(null));
			DynamicMemberHandle mh = null;
			if (!_memberCache.TryGetValue(key, out mh))
			{
				lock (_memberCache)
				{
					if (!_memberCache.TryGetValue(key, out mh))
					{
						PropertyInfo info = objectType.GetProperty(propertyName, propertyFlags);
						mh = new DynamicMemberHandle(info);
						_memberCache.Add(key, mh);
					}
				}
			}
			return mh;
		}

		internal static DynamicMemberHandle GetCachedField(Type objectType, string fieldName)
		{
			MethodCacheKey key = new MethodCacheKey(objectType.FullName, fieldName, GetParameterTypes(null));
			DynamicMemberHandle mh = null;
			if (!_memberCache.TryGetValue(key, out mh))
			{
				lock (_memberCache)
				{
					if (!_memberCache.TryGetValue(key, out mh))
					{
						FieldInfo info = objectType.GetField(fieldName, fieldFlags);
						mh = new DynamicMemberHandle(info);
						_memberCache.Add(key, mh);
					}
				}
			}
			return mh;
		}

		/// <summary>
		/// Call Property Getter
		/// </summary>
		/// <param name="obj">object</param>
		/// <param name="property">property name</param>
		public static object CallPropertyGetter(object obj, string property)
		{
			DynamicMemberHandle mh = GetCachedProperty(obj.GetType(), property);
			return mh.DynamicMemberGet(obj);
		}

		/// <summary>
		/// Call Property Setter
		/// </summary>
		/// <param name="obj">object</param>
		/// <param name="property">property name</param>
		/// <param name="value">value</param>
		public static void CallPropertySetter(object obj, string property, object value)
		{
			DynamicMemberHandle mh = GetCachedProperty(obj.GetType(), property);
			object setValue = value;
			if (mh.MemberType != value.GetType())
			{
				if (ReflectionUtilities.IsImplementFromInterface(mh.MemberType, typeof(IConvertible)))
				{
					setValue = Convert.ChangeType(value, mh.MemberType);
				}
			}
			mh.DynamicMemberSet(obj, setValue);
		}


		#region Call Method

		/// <summary>
		/// Uses reflection to dynamically invoke a method
		/// if that method is implemented on the target object.
		/// </summary>
		/// <param name="obj">
		/// Object containing method.
		/// </param>
		/// <param name="method">
		/// Name of the method.
		/// </param>
		/// <param name="parameters">
		/// Parameters to pass to method.
		/// </param>
		public static object CallMethodIfImplemented(object obj, string method, params object[] parameters)
		{
			if (obj == null)
			{
				throw new ArgumentException("obj把计ぃNull");
			}
			if (method == null)
			{
				throw new ArgumentException("method把计ぃNull");
			}

			DynamicMethodHandle mh = GetCachedMethod(obj, method, parameters);
			if (mh == null || mh.DynamicMethod == null)
				return null;
			return CallMethod(obj, mh, parameters);
		}

		/// <summary>
		/// Uses reflection to dynamically invoke a method,
		/// throwing an exception if it is not
		/// implemented on the target object.
		/// </summary>
		/// <param name="obj">
		/// Object containing method.
		/// </param>
		/// <param name="method">
		/// Name of the method.
		/// </param>
		/// <param name="parameters">
		/// Parameters to pass to method.
		/// </param>
		public static object CallMethod(object obj, string method, params object[] parameters)
		{
			if (obj == null)
			{
				throw new ArgumentException("obj把计ぃNull");
			}
			if (method == null)
			{
				throw new ArgumentException("method把计ぃNull");
			}

			DynamicMethodHandle mh = GetCachedMethod(obj, method, parameters);
			if (mh == null || mh.DynamicMethod == null)
			{
				throw new Exception(string.Format("Type:{0} 方法{1}调用错误", obj.GetType(), method));
			}
			return CallMethod(obj, mh, parameters);
		}

		/// <summary>
		/// Uses reflection to dynamically invoke a method,
		/// throwing an exception if it is not
		/// implemented on the target object.
		/// </summary>
		/// <param name="obj">
		/// Object containing method.
		/// </param>
		/// <param name="info">
		/// MethodInfo for the method.
		/// </param>
		/// <param name="parameters">
		/// Parameters to pass to method.
		/// </param>
		public static object CallMethod(object obj, MethodInfo methodInfo, params object[] parameters)
		{
			if (obj == null)
			{
				throw new ArgumentException("obj把计ぃNull");
			}
			if (methodInfo == null)
			{
				throw new ArgumentException("methodInfo把计ぃNull");
			}

			DynamicMethodHandle mh = GetCachedMethod(obj, methodInfo, parameters);
			if (mh == null || mh.DynamicMethod == null)
				throw new Exception(string.Format("Type:{0} 方法:{1} 调用错误", obj.GetType(), methodInfo.Name));
			return CallMethod(obj, mh, parameters);
		}

		/// <summary>
		/// Uses reflection to dynamically invoke a method,
		/// throwing an exception if it is not implemented
		/// on the target object.
		/// </summary>
		/// <param name="obj">
		/// Object containing method.
		/// </param>
		/// <param name="methodHandle">
		/// MethodHandle for the method.
		/// </param>
		/// <param name="parameters">
		/// Parameters to pass to method.
		/// </param>
		[DebuggerStepThrough]
		[DebuggerHidden]
		private static object CallMethod(object obj, DynamicMethodHandle methodHandle, params object[] parameters)
		{
			object result = null;
			DynamicMethodDelegate method = methodHandle.DynamicMethod;

			object[] inParams = null;
			if (parameters == null)
				inParams = new object[] { null };
			else
			{
				inParams = new object[parameters.Length];
				for (int i = 0; i < methodHandle.ParameterInfoList.Length; i++)
				{
					//狦肚把计籔よ猭把计摸璓ê肚把计Τ
					if ((methodHandle.ParameterInfoList[i].ParameterType == parameters[i].GetType()) || (parameters[i] == null))
					{
						inParams[i] = parameters[i];
					}
					//狦肚把计镑锣传よ猭把计ê肚把计Τ
					else if (methodHandle.ParameterInfoList[i].ParameterType.IsAssignableFrom(parameters[i].GetType()))
					{
						inParams[i] = parameters[i];
					}
					else
					{
						if (ReflectionUtilities.IsImplementFromInterface(methodHandle.ParameterInfoList[i].ParameterType, typeof(IConvertible)))
						{
							inParams[i] = Convert.ChangeType(parameters[i], methodHandle.ParameterInfoList[i].ParameterType);
						}
					}
				}
			}

			if (methodHandle.HasFinalArrayParam)
			{
				int pCount = methodHandle.MethodParamsLength;
				// last param is a param array or only param is an array
				int extras = inParams.Length - (pCount - 1);

				// 1 or more params go in the param array
				// copy extras into an array
				object[] extraArray = (object[])System.Array.CreateInstance(typeof(object), extras);
				for (int i = 0; i < extras; i++)
				{
					extraArray[i] = inParams[i];
				}
				//Array.Copy(inParams, extraArray, extras);

				// copy items into new array
				object[] paramList = new object[pCount];
				for (int pos = 0; pos <= pCount - 2; pos++)
					paramList[pos] = parameters[pos];
				paramList[paramList.Length - 1] = extraArray;

				// use new array
				inParams = paramList;
			}
			try
			{
				result = methodHandle.DynamicMethod(obj, inParams);
			}
			catch (Exception ex)
			{
				throw new Exception(methodHandle.MethodName + " 调用错误" , ex);
			}
			return result;
		}

		//private static object[] GetExtrasArray( int count, Type arrayType )
		//{
		//    //if (arrayType.IsArray)
		//    //{
		//    //    return (object[])(System.Array.CreateInstance(arrayType.UnderlyingSystemType, count));
		//    //}
		//    //else
		//    //{
		//    return (object[])(System.Array.CreateInstance(typeof(object), count));
		//    //}
		//}

		#endregion

		#region Get/Find Method

		/// <summary>
		/// Uses reflection to locate a matching method
		/// on the target object.
		/// </summary>
		/// <param name="objectType">
		/// Type of object containing method.
		/// </param>
		/// <param name="method">
		/// Name of the method.
		/// </param>
		/// <param name="parameters">
		/// Parameters to pass to method.
		/// </param>
		public static MethodInfo GetMethod(Type objectType, string method, params object[] parameters)
		{

			MethodInfo result = null;

			object[] inParams = null;
			if (parameters == null)
				inParams = new object[] { null };
			else
				inParams = parameters;

			// try to find a strongly typed match

			// first see if there's a matching method
			// where all params match types
			result = FindMethod(objectType, method, GetParameterTypes(inParams));

			if (result == null)
			{
				// no match found - so look for any method
				// with the right number of parameters
				try
				{
					result = FindMethod(objectType, method, inParams.Length);
				}
				catch (AmbiguousMatchException)
				{
					// we have multiple methods matching by name and parameter count
					result = FindMethodUsingFuzzyMatching(objectType, method, inParams);
				}
			}

			// no strongly typed match found, get default based on name only
			if (result == null)
			{
				result = objectType.GetMethod(method, allLevelFlags);
			}
			return result;
		}

		private static MethodInfo FindMethodUsingFuzzyMatching(Type objectType, string method, object[] parameters)
		{
			MethodInfo result = null;
			Type currentType = objectType;
			do
			{
				MethodInfo[] methods = currentType.GetMethods(oneLevelFlags);
				int parameterCount = parameters.Length;
				// Match based on name and parameter types and parameter arrays
				foreach (MethodInfo m in methods)
				{
					if (m.Name == method)
					{
						ParameterInfo[] infoParams = m.GetParameters();
						int pCount = infoParams.Length;
						if (pCount > 0 &&
						   ((pCount == 1 && infoParams[0].ParameterType.IsArray) ||
						   (infoParams[pCount - 1].GetCustomAttributes(typeof(ParamArrayAttribute), true).Length > 0)))
						{
							// last param is a param array or only param is an array
							if (parameterCount >= pCount - 1)
							{
								// got a match so use it
								result = m;
								break;
							}
						}
					}
				}
				if (result == null)
				{
					// match based on parameter name and number of parameters
					foreach (MethodInfo m in methods)
					{
						if (m.Name == method && m.GetParameters().Length == parameterCount)
						{
							result = m;
							break;
						}
					}
				}
				if (result != null)
					break;
				currentType = currentType.BaseType;
			} while (currentType != null);


			return result;
		}

		/// <summary>
		/// Returns information about the specified
		/// method, even if the parameter types are
		/// generic and are located in an abstract
		/// generic base class.
		/// </summary>
		/// <param name="objectType">
		/// Type of object containing method.
		/// </param>
		/// <param name="method">
		/// Name of the method.
		/// </param>
		/// <param name="types">
		/// Parameter types to pass to method.
		/// </param>
		public static MethodInfo FindMethod(Type objectType, string method, Type[] types)
		{
			MethodInfo info = null;
			do
			{
				// find for a strongly typed match
				info = objectType.GetMethod(method, oneLevelFlags, null, types, null);
				if (info != null)
				{
					break; // match found
				}

				objectType = objectType.BaseType;
			} while (objectType != null);

			return info;
		}

		/// <summary>
		/// Returns information about the specified
		/// method, finding the method based purely
		/// on the method name and number of parameters.
		/// </summary>
		/// <param name="objectType">
		/// Type of object containing method.
		/// </param>
		/// <param name="method">
		/// Name of the method.
		/// </param>
		/// <param name="parameterCount">
		/// Number of parameters to pass to method.
		/// </param>
		public static MethodInfo FindMethod(Type objectType, string method, int parameterCount)
		{
			// walk up the inheritance hierarchy looking
			// for a method with the right number of
			// parameters
			MethodInfo result = null;
			Type currentType = objectType;
			do
			{
				MethodInfo info = currentType.GetMethod(method, oneLevelFlags);
				if (info != null)
				{
					ParameterInfo[] infoParams = info.GetParameters();
					int pCount = infoParams.Length;
					if (pCount > 0 &&
					   ((pCount == 1 && infoParams[0].ParameterType.IsArray) ||
					   (infoParams[pCount - 1].GetCustomAttributes(typeof(ParamArrayAttribute), true).Length > 0)))
					{
						// last param is a param array or only param is an array
						if (parameterCount >= pCount - 1)
						{
							// got a match so use it
							result = info;
							break;
						}
					}
					else if (pCount == parameterCount)
					{
						// got a match so use it
						result = info;
						break;
					}
				}
				currentType = currentType.BaseType;
			} while (currentType != null);

			return result;
		}

		#endregion

		/// <summary>
		/// Returns an array of Type objects corresponding
		/// to the type of parameters provided.
		/// </summary>
		/// <param name="parameters">
		/// Parameter values.
		/// </param>
		public static Type[] GetParameterTypes(object[] parameters)
		{
			List<Type> result = new List<Type>();

			if (parameters == null)
			{
				result.Add(typeof(object));

			}
			else
			{
				foreach (object item in parameters)
				{
					if (item == null)
					{
						result.Add(typeof(object));
					}
					else
					{
						result.Add(item.GetType());
					}
				}
			}
			return result.ToArray();
		}

		///// <summary>
		///// Returns a business object type based on
		///// the supplied criteria object.
		///// </summary>
		///// <param name="criteria">
		///// Criteria object.
		///// </param>
		//public static Type GetObjectType( object criteria )
		//{
		//    var strong = criteria as ICriteria;
		//    if (strong != null)
		//    {
		//        // get the type of the actual business object
		//        // from the ICriteria
		//        return strong.ObjectType;
		//    }
		//    else
		//    {
		//        // get the type of the actual business object
		//        // based on the nested class scheme in the book
		//        return criteria.GetType().DeclaringType;
		//    }
		//}
	}
}
