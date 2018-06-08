cmake_minimum_required(VERSION 3.5.2 FATAL_ERROR)

project(dpatterns)

set (CMAKE_CXX_STANDARD 11)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/../bin)

include_directories(include)

set(SOURCES
  src/object_pool.cpp
  src/observer.cpp
  src/iterator.cpp
  src/composite.cpp
  src/third_party.cpp
  src/main.cpp
  )

add_executable(dpatterns ${SOURCES})
