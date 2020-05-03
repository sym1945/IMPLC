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

        public ErrorCode ReadDeviceBlock(eDevice device, short address, short length, out short[] readValues)
        {
            readValues = null;

            if (address + length > _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            readValues = _Values.Skip(address).Take(length).ToArray();

            return ErrorCode.None;
        }

        public ErrorCode WriteDeviceBlock(eDevice device, short address, short length, ref short[] writeValues)
        {
            if (address + length > _Values.Length)
                return ErrorCode.DeviceLengthLimitOver;

            if (writeValues == null)
                return ErrorCode.WriteValueIsNull;

            if (writeValues.Length != length)
                return ErrorCode.WriteValueLengthError;

            Array.Copy(writeValues, 0, _Values, address, length);

            return ErrorCode.None;
        }

        public ErrorCode WriteBit(eDevice device, short address, bool value)
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