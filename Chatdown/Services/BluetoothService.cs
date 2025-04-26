using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Chatdown.Shared.Services;

namespace Chatdown.Services;

public class BluetoothService : IBluetoothService
{
    private readonly IAdapter _adapter;

    public BluetoothService()
    {
        var ble = CrossBluetoothLE.Current;
        _adapter = ble.Adapter;
    }

    public bool IsBluetoothAvailable()
    {
        return CrossBluetoothLE.Current.State == BluetoothState.On;
    }

    public IEnumerable<string> GetPairedDeviceNames()
    {
        var devices = _adapter.BondedDevices;
        if (devices == null || devices.Count == 0)
        {
            return Enumerable.Empty<string>();
        }
        return devices.Select(d => d.Name);
    }

    public async Task ConnectToDeviceAsync(string deviceName)
    {
        var devices = _adapter.BondedDevices;
        var device = devices.FirstOrDefault(d => d.Name == deviceName);
        if (device != null)
        {
            await _adapter.ConnectToDeviceAsync(device);
        }
        else
        {
            throw new Exception($"Device {deviceName} not found in paired devices.");
        }
    }

    public async Task DisconnectAsync()
    {
        foreach (var connectedDevice in _adapter.ConnectedDevices)
        {
            await _adapter.DisconnectDeviceAsync(connectedDevice);
        }
    }

    public async Task<IEnumerable<IDevice>> GetBroadcastDevicesAsync()
    {
        List<IDevice> devices = new List<IDevice>();
        await _adapter.StartScanningForDevicesAsync();
        _adapter.DeviceDiscovered += (sender, deviceEventArgs) =>
        {
            // Handle device discovery if needed
            devices.Add(deviceEventArgs.Device);
        };
        return devices;
    }
}