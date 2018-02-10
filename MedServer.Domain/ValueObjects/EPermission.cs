using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Domain.ValueObjects
{
    public enum EPermission
    {
        Admin = 0,
        Doctor = 1,
        Patient = 2,
        User = 3
    }
}
