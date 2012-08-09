using System;
using System.Reflection;

namespace Rance.Tools
{
    /// <summary>
    /// Delegate for a dynamic method handle.
    /// </summary>
    public class DynamicMethodHandle
    {
        private string methodName = string.Empty;
        /// <summary>
        /// Method Name
        /// </summary>
        public string MethodName
        {
            get
            {
                return methodName;
            }
        }

        private DynamicMethodDelegate dynamicMethod;
        /// <summary>
        /// Delegate for a dynamic method.
        /// </summary>
        public DynamicMethodDelegate DynamicMethod
        {
            get
            {
                return dynamicMethod;
            }
        }

        private bool hasFinalArrayParam;
        /// <summary>
        /// 最后的參數是不是數組參數
        /// </summary>
        public bool HasFinalArrayParam
        {
            get
            {
                return hasFinalArrayParam;
            }
        }

        private int methodParamsLength;
        /// <summary>
        /// 參數數量
        /// </summary>
        public int MethodParamsLength
        {
            get
            {
                return methodParamsLength;
            }
        }

        private Type finalArrayElementType;
        /// <summary>
        /// 最后數組參數的類型
        /// </summary>
        public Type FinalArrayElementType
        {
            get
            {
                return finalArrayElementType;
            }
        }

        private ParameterInfo[] parameterInfoList;
        public ParameterInfo[] ParameterInfoList
        {
            get
            {
                return parameterInfoList;
            }
        }
        

        //public DynamicMethodHandle( MethodInfo info, params object[] parameters )

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicMethodHandle"/> class.
        /// </summary>
        /// <param name="info">MethodInfo</param>
        public DynamicMethodHandle( MethodInfo info )
        {
            if (info == null)
            {
                this.dynamicMethod = null;
            }
            else
            {
                this.methodName = info.Name;
                ParameterInfo[] infoParams = info.GetParameters();
                //object[] inParams = null;
                //if (parameters == null)
                //{
                //    inParams = new object[] { null };

                //}
                //else
                //{
                //    inParams = parameters;
                //}
                int pCount = infoParams.Length;
                if (pCount > 0 &&
                   ((pCount == 1 && infoParams[0].ParameterType.IsArray) ||
                   (infoParams[pCount - 1].GetCustomAttributes(typeof(ParamArrayAttribute), true).Length > 0)))
                {
                    this.hasFinalArrayParam = true;
                    this.methodParamsLength = pCount;
                    this.finalArrayElementType = infoParams[pCount - 1].ParameterType;
                }
                this.dynamicMethod = DynamicMethodHandlerFactory.CreateMethod(info);
            }

            this.parameterInfoList = info.GetParameters();
        }
    }
}
