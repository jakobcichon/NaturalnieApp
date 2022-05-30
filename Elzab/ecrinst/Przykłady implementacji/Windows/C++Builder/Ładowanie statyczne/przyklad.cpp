//---------------------------------------------------------------------------

#include <vcl.h>
#include "winip.h"
#pragma hdrstop

USELIB("WinIP.lib");
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
      unsigned char error;

      error = _TowarMax("towarmax.in","towarmax.out");
      if (error)
      {
         //obsluga bledow
         return error;
      }

      error = _ZTowar("ztowar.in");
      if (error)
      {
         //obsluga bledow
         return error;
      }

      return 0;
}
//---------------------------------------------------------------------------
