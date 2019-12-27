#pragma once

int addTLVToMessage(struct nlmsghdr *n, int maxLength, int type, const void* data, int attributeLength);