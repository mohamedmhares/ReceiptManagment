﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Shared.Interfaces
{
    public interface IDateTimeService
    {
        public DateTime Now { get;  }
    }
}
