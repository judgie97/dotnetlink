using System.Management.Automation;
using dotnetlink;

namespace dotnetlinkps.Util
{
    [Cmdlet(VerbsCommon.New, "InterfaceInformation")]

    public class NewInterfaceInformation : PSCmdlet
    {
        [Parameter(Position = 0)] public InterfaceType type;
        [Parameter(Position = 1)] public uint vlanID;
        
        protected override void BeginProcessing()
        {
            if (type == InterfaceType.DOT1Q)
            {
                VLAN vlan = new VLAN(vlanID);
                WriteObject(vlan);
            }
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