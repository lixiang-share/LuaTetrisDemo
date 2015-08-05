using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Wshrzzz.UnityUtil
{
    /// <summary>
    /// Print the log on Unity GUI.
    /// It can be used sometimes where can't easily see system log.
    /// </summary>
    public class GUILogDisplay : MonoBehaviour
    {
        private Vector2 m_ScrollV2 = new Vector2(0f, 0f);
        private Vector2 m_TempV2 = new Vector2(0f, 1000f);
        private bool m_IsAutoScroll = true;
        private float m_WinWidth;
        private float m_WinHeight;
        private Rect m_MyDebugWindow0;
        private bool m_ShowWin = true;

        /// <summary>
        /// Whether show debug log window.
        /// </summary>
        public bool showLog = true;

        void Awake()
        {
            isWork = true;
        }

        void Start()
        {
            m_WinWidth = Screen.width;
            m_WinHeight = Screen.height * 0.4f;
            m_MyDebugWindow0 = new Rect(0f, Screen.height * 0.6f, m_WinWidth, m_WinHeight);

            CheeterConsole.AddCheeter("showmydebug", () => { showLog = true; });
            CheeterConsole.AddCheeter("hidemydebug", () => { showLog = false; });
        }

        void OnGUI()
        {
            if (showLog)
            {
                if (m_ShowWin)
                {
                    m_MyDebugWindow0.width = m_WinWidth;
                    m_MyDebugWindow0.height = m_WinHeight;
                }
                else
	            {
                    m_MyDebugWindow0.width = 0f;
                    m_MyDebugWindow0.height = 0f;
	            }
                m_MyDebugWindow0 = GUILayout.Window(1226, m_MyDebugWindow0, DisplayMyLog, "DEBUG");
            }
        }

        /// <summary>
        /// My window function.
        /// </summary>
        void DisplayMyLog(int winID)
        {
            GUILayout.BeginHorizontal("Label");
            m_ShowWin = GUILayout.Toggle(m_ShowWin, "Show Debug", GUILayout.MinWidth(Screen.width * 0.1f), GUILayout.ExpandWidth(false));
            if (m_ShowWin)
            {
                m_IsAutoScroll = GUILayout.Toggle(m_IsAutoScroll, "Auto Scroll", GUILayout.MinWidth(Screen.width * 0.1f), GUILayout.ExpandWidth(false));
                if (GUILayout.Button("Clean Log", GUILayout.ExpandWidth(false)))
                {
                    logQueue.Clear();
                }
            }
            GUILayout.EndHorizontal();

            if (m_ShowWin)
            {
                GUILayout.BeginHorizontal("Label");
                GUILayout.Label("Width", GUILayout.ExpandWidth(false));
                m_WinWidth = GUILayout.HorizontalSlider(m_WinWidth, Screen.width * 0.5f, Screen.width, GUILayout.MinWidth(Screen.width * 0.2f), GUILayout.ExpandWidth(false));
                GUILayout.Label("Height", GUILayout.ExpandWidth(false));
                m_WinHeight = GUILayout.HorizontalSlider(m_WinHeight, Screen.height * 0.3f, Screen.height, GUILayout.MinWidth(Screen.width * 0.2f), GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();

                if (m_IsAutoScroll)
                {
                    m_ScrollV2 += m_TempV2;
                }
                m_ScrollV2 = GUILayout.BeginScrollView(m_ScrollV2);
                foreach (var item in logQueue)
                {
                    switch (item.type)
                    {
                        case LogType.Log:
                            GUI.color = Color.white;
                            break;
                        case LogType.LogWarning:
                            GUI.color = Color.yellow;
                            break;
                        case LogType.LogError:
                            GUI.color = Color.red;
                            break;
                        default:
                            break;
                    }
                    GUILayout.Box(item.log);
                }
                GUI.color = Color.white;
                //GUILayout.Box(logInfo);
                GUILayout.EndScrollView();
            }

            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        private static Queue<LogItem> logQueue = new Queue<LogItem>();
        private static int maxLogNumber = 400;
        private static bool isWork = false;

        private struct LogItem
        {
            public LogType type;
            public string log;

            public LogItem(LogType type, string log)
            {
                this.type = type;
                this.log = log;
            }
        }

        private enum LogType
        {
            Log,
            LogWarning,
            LogError
        }

        /// <summary>
        /// Use this static method to print log on GUI window.
        /// </summary>
        /// <param name="log">Log to print.</param>
        public static void Log(object log)
        {
            string logStr = log.ToString();
            Debug.Log(logStr);
            if (isWork)
            {
                logQueue.Enqueue(new LogItem(LogType.Log, logStr));
                if (logQueue.Count > maxLogNumber)
                {
                    logQueue.Dequeue();
                }
            }
        }

        /// <summary>
        /// Use this static method to print warning on GUI window.
        /// </summary>
        /// <param name="log">Warning to print.</param>
        public static void LogWarning(object log)
        {
            string logStr = log.ToString();
            Debug.LogWarning(logStr);
            if (isWork)
            {
                logQueue.Enqueue(new LogItem(LogType.LogWarning, logStr));
                if (logQueue.Count > maxLogNumber)
                {
                    logQueue.Dequeue();
                }
            }
        }

        /// <summary>
        /// Use this static method to print error on GUI window.
        /// </summary>
        /// <param name="log">Error to print.</param>
        public static void LogError(object log)
        {
            string logStr = log.ToString();
            Debug.LogError(logStr);
            if (isWork)
            {
                logQueue.Enqueue(new LogItem(LogType.LogError, logStr));
                if (logQueue.Count > maxLogNumber)
                {
                    logQueue.Dequeue();
                }
            }
        }

        /// <summary>
        /// Deprecate, use Log() instead.
        /// </summary>
        /// <param name="log">Log to print.</param>
        public static void PrintLog(object log)
        {
            Log(log);
        }
    }
}