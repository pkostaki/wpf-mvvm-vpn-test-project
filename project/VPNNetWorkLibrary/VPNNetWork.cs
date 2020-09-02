using System;
using System.Threading;
using System.Threading.Tasks;

namespace VPNNetWorkLibrary
{
    public class VPNNetWork : INetWork
    {
        public ISetting Setting { get; set; }
        public event EventHandler<ConnectionStatus> StatusChanged;

        private ConnectionStatus _status = ConnectionStatus.Disconnected;
        public ConnectionStatus Status { get => _status; private set
            {
                if(_status==value)
                {
                    return;
                }
                _status = value;
                StatusChanged?.Invoke(this, _status);
            }
        }

        private TaskCompletionSource<bool> _emulatedConnectionTask;
        private Timer _emulatedConnectionTimer;
        private readonly object _lock = new object();
        public Task Connect()
        {
            lock (_lock)
            {
                if (_emulatedConnectionTask == null)
                {
                    _emulatedConnectionTask = new TaskCompletionSource<bool>();
                    _emulatedConnectionTimer = new Timer(OnEmulatedTimer);
                    _emulatedConnectionTimer.Change(4000, Timeout.Infinite);
                    Status = ConnectionStatus.Connecting;
                }

                return _emulatedConnectionTask.Task;
            }
        }

        private void ResetEmulatorTimer()
        {
            if (_emulatedConnectionTask != null)
            {
                _emulatedConnectionTask.TrySetResult(true);
                _emulatedConnectionTask = null;
            }

            if (_emulatedConnectionTimer==null)
            {
                return;
            }
            _emulatedConnectionTimer.Dispose();
            _emulatedConnectionTimer = null;
        }

        private void OnEmulatedTimer(object state)
        {
            ResetEmulatorTimer();
            // emulate result of connection (succeed or failed)
            Status = new Random().NextDouble() > 0.5 ? ConnectionStatus.Connected : ConnectionStatus.Disconnected;
        }

        public void Disconnect()
        {
            if (Status == ConnectionStatus.Disconnected)
            {
                return;
            }
            ResetEmulatorTimer();

            Status = ConnectionStatus.Disconnected;
        }
    }

    public class VpnSpecialSetting
    {
        private readonly string _id;

        public VpnSpecialSetting(string id)
        {
            _id = id;
        }

        // here list of settings for proper setup vpn 
        public override string ToString()
        {
            return $"VpnSpecialSetting: {_id}";
        }
    }
}
