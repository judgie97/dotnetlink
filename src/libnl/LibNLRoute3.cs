using System.Runtime.InteropServices;

namespace libnl
{
    public struct rtnl_addr
    {
    }

    public struct rtnl_link
    {
    }

    public struct rtnl_link_vf
    {
    }

    public struct rtnl_rule
    {
    }
    
    public struct rtnl_netconf
    {
    }

    public struct rtnl_class
    {
    }

    public struct rtnl_qdisc
    {
    }

    public struct rtnl_nexthop
    {
    }

    public struct rtnl_neigh
    {
    }

    public struct rtnl_act
    {
    }
    
    
    public struct rtnl_route
    {
    }

    public struct rtnl_tc_type_ops
    {
    }

    public struct rtnl_cls
    {
    }

    public struct rtnl_tc_ops
    {
    }

    public struct rtnl_tc
    {
    }

    public struct rtnl_link_af_ops
    {
    }

    public struct rtnl_ematch
    {
    }

    public struct nl_vf_rate
    {
    }

    public struct rtnl_link_vf_stats_t
    {
    }

    public struct nl_vf_vlans_t
    {
    }

    public struct rtnl_link_info_ops
    {
    }

    public struct ifla_vxlan_port_range
    {
    }

    public struct rtnl_neightbl
    {
    }

    public struct tc_service_curve
    {
    }

    public struct rtnl_ematch_ops
    {
    }

    public struct rtnl_link_stat_id_t
    {
    }

    public struct rtnl_ematch_tree
    {
    }

    public struct can_berr_counter
    {
    }

    public struct can_bittiming
    {
    }

    public struct can_bittiming_const
    {
    }

    public struct vlan_map
    {
    }

    public struct rtnl_ratespec
    {
    }

