using System.Runtime.InteropServices;

namespace OwnArrayList
{
    public class ArrayList<T> where T : struct
    {
        private readonly int _typeSize;
        private IntPtr _arrayPointer;

        public ArrayList(int initialSize = 1)
        {
            _typeSize = Marshal.SizeOf<T>();
            _arrayPointer = DynamicArray.AllocArray(initialSize, _typeSize);
        }

        ~ArrayList()
        {
            DynamicArray.FreeArray(_arrayPointer);
        }

        public T this[int index] => Get(index);

        public void Append(T item)
        {

        }

        public void Insert(int index, T item)
        {
            IntPtr itemPtr = Marshal.AllocHGlobal(_typeSize);
            Marshal.StructureToPtr(item, itemPtr, false);
            DynamicArray.Insert(_arrayPointer, index, itemPtr);
            Marshal.FreeHGlobal(itemPtr);
        }

        public int BinarySearch(T item)
        {
            return BinarySearch(item, Comparer<T>.Default);
        }

        public int BinarySearch(T item, IComparer<T> comparer)
        {
            IntPtr itemPtr = Marshal.AllocHGlobal(_typeSize);
            Marshal.StructureToPtr(item, itemPtr, false);
            int result = DynamicArray.BinarySearch(_arrayPointer, itemPtr, CompareDelegate);
            Marshal.FreeHGlobal(itemPtr);
            return result;

            int CompareDelegate(IntPtr lhsPtr, IntPtr rhsPtr)
            {
                T lhs = Marshal.PtrToStructure<T>(lhsPtr);
                T rhs = Marshal.PtrToStructure<T>(rhsPtr);
                return comparer.Compare(lhs, rhs);
            }
        }

        private T Get(int index)
        {
            IntPtr itemPtr = DynamicArray.Get(_arrayPointer, index);
            return Marshal.PtrToStructure<T>(itemPtr);
        }
    }
}
