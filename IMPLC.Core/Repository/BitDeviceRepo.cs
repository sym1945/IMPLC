using System.Collections.Generic;

namespace IMPLC.Core
{
    public class BitDeviceRepo : IDeviceRepo
    {
        private readonly bool[] _Values;

        public int Length => _Values.Length;

        public BitDeviceRepo(int length)
        {
            _Values = new bool[length];
        }

        public ErrorCode ReadDeviceBlock(Device device, int address, int length, ref short[] readValues)
        {
            if (readValues == null)
                return ErrorCode.RefValueIsNull;

            if (readValues.Length != length)
                return ErrorCode.RefValueLengthError;

            if (address >= _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            for (int i = 0; i < length; i++)
            {
                int value = 0;
                for (int pos = 0; pos < 16; pos++)
                {
                    if (address >= _Values.Length)
                        break;

                    if (_Values[address++])
                        value |= (1 << pos);
                }

                readValues[i] = (short)value;
            }

            return ErrorCode.None;
        }

        public ErrorCode WriteDeviceBlock(Device device, int address, int length, ref short[] writeValues)
        {
            if (writeValues == null)
                return ErrorCode.RefValueIsNull;

            if (writeValues.Length != length)
                return ErrorCode.RefValueLengthError;

            if (address >= _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            for (int i = 0; i < length;  i++)
            {
                for (int pos = 0; pos < 16; pos++)
                {
                    address += pos;
                    if (address >= _Values.Length)
                        break;

                    _Values[address] = ((writeValues[i] >> pos) & 1) == 1;
                }
            }

            return ErrorCode.None;
        }

        public ErrorCode WriteBit(Device device, int address, bool value)
        {
            if (address >= _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            _Values[address] = value;

            return ErrorCode.None;
        }
        
    }
}