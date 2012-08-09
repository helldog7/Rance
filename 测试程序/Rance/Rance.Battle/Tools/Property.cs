using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Rance.Tools
{
    /// <summary>
    /// 封裝PropertyInfo
    /// </summary>
    public class Property : IMember
    {
        /// <summary>
        /// 封裝PropertyInfo,獲取一個新的Property實體
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo</param>
        public Property( System.Reflection.PropertyInfo propertyInfo )
        {
            if (propertyInfo == null)
            {
                throw new ArgumentException("propertyInfo不能為空");
            }

            this.propertyInfo = propertyInfo;
            this.dynamicMemberHandle = new DynamicMemberHandle(propertyInfo);
        }

        private System.Reflection.PropertyInfo propertyInfo;
        private DynamicMemberHandle dynamicMemberHandle;

        #region IMember 成員

        /// <summary>
        /// 讀取資料
        /// </summary>
        /// <param name="target">讀取資料的目標</param>
        /// <returns>讀取的資料</returns>
        object IMember.GetValue( object target )
        {
            try
            {
                return dynamicMemberHandle.DynamicMemberGet(target);
                //return propertyInfo.GetValue(target, null);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Type:{0}取Property:{1}出覃蚚渣昫", ReflectedType, propertyInfo.Name), e);
            }
        }

        /// <summary>
        /// 寫入資料
        /// </summary>
        /// <param name="target">寫入資料的目標</param>
        /// <param name="value">寫入的資料</param>
        void IMember.SetValue( object target, object value )
        {
            try
            {
                object setValue = value;
				//如果要寫入的值，與屬性的類型不一致，那么判斷能否自動轉換。比如float值和double類型。
				if (value != null && dynamicMemberHandle.MemberType != value.GetType())
                {
                    if (ReflectionUtilities.IsImplementFromInterface(dynamicMemberHandle.MemberType, typeof(IConvertible)))
                    {
                        setValue = Convert.ChangeType(value, dynamicMemberHandle.MemberType);
                    }
                    else if(value is DBNull)
                    {
                        setValue = null;
                    }
                }
                dynamicMemberHandle.DynamicMemberSet(target, setValue);
                //propertyInfo.SetValue(target, value, null);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Type:{0} Property:{1}出覃蚚渣昫", ReflectedType, propertyInfo.Name), e);
            }
        }

        /// <summary>
        /// 名稱
        /// </summary>
        /// <value></value>
        public string Name
        {
            get
            {
                return propertyInfo.Name;
            }
        }

        /// <summary>
        /// 取得類別物件，是用來取得這個 Member 的執行個體
        /// </summary>
        /// <value></value>
        public Type ReflectedType
        {
            get
            {
                return propertyInfo.ReflectedType;
            }
        }

        /// <summary>
        /// 取得這個Member物件的型別。
        /// </summary>
        /// <value></value>
        public Type Type
        {
            get
            {
                return propertyInfo.PropertyType;
            }
        }

        /// <summary>
        /// 是否可以讀取
        /// </summary>
        /// <value></value>
        public bool CanRead
        {
            get
            {
                return propertyInfo.CanRead;
            }
        }

        /// <summary>
        /// 是否可以寫入
        /// </summary>
        /// <value></value>
        public bool CanWrite
        {
            get
            {
                return propertyInfo.CanWrite;
            }
        }

        /// <summary>
        /// Member的類型
        /// </summary>
        /// <value></value>
        public MemberType MemberType
        {
            get
            {
                return MemberType.Property;
            }
        }

        /// <summary>
        /// 這個方法用於從 Unmanaged 程式碼存取 Managed 類別，並且不應該從 Managed 程式碼中呼叫。GetCustomAttributes 方法會取得這個組件的所有自訂屬性。
        /// </summary>
        /// <param name="attributeType">Type，要為其傳回自訂屬性</param>
        /// <param name="inherit">Assembly 型別的物件會忽略這個引數。</param>
        /// <returns>
        /// Object 型別的陣列，包含這個組件由 attributeType 指定的自訂屬性。
        /// </returns>
        public object[] GetCustomAttributes( Type attributeType, bool inherit )
        {
            return this.propertyInfo.GetCustomAttributes(attributeType, inherit);
        }

        #endregion
    }
}
