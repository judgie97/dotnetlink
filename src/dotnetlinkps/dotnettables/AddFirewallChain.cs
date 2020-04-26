using System;
using System.Management.Automation;
using dotnettables;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Add, "FirewallChain")]
    public class AddFirewallChain : PSCmdlet
    {
        [Parameter] public AddressFamily family;
        [Parameter] public string name;
        [Parameter] public ChainType type;
        [Parameter] public Hook hook;
        [Parameter] public int priority;
        [Parameter] public Policy policy;
        [Parameter] public Table table;

        protected override void BeginProcessing()
        {
            Firewall firewall = Connector.GetFirewall();
            Table t = firewall.GetTable(table.name);
            Chain chain = new Chain(name, family, policy, type, hook, priority);
            t.AddChain(chain);
            Connector.SetFirewall(firewall);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}