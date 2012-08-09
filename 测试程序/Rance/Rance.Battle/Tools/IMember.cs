using System;
using System.Collections.Generic;
using System.Text;

namespace Rance.Tools
{
    /// <summary>
    /// �ʸ�Property�MField�����f
    /// </summary>
	public interface IMember
	{
        /// <summary>
        /// �O�_�i�HŪ��
        /// </summary>
		bool CanRead
		{
			get;
		}
        /// <summary>
        /// �O�_�i�H�g�J
        /// </summary>
		bool CanWrite
		{
			get;
		}
        /// <summary>
        /// Ū�����
        /// </summary>
        /// <param name="target">Ū����ƪ��ؼ�</param>
        /// <returns>Ū�������</returns>
		object GetValue(object target);
        /// <summary>
        /// �g�J���
        /// </summary>
        /// <param name="target">�g�J��ƪ��ؼ�</param>
        /// <param name="value">�g�J�����</param>
        void SetValue(object target, object value);
        /// <summary>
        /// �W��
        /// </summary>
		string Name
		{
			get;
		}
        /// <summary>
        /// ���o���O����A�O�ΨӨ��o�o�� Member ���������
        /// </summary>
		Type ReflectedType
		{
			get;
		}
        /// <summary>
        /// ���o�o��Member���󪺫��O�C
        /// </summary>
		Type Type
		{
			get;
		}
        /// <summary>
        /// Member������
        /// </summary>
        MemberType MemberType
        {
            get;
        }

        /// <summary>
        /// �o�Ӥ�k�Ω�q Unmanaged �{���X�s�� Managed ���O�A�åB�����ӱq Managed �{���X���I�s�CGetCustomAttributes ��k�|���o�o�Ӳե󪺩Ҧ��ۭq�ݩʡC
        /// </summary>
        /// <param name="attributeType">Type�A�n����Ǧ^�ۭq�ݩ�</param>
        /// <param name="inherit">Assembly ���O������|�����o�Ӥ޼ơC </param>
        /// <returns>Object ���O���}�C�A�]�t�o�Ӳե�� attributeType ���w���ۭq�ݩʡC</returns>
        object[] GetCustomAttributes( Type attributeType, bool inherit );
	}

    /// <summary>
    /// Member������
    /// </summary>
    public enum MemberType
    {
        /// <summary>
        /// ���
        /// </summary>
        Field,
        /// <summary>
        /// �ݩ�
        /// </summary>
        Property
    }
}
