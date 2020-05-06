namespace IMPLC.Service
{
    public interface IPLCServiceClient
    {
        IPLCServiceObject Connect(string rootUri);

        bool Disconnect();

        
    }
}