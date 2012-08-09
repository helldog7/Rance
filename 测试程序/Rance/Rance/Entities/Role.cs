using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance
{
    public partial class Role
    {
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Role))
                return false;

            Role role = obj as Role;
            return role.ID == ID;
        }
    }
}
