#include <iostream>
#include "MainWindow.h"

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpCmdLine, int nShowCmd)
{
    MainWindow window(hInst);
    window.createWindow("Окно");
    window.showWindow(nShowCmd);
    window.changeMenu(4);
    window.runLoop();
    return window.getMSG().wParam;
}
