using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Get, "NetworkInterface")]
    public class GetNetworkInterface : PSCmdlet
    {
        private NetworkInterface[] interfaces;
        
        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            interfaces = socket.getNetworkInterfaces();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            foreach (var i in interfaces)
            {
                WriteObject(i);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}