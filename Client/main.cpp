#include <iostream>
#include <windows.h>
#include "ResID.h"
LRESULT CALLBACK WinProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
LRESULT CALLBACK GlobDlgProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
void addStatsInformation(HWND hWnd);
HWND hEdit;
HINSTANCE hThisInst;
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpCmdLine, int nShowCmd)
{
    HWND hWnd;
    WNDCLASSEX wnd;
    MSG msg;
    hThisInst = hInst;
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
    wnd.lpszMenuName = "MainMenu";
    wnd.style = CS_DBLCLKS;

    if(!RegisterClassExA(&wnd))
        return MessageBox(NULL,"Класс не был зарегестирован","Critical Error",MB_OK);

    hWnd = CreateWindowEx(0,"MainWindow","Окно",WS_OVERLAPPEDWINDOW,CW_USEDEFAULT,CW_USEDEFAULT,800,600,NULL,NULL,hInst,NULL);

    ShowWindow(hWnd,nShowCmd);


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
        case WM_CREATE:
            addStatsInformation(hWnd);
            break;
        case WM_DESTROY:
            PostQuitMessage(0);
            return 0;
        case WM_COMMAND:
            if(HIWORD(wParam)==0)
            {
                switch(LOWORD(wParam))
                {
                    case MainMenuStatsRebuild:
                        SendMessage(hEdit,WM_SETTEXT,0,(LPARAM)"text");
                        break;
                    case MainMenuUserAdd:
                        if(hEdit != NULL) DestroyWindow(hEdit);
                        hEdit = NULL;
                        break;
                    case MainMenuStats:
                        if(hEdit == NULL) {addStatsInformation(hWnd);}
                        break;
                }
            }
            break;
    }
    return DefWindowProc(hWnd,msg,wParam,lParam);
}
void addStatsInformation(HWND hWnd)
{
    hEdit = CreateWindow("Edit",NULL,WS_CHILD|WS_VISIBLE|ES_MULTILINE,10,10,180,70,hWnd,NULL,hThisInst,NULL);
}
void addEditInfo()
{

}
