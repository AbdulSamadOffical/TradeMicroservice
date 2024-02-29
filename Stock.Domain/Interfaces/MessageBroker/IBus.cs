﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Domain.Interfaces.MessageBroker
{
    public interface IBus
    {
        Task SendAsync<T>(string queue, T message);
        Task ReceiveAsync<T>(string exchange, string queue, Action<T> onMessage);
    }
}
