using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace NetMasker
{
    public static class Functions
    {
        private static RegistryKey networkClassKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\");
        private static Random random = new Random();

        public static string GenerateValidMacAddress()
        {
            byte[][] ouis = new byte[][]
            {
                new byte[] { 0x00, 0x26, 0x18}, // ASUS
                new byte[] { 0xF0, 0xEE, 0x7A}, // APPLE
                new byte[] { 0xF0, 0xEE, 0xF4}, // LENOVO
            };
            byte[] macBytes = new byte[6];
            random.NextBytes(macBytes);
            byte[] selectedOui = ouis[random.Next(ouis.Length)];
            Array.Copy(selectedOui, 0, macBytes, 0, 3);
            macBytes[0] = (byte)(macBytes[0] & 0xFE);
            macBytes[0] = (byte)(macBytes[0] | 0x02);
            return BitConverter.ToString(macBytes);
        }

        public static List<string> GetDeviceIds()
        {
            var ids = new List<string>();
            for (int i = 0; i <= 9999; i++)
            {
                string id = i.ToString().PadLeft(4, '0');
                if (networkClassKey.OpenSubKey(id) != null)
                    ids.Add(id);
                else
                    break;
            }
            return ids;
        }

        public static string GetDriverDescriptionById(string id)
        {
            return networkClassKey.OpenSubKey(id)?.GetValue("DriverDesc")?.ToString();
        }
    }
}
