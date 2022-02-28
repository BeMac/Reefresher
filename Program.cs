using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace Reefresher
{
    class Program
    {
        private static Timer _timer = null;
        private static Process _appToPoke = Process.GetProcessesByName("Teams").FirstOrDefault();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        static void Main(string[] args)
        {
            _appToPoke = Process.GetProcessesByName("Teams").FirstOrDefault();
            int seconds = 45;
            int milliseconds = seconds * 1000;
            _timer = new Timer(SendF15, null, 0, milliseconds);
            
            //Console.ReadLine();
        }

        private static void SendF15(Object o) 
        {
            if (_appToPoke != null)
            {
                IntPtr handle = _appToPoke.MainWindowHandle;
                SetForegroundWindow(handle);
                SendKeys.SendWait("{F15}");
            }
            
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
        }
    }
}
