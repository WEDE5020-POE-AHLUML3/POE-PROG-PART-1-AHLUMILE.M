using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CyberAwareBot
{
    public static class AudioPlayer
    {
        // PlaySound flags
        private const uint SND_ASYNC = 0x0001;
        private const uint SND_NODEFAULT = 0x0002;
        private const uint SND_FILENAME = 0x00020000;

        [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        public static void PlayGreeting()
        {
            try
            {
                string baseDir = AppContext.BaseDirectory ?? Environment.CurrentDirectory;
                string path = Path.Combine(baseDir, "greeting.wav");
                path = Path.GetFullPath(path);

                if (!File.Exists(path))
                {
                    // fallback to current directory
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "greeting.wav"));
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Audio file 'greeting.wav' not found in application directory.");
                        return;
                    }
                }

                // Only attempt native playback on Windows.
                if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // Non-Windows: skip playback or add a cross-platform library if required.
                    Console.WriteLine("Audio playback is only supported on Windows in the current build.");
                    return;
                }

                // Play async from file without launching any external player (no popup).
                bool ok = PlaySound(path, IntPtr.Zero, SND_ASYNC | SND_FILENAME | SND_NODEFAULT);
                if (!ok)
                {
                    // If PlaySound fails, log the Win32 error for diagnosis.
                    int err = Marshal.GetLastWin32Error();
                    Console.WriteLine($"PlaySound failed (error {err}).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to play greeting.wav: {ex.Message}");
            }
        }
    }
}