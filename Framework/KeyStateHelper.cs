using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostMater.Framework
{
    public class KeyStateHelper
    {
        // Import the GetKeyState function from user32.dll
        [DllImport("user32.dll")]
        private static extern short GetKeyState(int keyCode);

        // Method to check if a key is currently down
        public static bool IsKeyDown(Keys key)
        {
            // The high-order bit (0x8000) indicates the key is down
            return (GetKeyState((int)key) & 0x8000) != 0;
        }
    }
}
