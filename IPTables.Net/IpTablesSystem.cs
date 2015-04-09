﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SystemInteract;
using IPTables.Net.Iptables;
using IPTables.Net.Iptables.Adapter;
using IPTables.Net.Iptables.Adapter.Client;
using IPTables.Net.Iptables.IpSet.Adapter;
using IPTables.Net.Netfilter;

namespace IPTables.Net
{
    /// <summary>
    /// A class to act as the core controller for the IPTables system being manipulated
    /// </summary>
    public class IpTablesSystem: NetfilterSystem
    {
        public IpTablesSystem(ISystemFactory system, IIPTablesAdapter tableAdapter, IpSetBinaryAdapter setAdapter = null)
            : base(system, tableAdapter, setAdapter)
        {
        }

        public new IEnumerable<IpTablesChain> GetChains(String table, int ipVersion)
        {
            return base.GetChains(table, ipVersion).Cast<IpTablesChain>();
        }

        public List<String> GetChainNames(String table, int ipVersion)
        {
            var tableAdapter = GetTableAdapter(ipVersion);
            var adapter = tableAdapter as IIPTablesAdapterClient;
            return adapter.GetChains(table);
        } 
    }
}
