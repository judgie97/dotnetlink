using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Get, "NetworkFilterRule")]
    public class GetNetworkFilterRule : PSCmdlet
    {
        private FilterRule[] rules;
        
        protected override void BeginProcessing()
        {
            NetfilterSocket socket = SingletonRepository.getNetfilterSocket();
            rules = socket.getFilterRules();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            foreach (var rule in rules)
            {
                WriteObject(rule);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}