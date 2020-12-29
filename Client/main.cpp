#include <iostream>
#include <windows.h>
LRESULT CALLBACK WinProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpCmdLine, int nShowCmd)
{
    HWND hWnd;
    WNDCLASSEX wnd;
    MSG msg;
    wnd.cbSize = sizeof(WNDCLASSEX);
    wnd.cbClsExtra = 0;
    wnd.cbWndExtra = 0;
    wnd.hbrBackground = (HBRUSH) COLOR_BACKGROUND;
    wnd.hCursor = LoadCursor(NULL,IDC_ARROW);
    wnd.hIcon = LoadIcon(NULL,IDI_APPLICATION);
    wnd.hIconSm = LoadIcon(NULL,IDI_APPLICATION);
    wnd.hInstance = hInst;
    wnd.lpfnWndProc = WinProc;
    wnd.lpszClassName = "MainWindow";
    wnd.lpszMenuName = NULL;
    wnd.style = CS_DBLCLKS;

    if(!RegisterClassExA(&wnd))
        return MessageBox(NULL,"Класс не был зарегестирован","Critical Error",MB_OK);

    hWnd = CreateWindowEx(0,"MainWindow","Окно",WS_OVERLAPPEDWINDOW,CW_USEDEFAULT,CW_USEDEFAULT,800,600,NULL,NULL,hInst,NULL);
    ShowWindow(hWnd,nShowCmd);
    MessageBox(NULL,"Hello world!","Caption",MB_OK);
    while(GetMessage(&msg,NULL,NULL,NULL))
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return msg.wParam;
}
LRESULT CALLBACK WinProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
    switch(msg)
    {
        case WM_DESTROY:
            PostQuitMessage(0);
            return 0;
    }
    return DefWindowProc(hWnd,msg,wParam,lParam);
}
