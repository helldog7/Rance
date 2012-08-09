using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Rance.Tools
{
    /// <summary>
    /// �ʸ�PropertyInfo
    /// </summary>
    public class Property : IMember
    {
        /// <summary>
        /// �ʸ�PropertyInfo,����@�ӷs��Property����
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo</param>
        public Property( System.Reflection.PropertyInfo propertyInfo )
        {
            if (propertyInfo == null)
            {
                throw new ArgumentException("propertyInfo���ର��");
            }

            this.propertyInfo = propertyInfo;
            this.dynamicMemberHandle = new DynamicMemberHandle(propertyInfo);
        }

        private System.Reflection.PropertyInfo propertyInfo;
        private DynamicMemberHandle dynamicMemberHandle;

        #region IMember ����

        /// <summary>
        /// Ū�����
        /// </summary>
        /// <param name="target">Ū����ƪ��ؼ�</param>
        /// <returns>Ū�������</returns>
        object IMember.GetValue( object target )
        {
            try
            {
                return dynamicMemberHandle.DynamicMemberGet(target);
                //return propertyInfo.GetValue(target, null);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Type:{0}��Property:{1}�X���ô���", ReflectedType, propertyInfo.Name), e);
            }
        }

        /// <summary>
        /// �g�J���
        /// </summary>
        /// <param name="target">�g�J��ƪ��ؼ�</param>
        /// <param name="value">�g�J�����</param>
        void IMember.SetValue( object target, object value )
        {
            try
            {
                object setValue = value;
				//�p�G�n�g�J���ȡA�P�ݩʪ��������@�P�A���\�P�_��_�۰��ഫ�C��pfloat�ȩMdouble�����C
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
                throw new Exception(string.Format("Type:{0} Property:{1}�X���ô���", ReflectedType, propertyInfo.Name), e);
            }
        }

        /// <summary>
        /// �W��
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
        /// ���o���O����A�O�ΨӨ��o�o�� Member ���������
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
        /// ���o�o��Member���󪺫��O�C
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
        /// �O�_�i�HŪ��
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
        /// �O�_�i�H�g�J
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
        /// Member������
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
        /// �o�Ӥ�k�Ω�q Unmanaged �{���X�s�� Managed ���O�A�åB�����ӱq Managed �{���X���I�s�CGetCustomAttributes ��k�|���o�o�Ӳե󪺩Ҧ��ۭq�ݩʡC
        /// </summary>
        /// <param name="attributeType">Type�A�n����Ǧ^�ۭq�ݩ�</param>
        /// <param name="inherit">Assembly ���O������|�����o�Ӥ޼ơC</param>
        /// <returns>
        /// Object ���O���}�C�A�]�t�o�Ӳե�� attributeType ���w���ۭq�ݩʡC
        /// </returns>
        public object[] GetCustomAttributes( Type attributeType, bool inherit )
        {
            return this.propertyInfo.GetCustomAttributes(attributeType, inherit);
        }

        #endregion
    }
}
