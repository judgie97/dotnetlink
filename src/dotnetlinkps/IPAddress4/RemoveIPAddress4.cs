using System.Management.Automation;
using System.Net;
using dotnetlink;

namespace dotnetlinkps
{
    public class RemoveIPAddress4 : PSCmdlet
    {
        [Cmdlet(VerbsCommon.Remove, "IPAddress4")]
        public class GetIPAddress4 : PSCmdlet
        {
            private NetlinkSocket socket;

            [Parameter] public IPAddress4 address;

            protected override void BeginProcessing()
            {
                socket = SingletonRepository.getNetlinkSocket();
                socket.removeIPAddress(address);
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
}