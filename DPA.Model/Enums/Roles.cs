using System;

namespace DPA.Model
{
    [Flags]
    public enum Roles
    {
        None = 0,
        User = 1,
        Admin = 2,
        Administrator = 3
    }
}