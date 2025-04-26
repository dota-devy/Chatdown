using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;

namespace Chatdown.Shared.Services;

public interface IBluetoothService
{
    bool IsBluetoothAvailable();
    IEnumerable<string> GetPairedDeviceNames();
    Task ConnectToDeviceAsync(string deviceName);
    Task DisconnectAsync();

    Task<IEnumerable<IDevice>> GetBroadcastDevicesAsync();
}