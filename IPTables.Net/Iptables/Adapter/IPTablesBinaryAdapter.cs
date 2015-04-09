﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPTables.Net.Iptables.Adapter.Client;
using IPTables.Net.Netfilter;

namespace IPTables.Net.Iptables.Adapter
{
    public class IPTablesBinaryAdapter : IPTablesAdapterBase
    {
        public override IIPTablesAdapterClient GetClient(IpTablesSystem system, int ipVersion = 4)
        {
            return new Client.IPTablesBinaryAdapterClient(ipVersion, system, ipVersion == 4 ? "iptables" : "ip6tables");
        }
    }
}
