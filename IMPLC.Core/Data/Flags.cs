using System.ComponentModel;

namespace IMPLC.Core
{
    public enum eChannel : short
    {
        [Description("MELSECNET/H-1")]
        MELSECNET_H_1 = 51,
        [Description("MELSECNET/H-2")]
        MELSECNET_H_2 = 52,
        [Description("MELSECNET/H-3")]
        MELSECNET_H_3 = 53,
        [Description("MELSECNET/H-4")]
        MELSECNET_H_4 = 54,

        [Description("CC-Link-1")]
        CCLINK_1 = 81,
        [Description("CC-Link-2")]
        CCLINK_2 = 82,
        [Description("CC-Link-3")]
        CCLINK_3 = 83,
        [Description("CC-Link-4")]
        CCLINK_4 = 84,

        [Description("CC-Link IE Controller-1")]
        CCLINK_IE_CTRLER_1 = 151,
        [Description("CC-Link IE Controller-2")]
        CCLINK_IE_CTRLER_2 = 152,
        [Description("CC-Link IE Controller-3")]
        CCLINK_IE_CTRLER_3 = 153,
        [Description("CC-Link IE Controller-4")]
        CCLINK_IE_CTRLER_4 = 154,

        [Description("CC-Link IE Field-1")]
        CCLINK_IE_FIELD_1 = 181,
        [Description("CC-Link IE Field-2")]
        CCLINK_IE_FIELD_2 = 182,
        [Description("CC-Link IE Field-3")]
        CCLINK_IE_FIELD_3 = 183,
        [Description("CC-Link IE Field-4")]
        CCLINK_IE_FIELD_4 = 184,
    }

    public enum eDeviceType
    {
        [Description("BIT")]
        Bit,
        [Description("WORD")]
        Word
    }

    public enum eDevice
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

    public enum eDeviceUseType
    {
        [Description("STATUS")]
        Status,
        [Description("INTERFACE")]
        Interface,
    }

    public enum eValueType
    {
        [Description("BOOLEAN")]
        Bool,
        [Description("BINARY")]
        Binary,
        [Description("OCT")]
        Oct,
        [Description("DECIMAL")]
        Decimal,
        [Description("HEX")]
        Hex,
        [Description("ASCII")]
        Ascii,
    }

    public enum eValueDisplayMode
    {
        ASCII,
        DEC,
        HEX,
    }

    public enum CommandTrigger
    {
        Change,
        BitOn,
        BitOff,
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