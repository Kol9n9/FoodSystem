#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#include <windows.h>
#include <iostream>
#include <string>

class MainWindow
{
    public:
        MainWindow(HINSTANCE hInst);
        virtual ~MainWindow();
        void createWindow(char *windowName);
        void showWindow(int nShowCmd);
        void runLoop();
        static LRESULT CALLBACK windowProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
        MSG &getMSG(){return windowMSG;}
        void changeMenu(int role);
    protected:

    private:
        HWND hWindow;
        HINSTANCE hWindowInstance;
        WNDCLASSEX windowClass;
        MSG windowMSG;
        bool isWindowOpen;

        bool registerWindowClass();
        LRESULT CALLBACK realWindowProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
};

#endif // MAINWINDOW_H
