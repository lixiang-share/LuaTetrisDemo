using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Wshrzzz.UnityUtil
{
    /// <summary>
    /// Cheeter console. Invisible input and activate cheeter.
    /// </summary>
    public class CheeterConsole : MonoBehaviour
    {
        public delegate void CheetDelegate();

        private string CheeterInput { get; set; }

        void Update()
        {
            CheeterInput += Input.inputString;
            if (CheeterInput.Length > 30)
            {
                CheeterInput = CheeterInput.Substring(CheeterInput.Length - 30, 30);
            }
            if (CheeterHash != null)
            {
                for (int cheeterLength = 1; cheeterLength <= LonggestCheeterLength && cheeterLength <= CheeterInput.Length; cheeterLength++ )
                {
                    string str = CheeterInput.Substring(CheeterInput.Length - cheeterLength, cheeterLength);
                    if (CheeterHash.ContainsKey(str))
                    {
                        CheeterInput = "";
                        (HandlerHash[str] as CheetDelegate)();
                        GUILogDisplay.Log("On cheet [" +  str + "].");
                    }
                }
            }
        }

        private static Hashtable CheeterHash { get; set; }
        private static Hashtable HandlerHash { get; set; }
        private static int LonggestCheeterLength { get; set; }

        /// <summary>
        /// Add a cheeter. If something wrong, it will give some warnings or errors.
        /// </summary>
        /// <param name="cheeterName">Cheeter name.</param>
        /// <param name="handler">When this cheeter works, it will call the handler.</param>
        /// <returns>Is success?</returns>
        public static bool AddCheeter(string cheeterName, CheetDelegate handler)
        {
            if (CheeterConsole.GetInstance())
            {
                if (CheeterHash == null)
                {
                    CheeterHash = new Hashtable();
                }
                if (HandlerHash == null)
                {
                    HandlerHash = new Hashtable();
                }
                if (cheeterName.Length > 30 || cheeterName.Length < 5)
                {
                    cheeterName = cheeterName.Substring(0, 30);
                    GUILogDisplay.LogWarning("Cheeter name is limited in 5-30 chars.");
                }

                bool result = false;
                switch (CheckCheeterName(cheeterName))
                {
                    case CheeterNameInfo.Exsit:
                        CheetDelegate newHandler = HandlerHash[cheeterName] as CheetDelegate;
                        newHandler += handler;
                        HandlerHash[cheeterName] = newHandler;
                        GUILogDisplay.Log("Expand exist cheeter [" + cheeterName + "].");
                        result = true;
                        break;
                    case CheeterNameInfo.DontExsit:
                        CheeterHash.Add(cheeterName, cheeterName.Length);
                        if (cheeterName.Length > LonggestCheeterLength)
                        {
                            LonggestCheeterLength = cheeterName.Length;
                        }
                        HandlerHash.Add(cheeterName, handler);
                        GUILogDisplay.Log("Add new cheeter [" + cheeterName + "].");
                        result = true;
                        break;
                    case CheeterNameInfo.NameError:
                        GUILogDisplay.LogWarning("Cheeter name [" + cheeterName + "] conflicts with others.");
                        break;
                    case CheeterNameInfo.Unknown:
                        GUILogDisplay.LogError("Unknown error...");
                        break;
                    default:
                        break;
                }
                return result;
            }
            else
            {
                return false;
            }
        }

        private static CheeterNameInfo CheckCheeterName(string cheeterName)
        {
            if (!CheeterHash.ContainsKey(cheeterName))
            {
                foreach (DictionaryEntry item in CheeterHash)
                {
                    if ((int)item.Value > cheeterName.Length)
                    {
                        if ((item.Key as string).Contains(cheeterName))
                        {
                            return CheeterNameInfo.NameError;
                        }
                    }
                    else
                    {
                        if (cheeterName.Contains(item.Key as string))
                        {
                            return CheeterNameInfo.NameError;
                        }
                    }
                }

                return CheeterNameInfo.DontExsit;
            }
            else
            {
                return CheeterNameInfo.Exsit;
            }
        }

        /// <summary>
        /// Remove a cheeter. If something wrong, it will give some warning.
        /// Pay attention, it remove all handlers under this cheeter called [cheeterName].
        /// </summary>
        /// <param name="cheeterName">Cheeter name.</param>
        /// <returns>Is success?</returns>
        public static bool RemoveCheeter(string cheeterName)
        {
            if (CheeterConsole.GetInstance())
            {
                if (CheeterHash == null && HandlerHash == null)
                {
                    CheeterHash = new Hashtable();
                    HandlerHash = new Hashtable();
                    GUILogDisplay.LogWarning("There isn't a cheeter.");
                    return false;
                }
                if (CheeterHash.ContainsKey(cheeterName))
                {
                    CheeterHash.Remove(cheeterName);
                    HandlerHash.Remove(cheeterName);
                    GUILogDisplay.Log("Remove cheeter [" + cheeterName + "].");

                    if (cheeterName.Length == LonggestCheeterLength)
                    {
                        for (int length = cheeterName.Length; length >= 5; length--)
                        {
                            if (CheeterHash.ContainsValue(length))
                            {
                                LonggestCheeterLength = length;
                                return true;
                            }
                        }
                        LonggestCheeterLength = -1;
                    }
                    return true;
                }
                else
                {
                    GUILogDisplay.LogWarning("Cheeter [" + cheeterName + "] isn't exist.");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static CheeterConsole s_Instance = null;

        public static CheeterConsole GetInstance()
        {
            if (s_Instance != null)
            {
                return s_Instance;
            }
            else
            {
                s_Instance = FindObjectOfType<CheeterConsole>();
                if (s_Instance != null)
                {
                    return s_Instance;
                }
                else
                {
                    GameObject go = new GameObject();
                    go.name = "CheeterManager";
                    go.AddComponent<CheeterConsole>();
                    s_Instance = go.GetComponent<CheeterConsole>();
                    return s_Instance;
                }
            }
        }

        public enum CheeterNameInfo
        {
            DontExsit,
            Exsit,
            NameError,
            Unknown
        }
    }
}
