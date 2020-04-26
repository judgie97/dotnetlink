using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Get, "IPAddress4")]
    [OutputType(typeof(IPAddress4))]
    public class GetIPAddress4 : PSCmdlet
    {
        private IPAddress4[] addresses;
        
        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            addresses = socket.getAddresses();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            foreach (var address in addresses)
            {
                WriteObject(address);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}