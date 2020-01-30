using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace dotnetlink
{
    public class NetfilterSocket
    {
        private static int NETLINK_DOTNETFILTER = 25;
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern int openNetlinkSocket(uint portID, int protocol);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern int closeNetlinkSocket(int sock);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe int requestAllRules(int sockfd, uint pid, byte** storage);

        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe uint deleteRule(int sockfd, uint pid, uint rule);
        
        [DllImport("libdotnetlinkconnector.so")]
        private static extern unsafe uint addNewRule(int sockfd, uint pid, NetlinkFilterRule* rule);

        private int m_sockfd;
        private uint m_pid;

        public NetfilterSocket()
        {
            m_pid = (uint)Process.GetCurrentProcess().Id;
            m_sockfd = openNetlinkSocket(m_pid, NETLINK_DOTNETFILTER);
        }

        ~NetfilterSocket()
        {
            closeNetlinkSocket(m_sockfd);
        }

        public unsafe FilterRule[] getFilterRules()
        {
            byte* netlinkFilterRules;
            int count = requestAllRules(m_sockfd, m_pid, &netlinkFilterRules);
            byte* currentRule = netlinkFilterRules;
            FilterRule[] rules = new FilterRule[count];
            for (int i = 0; i < count; i++)
            {
                NetlinkFilterRule r = (NetlinkFilterRule) Marshal.PtrToStructure((IntPtr) currentRule, typeof(NetlinkFilterRule));
                currentRule += sizeof(NetlinkFilterRule);
                rules[i] = r.toFilterRule();
            }
            return rules;
        }

        public bool removeFilterRule(uint ruleID)
        {
            uint status = deleteRule(m_sockfd, m_pid, ruleID);
            return status == ruleID;
        }
        
        public unsafe bool addFilterRule(FilterRule rule)
        {
            NetlinkFilterRule nlr = new NetlinkFilterRule();
            nlr.next = rule.next;
            nlr.action = (byte)rule.action;
            nlr.id = 0;

            if (rule.protocol != IPProtocol.ANY)
            {
                nlr.protocol = (byte) rule.protocol;
                nlr.filterByProtocol = 1;
            }
            Console.WriteLine("Rule size: " + sizeof(NetlinkFilterRule));


            uint ruleID = addNewRule(m_sockfd, m_pid, &nlr);
            return ruleID > 0;
        }
    }
}