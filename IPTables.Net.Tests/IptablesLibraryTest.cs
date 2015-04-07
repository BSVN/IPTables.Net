﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using IPTables.Net.Iptables.NativeLibrary;
using NUnit.Framework;

namespace IPTables.Net.Tests
{
    [TestFixture]
    class IptablesLibraryTest
    {
        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        [TestFixtureSetUp]
        public void TestStartup()
        {
            if (IsLinux)
            {
                Process.Start("/sbin/iptables", "-N test2").WaitForExit();
                Process.Start("/sbin/iptables", "-N test").WaitForExit();
                Process.Start("/sbin/iptables", "-A test -j ACCEPT").WaitForExit();

                Process.Start("/sbin/iptables", "-N test3").WaitForExit();
                Process.Start("/sbin/iptables", "-A test3 -p tcp -m tcp --dport 80 -j ACCEPT").WaitForExit();
            }
        }

        [TestFixtureTearDown]
        public void TestDestroy()
        {
            if (IsLinux)
            {
                Process.Start("/sbin/iptables", "-D test -j ACCEPT").WaitForExit();
                Process.Start("/sbin/iptables", "-X test").WaitForExit();
                Process.Start("/sbin/iptables", "-F test2").WaitForExit();
                Process.Start("/sbin/iptables", "-X test2").WaitForExit();
                Process.Start("/sbin/iptables", "-F test3").WaitForExit();
                Process.Start("/sbin/iptables", "-X test3").WaitForExit();
            }
        }

        [Test]
        public void TestRuleOutputSimple()
        {
            if (IsLinux)
            {
                IptcInterface iptc = new IptcInterface("filter");
                var rules = iptc.GetRules("test");
                Assert.AreEqual(1,rules.Count);
                Assert.AreEqual("-A test -j ACCEPT", iptc.GetRuleString("test",rules[0]));
            }   
        }

        [Test]
        public void TestRuleOutputModule()
        {
            if (IsLinux)
            {
                IptcInterface iptc = new IptcInterface("filter");
                var rules = iptc.GetRules("test3");
                Assert.AreEqual(1, rules.Count);
                Assert.AreEqual("-A test3 -p tcp -m tcp --dport 80 -j ACCEPT", iptc.GetRuleString("test3", rules[0]));
            }
        }

        [Test]
        public void TestRuleInput()
        {
            if (IsLinux)
            {
                IptcInterface iptc = new IptcInterface("filter");

                var status = iptc.ExecuteCommand("iptables -A test2 -d 1.1.1.1 -p tcp -m tcp --dport 80 -j ACCEPT");
                Assert.AreEqual(1, status, "Expected OK return value");

                var rules = iptc.GetRules("test2");
                Assert.AreEqual(1, rules.Count);
                Assert.AreEqual("-A test2 -d 1.1.1.1/32 -p tcp -m tcp --dport 80 -j ACCEPT", iptc.GetRuleString("test2", rules[0]));
            }
        }

        [Test]
        public void TestListChains()
        {
            if (IsLinux)
            {
                IptcInterface iptc = new IptcInterface("filter");

                var chains = iptc.GetChains();
                Assert.AreNotEqual(0, chains.Count, "Expected atleast one chain");
            }
        }
    }
}
