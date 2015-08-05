using UnityEngine;
using System.Collections;

namespace Wshrzzz.UnityUtil
{
    public class TimerBasic : MonoBehaviour
    {
        /// <summary>
        /// Is true while counting time.
        /// </summary>
        public bool IsCounting { get; private set; }

        /// <summary>
        /// Count time number.
        /// </summary>
        public float CountTime { get; private set; }

        private bool IsStopInTheEnd { get; set; }
        private float StartTime { get; set; }
        private float LimiteTime { get; set; }

        /// <summary>
        /// Start a counting.
        /// </summary>
        /// <param name="time">How long will this timer counts time. If don't want this timer stop, set the stopInTheEnd para false and ignore this.</param>
        /// <param name="stopInTheEnd">Whether the timer will stop.</param>
        /// <param name="reset">Don't want the timer reset like counting from a pause, set it false.</param>
        public void StartCount(float time = 0f, bool stopInTheEnd = true, bool reset = true)
        {
            StopAllCoroutines();
            
            if (reset)
            {
                LimiteTime = time;
                IsStopInTheEnd = stopInTheEnd;
                StartTime = Time.time;
                CountTime = 0f;
            }
            else
            {
                StartTime = Time.time - CountTime;
            }
            IsCounting = true;

            StartCoroutine(OnCountingTime());
        }

        IEnumerator OnCountingTime()
        {
            while (IsCounting)
            {
                CountTime = Time.time - StartTime;
                if (CountTime >= LimiteTime && IsStopInTheEnd)
                {
                    IsCounting = false;
                }
                yield return new WaitForEndOfFrame();
            }
        }

        /// <summary>
        /// Stop counting time, generally, used like pause.
        /// </summary>
        public void StopCount()
        {
            StopAllCoroutines();
            IsCounting = false;
        }

        /// <summary>
        /// Destroy timer.
        /// </summary>
        public void DeinitTimer()
        {
            Destroy(this);
        }

        /// <summary>
        /// Init TimerBasic, attach it to a GameObject.
        /// </summary>
        /// <param name="go">Where should the timer component attach to.</param>
        /// <returns>A TimerBasic instance.</returns>
        public static TimerBasic InitTimer(GameObject go){
            TimerBasic timer = go.AddComponent<TimerBasic>();
            timer.IsCounting = false;
            timer.IsStopInTheEnd = true;
            timer.CountTime = 0f;
            timer.StartTime = 0f;
            timer.LimiteTime = 0f;
            return timer;
        }
    }
}