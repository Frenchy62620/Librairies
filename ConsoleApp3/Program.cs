using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        static void Main(string[] args)
        {
            IntPtr notepadHandle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Notepad", null);

            if (notepadHandle == IntPtr.Zero)
            {
                Console.WriteLine("Notepad is not running.");
            }
            else
            {
                Console.WriteLine("Notepad handle found: " + notepadHandle.ToString());
            }
            MoveWindow(notepadHandle, 0, 0, 700, 300, false);
        }
    }
}
