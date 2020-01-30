ccflags-y := -Wdeclaration-after-statement
obj-m += dotnetfilter.o
dotnetfilter-objs += Module.o Hooks.o FilterTable.o Filtering.o Communication.o
all:
	make -j 24 -C /lib/modules/$(shell uname -r)/build M=$(PWD) modules
clean:
	make -j 24 -C /lib/modules/$(shell uname -r)/build M=$(PWD) clean

