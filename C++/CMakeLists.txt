cmake_minimum_required(VERSION 3.15)
project(dotnetlink)

set(CMAKE_CXX_STANDARD 17)

file(GLOB_RECURSE DOTNETLINK_SRC "src/**.cpp")

add_library(dotnetlinkconnector SHARED ${DOTNETLINK_SRC})

add_executable(Test Test.cpp)
target_link_libraries(Test dotnetlinkconnector)