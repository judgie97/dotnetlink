namespace dotnetlink
{
    public class VLAN
    {
        public ushort vlanID;

        public VLAN()
        {
            vlanID = 0;
        }

        public VLAN(ushort vlanID)
        {
            this.vlanID = vlanID;
        }

        public override string ToString()
        {
            return "VLAN " + vlanID;
        }
    }
}