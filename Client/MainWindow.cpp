#include "MainWindow.h"
MainWindow::MainWindow(HINSTANCE hInst)
{
    hWindow = NULL;
    hWindowInstance = hInst;
    isWindowOpen = false;
    //ctor
}

MainWindow::~MainWindow()
{
    //dtor
}
void MainWindow::showWindow(int nShowCmd)
{
    ShowWindow(hWindow,nShowCmd);
    isWindowOpen = true;
}
void MainWindow::createWindow(char *windowName)
{
    if(!registerWindowClass())
    {
        MessageBox(NULL,"Класс не был зарегестирован","Critical Error",MB_OK);
        return;
    }
    hWindow = CreateWindowEx(1,"MainWindowClass",windowName,WS_OVERLAPPEDWINDOW,CW_USEDEFAULT,CW_USEDEFAULT,800,600,NULL,NULL,hWindowInstance,NULL);
}
bool MainWindow::registerWindowClass()
{
    windowClass.cbSize = sizeof(WNDCLASSEX);
    windowClass.cbClsExtra = 0;
    windowClass.cbWndExtra = 0;
    windowClass.hbrBackground = (HBRUSH) COLOR_BACKGROUND;
    windowClass.hCursor = LoadCursor(NULL,IDC_ARROW);
    windowClass.hIcon = LoadIcon(NULL,IDI_APPLICATION);
    windowClass.hIconSm = LoadIcon(NULL,IDI_APPLICATION);
    windowClass.hInstance = hWindowInstance;
    windowClass.lpfnWndProc = windowProc;
    windowClass.lpszClassName = "MainWindowClass";
    windowClass.lpszMenuName = NULL;
    windowClass.style = CS_DBLCLKS;

    if(!RegisterClassExA(&windowClass))
        return FALSE;
    return TRUE;
}
void MainWindow::changeMenu(int role)
{
    std::string menuName = "MainMenu";
    menuName += std::to_string(role);
    HMENU menu = LoadMenu(hWindowInstance,menuName.c_str());
    SetMenu(hWindow,menu);
}
void MainWindow::runLoop()
{
    while(isWindowOpen)
    {
        if(GetMessage(&windowMSG,hWindow,0,0))
        {

            TranslateMessage(&windowMSG);
            DispatchMessage(&windowMSG);
            if(windowMSG.wParam == WM_ERASEBKGND && windowMSG.message == WM_NCLBUTTONDOWN)
            {
                isWindowOpen = false;
            }
        }
    }

}
LRESULT CALLBACK MainWindow::windowProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{

    switch(msg)
    {
        case WM_DESTROY:
            PostQuitMessage(0);
            break;
        case WM_CLOSE:
            break;
    }
    return DefWindowProc(hWnd,msg,wParam,lParam);
}
/*LRESULT CALLBACK MainWindow::realWindowProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
    switch(msg)
    {
        case WM_DESTROY:
            std::cout << "WM_DESTROY\n";
            //isWindowOpen = false;
            //PostQuitMessage(0);
            break;
        case WM_CLOSE:
            break;
    }
    return DefWindowProc(hWnd,msg,wParam,lParam);
}*/
