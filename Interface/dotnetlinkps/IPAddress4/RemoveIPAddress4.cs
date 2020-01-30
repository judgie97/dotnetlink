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

            [Parameter] public IPAddress address;

            [Parameter] public byte netmask;

            [Parameter] public uint nic;

            protected override void BeginProcessing()
            {
                socket = SingletonRepository.getNetlinkSocket();
                socket.removeIPAddress(new IPAddress4(address, netmask, nic));
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