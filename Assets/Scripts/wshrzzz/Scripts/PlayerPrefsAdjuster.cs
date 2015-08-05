using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Wshrzzz.UnityUtil
{
    /// <summary>
    /// Set PlayerPrefs and get info display on GUI with PlayerPrefsAdjuster.
    /// </summary>
    public class PlayerPrefsAdjuster : MonoBehaviour
    {
        private List<PrefsListItem> MyChangeList { get; set; }
        private List<PrefsListItem> MyRemoveList { get; set; }

        void Update()
        {
            foreach (var item in MyChangeList)
            {
                item.ShowCountDown -= Time.deltaTime;
                if (item.ShowCountDown <= 0f)
                {
                    MyRemoveList.Add(item);
                }
            }
            foreach (var item in MyRemoveList)
            {
                MyChangeList.Remove(item);
            }
            MyRemoveList.Clear();
        }

        void OnGUI()
        {
            foreach (var item in MyChangeList)
            {
                GUILayout.Box(item.PrefsName + " : " + item.Value);
            }
        }

        private static PlayerPrefsAdjuster s_Instance = null;

        public static PlayerPrefsAdjuster GetInstance()
        {
            if (s_Instance == null)
            {
                GameObject go = new GameObject();
                go.name = "PlayerPrefsAdjuster";
                go.AddComponent<PlayerPrefsAdjuster>();
                s_Instance = go.GetComponent<PlayerPrefsAdjuster>();
                s_Instance.MyChangeList = new List<PrefsListItem>();
                s_Instance.MyRemoveList = new List<PrefsListItem>();
            }
            return s_Instance;
        }

        public static void ChangeSetting(string prefsName, int value, string info)
        {
            GetInstance();
            PlayerPrefs.SetInt(prefsName, value);
            foreach (var item in s_Instance.MyChangeList)
            {
                if (item.PrefsName == prefsName)
                {
                    if (info != null)
                    {
                        item.Value = value.ToString() + " -- [" + info + "]";
                    }
                    else
                    {
                        item.Value = value.ToString();
                    }
                    item.ShowCountDown = 2.5f;
                    return;
                }
            }
            if (info != null)
            {
                PrefsListItem newItem = new PrefsListItem() { PrefsName = prefsName, Value = value.ToString() + " -- [" + info + "]", ShowCountDown = 2.5f };
                s_Instance.MyChangeList.Add(newItem);
            }
            else
            {
                PrefsListItem newItem = new PrefsListItem() { PrefsName = prefsName, Value = value.ToString(), ShowCountDown = 2.5f };
                s_Instance.MyChangeList.Add(newItem);
            }
        }

        public static void ChangeSetting(string prefsName, float value, string info)
        {
            GetInstance();
            PlayerPrefs.SetFloat(prefsName, value);
            foreach (var item in s_Instance.MyChangeList)
            {
                if (item.PrefsName == prefsName)
                {
                    if (info != null)
                    {
                        item.Value = value.ToString("F3") + " -- [" + info + "]";
                    }
                    else
                    {
                        item.Value = value.ToString("F3");
                    }
                    item.ShowCountDown = 2.5f;
                    return;
                }
            }
            if (info != null)
            {
                PrefsListItem newItem = new PrefsListItem() { PrefsName = prefsName, Value = value.ToString("F3") + " -- [" + info + "]", ShowCountDown = 2.5f };
                s_Instance.MyChangeList.Add(newItem);
            }
            else
            {
                PrefsListItem newItem = new PrefsListItem() { PrefsName = prefsName, Value = value.ToString("F3"), ShowCountDown = 2.5f };
                s_Instance.MyChangeList.Add(newItem);
            }
        }

        public static void ChangeSetting(string prefsName, string value, string info)
        {
            GetInstance();
            PlayerPrefs.SetString(prefsName, value);
            foreach (var item in s_Instance.MyChangeList)
            {
                if (item.PrefsName == prefsName)
                {
                    if (info != null)
                    {
                        item.Value = value + " -- [" + info + "]";
                    }
                    else
                    {
                        item.Value = value;
                    }
                    item.ShowCountDown = 2.5f;
                    return;
                }
            }
            if (info != null)
            {
                PrefsListItem newItem = new PrefsListItem() { PrefsName = prefsName, Value = value + " -- [" + info + "]", ShowCountDown = 2.5f };
                s_Instance.MyChangeList.Add(newItem);
            }
            else
            {
                PrefsListItem newItem = new PrefsListItem() { PrefsName = prefsName, Value = value, ShowCountDown = 2.5f };
                s_Instance.MyChangeList.Add(newItem);
            }
        }

        public class PrefsListItem
        {
            public string PrefsName { get; set; }
            public string Value { get; set; }
            public float ShowCountDown { get; set; }
        }
    }
}