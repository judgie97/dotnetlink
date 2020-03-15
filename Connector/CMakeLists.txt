cmake_minimum_required(VERSION 3.1)
project(dotnetlink)

set(CMAKE_CXX_STANDARD 17)

file(GLOB_RECURSE DOTNETLINK_SRC "src/**.cpp")
include_directories("/usr/include/libnl3")

add_library(dotnetlinkconnector ${DOTNETLINK_SRC})

add_executable(Test Test.cpp)
target_link_libraries(Test dotnetlinkconnector libnl-3.a libnl-route-3.a)
