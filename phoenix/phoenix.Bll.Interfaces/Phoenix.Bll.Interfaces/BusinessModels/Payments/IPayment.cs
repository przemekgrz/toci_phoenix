﻿using System;

using Phoenix.Bll.Interfaces.BusinessModels.UsersList;

namespace Phoenix.Bll.Interfaces.BusinessModels.Payments
{
    public interface IPayment
    {
        DateTime PaymentDateStamp { get; set; }
        decimal TransferedMoney { get; set; }
        IUsers User { get; set; }
    }
}