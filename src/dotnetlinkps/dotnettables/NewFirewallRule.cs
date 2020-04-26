using System;
using System.Management.Automation;
using dotnettables;
using dotnettables.Matches;
using dotnettables.Statements;

namespace dotnetlinkps
{
    [Cmdlet(VerbsCommon.New, "FirewallRule")]
    public class NewFirewallRule : PSCmdlet
    {
        [Parameter(Mandatory = true)] public Chain chain;

        [Parameter] public byte ipVersion = 0;

        [Parameter] public ushort tcpSourcePort = 0;
        [Parameter] public ushort tcpDestinationPort = 0;
        
        [Parameter] public ushort udpSourcePort = 0;
        [Parameter] public ushort udpDestinationPort = 0;

        [Parameter]
        public SwitchParameter Accept
        {
            get => accept;
            set => accept = value;
        }

        private bool accept;

        [Parameter]
        public SwitchParameter Drop
        {
            get => drop;
            set => drop = value;
        }

        private bool drop;


        protected override void BeginProcessing()
        {
            Firewall f = Connector.GetFirewall();
            Rule r = new Rule(chain.family, 0, null);

            if (ipVersion != 0)
            {
                r.expression.matches.Add(new IPVersionMatch(ipVersion));
            }
            
            if (tcpSourcePort != 0)
            {
                r.expression.matches.Add(new PortMatch(tcpSourcePort, Protocol.TCP, true));
            }
            
            if (tcpDestinationPort != 0)
            {
                r.expression.matches.Add(new PortMatch(tcpDestinationPort, Protocol.TCP, false));
            }
            
            if (udpSourcePort != 0)
            {
                r.expression.matches.Add(new PortMatch(udpSourcePort, Protocol.UDP, true));
            }
            
            if (udpDestinationPort != 0)
            {
                r.expression.matches.Add(new PortMatch(udpDestinationPort, Protocol.UDP, false));
            }

            if (Accept.IsPresent && Drop.IsPresent)
            {
                throw new Exception("Accept and Drop cannot be specified in the same call");
            }

            if (Accept.IsPresent && accept)
            {
                r.expression.statements.Add(new AcceptStatement());
            }

            if (Drop.IsPresent && drop)
            {
                r.expression.statements.Add(new DropStatement());
            }

            f.GetTable(chain.table.name).GetChain(chain.name).AddRule(r);
            Connector.ClearAll();
            Connector.SetFirewall(f);
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