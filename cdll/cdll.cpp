#include <Windows.h>
void __stdcall f(void(*h)()) {
    DWORD id;
    CreateThread(nullptr, 0, [](auto h) {
        Sleep(1000);
        ((void(*)())h)();
        return (DWORD)0;
    }, h, 0, &id);
}