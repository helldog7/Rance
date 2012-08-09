using System;
using System.Collections.Generic;
using System.Text;

namespace Rance.Tools
{
    /// <summary>
    /// 封裝Property和Field的接口
    /// </summary>
	public interface IMember
	{
        /// <summary>
        /// 是否可以讀取
        /// </summary>
		bool CanRead
		{
			get;
		}
        /// <summary>
        /// 是否可以寫入
        /// </summary>
		bool CanWrite
		{
			get;
		}
        /// <summary>
        /// 讀取資料
        /// </summary>
        /// <param name="target">讀取資料的目標</param>
        /// <returns>讀取的資料</returns>
		object GetValue(object target);
        /// <summary>
        /// 寫入資料
        /// </summary>
        /// <param name="target">寫入資料的目標</param>
        /// <param name="value">寫入的資料</param>
        void SetValue(object target, object value);
        /// <summary>
        /// 名稱
        /// </summary>
		string Name
		{
			get;
		}
        /// <summary>
        /// 取得類別物件，是用來取得這個 Member 的執行個體
        /// </summary>
		Type ReflectedType
		{
			get;
		}
        /// <summary>
        /// 取得這個Member物件的型別。
        /// </summary>
		Type Type
		{
			get;
		}
        /// <summary>
        /// Member的類型
        /// </summary>
        MemberType MemberType
        {
            get;
        }

        /// <summary>
        /// 這個方法用於從 Unmanaged 程式碼存取 Managed 類別，並且不應該從 Managed 程式碼中呼叫。GetCustomAttributes 方法會取得這個組件的所有自訂屬性。
        /// </summary>
        /// <param name="attributeType">Type，要為其傳回自訂屬性</param>
        /// <param name="inherit">Assembly 型別的物件會忽略這個引數。 </param>
        /// <returns>Object 型別的陣列，包含這個組件由 attributeType 指定的自訂屬性。</returns>
        object[] GetCustomAttributes( Type attributeType, bool inherit );
	}

    /// <summary>
    /// Member的類型
    /// </summary>
    public enum MemberType
    {
        /// <summary>
        /// 欄位
        /// </summary>
        Field,
        /// <summary>
        /// 屬性
        /// </summary>
        Property
    }
}
