#pragma once

int addTLVToMessage(struct nlmsghdr* n, int maxLength, int type, const void* data, int attributeLength);
int addTLVToMessage(struct nlmsghdr* n, int maxLength, int type, const void* data, int attributeLength, int printedLength);

#define ALIGN_TLV(X) ((X) + ((4-((X)%4))%4))
