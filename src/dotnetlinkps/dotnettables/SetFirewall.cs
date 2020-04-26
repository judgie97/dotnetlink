using System;
using System.Management.Automation;
using dotnettables;
using Newtonsoft.Json;
using Connector = dotnettables.Connector;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Set, "Firewall")]
    public class SetFirewall : PSCmdlet
    {
        [Parameter] public Firewall Firewall;

        protected override void BeginProcessing()
        {
            Connector.ClearAll();
            Connector.SetFirewall(Firewall);
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