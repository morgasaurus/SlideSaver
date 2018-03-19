﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SlideSaver
{
    public static class Utils
    {
        public static void SaveConfig(Config config)
        {
            string json = Serialize(config);
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MorgasaurusSlideSaver");
            key.SetValue("config", json);
        }

        public static Config LoadConfig()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MorgasaurusSlideSaver");
            if (key == null)
            {
                return GetDefaultConfig();
            }
            try
            {
                return Deserialize<Config>((string)key.GetValue("config"));
            }
            catch
            {
                return GetDefaultConfig();
            }
        }
        public static string Serialize<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T Deserialize<T>(string json)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }

        public static Config GetDefaultConfig()
        {
            return new Config()
            {
                SequenceMode = SequenceMode.Name,
                BasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                IncludeSubdirectories = true,
            };
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
    }
}