using global::System.Diagnostics;
using global::System.ComponentModel;
using global::System.Runtime.InteropServices;

namespace General
{
    /// <summary>計測、スリープ クラス</summary>
    /// <remarks></remarks>
    public class Measure
    {
        #region "フィールド"
        private static Stopwatch sw = new Stopwatch();
        private static DateTime startDateTime;
        private static long startCount;
        private static long stopCount;
        private const string KERNEL32_DLL = "kernel32.dll";
        private const string USER32_DLL = "user32.dll";
        #endregion

        #region "P/Invoke構造体、宣言、呼び出し"
        [DllImport(KERNEL32_DLL, SetLastError = true, EntryPoint = "Sleep")]
        private static extern void Sleep(uint dwMilliseconds);

        [DllImport(KERNEL32_DLL, SetLastError = true, EntryPoint = "QueryPerformanceCounter")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport(KERNEL32_DLL, SetLastError = true, EntryPoint = "QueryPerformanceFrequency")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        [DllImport(USER32_DLL, SetLastError = true, EntryPoint = "GetInputState")]
        private static extern bool GetInputState();
        #endregion

        #region "メソッド"
        /// <summary>WindowsAPIのスリープ呼び出し</summary>
        /// <param name="milli">スリープさせるミリ秒</param>
        public static void ApiSleep(uint milli)
        {
            Sleep(milli);
        }

        /// <summary>DataTime.Nowの時間差分で計測するストップウォッチのスタート</summary>
        /// <remarks></remarks>>
        public static void DateTimeStart()
        {
            startDateTime = DateTime.Now;
        }

        /// <summary>DataTime.Nowの時間差分で計測するストップウォッチのストップ</summary>
        /// <returns>TimeSpan</returns>
        public static TimeSpan DateTimeStop()
        {
            return DateTime.Now.Subtract(startDateTime);
        }

        /// <summary>Stopwatchクラスで計測するストップウォッチのスタート</summary>
        /// <remarks></remarks>>
        public static void StopwatchStart()
        {
            sw.Reset();
            sw.Start();
        }

        /// <summary>Stopwatchクラスで計測するストップウォッチのストップ</summary>
        /// <returns>TimeSpan</returns>
        public static TimeSpan StopwatchStop()
        {
            sw.Stop();
            var time = sw.Elapsed;

            return time;
        }

        /// <summary>WindowsAPIのQueryPerformanceCounterで計測するストップウォッチのスタート</summary>
        /// <remarks></remarks>
        public static void QueryPerformanceStart()
        {
            try
            {
                if (QueryPerformanceCounter(out startCount) == false)
                {
                    new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            catch (Win32Exception ex)
            {
                throw;
            }
        }

        /// <summary>WindowsAPIのQueryPerformanceCounterで計測するストップウォッチのストップ</summary>
        /// <returns>TimeSpan</returns>
        public static TimeSpan QueryPerformanceStop()
        {
            TimeSpan tspan = new();
            try
            {
                if (QueryPerformanceCounter(out stopCount) == false)
                {
                    new Win32Exception(Marshal.GetLastWin32Error());
                }
                long frequency;
                if (QueryPerformanceFrequency(out frequency))
                {
                    new Win32Exception(Marshal.GetLastWin32Error());
                }
                double byo = (double)((stopCount - startCount) / (double)frequency);
                tspan = TimeSpan.FromSeconds(byo);
            }
            catch (Win32Exception ex)
            {
                throw;
            }

            return tspan;
        }

        /// <summary>スリープではなくタイマーで待機するメソッド</summary>
        /// <param name="milli">待機するミリ秒</param>
        /// <remarks>ループ中はWindowsAPIのGetInputState()関数でメッセージキューを取得します</remarks>>
        public static void TimeLoop(int milli)
        {
            var sp = new Stopwatch();

            sp.Reset();
            sp.Start();
            while (sp.ElapsedMilliseconds < milli)
            {
                if (GetInputState() == false)
                    new Win32Exception(Marshal.GetLastWin32Error());
            }
            sp.Stop();
        }
        #endregion
    }
}