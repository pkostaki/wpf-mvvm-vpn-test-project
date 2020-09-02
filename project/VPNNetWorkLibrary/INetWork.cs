using System;
using System.Threading.Tasks;

namespace VPNNetWorkLibrary
{
    public interface INetWork
    {
        event EventHandler<ConnectionStatus> StatusChanged;
        ConnectionStatus Status { get; }
        ISetting Setting { get; set; }
        Task Connect();
        void Disconnect();
    }

    public interface ISetting
    {

    }

}
