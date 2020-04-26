using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Get, "NetworkInterface")]
    [OutputType(typeof(NetworkInterface))]
    public class GetNetworkInterface : PSCmdlet
    {
        private NetworkInterface[] interfaces;

        [Parameter(Position = 0)]
        public string[] Name
        {
            get { return interfaceNames; }
            set { interfaceNames = value; }
        }

        private string[] interfaceNames;

        protected override void BeginProcessing()
        {
            NetlinkSocket socket = SingletonRepository.getNetlinkSocket();
            interfaces = socket.getNetworkInterfaces();
        }

        protected override void ProcessRecord()
        {
            if (interfaceNames == null)
            {
                foreach (var i in interfaces)
                {
                    WriteObject(i);
                }
            }
            else
            {
                foreach (var n in interfaceNames)
                {
                    foreach (var i in interfaces)
                    {
                        if (i.interfaceName.ToLower() == n.ToLower())
                        {
                            WriteObject(i);
                        }
                    }
                }
            }
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