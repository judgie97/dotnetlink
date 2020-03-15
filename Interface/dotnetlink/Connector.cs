using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace dotnetlink
{
    public static unsafe class Connector
    {
        //SOCK MANAGEMENT
        [DllImport("libdotnetlinkconnector.so")]
        public static extern void* openNetlinkSocket();

        [DllImport("libdotnetlinkconnector.so")]
        public static extern void closeNetlinkSocket(void* socket);

        //ROUTING
        [DllImport("libdotnetlinkconnector.so")]
        public static extern int addRoute(void* socket, NetlinkRoute4* route);

        [DllImport("libdotnetlinkconnector.so")]
        public static extern int removeRoute(void* socket, NetlinkRoute4* route);

        [DllImport("libdotnetlinkconnector.so")]
        public static extern int requestAllRoutes(void* socket, byte** storage);

        //ADDRESSING
        [DllImport("libdotnetlinkconnector.so")]
        public static extern int addIPAddress(void* socket, NetlinkIPAddress4* address);
        
        [DllImport("libdotnetlinkconnector.so")]
        public static extern int removeIPAddress(void* socket, NetlinkIPAddress4* address);

        [DllImport("libdotnetlinkconnector.so")]
        public static extern int requestAllAddresses(void* socket, byte** storage);
        
        //NETWORK INTERFACES
        [DllImport("libdotnetlinkconnector.so")]
        public static extern int addInterface(void* socket, NetlinkInterface* nic);

        [DllImport("libdotnetlinkconnector.so")]
        public static extern int removeInterface(void* socket, uint interfaceIndex);

        [DllImport("libdotnetlinkconnector.so")]
        public static extern int requestAllNetworkInterfaces(void* socket, byte** storage);

        [DllImport("libdotnetlinkconnector.so")]
        public static extern int setNetworkInterface(void* socket, uint interfaceIndex, bool up);
    }
}