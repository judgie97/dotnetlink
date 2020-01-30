#pragma once

#define DNF_ADDRULE 150
#define DNF_DELRULE 151
#define DNF_GETRULE 152

#define NETLINK_DOTNETFILTER 25

void setupListener(void);
void destroyListener(void);
