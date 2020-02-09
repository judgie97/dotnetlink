cmake_minimum_required(VERSION 3.1)
project(dotnetfilterKernelModule)

set(C_STANDARD 90)

execute_process(COMMAND uname -r OUTPUT_VARIABLE sys_ver OUTPUT_STRIP_TRAILING_WHITESPACE)
include_directories("/usr/lib/modules/${sys_ver}/build/include")

add_executable(kernel Module.c Filtering.c Hooks.c Communication.c FilterTable.c)
