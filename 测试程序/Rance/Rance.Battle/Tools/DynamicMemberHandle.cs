using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Rance.Tools
{
    public class DynamicMemberHandle
    {
        private string memberName = string.Empty;
        /// <summary>
        /// Member Name
        /// </summary>
        public string MemberName
        {
            get
            {
                return memberName;
            }
        }

        private Type memberType;
        /// <summary>
        /// Member Type
        /// </summary>
        public Type MemberType
        {
            get
            {
                return memberType;
            }
        }

        private DynamicMemberGetDelegate dynamicMemberGet;
        /// <summary>
        /// Delegate for a dynamic field/property get
        /// </summary>
        public DynamicMemberGetDelegate DynamicMemberGet
        {
            get
            {
                return dynamicMemberGet;
            }
        }

        private DynamicMemberSetDelegate dynamicMemberSet;
        /// <summary>
        /// Delegate for a dynamic field/property set
        /// </summary>
        public DynamicMemberSetDelegate DynamicMemberSet
        {
            get
            {
                return dynamicMemberSet;
            }
        }

        private DynamicMemberHandle( string memberName, Type memberType, DynamicMemberGetDelegate dynamicMemberGet, DynamicMemberSetDelegate dynamicMemberSet )
        {
            this.memberName = memberName;
            this.memberType = memberType;
            this.dynamicMemberGet = dynamicMemberGet;
            this.dynamicMemberSet = dynamicMemberSet;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicMemberHandle"/> class.
        /// </summary>
        /// <param name="info">PropertyInfp</param>
        public DynamicMemberHandle( PropertyInfo info )
            :
            this(
                info.Name,
                info.PropertyType,
                DynamicMethodHandlerFactory.CreatePropertyGetter(info),
                DynamicMethodHandlerFactory.CreatePropertySetter(info))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicMemberHandle"/> class.
        /// </summary>
        /// <param name="info">FieldInfo</param>
        public DynamicMemberHandle( FieldInfo info )
            :
            this(
                info.Name,
                info.FieldType,
                DynamicMethodHandlerFactory.CreateFieldGetter(info),
                DynamicMethodHandlerFactory.CreateFieldSetter(info))
        {
        }
    }
}
