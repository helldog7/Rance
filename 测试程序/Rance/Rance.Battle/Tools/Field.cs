using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Rance.Tools
{
    /// <summary>
    /// 封裝FieldInfo
    /// </summary>
    public class Field : IMember
    {
        /// <summary>
        /// 封裝FieldInfo,獲取一個新的Field實體
        /// </summary>
        /// <param name="fieldInfo">FieldInfo</param>
        public Field( System.Reflection.FieldInfo fieldInfo )
        {
            if (fieldInfo == null)
            {
                throw new ArgumentException("fieldInfo不能為空");
            }

            this.fieldInfo = fieldInfo;
            this.dynamicMemberHandle = new DynamicMemberHandle(fieldInfo);
        }

        private System.Reflection.FieldInfo fieldInfo;
        private DynamicMemberHandle dynamicMemberHandle;

        #region IMember 成員

        /// <summary>
        /// 讀取資料
        /// </summary>
        /// <param name="target">讀取資料的目標</param>
        /// <returns>讀取的資料</returns>
        public object GetValue( object target )
        {
            try
            {
                return dynamicMemberHandle.DynamicMemberGet(target);
                //return fieldInfo.GetValue(target);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Type:{0}取Field:{1}出覃蚚渣昫", ReflectedType, fieldInfo.Name), e);
            }
        }

        /// <summary>
        /// 寫入資料
        /// </summary>
        /// <param name="target">寫入資料的目標</param>
        /// <param name="value">寫入的資料</param>
        public void SetValue( object target, object value )
        {
            try
            {
                object setValue = value;
                if (value != null && dynamicMemberHandle.MemberType != value.GetType())
                {
                    if (ReflectionUtilities.IsImplementFromInterface(dynamicMemberHandle.MemberType, typeof(IConvertible)))
                    {
                        setValue = Convert.ChangeType(value, dynamicMemberHandle.MemberType);
                    }
                }
                dynamicMemberHandle.DynamicMemberSet(target, setValue);
                //fieldInfo.SetValue(target, value);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Type:{0} Field:{1}出覃蚚渣昫", ReflectedType, fieldInfo.Name), e);
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
                return fieldInfo.Name;
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
                return fieldInfo.ReflectedType;
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
                return fieldInfo.FieldType;
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
                return true;
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
                return true;
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
                return MemberType.Field;
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
            return this.fieldInfo.GetCustomAttributes(attributeType, inherit);
        }

        #endregion
    }
}
