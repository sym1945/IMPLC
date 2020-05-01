namespace IMPLC.Service
{
    public interface IPLCService
    {
        bool Start(string portName);
        bool Stop();
    }
}
