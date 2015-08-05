using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Wshrzzz.UnityUtil
{
    public class ConsoleBasic : MonoBehaviour
    {
        private bool m_ShowConsole = false;

        private List<string> m_ArgsList = new List<string>();

        public delegate void ConsoleDelegate(params string[] list);
        private static Hashtable s_Command = new Hashtable();

        void Start()
        {
            CheeterConsole.AddCheeter("openmyconsole", () => { m_ShowConsole = true; });

            AddCommand("exit", (list) => { m_ShowConsole = false; });
        }

        void OnGUI()
        {
            if (m_ShowConsole)
            {
                GUILayout.BeginArea(new Rect(0, Screen.height - 25, Screen.width, 25));
                GUI.SetNextControlName("ConsoleString");
                s_ConsoleStr = GUILayout.TextField(s_ConsoleStr);
                GUI.FocusControl("ConsoleString");
                GUILayout.EndArea();
                if (Event.current.keyCode == KeyCode.Return && Event.current.type == EventType.KeyUp)
                {
                    DealCommand(s_ConsoleStr);
                }
            }
        }

        /// <summary>
        /// When press Enter key in the console input bar, it will deal the command.
        /// </summary>
        /// <param name="consoleStr">Whole command string.</param>
        void DealCommand(string consoleStr){
            consoleStr = consoleStr.Trim();
            int spaceIndex = consoleStr.IndexOf(' ');
            if (spaceIndex == -1)
            {
                if (s_Command.ContainsKey(consoleStr))
                {
                    (s_Command[consoleStr] as ConsoleDelegate)();
                }
                else
                {
                    GUILogDisplay.LogError("\"" + consoleStr + "\" isn't an available command!");
                }
            }
            else
            {
                string command = consoleStr.Substring(0, spaceIndex);
                if (s_Command.ContainsKey(command))
                {
                    m_ArgsList.Clear();
                    while (true)
                    {
                        int nextStartIndex = spaceIndex + 1;
                        spaceIndex = consoleStr.IndexOf(' ', nextStartIndex);
                        if (spaceIndex == -1)
                        {
                            m_ArgsList.Add(consoleStr.Substring(nextStartIndex));
                            break;
                        }
                        else
                        {
                            m_ArgsList.Add(consoleStr.Substring(nextStartIndex, spaceIndex - nextStartIndex));
                        }
                    }
                    (s_Command[command] as ConsoleDelegate)(m_ArgsList.ToArray());
                }
                else
                {
                    GUILogDisplay.LogError("\"" + command + "\" isn't an available command!");
                }
            }
            s_ConsoleStr = "";
        }

        /// <summary>
        /// Use this method to add commands to the ConsoleBasic.
        /// </summary>
        /// <param name="command">Command name.</param>
        /// <param name="method">Call back handler.</param>
        public static void AddCommand(string command, ConsoleDelegate method)
        {
            if (!ConsoleBasic.Instance)
            {
                return;
            }

            if (s_Command.ContainsKey(command))
            {
                GUILogDisplay.LogError("\"" + command + "\" is already exsit.");
            }
            else
            {
                s_Command.Add(command, method);
                GUILogDisplay.Log("Add command \"" + command + "\"");
            }
        }

        private static string s_ConsoleStr = "";
        private static ConsoleBasic s_Instance = null;
        public static ConsoleBasic Instance
        {
            get
            {
                if (s_Instance != null)
                {
                    return s_Instance;
                }
                else
                {
                    GameObject go = new GameObject();
                    s_Instance = go.AddComponent<ConsoleBasic>();
                    return s_Instance;
                }
            }
        }
    }
}

