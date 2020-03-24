using System;
using System.Runtime.InteropServices;

namespace libnl
{
    public struct nl_addr
    {
    }

    public struct nl_object
    {
    }

    public struct nl_cache
    {
    }

    public struct nl_object_ops
    {
    }

    public struct nl_cache_ops
    {
    }

    public struct nl_msg
    {
    }

    public struct nl_sock
    {
    }

    public struct nl_dump_params
    {
    }

    public struct nl_data
    {
    }

    public struct nl_msgtype
    {
    }

    public struct nl_list_head
    {
    }

    public unsafe class LibNL3
    {
        [DllImport("libnl-3.so")]
        public static extern char* nl_addr2str(nl_addr* addr, char* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern char* nl_af2str(int family, char* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern char* nl_ether_proto2str(int eproto, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_ip_proto2str(int proto, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_llproto2str(int llproto, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_msec2str(ulong msec, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_nlfamily2str(int family, char* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern char* nl_nlmsg_flags2str(int flags, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_nlmsgtype2str(int type, char* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern char* nl_object_attr_list(nl_object* obj, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_object_attrs2str(nl_object* obj, uint attrs, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_police2str(int type, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_rtntype2str(int type, char* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern char* nl_size2str(uint size, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern char* nl_object_get_type(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern double nl_cancel_down_us(uint l, char** unit);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_cmp_prefix(nl_addr* a, nl_addr* b);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_cmp(nl_addr* a, nl_addr* b);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_get_family(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_guess_family(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_iszero(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_parse(char* addrstr, int hint, nl_addr** result);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_resolve(nl_addr* addr, char* host, uint hostlen);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_set_binary_addr(nl_addr* addr, void* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_shared(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern int nl_addr_valid(char* addr, int family);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_add(nl_cache* cache, nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_alloc_name(char* kind, nl_cache** result);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_is_empty(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_mngt_register(nl_cache_ops* ops);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_mngt_unregister(nl_cache_ops* ops);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_move(nl_cache* cache, nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_nitems_filter(nl_cache* cache, nl_object* filter);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_nitems(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_parse_and_add(nl_cache* cache, nl_msg* msg);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_pickup_checkdup(nl_sock* sk, nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_pickup(nl_sock* sk, nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_refill(nl_sock* sk, nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern int nl_cache_request_full_dump(nl_sock* sk, nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern int nl_connect(nl_sock* sk, int protocol);

        [DllImport("libnl-3.so")]
        public static extern int nl_data_append(nl_data* data, void* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern int nl_data_cmp(nl_data* a, nl_data* b);

        [DllImport("libnl-3.so")]
        public static extern int nl_get_psched_hz();

        [DllImport("libnl-3.so")]
        public static extern int nl_get_user_hz();

        [DllImport("libnl-3.so")]
        public static extern int nl_object_alloc_name(char* kind, nl_object** result);

        [DllImport("libnl-3.so")]
        public static extern int nl_object_get_msgtype(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern int nl_object_get_refcnt(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern int nl_object_identical(nl_object* a, nl_object* b);

        [DllImport("libnl-3.so")]
        public static extern int nl_object_is_marked(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern int nl_object_match_filter(nl_object* obj, nl_object* filter);

        [DllImport("libnl-3.so")]
        public static extern int nl_object_shared(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern int nl_object_update(nl_object* dst, nl_object* src);
        
        [DllImport("libnl-3.so")]
        public static extern int nl_recvmsgs_default(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern int nl_rtgen_request(nl_sock* sk, int type, int family, int flags);

        [DllImport("libnl-3.so")]
        public static extern int nl_send_auto_complete(nl_sock* sk, nl_msg* msg);

        [DllImport("libnl-3.so")]
        public static extern int nl_send_auto(nl_sock* sk, nl_msg* msg);

        [DllImport("libnl-3.so")]
        public static extern int nl_send_simple(nl_sock* sk, int type, int flags, void* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern int nl_send_sync(nl_sock* sk, nl_msg* msg);

        [DllImport("libnl-3.so")]
        public static extern int nl_send(nl_sock* sk, nl_msg* msg);

        [DllImport("libnl-3.so")]
        public static extern int nl_sendto(nl_sock* sk, void* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_add_membership(nl_sock* sk, int group);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_drop_membership(nl_sock* sk, int group);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_get_fd(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_recv_pktinfo(nl_sock* sk, int state);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_set_buffer_size(nl_sock* sk, int rxbuf, int txbuf);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_set_fd(nl_sock* sk, int protocol, int fd);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_set_msg_buf_size(nl_sock* sk, uint bufsize);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_set_nonblocking(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern int nl_socket_set_passcred(nl_sock* sk, int state);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2af(char* name);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2ether_proto(char* name);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2ip_proto(char* name);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2llproto(char* name);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2msec(char* str, ulong* result);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2nlfamily(char* name);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2nlmsgtype(char* name);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2police(char* name);

        [DllImport("libnl-3.so")]
        public static extern int nl_str2rtntype(char* name);

        [DllImport("libnl-3.so")]
        public static extern int nl_wait_for_ack(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern long nl_prob2int(char* str);

        [DllImport("libnl-3.so")]
        public static extern long nl_size2int(char* str);

        [DllImport("libnl-3.so")]
        public static extern nl_addr* nl_addr_alloc(uint maxsize);

        [DllImport("libnl-3.so")]
        public static extern nl_addr* nl_addr_build(int family, void* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern nl_addr* nl_addr_clone(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern nl_addr* nl_addr_get(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern nl_cache_ops* nl_cache_get_ops(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern nl_cache_ops* nl_cache_ops_associate_safe(int protocol, int msgtype);

        [DllImport("libnl-3.so")]
        public static extern nl_cache_ops* nl_cache_ops_associate(int protocol, int msgtype);

        [DllImport("libnl-3.so")]
        public static extern nl_cache_ops* nl_cache_ops_lookup_safe(char* name);

        [DllImport("libnl-3.so")]
        public static extern nl_cache_ops* nl_cache_ops_lookup(char* name);

        [DllImport("libnl-3.so")]
        public static extern nl_cache* nl_cache_alloc(nl_cache_ops* ops);

        [DllImport("libnl-3.so")]
        public static extern nl_cache* nl_cache_clone(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern nl_cache* nl_cache_mngt_require_safe(char* name);

        [DllImport("libnl-3.so")]
        public static extern nl_cache* nl_cache_mngt_require(char* name);

        [DllImport("libnl-3.so")]
        public static extern nl_cache* nl_cache_subset(nl_cache* orig, nl_object* filter);

        [DllImport("libnl-3.so")]
        public static extern nl_cache* nl_object_get_cache(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern nl_data* nl_data_alloc(void* buf, uint size);

        [DllImport("libnl-3.so")]
        public static extern nl_data* nl_data_clone(nl_data* src);

        [DllImport("libnl-3.so")]
        public static extern nl_msgtype* nl_msgtype_lookup(nl_cache_ops* ops, int msgtype);

        [DllImport("libnl-3.so")]
        public static extern nl_object_ops* nl_object_get_ops(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern nl_object* nl_cache_find(nl_cache* cache, nl_object* filter);

        [DllImport("libnl-3.so")]
        public static extern nl_object* nl_cache_get_first(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern nl_object* nl_cache_get_last(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern nl_object* nl_cache_get_next(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern nl_object* nl_cache_get_prev(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern nl_object* nl_cache_search(nl_cache* cache, nl_object* needle);

        [DllImport("libnl-3.so")]
        public static extern nl_object* nl_object_alloc(nl_object_ops* ops);

        [DllImport("libnl-3.so")]
        public static extern nl_object* nl_object_clone(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern nl_sock* nl_socket_alloc();

        [DllImport("libnl-3.so")]
        public static extern uint nl_data_get_size(nl_data* data);

        [DllImport("libnl-3.so")]
        public static extern uint nl_socket_get_msg_buf_size(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern uint nl_object_diff(nl_object* a, nl_object* b);

        [DllImport("libnl-3.so")]
        public static extern uint nl_object_get_id_attrs(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern uint nl_socket_get_local_port(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern uint nl_socket_get_peer_groups(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern uint nl_socket_get_peer_port(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern uint nl_ticks2us(uint ticks);

        [DllImport("libnl-3.so")]
        public static extern uint nl_us2ticks(uint us);

        [DllImport("libnl-3.so")]
        public static extern ulong nl_object_diff64(nl_object* a, nl_object* b);

        [DllImport("libnl-3.so")]
        public static extern uint nl_addr_get_len(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern uint nl_addr_get_prefixlen(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern uint nl_socket_use_seq(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern void nl_addr_put(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern void nl_addr_set_family(nl_addr* addr, int family);

        [DllImport("libnl-3.so")]
        public static extern void nl_addr_set_prefixlen(nl_addr* addr, int prefixlen);

        [DllImport("libnl-3.so")]
        public static extern void nl_auto_complete(nl_sock* sk, nl_msg* msg);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_clear(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_dump_filter(nl_cache* cache, nl_dump_params* parameters, nl_object* filter);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_dump(nl_cache* cache, nl_dump_params* parameters);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_free(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_get(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_mark_all(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_mngt_provide(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_mngt_unprovide(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_ops_get(nl_cache_ops* ops);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_ops_put(nl_cache_ops* ops);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_ops_set_flags(nl_cache_ops* ops, uint flags);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_put(nl_cache* cache);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_remove(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_set_arg1(nl_cache* cache, int arg);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_set_arg2(nl_cache* cache, int arg);

        [DllImport("libnl-3.so")]
        public static extern void nl_cache_set_flags(nl_cache* cache, uint flags);

        [DllImport("libnl-3.so")]
        public static extern void nl_close(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern void nl_complete_msg(nl_sock* sk, nl_msg* msg);

        [DllImport("libnl-3.so")]
        public static extern void nl_data_free(nl_data* data);

        [DllImport("libnl-3.so")]
        public static extern void nl_join_groups(nl_sock* sk, int groups);

        [DllImport("libnl-3.so")]
        public static extern void nl_new_line(nl_dump_params* parameters);

        [DllImport("libnl-3.so")]
        public static extern void nl_object_dump_buf(nl_object* obj, char* buf, uint len);

        [DllImport("libnl-3.so")]
        public static extern void nl_object_dump(nl_object* obj, nl_dump_params* parameters);

        [DllImport("libnl-3.so")]
        public static extern void nl_object_free(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern void nl_object_get(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern void nl_object_keygen(nl_object* obj, uint* hashkey, uint hashtbl_sz);

        [DllImport("libnl-3.so")]
        public static extern void nl_object_mark(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern void nl_object_put(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern void nl_object_unmark(nl_object* obj);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_disable_auto_ack(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_disable_msg_peek(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_disable_seq_check(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_enable_auto_ack(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_enable_msg_peek(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_free(nl_sock* sk);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_set_local_port(nl_sock* sk, uint port);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_set_peer_groups(nl_sock* sk, uint groups);

        [DllImport("libnl-3.so")]
        public static extern void nl_socket_set_peer_port(nl_sock* sk, uint port);

        [DllImport("libnl-3.so")]
        public static extern void* nl_addr_get_binary_addr(nl_addr* addr);

        [DllImport("libnl-3.so")]
        public static extern void* nl_data_get(nl_data* data);
    }
}