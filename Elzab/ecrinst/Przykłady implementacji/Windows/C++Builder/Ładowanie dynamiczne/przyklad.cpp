//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

typedef unsigned char __cdecl  (*WINIPFUNC1)(char* in, char* out);
typedef unsigned char __cdecl  (*WINIPFUNC2)(char* in);

WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
   HINSTANCE handle;
   WINIPFUNC1 F1;
   WINIPFUNC2 F2;
   unsigned char error;

   if ((handle = LoadLibrary("WinIP.Dll"))!=NULL)
   {

       F1=(WINIPFUNC1)GetProcAddress(handle,"__TowarMax");
       error = F1("towarmax.in", "towarmax.out");
       if (error)
       {
           //obsluga bledow
           FreeLibrary(handle);
           return error;
       }

      F2=(WINIPFUNC2)GetProcAddress(handle,"__ZTowar");
      error = F2("ztowar.in");
      if (error)
       {
           //obsluga bledow
           FreeLibrary(handle);
           return error;
       }
   }
   else
   {
     //brak biblioteki winip.dll
     return 1000;
   }

   return 0; 
}
//---------------------------------------------------------------------------
