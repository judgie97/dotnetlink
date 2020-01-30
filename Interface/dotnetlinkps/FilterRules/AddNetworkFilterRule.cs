using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Add, "NetworkFilterRule")]
    public class AddNetworkFilterRule : PSCmdlet
    {
        [Parameter] public uint nextRule;
        
        [Parameter] public IPProtocol protocol;
        
        [Parameter] public FilterAction action;
        
        protected override void BeginProcessing()
        {
            NetfilterSocket socket = SingletonRepository.getNetfilterSocket();
            FilterRule rule = new FilterRule();
            rule.action = action;
            rule.protocol = protocol;
            rule.next = nextRule;
            socket.addFilterRule(rule);
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