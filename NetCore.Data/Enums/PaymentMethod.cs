﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NetCore.Data.Enums
{
    public enum PaymentMethod
    {
        [Description("Cash on delivery")]
         CashOnDelivery,
        [Description("Online Banking")]
        OnlinBanking,
        [Description("Payment Gateway")]
        PaymentGateway,
        [Description("Visa")]
        Visa,
        [Description("Master Card")]
        MasterCard,
        [Description("Paypal")]
        Paypal,
        [Description("ATM")]
        ATM
    }
}
