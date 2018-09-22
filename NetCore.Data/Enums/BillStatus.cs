using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NetCore.Data.Enums
{
    public enum BillStatus
    {
        [Description("New")]
        New,
        [Description("In Progress")]
        InProgress,
        [Description("Returned")]
        Returned,
        [Description("Cancelled")]
        Cancelled,
        [Description("Complete")]
        Completed
    }
}
