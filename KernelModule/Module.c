#define __KERNEL__
#define MODULE

#include <linux/init.h>
#include <linux/module.h>
#include <linux/kernel.h>

#include <linux/netfilter.h>
#include <linux/ip.h>

#include "Filtering.h"
#include "Hooks.h"
#include "Communication.h"
#include "FilterTable.h"

extern unsigned char implicitFilterAction[NF_INET_NUMHOOKS];

int start(void)
{
  implicitFilterAction[NF_INET_PRE_ROUTING] = NF_ACCEPT;
  implicitFilterAction[NF_INET_LOCAL_IN] = NF_ACCEPT;
  implicitFilterAction[NF_INET_FORWARD] = NF_DROP;
  implicitFilterAction[NF_INET_LOCAL_OUT] = NF_ACCEPT;
  implicitFilterAction[NF_INET_POST_ROUTING] = NF_ACCEPT;
  setupListener();
  registerHooks();
  return 0;
}

void end(void)
{
  unregisterHooks();
  destroyListener();
  destroyFilterTable();
}

module_init(start);
module_exit(end);

MODULE_LICENSE("MIT");
