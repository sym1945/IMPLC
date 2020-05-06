using System.ComponentModel;

namespace IMPLC.Core
{
    public enum Device
    {
        [Description("INPUT")]
        X = 1,
        [Description("OUTPUT")]
        Y = 2,
        [Description("LATCH RELAY")]
        L = 3,
        [Description("INTERNAL RELAY")]
        M = 4,
        [Description("SPECIAL RELAY")]
        SB_Special_M = 5,
        [Description("ANNUNCIATOR")]
        F = 6,
        TT = 7,
        TC = 8,
        CT = 9,
        CC = 10,
        TN = 11,
        CN = 12,
        D = 13,
        SW_Special_D = 14,
        TM = 15,
        TS = 16,
        CM = 18,
        [Description("ACCUMULATOR")]
        A = 19,
        [Description("INDEX REGISTER")]
        Z = 20,
        [Description("INDEX REGISTER")]
        V = 21,
        [Description("FILE REGISTER")]
        R = 22,
        [Description("LINK RELAY")]
        B = 23,
        [Description("LINK REGISTER")]
        W = 24,
    }

    public enum ErrorCode
    { 
        None = 0,
        DeviceIsNotExist = 1,
        DeviceLengthLimitOver = 2,
        WriteValueIsNull = 3,
        WriteValueLengthError = 4,
        NotSupported = 99,

    }

}