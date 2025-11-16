using System.Collections.Generic;
using System.Text;
using global::System.Runtime.InteropServices;

namespace General
{
    public interface IWin32ApiFile
    {
        protected const string KERNEL32_DLL = "kernel32.dll";

        #region "P/Invoke構造体、宣言、呼び出し"
        [DllImport(KERNEL32_DLL, CharSet = CharSet.Ansi, SetLastError = true)]
        protected static extern IntPtr CreateFileA(string lpFileName, uint dwDesiredAccess, uint dwShareMode,
            IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport(KERNEL32_DLL, SetLastError = true)]
        protected static extern bool CloseHandle(IntPtr hObject);

        [DllImport(KERNEL32_DLL, SetLastError = true)]
        protected static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead,
            out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport(KERNEL32_DLL, SetLastError = true)]
        protected static extern bool WriteFile(IntPtr hFile, [In] byte[] lpBuffer, uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);
        #endregion

        #region "列挙型"
        protected enum DwDesiredAccess : uint
        {
            GENERIC_EXECUTE = 0x20000000,
            GENERIC_WRITE = 0x40000000,
            GENERIC_READ = 0x80000000
        }

        protected enum DwShareMode : uint
        {
            FILE_SHARE_READ = 0x00000001,
            FILE_SHARE_WRITE = 0x00000002,
            FILE_SHARE_DELITE = 0x00000004
        }

        protected enum DwCreateDisposition : uint
        {
            CREATE_NEW = 1,
            CREATE_ALLWAYS = 2,
            OPEN_EXISTING = 3,
            OPEN_ALWAYS = 4,
            TRUNCATE_EXISTING = 5
        }

        protected enum DwFlagsAndAttributes : uint
        {
            FILE_ATTRIBUTE_READONLY = 0x00000001,
            FILE_ATTRIBUTE_HIDDEN = 0x00000002,
            FILE_ATTRIBUTE_SYSTEM = 0x00000004,
            FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
            FILE_ATTRIBUTE_NORMAL = 0x00000080,
            FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
            FILE_ATTRIBUTE_OFFLINE = 0x00001000,
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
            FILE_ATTRIBUTE_ENCRYPTED = 0x00004000
        }
        #endregion
    }
}