﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace TxSms.SingalR
{
    public static class Notifier
    {
        private static readonly IHubContext Context = GlobalHost.ConnectionManager.GetHubContext<QRCodeHub>();

        public static void SessionTimeOut(string connectionId, int time)
        {
            Context.Clients.Client(connectionId).alertClient(time);
        }

        public static void SendElapsedTime(string connectionId, int time)
        {
            Context.Clients.Client(connectionId).sendElapsedTime(time);
        }

        public static void SendQRCodeUUID(string connectionId, string uuid)
        {
            Context.Clients.Client(connectionId).sendQRCodeUUID(uuid);
        }
    }
}
