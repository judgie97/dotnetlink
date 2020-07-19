using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps.Interfaces
{
    [Cmdlet(VerbsCommon.Get, "Interface")]
    [OutputType(typeof(InterfaceDto))]
    public class GetInterface : PSCmdlet
    {
        private NetworkInterface[] _interfaces;
        private NetworkInterface[] _requestedInterfaces;

        [Parameter(Position = 0)] public string[] Name { get; set; }

        [Parameter] public int[] Index { get; set; }

        protected override void BeginProcessing()
        {
            var socket = SingletonRepository.getNetlinkSocket();
            _interfaces = socket.getNetworkInterfaces();
            if (Name != null)
                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i] = Name[i].ToLower();
                }
        }

        private void WriteInterface(NetworkInterface networkInterface)
        {
            var interfaceDto = InterfaceDtoUtil.ConvertToDto(networkInterface.index, _interfaces);
            WriteObject(interfaceDto);
        }

        protected override void ProcessRecord()
        {
            IEnumerable<NetworkInterface> linqInterfaces = _interfaces;
            if (Name != null)
                linqInterfaces = linqInterfaces.Where(i => Name.Contains(i.interfaceName.ToLower()));
            if (Index != null)
                linqInterfaces = linqInterfaces.Where(i => Index.Contains(i.index));
            _requestedInterfaces = linqInterfaces.ToArray();
        }

        protected override void EndProcessing()
        {
            foreach (var i in _requestedInterfaces)
            {
                WriteInterface(i);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}