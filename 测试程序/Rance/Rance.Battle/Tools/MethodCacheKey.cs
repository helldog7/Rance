using System;
using System.Text;

namespace Rance.Tools
{
    internal class MethodCacheKey
    {
        private string typeName = string.Empty;
        public string TypeName
        {
            get
            {
                return typeName;
            }
        }

        private string methodName = string.Empty;
        public string MethodName
        {
            get
            {
                return methodName;
            }
        }

        public Type[] paramTypes;
        public Type[] ParamTypes
        {
            get
            {
                return paramTypes;
            }
        }

        private string _hashKey;

        public MethodCacheKey( string typeName, string methodName, Type[] paramTypes )
        {
            this.typeName = typeName;
            this.methodName = methodName;
            this.paramTypes = paramTypes;

            StringBuilder sb = new StringBuilder();
            sb.Append(typeName);
            sb.Append("|");
            sb.Append(methodName);
            foreach (Type item in paramTypes)
            {
                sb.Append("@");
                sb.Append(item.Name);
            }
            _hashKey = sb.ToString();

            //_hashKey = typeName.GetHashCode();
            //_hashKey = _hashKey ^ methodName.GetHashCode();
            //foreach (Type item in paramTypes)
            //    _hashKey = _hashKey ^ item.Name.GetHashCode();
        }

        public override bool Equals( object obj )
        {
            MethodCacheKey key = obj as MethodCacheKey;
            if (key != null &&
                key.TypeName == this.TypeName &&
                key.MethodName == this.MethodName &&
                ArrayEquals(key.ParamTypes, this.ParamTypes))
                return true;

            return false;
        }

        private bool ArrayEquals( Type[] a1, Type[] a2 )
        {
            if (a1.Length != a2.Length)
                return false;

            for (int pos = 0; pos < a1.Length; pos++)
                if (a1[pos] != a2[pos])
                    return false;
            return true;
        }

        public override int GetHashCode()
        {
            return _hashKey.GetHashCode();
        }
    }
}
