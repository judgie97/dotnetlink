namespace dotnetlink
{
    public class VLAN
    {
        public uint vlanID;

        public VLAN()
        {
            vlanID = 0;
        }

        public VLAN(uint vlanID)
        {
            this.vlanID = vlanID;
        }

        public override string ToString()
        {
            return "VLAN " + vlanID;
        }
    }
}