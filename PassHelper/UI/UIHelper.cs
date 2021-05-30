using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PassHelper.UI {

    public static class UIHelper {

        private const string EscapeSymbols = "+^%~()[]{}";

        private static class Native {

            [Flags]
            public enum MouseEventFlags : uint {
                LeftDown = 0x00000002,
                LeftUp = 0x00000004,
            }

            [DllImport("user32.dll")]
            public static extern IntPtr WindowFromPoint(Point point);

            [DllImport("user32.dll")]
            public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInfo);

            [StructLayout(LayoutKind.Sequential)]
            public struct Point {
                public int X;
                public int Y;
            }
        }

        public static void Click(Point point) {
            Native.mouse_event((uint) (Native.MouseEventFlags.LeftDown | Native.MouseEventFlags.LeftUp), (uint) point.X, (uint) point.Y, 0, 0);
        }

        public static IntPtr GetPointedWindow(Point point) {
            return Native.WindowFromPoint(new Native.Point {
                X = point.X,
                Y = point.Y
            });
        }

        public static void TypeText(string text, TimeSpan startDelay, TimeSpan delay) {

            if (text is null) {
                throw new ArgumentNullException(nameof(text));
            }

            Thread.Sleep(startDelay);

            foreach (var ch in text) {
                var escaped = EscapeChar(ch);
                SendKeys.Send(escaped);
                Thread.Sleep(delay);
            }
        }

        private static string EscapeChar(char ch) {

            if (EscapeSymbols.Contains(ch)) {
                return string.Concat('{', ch, '}');
            }

            return ch.ToString();
        }


    }
}
