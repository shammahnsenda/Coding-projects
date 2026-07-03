@echo off

REM Create the bin directory if it doesn't exist
if not exist "..\bin" mkdir "..\bin"

REM Create the docs directory if it doesn't exist
if not exist "..\docs" mkdir "..\docs"

REM Create the output directory if it doesn't exist
if not exist "..\output" mkdir "..\output"

echo Compiling.
REM Listing the source files individually prevents issues that may arise if the compiler
REM reads main.cpp before reading UJImage.cpp (in which case the module would not yet exist).
g++ --std=c++20 -fmodules-ts -c LibUtility.cpp
g++ --std=c++20 -fmodules-ts -c UJImage.cpp
g++ --std=c++20 -fmodules-ts -c main.cpp
g++ LibUtility.o UJImage.o main.o -o ..\bin\program

echo Cleaning up.
REM The following command deletes the gcm.cache directory and all its contents
REM or subdirectories (/s) quietly (/q)
rmdir /s /q gcm.cache
del *.o

echo Images exported successfully.
pause
