﻿using NetCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.Interfaces
{
    public interface ISwitchable
    {
        Active Active { set; get; }
    }
}
