using Microsoft.Win32;
using System;
using System.Linq;
using System.Management;

namespace NetMasker
{
    public class NetMasker
    {
        private static RegistryKey networkClassKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\");
        private RegistryKey networkInterfaceKey;
        private ManagementObject networkAdapter;
        private string deviceId;
        private string driverDescription;
        private string originalMacAddress;

        public NetMasker(string deviceId)
        {
            this.deviceId = deviceId;
            driverDescription = Functions.GetDriverDescriptionById(deviceId);
            networkInterfaceKey = networkClassKey.OpenSubKey(deviceId, true);
            networkAdapter = new ManagementObjectSearcher($"select * from win32_networkadapter where Name='{driverDescription}'").Get().Cast<ManagementObject>().FirstOrDefault();
            originalMacAddress = networkInterfaceKey.GetValue("NetworkAddress")?.ToString() ?? "No establecida";
        }

        public bool ChangeMacAddress(string newMac = null)
        {
            if (!DisableNetworkDriver()) return false;
            newMac ??= Functions.GenerateValidMacAddress();
            networkInterfaceKey.SetValue("NetworkAddress", newMac, RegistryValueKind.String);
            bool result = EnableNetworkDriver();
            if (result)
            {
                Console.WriteLine($"MAC original: {originalMacAddress}, MAC nueva: {newMac}");
                originalMacAddress = newMac;
            }
            return result;
        }

        public bool ResetMacAddress()
        {
            return ChangeMacAddress(string.Empty);
        }

        private bool DisableNetworkDriver()
        {
            try
            {
                return (uint)networkAdapter.InvokeMethod("Disable", null) == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deshabilitando el controlador de red: {ex.Message}");
                return false;
            }
        }

        private bool EnableNetworkDriver()
        {
            try
            {
                return (uint)networkAdapter.InvokeMethod("Enable", null) == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error habilitando el controlador de red: {ex.Message}");
                return false;
            }
        }
    }
}
