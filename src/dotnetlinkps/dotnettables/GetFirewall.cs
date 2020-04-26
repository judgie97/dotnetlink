using System.Management.Automation;
using dotnettables;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Get, "Firewall")]
    public class GetFirewall : PSCmdlet
    {
        private Firewall _firewall;
        
        protected override void BeginProcessing()
        {
            _firewall = Connector.GetFirewall();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            WriteObject(_firewall);
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}