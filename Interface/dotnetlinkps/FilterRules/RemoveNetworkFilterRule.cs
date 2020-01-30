using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Remove, "NetworkFilterRule")]
    public class RemoveNetworkFilterRule : PSCmdlet
    {
        [Parameter] public uint ruleID;
        
        protected override void BeginProcessing()
        {
            NetfilterSocket socket = SingletonRepository.getNetfilterSocket();
            socket.removeFilterRule(ruleID);
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