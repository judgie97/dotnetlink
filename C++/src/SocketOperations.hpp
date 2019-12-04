#pragma once

int receiveMessage(int sock, struct msghdr* header, int flags);

void flushSocket(int sock);


