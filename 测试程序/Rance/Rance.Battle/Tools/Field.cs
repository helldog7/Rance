using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Rance.Tools
{
    /// <summary>
    /// �ʸ�FieldInfo
    /// </summary>
    public class Field : IMember
    {
        /// <summary>
        /// �ʸ�FieldInfo,����@�ӷs��Field����
        /// </summary>
        /// <param name="fieldInfo">FieldInfo</param>
        public Field( System.Reflection.FieldInfo fieldInfo )
        {
            if (fieldInfo == null)
            {
                throw new ArgumentException("fieldInfo���ର��");
            }

            this.fieldInfo = fieldInfo;
            this.dynamicMemberHandle = new DynamicMemberHandle(fieldInfo);
        }

        private System.Reflection.FieldInfo fieldInfo;
        private DynamicMemberHandle dynamicMemberHandle;

        #region IMember ����

        /// <summary>
        /// Ū�����
        /// </summary>
        /// <param name="target">Ū����ƪ��ؼ�</param>
        /// <returns>Ū�������</returns>
        public object GetValue( object target )
        {
            try
            {
                return dynamicMemberHandle.DynamicMemberGet(target);
                //return fieldInfo.GetValue(target);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Type:{0}��Field:{1}�X���ô���", ReflectedType, fieldInfo.Name), e);
            }
        }

        /// <summary>
        /// �g�J���
        /// </summary>
        /// <param name="target">�g�J��ƪ��ؼ�</param>
        /// <param name="value">�g�J�����</param>
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
                throw new Exception(string.Format("Type:{0} Field:{1}�X���ô���", ReflectedType, fieldInfo.Name), e);
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
                return fieldInfo.Name;
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
                return fieldInfo.ReflectedType;
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
                return fieldInfo.FieldType;
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
                return true;
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
                return true;
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
                return MemberType.Field;
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
            return this.fieldInfo.GetCustomAttributes(attributeType, inherit);
        }

        #endregion
    }
}
