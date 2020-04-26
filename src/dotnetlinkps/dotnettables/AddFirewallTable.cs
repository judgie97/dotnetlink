using System.Management.Automation;
using dotnettables;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Add, "FirewallTable")]
    public class AddFirewallTable : PSCmdlet
    {
        [Parameter] public AddressFamily family;
        [Parameter] public string name;

        protected override void BeginProcessing()
        {
            Firewall firewall = new Firewall();
            Table table = new Table(name, family);
            firewall.AddTable(table);
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