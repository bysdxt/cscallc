#include <Windows.h>
#include <process.h>
#include <cstdio>
void (__stdcall*_h)(int*);
void __stdcall f(void(__stdcall*h)(int*)) {
    DWORD id;
    _h = h;
    _beginthread(
        [](auto h) {
            Sleep(1000);
            int i = 789;
            printf("%lld\n", (long long)&i);
            _h(&i);
        },
        0,
        nullptr
    );
    //_(nullptr, 0, [](auto h) {
    //    Sleep(1000);
    //    ((void(*)())_h)();
    //    return (DWORD)0;
    //}, h, 0, &id);
}