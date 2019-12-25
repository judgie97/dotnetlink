#pragma once

int addAttributeToMessage(struct nlmsghdr *n, int maxLength, int type, const void* data, int attributeLength);