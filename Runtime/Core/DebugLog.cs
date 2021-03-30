using UnityEngine;

namespace URPTemplate.Core
{
    public class DebugLog : MonoBehaviour
    {

        public static void LogError(string message, ErrorCode exception)
        {
            Debug.LogError(exception + " : " + message);
        }

        public static void LogWarning(string message, ErrorCode exception)
        {
            Debug.LogWarning(exception + " : " + message);
        }

        public static void LogDebug(string message)
        {
            Debug.Log("Debug : " + message);
        }
    }
}


