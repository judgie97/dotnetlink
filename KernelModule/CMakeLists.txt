cmake_minimum_required(VERSION 3.1)
project(dotnetfilterKernelModule)

set(C_STANDARD 90)

include_directories(/usr/lib/modules/5.4.12-1-MANJARO/build/include)

add_executable(kernel Module.c Filtering.c Hooks.c Communication.c FilterTable.c)
