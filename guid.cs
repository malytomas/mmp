/*
using FMOD;
using System.Runtime.InteropServices;

namespace mmp
{
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct ByteArray
    {
        [FieldOffset(0)]
        public FMOD.GUID guid;
        [FieldOffset(0)]
        public fixed byte bytes[16];
    }

    public class guidConverter
    {
        public static string toString (FMOD.GUID g)
        {
            ByteArray arr = new ByteArray();
            arr.guid = g;
            string s = "";
            for (int i = 0; i < 16; i++)
            {
                unsafe
                {
                    s += (char)arr.bytes[i] / 16 + '0';
                    s += (char)arr.bytes[i] % 16 + '0';
                }
            }
            return s;
        }

        public static FMOD.GUID toGuid (string s)
        {
            if (s == "")
                return toGuid(new string('0', 32));
            if (s.Length != 32)
                throw new System.Exception("invalid value");
            ByteArray arr = new ByteArray();
            for (int i = 0; i < 16; i++)
            {
                unsafe
                {
                    arr.bytes[i] = (byte)((s[i * 2] - '0') * 16 + (s[i * 2 + 1] - '0'));
                }
            }
            return arr.guid;
        }
    }
}
*/