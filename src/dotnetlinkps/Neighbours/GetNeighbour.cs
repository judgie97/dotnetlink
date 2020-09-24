using System.Linq;
using System.Management.Automation;
using dotnetlink;
using libnl;

namespace dotnetlinkps.Neighbours
{
    [Cmdlet(VerbsCommon.Get, "Neighbour")]
    [OutputType(typeof(NeighbourDto))]
    public class GetNeighbour : PSCmdlet
    {
        private Neighbour[] _neighbours;
        private NetworkInterface[] _interfaces;

        [Parameter(Mandatory = false)] public ushort VlanId { get; set; } = 0;

        [Parameter(Mandatory = false)] public RouteScope RouteScope { get; set; } = RouteScope.ANY;

        protected override void BeginProcessing()
        {
            var socket = SingletonRepository.getNetlinkSocket();
            _neighbours = socket.GetArpCache();
            _interfaces = socket.GetNetworkInterfaces();

            if (VlanId != 0)
                _neighbours = _neighbours.Where(n => n.VlanId == VlanId).ToArray();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        private void WriteRoute(Neighbour neighbour)
        {
            NeighbourDto neighbourDto = new NeighbourDto
            {
                Layer2Address = neighbour.Layer2Address,
                Layer3Address = neighbour.Layer3Address,
                Family = neighbour.Family,
                VlanId = neighbour.VlanId
            };
            WriteObject(neighbourDto);
        }

        protected override void EndProcessing()
        {
            foreach (var neighbour in _neighbours)
            {
                WriteRoute(neighbour);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}