using System.Collections.Generic;

namespace IMPLC.Core
{
    public class BitDeviceRepo : IDeviceRepo
    {
        private readonly bool[] _Values;

        public BitDeviceRepo(short length)
        {
            _Values = new bool[length];
        }

        public ErrorCode ReadDeviceBlock(eDevice device, short address, short length, out short[] readValues)
        {
            readValues = null;
            int totalLength = 16 * length;

            if (address + totalLength > _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            int pos = 0;
            int s = 0;
            var shortValues = new List<short>(length);
            for (int i = address; i < address + totalLength; i++, pos++)
            {
                if (_Values[i])
                    s |= (1 << pos);

                if (pos == 15)
                {
                    shortValues.Add((short)s);
                    s = 0;
                    pos = -1;
                }
            }

            readValues = shortValues.ToArray();
            return ErrorCode.None;
        }

        public ErrorCode WriteDeviceBlock(eDevice device, short address, short length, ref short[] writeValues)
        {
            int totalLength = 16 * length;

            if (address + totalLength > _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            if (writeValues == null)
                return ErrorCode.WriteValueIsNull;

            if (writeValues.Length != length)
                return ErrorCode.WriteValueLengthError;

            for (int i = 0; i < length;  i++)
            {
                var bitAddress = address + (i * 16);
                for (int j = 0; j < 16; j++)
                {
                    _Values[bitAddress + j] = ((writeValues[i] >> j) & 1) == 1;
                }
            }

            return ErrorCode.None;
        }

        public ErrorCode WriteBit(eDevice device, short address, bool value)
        {
            if (address >= _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            _Values[address] = value;

            return ErrorCode.None;
        }
        
    }
}