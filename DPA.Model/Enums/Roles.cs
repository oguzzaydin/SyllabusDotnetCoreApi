using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.Model.Enums
{
    [Flags]
    public enum Roles
    {
        None = 0,
        User = 1,
        Admin = 2
    }
}
