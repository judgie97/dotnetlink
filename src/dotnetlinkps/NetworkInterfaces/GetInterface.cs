using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.Get, "Interface")]
    [OutputType(typeof(InterfaceDTO))]
    public class GetInterface : PSCmdlet
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

        private void WriteInterface(NetworkInterface networkInterface)
        {
            InterfaceDTO interfaceDto = new InterfaceDTO
            {
                Index = networkInterface.index,
                ParentInterfaceIndex = networkInterface.parentInterfaceIndex,
                Name = networkInterface.interfaceName,
                HardwareAddress = networkInterface.hardwareAddress,
                PromiscuousMode = networkInterface.isPromiscuousInterface,
                Type = networkInterface.interfaceType,
                Encapsulation = networkInterface.encapsulation,
                State = networkInterface.isUp ? InterfaceState.UP : InterfaceState.DOWN
            };
            WriteObject(interfaceDto);
        }

        protected override void ProcessRecord()
        {
            if (interfaceNames == null)
            {
                foreach (var i in interfaces)
                {
                    WriteInterface(i);
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
                            WriteInterface(i);
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