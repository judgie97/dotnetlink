using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps
{
    public class AddRoute4 : PSCmdlet
    {
        [Cmdlet(VerbsCommon.Add, "Route4")]
        public class GetRoute4 : PSCmdlet
        {
            private NetlinkSocket socket;

            private Route4[] routes;
            
            [Parameter]
            public Route4 route;

            protected override void BeginProcessing()
            {
                socket = SingletonRepository.getNetlinkSocket();
                socket.addRoute(route);
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