    public unsafe class LibNLRoute3
    {
        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_addr_get_link(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_ematch_ops* rtnl_ematch_lookup_ops_by_name(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_ematch_ops* rtnl_ematch_lookup_ops(int kind);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_geneve_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_get_by_name(nl_cache* cache, char* name);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_get(nl_cache* cache, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_ipvlan_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_macsec_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_macvlan_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_macvtap_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_ppp_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_veth_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_veth_get_peer(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_vf_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_vf_get(rtnl_link* link, uint vf_num);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_vlan_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern vlan_map* rtnl_link_vlan_get_egress_map(rtnl_link* link, int* negress);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_vrf_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_link_vxlan_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern nl_list_head* rtnl_route_get_nexthops(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link* rtnl_tc_get_link(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_addr_flags2str(int flags, char* buf, uint size);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_addr_get_label(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_bridge_flags2str(int flags, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_bridge_hwmode2str(ushort st, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_bridge_portstate2str(int st, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_can_ctrlmode2str(int ctrlmode, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_carrier2str(byte st, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_flags2str(int flags, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_get_info_type(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_get_name(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_get_phys_port_name(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_get_qdisc(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_get_type(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_i2name(nl_cache* cache, int ifindex, char* dst, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_ipvlan_mode2str(int mode, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_macvlan_flags2str(int flags, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_macvlan_macmode2str(int mode, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_macvlan_mode2str(int mode, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_macvtap_flags2str(int flags, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_macvtap_mode2str(int mode, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_mode2str(byte st, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_operstate2str(byte st, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_stat2str(int st, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_vf_linkstate2str(uint ls, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_vf_vlanproto2str(ushort proto, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_vlan_flags2str(int flags, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_neigh_flags2str(int flags, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_neigh_state2str(int state, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_prio2str(int prio, char* buf, uint size);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_realms2str(uint realms, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_route_metric2str(int metric, char* buf, uint size);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_route_nh_flags2str(int flags, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_route_proto2str(int proto, char* buf, uint size);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_route_table2str(int table, char* buf, uint size);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_rule_get_iif(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_rule_get_oif(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_scope2str(int scope, char* buf, uint size);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_tc_get_kind(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_tc_handle2str(uint handle, char* buf, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_get_ifalias(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern char* rtnl_link_get_slave_type(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_act_add(nl_sock* sk, rtnl_act* act, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_act_build_add_request(rtnl_act* act, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_act_build_change_request(rtnl_act* act, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_act_build_delete_request(rtnl_act* act, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_act_change(nl_sock* sk, rtnl_act* act, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_act_delete(nl_sock* sk, rtnl_act* act, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_add(nl_sock* sk, rtnl_addr* addr, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_alloc_cache(nl_sock* sk, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_build_add_request(rtnl_addr* addr, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_build_delete_request(rtnl_addr* addr, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_delete(nl_sock* sk, rtnl_addr* addr, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_get_family(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_get_ifindex(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_get_prefixlen(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_get_scope(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_set_anycast(rtnl_addr* addr, nl_addr* anycast);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_set_broadcast(rtnl_addr* addr, nl_addr* bcast);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_set_label(rtnl_addr* addr, char* label);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_set_local(rtnl_addr* addr, nl_addr* local);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_set_multicast(rtnl_addr* addr, nl_addr* multicast);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_set_peer(rtnl_addr* addr, nl_addr* peer);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_addr_str2flags(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_basic_add_action(rtnl_class* cls, rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_basic_del_action(rtnl_class* cls, rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_add(nl_sock* sk, rtnl_class* cls, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_alloc_cache(nl_sock* sk, int ifindex, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_build_add_request(rtnl_class* cls, int flags, nl_msg* *result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_build_delete_request(rtnl_class* cls, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_delete(nl_sock* sk, rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_dsmark_get_bitmask(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_dsmark_get_value(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_dsmark_set_bitmask(rtnl_class* cls, byte mask);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_dsmark_set_value(rtnl_class* cls, byte value);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_hfsc_get_fsc(rtnl_class* cls, tc_service_curve* tsc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_hfsc_get_rsc(rtnl_class* cls, tc_service_curve* tsc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_hfsc_get_usc(rtnl_class* cls, tc_service_curve* tsc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_hfsc_set_fsc(rtnl_class* cls, tc_service_curve* tsc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_hfsc_set_rsc(rtnl_class* cls, tc_service_curve* tsc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_class_hfsc_set_usc(rtnl_class* cls, tc_service_curve* tsc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_classid_generate(char* name, uint* result, uint parent);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_cls_add(nl_sock* sk, rtnl_cls* cls, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_cls_alloc_cache(nl_sock* sk, int ifindex, uint parent, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_cls_build_add_request(rtnl_cls* cls, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_cls_build_change_request(rtnl_cls* cls, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_cls_build_delete_request(rtnl_cls* cls, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_cls_change(nl_sock* sk, rtnl_cls* cls, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_cls_delete(nl_sock* sk, rtnl_cls* cls, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_ematch_add_child(rtnl_ematch* parent, rtnl_ematch* child);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_ematch_fill_attr(nl_msg* msg, int attrid, rtnl_ematch_tree* tree);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_ematch_register(rtnl_ematch_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_ematch_set_kind(rtnl_ematch* ematch, ushort kind);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_ematch_set_name(rtnl_ematch* ematch, char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_ematch_set_ops(rtnl_ematch* ematch, rtnl_ematch_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_fw_set_classid(rtnl_cls* cls, uint classid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_fw_set_mask(rtnl_cls* cls, uint mask);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_gact_get_action(rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_gact_set_action(rtnl_act* act, int action);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_get_ceil64(rtnl_class* cls, ulong* out_ceil64);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_get_level(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_get_rate64(rtnl_class* cls, ulong* out_rate64);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_cbuffer(rtnl_class* cls, uint cbuffer);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_ceil(rtnl_class* cls, uint ceil);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_ceil64(rtnl_class* cls, ulong ceil64);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_defcls(rtnl_qdisc* qdisc, uint defcls);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_level(rtnl_class* cls, int level);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_prio(rtnl_class* cls, uint prio);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_quantum(rtnl_class* cls, uint quantum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_rate(rtnl_class* cls, uint rate);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_rate2quantum(rtnl_qdisc* qdisc, uint rate2quantum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_rate64(rtnl_class* cls, ulong rate);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_htb_set_rbuffer(rtnl_class* cls, uint rbuffer);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_add(nl_sock* sk, rtnl_link* link, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_af_data_compare(rtnl_link* a, rtnl_link* b, int family);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_af_register(rtnl_link_af_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_af_unregister(rtnl_link_af_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_alloc_cache_flags(nl_sock* sk, int family, nl_cache** result, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_alloc_cache(nl_sock* sk, int family, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_bridge_str2flags(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_bridge_str2portstate(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_build_add_request(rtnl_link* link, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_build_change_request(rtnl_link* orig, rtnl_link* changes, int flags,
            nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_build_delete_request(rtnl_link* link, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_build_get_request(int ifindex, char* name, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_berr_rx(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_berr_tx(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_berr(rtnl_link* link, can_berr_counter* berr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_freq(rtnl_link* link, uint* freq);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_get_bitrate(rtnl_link* link, uint* bitrate);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_get_bittiming(rtnl_link* link, can_bittiming* bit_timing);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_get_bt_const(rtnl_link* link, can_bittiming_const* bt_const);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_get_ctrlmode(rtnl_link* link, uint* ctrlmode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_get_restart_ms(rtnl_link* link, uint* interval);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_get_sample_point(rtnl_link* link, uint* sp);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_restart(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_set_bitrate(rtnl_link* link, uint bitrate);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_set_bittiming(rtnl_link* link, can_bittiming* bit_timing);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_set_ctrlmode(rtnl_link* link, uint ctrlmode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_set_restart_ms(rtnl_link* link, uint interval);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_set_sample_point(rtnl_link* link, uint sp);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_state(rtnl_link* link, uint* state);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_str2ctrlmode(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_can_unset_ctrlmode(rtnl_link* link, uint ctrlmode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_change(nl_sock* sk, rtnl_link* orig, rtnl_link* changes, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_delete(nl_sock* sk, rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_enslave_ifindex(nl_sock* sock, int master, int slave);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_enslave(nl_sock* sock, rtnl_link* master, rtnl_link* slave);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_flags(rtnl_link* link, byte* flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_id(rtnl_link* link, uint* id);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_label(rtnl_link* link, uint* label);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_port(rtnl_link* link, uint* port);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_remote(rtnl_link* link, nl_addr** addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_tos(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_ttl(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_udp_csum(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_udp_zero_csum6_rx(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_get_udp_zero_csum6_tx(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_flags(rtnl_link* link, byte flags, int enable);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_id(rtnl_link* link, uint id);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_label(rtnl_link* link, uint label);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_port(rtnl_link* link, uint port);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_remote(rtnl_link* link, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_tos(rtnl_link* link, byte tos);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_ttl(rtnl_link* link, byte ttl);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_udp_csum(rtnl_link* link, byte csum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_udp_zero_csum6_rx(rtnl_link* link, byte csum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_geneve_set_udp_zero_csum6_tx(rtnl_link* link, byte csum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_carrier_changes(rtnl_link* link, uint* carrier_changes);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_family(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_gso_max_segs(rtnl_link* link, uint* gso_max_segs);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_gso_max_size(rtnl_link* link, uint* gso_max_size);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_ifindex(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_kernel(nl_sock* sk, int ifindex, char* name, rtnl_link** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_link_netnsid(rtnl_link* link, int* out_link_netnsid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_link(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_master(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_ns_fd(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_num_vf(rtnl_link* link, uint* num_vf);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_has_vf_list(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_info_data_compare(rtnl_link* a, rtnl_link* b, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_ipvlan_get_mode(rtnl_link* link, ushort* out_mode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_ipvlan_set_mode(rtnl_link* link, ushort mode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_ipvlan_str2mode(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_can(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_geneve(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_ipvlan(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_macvlan(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_macvtap(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_veth(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_vlan(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_vrf(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_is_vxlan(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_cipher_suite(rtnl_link* link, ulong* cs);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_encoding_sa(rtnl_link* link, byte* encoding_sa);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_encrypt(rtnl_link* link, byte* encrypt);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_end_station(rtnl_link* link, byte* es);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_icv_len(rtnl_link* link, ushort* icv_len);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_port(rtnl_link* link, ushort* port);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_protect(rtnl_link* link, byte* protect);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_replay_protect(rtnl_link* link, byte* replay_protect);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_scb(rtnl_link* link, byte* scb);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_sci(rtnl_link* link, ulong* sci);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_send_sci(rtnl_link* link, byte* send_sci);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_get_window(rtnl_link* link, uint* window);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_cipher_suite(rtnl_link* link, ulong cipher_suite);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_encoding_sa(rtnl_link* link, byte encoding_sa);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_encrypt(rtnl_link* link, byte encrypt);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_end_station(rtnl_link* link, byte end_station);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_icv_len(rtnl_link* link, ushort icv_len);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_port(rtnl_link* link, ushort port);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_protect(rtnl_link* link, byte protect);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_replay_protect(rtnl_link* link, byte replay_protect);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_scb(rtnl_link* link, byte scb);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_sci(rtnl_link* link, ulong sci);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_send_sci(rtnl_link* link, byte send_sci);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macsec_set_window(rtnl_link* link, uint window);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_add_macaddr(rtnl_link* link, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_count_macaddr(rtnl_link* link, uint* out_count);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_del_macaddr(rtnl_link* link, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_get_macaddr(rtnl_link* link, uint idx, nl_addr** out_addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_get_macmode(rtnl_link* link, uint* out_macmode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_set_flags(rtnl_link* link, ushort flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_set_macmode(rtnl_link* link, uint macmode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_set_mode(rtnl_link* link, uint mode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_str2flags(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_str2macmode(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_str2mode(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvlan_unset_flags(rtnl_link* link, ushort flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvtap_set_flags(rtnl_link* link, ushort flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvtap_set_mode(rtnl_link* link, uint mode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvtap_str2flags(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvtap_str2mode(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_macvtap_unset_flags(rtnl_link* link, ushort flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_name2i(nl_cache* cache, byte* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_ppp_get_fd(rtnl_link* link, int* fd);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_ppp_set_fd(rtnl_link* link, int fd);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_register_info(rtnl_link_info_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_release_ifindex(nl_sock* sock, int slave);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_release(nl_sock* sock, rtnl_link* slave);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_set_info_type(rtnl_link* link, char* type);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_set_link_netnsid(rtnl_link* link, int link_netnsid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_set_slave_type(rtnl_link* link, char* type);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_set_stat(rtnl_link* link, rtnl_link_stat_id_t id, ulong value);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_set_type(rtnl_link* link, char* type);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_str2carrier(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_str2flags(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_str2mode(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_str2operstate(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_str2stat(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_unregister_info(rtnl_link_info_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_veth_add(nl_sock* sock, char* name, char* peer_name, int pid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_add(rtnl_link* link, rtnl_link_vf* vf_data);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_addr(rtnl_link_vf* vf_data, nl_addr** addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_index(rtnl_link_vf* vf_data, uint* vf_index);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_linkstate(rtnl_link_vf* vf_data, uint* vf_linkstate);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_rate(rtnl_link_vf* vf_data, nl_vf_rate* vf_rate);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_rss_query_en(rtnl_link_vf* vf_data, uint* vf_rss_query_en);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_spoofchk(rtnl_link_vf* vf_data, uint* vf_spoofchk);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_stat(rtnl_link_vf* vf_data, rtnl_link_vf_stats_t stat,
            ulong* vf_stat);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_trust(rtnl_link_vf* vf_data, uint* vf_trust);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_get_vlans(rtnl_link_vf* vf_data, nl_vf_vlans_t** vf_vlans);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_str2guid(ulong* guid, char* guid_s);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_str2linkstate(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_str2vlanproto(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vf_vlan_alloc(nl_vf_vlans_t** vf_vlans, int vlan_count);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_get_flags(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_get_id(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_get_protocol(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_set_egress_map(rtnl_link* link, uint from, int to);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_set_flags(rtnl_link* link, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_set_id(rtnl_link* link, ushort id);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_set_ingress_map(rtnl_link* link, int from, uint to);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_set_protocol(rtnl_link* link, ushort protocol);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_str2flags(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vlan_unset_flags(rtnl_link* link, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vrf_get_tableid(rtnl_link* link, uint* id);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vrf_set_tableid(rtnl_link* link, uint id);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_disable_l2miss(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_disable_l3miss(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_disable_learning(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_disable_proxy(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_disable_rsc(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_enable_l2miss(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_enable_l3miss(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_enable_learning(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_enable_proxy(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_enable_rsc(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_ageing(rtnl_link* link, uint* expiry);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_collect_metadata(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_flags(rtnl_link* link, uint* out_flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_group(rtnl_link* link, nl_addr** addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_id(rtnl_link* link, uint* id);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_l2miss(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_l3miss(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_label(rtnl_link* link, uint* label);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_learning(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_limit(rtnl_link* link, uint* limit);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_link(rtnl_link* link, uint* index);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_local(rtnl_link* link, nl_addr** addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_port_range(rtnl_link* link, ifla_vxlan_port_range* range);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_port(rtnl_link* link, uint* port);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_proxy(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_remcsum_rx(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_remcsum_tx(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_rsc(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_tos(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_ttl(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_udp_csum(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_udp_zero_csum6_rx(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_get_udp_zero_csum6_tx(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_ageing(rtnl_link* link, uint expiry);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_collect_metadata(rtnl_link* link, byte collect);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_flags(rtnl_link* link, uint flags, int enable);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_group(rtnl_link* link, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_id(rtnl_link* link, uint id);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_l2miss(rtnl_link* link, byte miss);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_l3miss(rtnl_link* link, byte miss);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_label(rtnl_link* link, uint label);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_learning(rtnl_link* link, byte learning);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_limit(rtnl_link* link, uint limit);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_link(rtnl_link* link, uint index);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_local(rtnl_link* link, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_port_range(rtnl_link* link, ifla_vxlan_port_range* range);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_port(rtnl_link* link, uint port);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_proxy(rtnl_link* link, byte proxy);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_remcsum_rx(rtnl_link* link, byte csum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_remcsum_tx(rtnl_link* link, byte csum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_rsc(rtnl_link* link, byte rsc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_tos(rtnl_link* link, byte tos);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_ttl(rtnl_link* link, byte ttl);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_udp_csum(rtnl_link* link, byte csum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_udp_zero_csum6_rx(rtnl_link* link, byte csum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_vxlan_set_udp_zero_csum6_tx(rtnl_link* link, byte csum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mall_append_action(rtnl_cls* cls, rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mall_del_action(rtnl_cls* cls, rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mall_get_classid(rtnl_cls* cls, uint* clsid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mall_get_flags(rtnl_cls* cls, uint* flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mall_set_classid(rtnl_cls* cls, uint classid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mall_set_flags(rtnl_cls* cls, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mirred_get_action(rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mirred_get_policy(rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mirred_set_action(rtnl_act* act, int action);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mirred_set_ifindex(rtnl_act* act, uint ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_mirred_set_policy(rtnl_act* act, int policy);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_add(nl_sock* sk, rtnl_neigh* tmpl, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_alloc_cache_flags(nl_sock* sock, nl_cache** result, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_alloc_cache(nl_sock* sock, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_build_add_request(rtnl_neigh* tmpl, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_build_delete_request(rtnl_neigh* neigh, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_delete(nl_sock* sk, rtnl_neigh* neigh, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_get_family(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_get_ifindex(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_get_master(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_get_state(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_get_type(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_get_vlan(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_set_dst(rtnl_neigh* neigh, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_str2flag(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neigh_str2state(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neightbl_alloc_cache(nl_sock* sk, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neightbl_build_change_request(rtnl_neightbl* old, rtnl_neightbl* tmpl,
            nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_neightbl_change(nl_sock* sk, rtnl_neightbl* old, rtnl_neightbl* tmpl);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_alloc_cache(nl_sock* sk, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_get_family(rtnl_netconf* nc, int* val);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_get_forwarding(rtnl_netconf* nc, int* val);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_get_ifindex(rtnl_netconf* nc, int* val);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_get_ignore_routes_linkdown(rtnl_netconf* nc, int* val);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_get_input(rtnl_netconf* nc, int* val);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_get_mc_forwarding(rtnl_netconf* nc, int* val);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_get_proxy_neigh(rtnl_netconf* nc, int* val);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netconf_get_rp_filter(rtnl_netconf* nc, int* val);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_corruption_correlation(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_corruption_probability(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_delay_correlation(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_delay_distribution_size(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_delay_distribution(rtnl_qdisc* qdisc, short** dist_ptr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_delay(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_duplicate_correlation(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_duplicate(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_gap(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_jitter(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_limit(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_loss_correlation(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_loss(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_reorder_correlation(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_get_reorder_probability(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_set_delay_distribution_data(rtnl_qdisc* qdisc, short* data, uint len);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_netem_set_delay_distribution(rtnl_qdisc* qdisc, char* dist_type);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_add(nl_sock* sk, rtnl_qdisc* qdisc, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_alloc_cache(nl_sock* sk, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_build_add_request(rtnl_qdisc* qdisc, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_build_change_request(rtnl_qdisc* qdisc, rtnl_qdisc* newVal, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_build_delete_request(rtnl_qdisc* qdisc, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_build_update_request(rtnl_qdisc* qdisc, rtnl_qdisc* newVal, int flags,
            nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_change(nl_sock* sk, rtnl_qdisc* qdisc, rtnl_qdisc* newVal);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_delete(nl_sock* sk, rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_dsmark_get_default_index(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_dsmark_get_indices(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_dsmark_get_set_tc_index(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_dsmark_set_default_index(rtnl_qdisc* qdisc, ushort default_index);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_dsmark_set_indices(rtnl_qdisc* qdisc, ushort indices);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_dsmark_set_set_tc_index(rtnl_qdisc* qdisc, int flag);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fifo_get_limit(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fifo_set_limit(rtnl_qdisc* qdisc, int limit);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_get_ecn(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_get_flows(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_get_limit(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_set_ecn(rtnl_qdisc* qdisc, int ecn);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_set_flows(rtnl_qdisc* qdisc, int flows);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_set_interval(rtnl_qdisc* qdisc, uint interval);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_set_limit(rtnl_qdisc* qdisc, int limit);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_set_quantum(rtnl_qdisc* qdisc, uint quantum);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_fq_codel_set_target(rtnl_qdisc* qdisc, uint target);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_hfsc_set_defcls(rtnl_qdisc* qdisc, uint defcls);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_get_hw_offload(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_get_max_rate(rtnl_qdisc* qdisc, ulong* max);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_get_min_rate(rtnl_qdisc* qdisc, ulong* min);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_get_mode(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_get_num_tc(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_get_queue(rtnl_qdisc* qdisc, ushort* count, ushort* offset);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_get_shaper(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_hw_offload(rtnl_qdisc* qdisc, int offload);
        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_set_mode(rtnl_qdisc* qdisc, ushort mode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_set_num_tc(rtnl_qdisc* qdisc, int num_tc);
        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_mqprio_set_shaper(rtnl_qdisc* qdisc, ushort shaper);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_plug_buffer(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_plug_release_indefinite(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_plug_release_one(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_plug_set_limit(rtnl_qdisc* qdisc, int limit);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_prio_get_bands(rtnl_qdisc* qdisc);
        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_get_limit(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_get_peakrate_bucket(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_get_peakrate_cell(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_get_peakrate(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_get_rate_bucket(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_get_rate_cell(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_get_rate(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_set_limit_by_latency(rtnl_qdisc* qdisc, int latency);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_tbf_set_peakrate(rtnl_qdisc* qdisc, int rate, int bucket, int cell);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_qdisc_update(nl_sock* sk, rtnl_qdisc* qdisc, rtnl_qdisc* newVal, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_red_get_limit(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_add(nl_sock* sk, rtnl_route* route, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_alloc_cache(nl_sock* sk, int family, int flags, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_build_add_request(rtnl_route* tmpl, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_build_del_request(rtnl_route* tmpl, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_delete(nl_sock* sk, rtnl_route* route, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_get_iif(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_get_metric(rtnl_route* route, int metric, uint* value);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_get_nnexthops(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_get_ttl_propagate(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_guess_scope(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_nh_get_ifindex(rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_nh_set_newdst(rtnl_nexthop* nh, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_nh_set_via(rtnl_nexthop* nh, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_nh_str2flags(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_read_protocol_names(char* path);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_read_table_names(char* path);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_set_dst(rtnl_route* route, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_set_family(rtnl_route* route, byte family);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_set_metric(rtnl_route* route, int metric, uint value);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_set_pref_src(rtnl_route* route, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_set_src(rtnl_route* route, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_set_type(rtnl_route* route, byte type);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_str2metric(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_str2proto(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_str2table(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_route_unset_metric(rtnl_route* route, int metric);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_add(nl_sock* sk, rtnl_rule* tmpl, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_alloc_cache(nl_sock* sock, int family, nl_cache** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_build_add_request(rtnl_rule* tmpl, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_build_delete_request(rtnl_rule* rule, int flags, nl_msg** result);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_delete(nl_sock* sk, rtnl_rule* rule, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_get_dport(rtnl_rule* rule, ushort* start, ushort* end);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_get_family(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_get_ipproto(rtnl_rule* rule, byte* ip_proto);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_get_l3mdev(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_get_protocol(rtnl_rule* rule, byte* protocol);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_get_sport(rtnl_rule* rule, ushort* start, ushort* end);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_dport_range(rtnl_rule* rule, ushort start, ushort end);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_dport(rtnl_rule* rule, ushort dport);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_dst(rtnl_rule* rule, nl_addr* dst);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_iif(rtnl_rule* rule, char* dev);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_ipproto(rtnl_rule* rule, byte ip_proto);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_oif(rtnl_rule* rule, char* dev);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_protocol(rtnl_rule* rule, byte protocol);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_sport_range(rtnl_rule* rule, ushort start, ushort end);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_sport(rtnl_rule* rule, ushort sport);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_rule_set_src(rtnl_rule* rule, nl_addr* src);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_sfq_get_divisor(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_sfq_get_limit(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_sfq_get_perturb(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_sfq_get_quantum(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_skbedit_get_action(rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_skbedit_get_mark(rtnl_act* act, uint* mark);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_skbedit_get_priority(rtnl_act* act, uint* prio);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_skbedit_get_queue_mapping(rtnl_act* act, ushort* index);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_skbedit_set_action(rtnl_act* act, int action);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_skbedit_set_mark(rtnl_act* act, uint mark);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_skbedit_set_priority(rtnl_act* act, uint prio);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_skbedit_set_queue_mapping(rtnl_act* act, ushort index);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_str2prio(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_str2scope(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_build_rate_table(rtnl_tc* tc, rtnl_ratespec* spec, uint* dst);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_calc_bufsize(int txtime, int rate);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_calc_cell_log(int cell_size);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_calc_txtime(int bufsize, int rate);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_clone(nl_object* dstobj, nl_object* srcobj);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_get_chain(rtnl_tc* tc, uint* out_value);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_get_ifindex(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_read_classid_file();

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_register(rtnl_tc_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_set_kind(rtnl_tc* tc, char* kind);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_str2handle(char* str, uint* res);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_tc_str2stat(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_add_action(rtnl_cls* cls, rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_add_key_uint16(rtnl_cls* cls, ushort val, ushort mask, int off,
            int offmask);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_add_key_uint32(rtnl_cls* cls, uint val, uint mask, int off, int offmask);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_add_key_uint8(rtnl_cls* cls, byte val, byte mask, int off, int offmask);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_add_key(rtnl_cls* cls, uint val, uint mask, int off, int offmask);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_add_mark(rtnl_cls* cls, uint val, uint mask);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_del_action(rtnl_cls* cls, rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_del_mark(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_get_classid(rtnl_cls* cls, uint* clsid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_get_key(rtnl_cls* cls, byte index, uint* val, uint* mask, int* off,
            int* offmask);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_set_classid(rtnl_cls* cls, uint classid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_set_cls_terminal(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_set_divisor(rtnl_cls* cls, uint divisor);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_set_flags(rtnl_cls* cls, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_set_hashmask(rtnl_cls* cls, uint hashmask, uint offset);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_set_hashtable(rtnl_cls* cls, uint ht);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_set_link(rtnl_cls* cls, uint link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_u32_set_selector(rtnl_cls* cls, int offoff, uint offmask, char offshift,
            ushort off, char flags);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_get_action(rtnl_act* act, int* out_action);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_get_mode(rtnl_act* act, int* out_mode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_get_protocol(rtnl_act* act, ushort* out_protocol);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_get_vlan_id(rtnl_act* act, ushort* out_vid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_get_vlan_prio(rtnl_act* act, byte* out_prio);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_set_action(rtnl_act* act, int action);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_set_mode(rtnl_act* act, int mode);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_set_protocol(rtnl_act* act, ushort protocol);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_set_vlan_id(rtnl_act* act, ushort vid);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_vlan_set_vlan_prio(rtnl_act* act, byte prio);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_addr_get_anycast(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_addr_get_broadcast(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_addr_get_local(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_addr_get_multicast(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_addr_get_peer(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_link_get_addr(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_link_get_broadcast(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_neigh_get_dst(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_neigh_get_lladdr(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_route_get_dst(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_route_get_pref_src(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_route_get_src(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_route_nh_get_gateway(rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_route_nh_get_newdst(rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_route_nh_get_via(rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_rule_get_dst(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern nl_addr* rtnl_rule_get_src(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern nl_data* rtnl_link_get_phys_port_id(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern nl_data* rtnl_link_get_phys_switch_id(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern int rtnl_link_get_ns_pid(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_act* rtnl_act_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_act* rtnl_basic_get_action(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_act* rtnl_mall_get_first_action(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_act* rtnl_u32_get_action(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_addr* rtnl_addr_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_addr* rtnl_addr_get(nl_cache* cache, int ifindex, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_class* rtnl_class_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_class* rtnl_class_get_by_parent(nl_cache* cache, int ifindex, uint parent);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_class* rtnl_class_get(nl_cache* cache, int ifindex, uint handle);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_cls* rtnl_cls_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_ematch_tree* rtnl_basic_get_ematch(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_ematch_tree* rtnl_cgroup_get_ematch(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_ematch_tree* rtnl_ematch_tree_alloc(ushort progid);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_ematch_tree* rtnl_ematch_tree_clone(rtnl_ematch_tree* src);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_ematch* rtnl_ematch_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link_af_ops* rtnl_link_af_ops_lookup(uint family);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_link_info_ops* rtnl_link_info_ops_lookup(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_neigh* rtnl_neigh_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_neigh*
            rtnl_neigh_get_by_vlan(nl_cache* cache, int ifindex, nl_addr* lladdr, int vlan);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_neigh* rtnl_neigh_get(nl_cache* cache, int ifindex, nl_addr* dst);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_neightbl* rtnl_neightbl_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_neightbl* rtnl_neightbl_get(nl_cache* cache, char* name, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_netconf* rtnl_netconf_get_all(nl_cache* cache, int family);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_netconf* rtnl_netconf_get_by_idx(nl_cache* cache, int family, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_netconf* rtnl_netconf_get_default(nl_cache* cache, int family);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_nexthop* rtnl_route_nexthop_n(rtnl_route* r, int n);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_nexthop* rtnl_route_nh_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_nexthop* rtnl_route_nh_clone(rtnl_nexthop* src);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_qdisc* rtnl_class_leaf_qdisc(rtnl_class* cls, nl_cache* cache);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_qdisc* rtnl_qdisc_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_qdisc* rtnl_qdisc_get_by_parent(nl_cache* cache, int ifindex, uint parent);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_qdisc* rtnl_qdisc_get(nl_cache* cache, int ifindex, uint handle);

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_route* rtnl_route_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_rule* rtnl_rule_alloc();

        [DllImport("libnl-route-3.so")]
        public static extern rtnl_tc_ops* rtnl_tc_get_ops(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern ushort rtnl_cls_get_prio(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern ushort rtnl_cls_get_protocol(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern ushort rtnl_ematch_get_flags(rtnl_ematch* ematch);

        [DllImport("libnl-route-3.so")]
        public static extern ushort rtnl_link_bridge_str2hwmode(char* name);

        [DllImport("libnl-route-3.so")]
        public static extern ushort rtnl_link_macvlan_get_flags(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern ushort rtnl_link_macvtap_get_flags(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_addr_get_create_time(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_addr_get_last_update_time(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_addr_get_preferred_lifetime(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_addr_get_valid_lifetime(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_basic_get_target(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_htb_get_cbuffer(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_htb_get_ceil(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_htb_get_defcls(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_htb_get_prio(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_htb_get_quantum(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_htb_get_rate(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_htb_get_rate2quantum(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_htb_get_rbuffer(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_group(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_num_rx_queues(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_num_tx_queues(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_promiscuity(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_macvlan_get_mode(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_macvtap_get_mode(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_mirred_get_ifindex(rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_qdisc_fq_codel_get_interval(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_qdisc_fq_codel_get_quantum(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_qdisc_fq_codel_get_target(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_qdisc_hfsc_get_defcls(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_route_get_flags(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_route_get_priority(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_route_get_table(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_route_nh_get_realms(rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_rule_get_goto(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_rule_get_mark(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_rule_get_mask(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_rule_get_prio(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_rule_get_realms(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_rule_get_table(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_tc_get_handle(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_tc_get_linktype(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_tc_get_mpu(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_tc_get_mtu(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_tc_get_overhead(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_tc_get_parent(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern uint* rtnl_link_vlan_get_ingress_map(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern ulong rtnl_link_get_stat(rtnl_link* link, rtnl_link_stat_id_t id);

        [DllImport("libnl-route-3.so")]
        public static extern ulong rtnl_tc_compare(nl_object* aobj, nl_object* bobj, ulong attrs, int flags);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_link_get_carrier(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_link_get_linkmode(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_link_get_operstate(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_route_get_family(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_route_get_protocol(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_route_get_scope(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_route_get_tos(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_route_get_type(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_route_nh_get_weight(rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_rule_get_action(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern byte rtnl_rule_get_dsfield(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern byte* rtnl_qdisc_mqprio_get_priomap(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern byte* rtnl_qdisc_prio_get_priomap(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_addr_get_flags(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_arptype(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_flags(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_mtu(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_txqlen(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_link_get_weight(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_neigh_get_flags(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern uint rtnl_route_nh_get_flags(rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_act_get(rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_act_put(rtnl_act* act);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_put(rtnl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_set_family(rtnl_addr* addr, int family);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_set_flags(rtnl_addr* addr, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_set_ifindex(rtnl_addr* addr, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_set_link(rtnl_addr* addr, rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_set_preferred_lifetime(rtnl_addr* addr, uint lifetime);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_set_prefixlen(rtnl_addr* addr, int prefixlen);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_set_scope(rtnl_addr* addr, int scope);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_set_valid_lifetime(rtnl_addr* addr, uint lifetime);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_addr_unset_flags(rtnl_addr* addr, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_basic_set_ematch(rtnl_cls* cls, rtnl_ematch_tree* tree);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_basic_set_target(rtnl_cls* cls, uint target);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_cgroup_set_ematch(rtnl_cls* cls, rtnl_ematch_tree* tree);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_class_put(rtnl_class* cls);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_cls_cache_set_tc_params(nl_cache* cache, int ifindex, uint parent);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_cls_put(rtnl_cls* cls);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_cls_set_prio(rtnl_cls* cls, ushort prio);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_cls_set_protocol(rtnl_cls* cls, ushort protocol);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_ematch_free(rtnl_ematch* ematch);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_ematch_set_flags(rtnl_ematch* ematch, ushort flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_ematch_tree_add(rtnl_ematch_tree* tree, rtnl_ematch* ematch);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_ematch_tree_dump(rtnl_ematch_tree* tree, nl_dump_params* p);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_ematch_tree_free(rtnl_ematch_tree* tree);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_ematch_unlink(rtnl_ematch* ematch);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_ematch_unset_flags(rtnl_ematch* ematch, ushort flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_af_ops_put(rtnl_link_af_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_info_ops_put(rtnl_link_info_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_put(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_addr(rtnl_link* link, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_arptype(rtnl_link* link, uint arptype);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_broadcast(rtnl_link* link, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_carrier(rtnl_link* link, byte status);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_family(rtnl_link* link, int family);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_flags(rtnl_link* link, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_group(rtnl_link* link, uint group);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_ifalias(rtnl_link* link, char* alias);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_ifindex(rtnl_link* link, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_link(rtnl_link* link, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_linkmode(rtnl_link* link, byte mode);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_master(rtnl_link* link, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_mtu(rtnl_link* link, uint mtu);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_name(rtnl_link* link, char* name);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_ns_fd(rtnl_link* link, int fd);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_ns_pid(rtnl_link* link, int pid);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_num_rx_queues(rtnl_link* link, uint nqueues);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_num_tx_queues(rtnl_link* link, uint nqueues);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_operstate(rtnl_link* link, byte status);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_promiscuity(rtnl_link* link, uint count);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_qdisc(rtnl_link* link, char* name);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_txqlen(rtnl_link* link, uint txqlen);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_vf_list(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_set_weight(rtnl_link* link, uint weight);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_unset_flags(rtnl_link* link, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_unset_vf_list(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_veth_release(rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_free(rtnl_link_vf* vf_data);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_put(rtnl_link_vf* vf_data);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_addr(rtnl_link_vf* vf_data, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_ib_node_guid(rtnl_link_vf* vf_data, ulong guid);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_ib_port_guid(rtnl_link_vf* vf_data, ulong guid);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_index(rtnl_link_vf* vf_data, uint vf_index);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_linkstate(rtnl_link_vf* vf_data, uint vf_linkstate);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_rate(rtnl_link_vf* vf_data, nl_vf_rate* vf_rate);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_rss_query_en(rtnl_link_vf* vf_data, uint vf_rss_query_en);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_spoofchk(rtnl_link_vf* vf_data, uint vf_spoofchk);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_trust(rtnl_link_vf* vf_data, uint vf_trust);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_set_vlans(rtnl_link_vf* vf_data, nl_vf_vlans_t* vf_vlans);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_vlan_free(nl_vf_vlans_t* vf_vlans);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_link_vf_vlan_put(nl_vf_vlans_t* vf_vlans);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_put(rtnl_neigh* neigh);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_set_family(rtnl_neigh* neigh, int family);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_set_flags(rtnl_neigh* neigh, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_set_ifindex(rtnl_neigh* neigh, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_set_lladdr(rtnl_neigh* neigh, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_set_master(rtnl_neigh* neigh, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_set_state(rtnl_neigh* neigh, int state);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_set_type(rtnl_neigh* neigh, int type);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_set_vlan(rtnl_neigh* neigh, int vlan);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_unset_flags(rtnl_neigh* neigh, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neigh_unset_state(rtnl_neigh* neigh, int state);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_put(rtnl_neightbl* neightbl);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_anycast_delay(rtnl_neightbl* ntbl, ulong ms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_app_probes(rtnl_neightbl* ntbl, int probes);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_base_reachable_time(rtnl_neightbl* ntbl, ulong ms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_delay_probe_time(rtnl_neightbl* ntbl, ulong ms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_dev(rtnl_neightbl* ntbl, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_family(rtnl_neightbl* ntbl, int family);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_gc_interval(rtnl_neightbl* ntbl, ulong ms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_gc_stale_time(rtnl_neightbl* ntbl, ulong ms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_gc_tresh1(rtnl_neightbl* ntbl, int thresh);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_gc_tresh2(rtnl_neightbl* ntbl, int thresh);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_gc_tresh3(rtnl_neightbl* ntbl, int thresh);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_locktime(rtnl_neightbl* ntbl, ulong ms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_mcast_probes(rtnl_neightbl* ntbl, int probes);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_name(rtnl_neightbl* ntbl, char* name);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_proxy_delay(rtnl_neightbl* ntbl, ulong ms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_proxy_queue_len(rtnl_neightbl* ntbl, int len);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_queue_len(rtnl_neightbl* ntbl, int len);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_retrans_time(rtnl_neightbl* ntbl, ulong ms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_neightbl_set_ucast_probes(rtnl_neightbl* ntbl, int probes);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netconf_put(rtnl_netconf* nc);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_corruption_correlation(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_corruption_probability(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_delay_correlation(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_delay(rtnl_qdisc* qdisc, int delay);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_duplicate_correlation(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_duplicate(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_gap(rtnl_qdisc* qdisc, int gap);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_jitter(rtnl_qdisc* qdisc, int jitter);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_limit(rtnl_qdisc* qdisc, int limit);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_loss_correlation(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_loss(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_reorder_correlation(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_netem_set_reorder_probability(rtnl_qdisc* qdisc, int prob);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_qdisc_prio_set_bands(rtnl_qdisc* qdisc, int bands);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_qdisc_put(rtnl_qdisc* qdisc);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_qdisc_tbf_set_limit(rtnl_qdisc* qdisc, int limit);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_qdisc_tbf_set_rate(rtnl_qdisc* qdisc, int rate, int bucket, int cell);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_red_set_limit(rtnl_qdisc* qdisc, int limit);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_add_nexthop(rtnl_route* route, rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_get(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_nh_free(rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_nh_set_flags(rtnl_nexthop* nh, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_nh_set_gateway(rtnl_nexthop* nh, nl_addr* addr);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_nh_set_ifindex(rtnl_nexthop* nh, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_nh_set_realms(rtnl_nexthop* nh, uint realms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_nh_set_weight(rtnl_nexthop* nh, byte weight);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_nh_unset_flags(rtnl_nexthop* nh, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_put(rtnl_route* route);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_remove_nexthop(rtnl_route* route, rtnl_nexthop* nh);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_set_flags(rtnl_route* route, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_set_iif(rtnl_route* route, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_set_priority(rtnl_route* route, uint prio);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_set_protocol(rtnl_route* route, byte protocol);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_set_scope(rtnl_route* route, byte scope);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_set_table(rtnl_route* route, uint table);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_set_tos(rtnl_route* route, byte tos);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_set_ttl_propagate(rtnl_route* route, byte ttl_prop);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_route_unset_flags(rtnl_route* route, uint flags);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_put(rtnl_rule* rule);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_action(rtnl_rule* rule, byte action);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_dsfield(rtnl_rule* rule, byte dsfield);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_family(rtnl_rule* rule, int family);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_goto(rtnl_rule* rule, uint reference);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_l3mdev(rtnl_rule* rule, int value);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_mark(rtnl_rule* rule, uint mark);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_mask(rtnl_rule* rule, uint mask);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_prio(rtnl_rule* rule, uint prio);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_realms(rtnl_rule* rule, uint realms);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_rule_set_table(rtnl_rule* rule, uint table);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_sfq_set_limit(rtnl_qdisc* qdisc, int limit);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_sfq_set_perturb(rtnl_qdisc* qdisc, int perturb);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_sfq_set_quantum(rtnl_qdisc* qdisc, int quantum);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_dump_details(nl_object* obj, nl_dump_params* p);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_dump_line(nl_object* obj, nl_dump_params* p);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_dump_stats(nl_object* obj, nl_dump_params* p);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_free_data(nl_object* obj);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_chain(rtnl_tc* tc, uint chain);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_handle(rtnl_tc* tc, uint id);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_ifindex(rtnl_tc* tc, int ifindex);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_link(rtnl_tc* tc, rtnl_link* link);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_linktype(rtnl_tc* tc, uint type);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_mpu(rtnl_tc* tc, uint mpu);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_mtu(rtnl_tc* tc, uint mtu);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_overhead(rtnl_tc* tc, uint overhead);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_set_parent(rtnl_tc* tc, uint parent);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_type_register(rtnl_tc_type_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_type_unregister(rtnl_tc_type_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_tc_unregister(rtnl_tc_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern void rtnl_u32_set_handle(rtnl_cls* cls, int htid, int hash, int nodeid);

        [DllImport("libnl-route-3.so")]
        public static extern void* rtnl_ematch_data(rtnl_ematch* ematch);

        [DllImport("libnl-route-3.so")]
        public static extern void* rtnl_link_af_alloc(rtnl_link* link, rtnl_link_af_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern void* rtnl_link_af_data(rtnl_link* link, rtnl_link_af_ops* ops);

        [DllImport("libnl-route-3.so")]
        public static extern void* rtnl_tc_data_check(rtnl_tc* tc, rtnl_tc_ops* ops, int* err);

        [DllImport("libnl-route-3.so")]
        public static extern void* rtnl_tc_data_peek(rtnl_tc* tc);

        [DllImport("libnl-route-3.so")]
        public static extern void* rtnl_tc_data(rtnl_tc* tc);
    }
}