using System;
using System.Linq;

namespace IMPLC.Core
{
    public class WordDeviceRepo : IDeviceRepo
    {
        private readonly short[] _Values;

        public short Length => (short)_Values.Length;

        public WordDeviceRepo(short length)
        {
            if (length < 1)
                throw new Exception("length must be bigger then 0");

            _Values = new short[length];
        }

        public ErrorCode ReadDeviceBlock(Device device, short address, short length, ref short[] readValues)
        {
            if (address + length > _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            if (readValues == null)
                return ErrorCode.RefValueIsNull;

            if (readValues.Length != length)
                return ErrorCode.RefValueLengthError;


            for (int i = 0; i < length; i++)
            {
                readValues[i] = _Values[address + i];
            }

            return ErrorCode.None;
        }

        public ErrorCode WriteDeviceBlock(Device device, short address, short length, ref short[] writeValues)
        {
            if (address + length > _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            if (writeValues == null)
                return ErrorCode.RefValueIsNull;

            if (writeValues.Length != length)
                return ErrorCode.RefValueLengthError;

            Array.Copy(writeValues, 0, _Values, address, length);

            return ErrorCode.None;
        }

        public ErrorCode WriteBit(Device device, short address, bool value)
        {
            if (address >= _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            var curValue = _Values[address];

            if (value)
                _Values[address] = (short)((curValue & 0b1111_1111_1111_1110) + 0b0000_0000_0000_0001);
            else
                _Values[address] = (short)((curValue & 0b1111_1111_1111_1110) + 0b0000_0000_0000_0000);

            return ErrorCode.None;
        }
        
    }
}