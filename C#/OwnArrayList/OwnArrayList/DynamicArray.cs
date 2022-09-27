using System.Runtime.InteropServices;

namespace OwnArrayList
{
    internal static class DynamicArray
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CompareDelegate(IntPtr lhs, IntPtr rhs);

        [DllImport("arraylist.dll", EntryPoint = "allocateArray")]
        public static extern IntPtr AllocArray(int initialSize, int objectSize);

        [DllImport("arraylist.dll", EntryPoint = "deallocateArray")]
        public static extern void FreeArray(IntPtr arrayPtr);

        [DllImport("arraylist.dll", EntryPoint = "insert")]
        public static extern void Insert(IntPtr arrayPtr, int index, IntPtr item);

        [DllImport("arraylist.dll", EntryPoint = "getItem")]
        public static extern IntPtr Get(IntPtr arrayPtr, int index);

        [DllImport("arraylist.dll", EntryPoint = "binarySearch")]
        public static extern int BinarySearch(IntPtr arrayPtr, IntPtr item, CompareDelegate comparer);
    }
}
