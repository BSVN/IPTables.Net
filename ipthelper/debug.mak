#Generated by VisualGDB (http://visualgdb.com)
#DO NOT EDIT THIS FILE MANUALLY UNLESS YOU ABSOLUTELY NEED TO
#USE VISUALGDB PROJECT PROPERTIES DIALOG INSTEAD

BINARYDIR := Debug

#Toolchain
CC := gcc
CXX := g++
LD := $(CC)
AR := ar
OBJCOPY := objcopy

#Additional flags
PREPROCESSOR_MACROS := DEBUG
INCLUDE_DIRS := . /usr/include/libnl3
LIBRARY_DIRS := 
LIBRARY_NAMES := iptc ip4tc ip6tc dl xtables nl-3 stdc++ rt
ADDITIONAL_LINKER_INPUTS := 
MACOS_FRAMEWORKS := 
LINUX_PACKAGES := 

CFLAGS := -ggdb -ffunction-sections -O0 $(ADDITIONAL_CFLAGS)
CXXFLAGS := -ggdb -ffunction-sections -O0 -fpermissive -std=c++11 $(ADDITIONAL_CFLAGS)
ASFLAGS := 
LDFLAGS := -Wl,-gc-sections
COMMONFLAGS := 

START_GROUP := -Wl,--start-group
END_GROUP := -Wl,--end-group

#Additional options detected from testing the toolchain
IS_LINUX_PROJECT := 1
