using System;
using System.IO;
using URPTemplate.Core;

namespace URPTemplate.Database
{
    class LocalFileLoader : IFileLoader
    {
        private static readonly string key = "CzTH0YQLzBw5dvJLFh7qrS8vT7GUfiQl";

        public string GetData(string lPath)
        {
            if (File.Exists(lPath))
            {
                using (var lStream = File.OpenText(lPath))
                {
                    try
                    {
                        var lFullString = lStream.ReadToEnd();
                        return DecryptIfEncrypted(lFullString);
                    }
                    catch (Exception lException)
                    {
                        DebugLog.LogError(lException.Message, ErrorCode.Exception);
                        return "";
                    }
                }
            }
            else
            {
                DebugLog.LogWarning("File not found", ErrorCode.Exception);
                return "";
            }
        }

        public void SaveData(string lPath, string lFullString)
        {
            lFullString = AesOperation.EncryptString(key, lFullString);
            File.WriteAllText(lPath, lFullString);
            DebugLog.LogDebug("Data saved to: " + lPath);
        }

        private static string DecryptIfEncrypted(string lFullString)
        {
            try
            {
                return AesOperation.DecryptString(key, lFullString);
            }
            catch (Exception)
            {
                return lFullString;
            }
        }
    }
}
