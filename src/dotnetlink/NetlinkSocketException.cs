using System;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global

namespace dotnetlink
{
    public class NetlinkSocketException : Exception
    {
        public int ExceptionValue { get; set; }

        public NetlinkSocketException(int exceptionValue) : base(ExceptionString(exceptionValue))
        {
            this.ExceptionValue = exceptionValue;
        }

        private static string ExceptionString(int value)
        {
            switch (value)
            {
                case 0: return "Success";
                case -1: return "Unspecific failure";
                case -2: return "Interrupted system call";
                case -3: return "Bad socket";
                case -4: return "Try again";
                case -5: return "Out of memory";
                case -6: return "Object exists";
                case -7: return "Invalid input data or parameter";
                case -8: return "Input data out of range";
                case -9: return "Message size not sufficient";
                case -10: return "Operation not supported";
                case -11: return "Address family not supported";
                case -12: return "Object not found";
                case -13: return "Attribute not available";
                case -14: return "Missing attribute";
                case -15: return "Address family mismatch";
                case -16: return "Message sequence number mismatch";
                case -17: return "Kernel reported message overflow";
                case -18: return "Kernel reported truncated message";
                case -19: return "Invalid address for specified address family";
                case -20: return "Source based routing not supported";
                case -21: return "Netlink message is too short";
                case -22: return "Netlink message type is not supported";
                case -23: return "Object type does not match cache";
                case -24: return "Unknown or invalid cache type";
                case -25: return "Object busy";
                case -26: return "Protocol mismatch";
                case -27: return "No Access";
                case -28: return "Operation not permitted";
                case -29: return "Unable to open packet location file";
                case -30: return "Unable to parse object";
                case -31: return "No such device";
                case -32: return "Immutable attribute";
                case -33: return "Dump inconsistency detected, interrupted";
                case -34: return "Attribute max length exceeded";
            }

            return "Netlink exception: " + value;
        }
    }
}