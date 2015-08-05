using UnityEngine;
using System.Collections;

namespace Wshrzzz.UnityUtil
{

    /// <summary>
    /// A tween basic class, offers some tween actions with params.
    /// </summary>
    public class TweenBasic : MonoBehaviour
    {
        /// <summary>
        /// Basic tween value calculate method, contain 4 modes:
        /// 1. EasyIn
        /// 2. EasyOut
        /// 3. EasyInOut
        /// 4. Linear
        /// </summary>
        /// <param name="process">Tween process. Between 0 - 1.</param>
        /// <param name="tweenFactor">A factor decides tween level.</param>
        /// <returns></returns>
        #region Basic static tween methods.
        public static float EasyInTween(float process, int tweenFactor = 1)
        {
            process = Mathf.Clamp01(process);
            float val = 1f - Mathf.Sin(Mathf.Clamp01(1f - process) * Mathf.PI * 0.5f);
            float tempVal = val;
            tweenFactor = Mathf.Clamp(tweenFactor, 1, 10);
            for (int i = 1; i < tweenFactor; i++ )
            {
                val *= tempVal;
            }
            return val;
        }

        public static float EasyOutTween(float process, int tweenFactor = 1)
        {
            process = Mathf.Clamp01(process);
            float val = 1f - Mathf.Sin(Mathf.Clamp01(process) * Mathf.PI * 0.5f);
            float tempVal = val;
            tweenFactor = Mathf.Clamp(tweenFactor, 1, 10);
            for (int i = 1; i < tweenFactor; i++)
            {
                val *= tempVal;
            }
            return 1f - val;
        }

        public static float EasyInOutTween(float process, int tweenFactor = 1)
        {
            process = Mathf.Clamp01(process);
            return process < 0.5f ? EasyInTween(process * 2f, tweenFactor) * 0.5f : EasyOutTween(process * 2f - 1f, tweenFactor) * 0.5f + 0.5f;
        }

        public static float LinearTween(float process)
        {
            return Mathf.Clamp01(process);
        }
        #endregion

        /// <summary>
        /// Init TweenBasic, attach it to a GameObject.
        /// </summary>
        /// <param name="go">Where should the tween component attach to.</param>
        /// <returns>A TweenBasic instance.</returns>
        public static TweenBasic InitTweener(GameObject go)
        {
            TweenBasic tweener = go.AddComponent<TweenBasic>();
            tweener.TweenProcess = 0f;
            tweener.TweenValue = 0f;
            return tweener;
        }

        public float TweenProcess { get; private set; }
        public float TweenValue { get; private set; }
        private float IdentifyDelta { get; set; }
        public bool IsTweening { get; private set; }
        public int TweenCount { get; private set; }

        /// <summary>
        /// Use it to make a tween start.
        /// </summary>
        /// <param name="tweenSort">Tween type.</param>
        /// <param name="duration">Tween duration.</param>
        /// <param name="forward">Is forward or backward. Default is forward.</param>
        /// <param name="reset">Whether reset the tween process. Sometimes you might want to stop the current tween,
        /// and let it tween back immediately from the current position.
        /// Default is true.</param>
        /// <param name="loopSort">3 tween loop type: Once, Loop, PingPong. Default is Once.</param>
        /// <param name="tweenFactor">Tween factor, work with Easy type tween. Bigger factor makes tween change more obviously</param>
        public void StartTween(TweenType tweenType, float duration, bool forward = true, bool reset = true, LoopType loopType = LoopType.Once, int tweenFactor = 1, int tweenTimes = -1)
        {
            StopAllCoroutines();

            if (reset)
            {
                TweenProcess = forward ? 0f : 1f;
                TweenValue = forward ? 0f : 1f;
            }
            IdentifyDelta = duration > 0f ? 1f / duration : 1f;
            IdentifyDelta = forward ? IdentifyDelta : -IdentifyDelta;
            IsTweening = true;
            TweenCount = 0;

            StartCoroutine(OnTweening(tweenType, tweenFactor, forward, loopType, tweenTimes));
        }

        IEnumerator OnTweening(TweenType tweenSort, int tweenFactor, bool forward, LoopType loopSort, int tweenTimes)
        {
            switch (tweenSort)
            {
                case TweenType.EasyIn:
                    while (true)
                    {
                        TweenProcess += IdentifyDelta * Time.deltaTime;
                        TweenValue = EasyInTween(TweenProcess, tweenFactor);
                        if (TweenProcess >= 1f && forward)
                        {
                            if (loopSort == LoopType.Once)
                            {
                                TweenProcess = 1f;
                                TweenValue = 1f;
                                TweenCount++;
                                break;
                            }
                            else if (loopSort == LoopType.Loop)
                            {
                                if (tweenTimes != -1)
                                {
                                    TweenCount++;
                                    if (TweenCount < tweenTimes)
                                    {
                                        TweenProcess = 0f;
                                    } 
                                    else
                                    {
                                        TweenProcess = 1f;
                                        break;
                                    }
                                }
                                else
                                {
                                    TweenProcess = 0f;
                                    TweenCount++;
                                }
                            }
                            else if (loopSort == LoopType.PingPong)
                            {
                                IdentifyDelta = -IdentifyDelta;
                                TweenProcess = 1f;
                                forward = !forward;
                                TweenCount++;

                                if (tweenTimes != -1)
                                {
                                    if (TweenCount >= tweenTimes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else if (TweenProcess <= 0f && !forward)
                        {
                            if (loopSort == LoopType.Once)
                            {
                                TweenProcess = 0f;
                                TweenValue = 0f;
                                TweenCount++;
                                break;
                            }
                            else if (loopSort == LoopType.Loop)
                            {
                                if (tweenTimes != -1)
                                {
                                    TweenCount++;
                                    if (TweenCount < tweenTimes)
                                    {
                                        TweenProcess = 1f;
                                    }
                                    else
                                    {
                                        TweenProcess = 0f;
                                        break;
                                    }
                                }
                                else
                                {
                                    TweenProcess = 1f;
                                    TweenCount++;
                                }
                            }
                            else if (loopSort == LoopType.PingPong)
                            {
                                IdentifyDelta = -IdentifyDelta;
                                TweenProcess = 0f;
                                forward = !forward;
                                TweenCount++;

                                if (tweenTimes != -1)
                                {
                                    if (TweenCount >= tweenTimes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;
                case TweenType.EasyOut:
                    while (true)
                    {
                        TweenProcess += IdentifyDelta * Time.deltaTime;
                        TweenValue = EasyOutTween(TweenProcess, tweenFactor);
                        if (TweenProcess >= 1f && forward)
                        {
                            if (loopSort == LoopType.Once)
                            {
                                TweenProcess = 1f;
                                TweenValue = 1f;
                                TweenCount++;
                                break;
                            }
                            else if (loopSort == LoopType.Loop)
                            {
                                if (tweenTimes != -1)
                                {
                                    TweenCount++;
                                    if (TweenCount < tweenTimes)
                                    {
                                        TweenProcess = 0f;
                                    }
                                    else
                                    {
                                        TweenProcess = 1f;
                                        break;
                                    }
                                }
                                else
                                {
                                    TweenProcess = 0f;
                                    TweenCount++;
                                }
                            }
                            else if (loopSort == LoopType.PingPong)
                            {
                                IdentifyDelta = -IdentifyDelta;
                                TweenProcess = 1f;
                                forward = !forward;
                                TweenCount++;

                                if (tweenTimes != -1)
                                {
                                    if (TweenCount >= tweenTimes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else if (TweenProcess <= 0f && !forward)
                        {
                            if (loopSort == LoopType.Once)
                            {
                                TweenProcess = 0f;
                                TweenValue = 0f;
                                TweenCount++;
                                break;
                            }
                            else if (loopSort == LoopType.Loop)
                            {
                                if (tweenTimes != -1)
                                {
                                    TweenCount++;
                                    if (TweenCount < tweenTimes)
                                    {
                                        TweenProcess = 1f;
                                    }
                                    else
                                    {
                                        TweenProcess = 0f;
                                        break;
                                    }
                                }
                                else
                                {
                                    TweenProcess = 1f;
                                    TweenCount++;
                                }
                            }
                            else if (loopSort == LoopType.PingPong)
                            {
                                IdentifyDelta = -IdentifyDelta;
                                TweenProcess = 0f;
                                forward = !forward;
                                TweenCount++;

                                if (tweenTimes != -1)
                                {
                                    if (TweenCount >= tweenTimes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;
                case TweenType.EasyInOut:
                    while (true)
                    {
                        TweenProcess += IdentifyDelta * Time.deltaTime;
                        TweenValue = EasyInOutTween(TweenProcess, tweenFactor);
                        if (TweenProcess >= 1f && forward)
                        {
                            if (loopSort == LoopType.Once)
                            {
                                TweenProcess = 1f;
                                TweenValue = 1f;
                                TweenCount++;
                                break;
                            }
                            else if (loopSort == LoopType.Loop)
                            {
                                if (tweenTimes != -1)
                                {
                                    TweenCount++;
                                    if (TweenCount < tweenTimes)
                                    {
                                        TweenProcess = 0f;
                                    }
                                    else
                                    {
                                        TweenProcess = 1f;
                                        break;
                                    }
                                }
                                else
                                {
                                    TweenProcess = 0f;
                                    TweenCount++;
                                }
                            }
                            else if (loopSort == LoopType.PingPong)
                            {
                                IdentifyDelta = -IdentifyDelta;
                                TweenProcess = 1f;
                                forward = !forward;
                                TweenCount++;

                                if (tweenTimes != -1)
                                {
                                    if (TweenCount >= tweenTimes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else if (TweenProcess <= 0f && !forward)
                        {
                            if (loopSort == LoopType.Once)
                            {
                                TweenProcess = 0f;
                                TweenValue = 0f;
                                TweenCount++;
                                break;
                            }
                            else if (loopSort == LoopType.Loop)
                            {
                                if (tweenTimes != -1)
                                {
                                    TweenCount++;
                                    if (TweenCount < tweenTimes)
                                    {
                                        TweenProcess = 1f;
                                    }
                                    else
                                    {
                                        TweenProcess = 0f;
                                        break;
                                    }
                                }
                                else
                                {
                                    TweenProcess = 1f;
                                    TweenCount++;
                                }
                            }
                            else if (loopSort == LoopType.PingPong)
                            {
                                IdentifyDelta = -IdentifyDelta;
                                TweenProcess = 0f;
                                forward = !forward;
                                TweenCount++;

                                if (tweenTimes != -1)
                                {
                                    if (TweenCount >= tweenTimes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;
                case TweenType.Linear:
                    while (true)
                    {
                        TweenProcess += IdentifyDelta * Time.deltaTime;
                        TweenValue = LinearTween(TweenProcess);
                        if (TweenProcess >= 1f && forward)
                        {
                            if (loopSort == LoopType.Once)
                            {
                                TweenProcess = 1f;
                                TweenValue = 1f;
                                TweenCount++;
                                break;
                            }
                            else if (loopSort == LoopType.Loop)
                            {
                                if (tweenTimes != -1)
                                {
                                    TweenCount++;
                                    if (TweenCount < tweenTimes)
                                    {
                                        TweenProcess = 0f;
                                    }
                                    else
                                    {
                                        TweenProcess = 1f;
                                        break;
                                    }
                                }
                                else
                                {
                                    TweenProcess = 0f;
                                    TweenCount++;
                                }
                            }
                            else if (loopSort == LoopType.PingPong)
                            {
                                IdentifyDelta = -IdentifyDelta;
                                TweenProcess = 1f;
                                forward = !forward;
                                TweenCount++;

                                if (tweenTimes != -1)
                                {
                                    if (TweenCount >= tweenTimes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else if (TweenProcess <= 0f && !forward)
                        {
                            if (loopSort == LoopType.Once)
                            {
                                TweenProcess = 0f;
                                TweenValue = 0f;
                                TweenCount++;
                                break;
                            }
                            else if (loopSort == LoopType.Loop)
                            {
                                if (tweenTimes != -1)
                                {
                                    TweenCount++;
                                    if (TweenCount < tweenTimes)
                                    {
                                        TweenProcess = 1f;
                                    }
                                    else
                                    {
                                        TweenProcess = 0f;
                                        break;
                                    }
                                }
                                else
                                {
                                    TweenProcess = 1f;
                                    TweenCount++;
                                }
                            }
                            else if (loopSort == LoopType.PingPong)
                            {
                                IdentifyDelta = -IdentifyDelta;
                                TweenProcess = 0f;
                                forward = !forward;
                                TweenCount++;

                                if (tweenTimes != -1)
                                {
                                    if (TweenCount >= tweenTimes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;
                default:
                    break;
            }
            yield return new WaitForEndOfFrame();
            IsTweening = false;
        }

        /// <summary>
        /// Stop current tween.
        /// </summary>
        public void StopTween()
        {
            StopAllCoroutines();
            IsTweening = false;
        }

        /// <summary>
        /// Stop tween and destroy tween component.
        /// </summary>
        public void DeinitTweener()
        {
            Destroy(this);
        }

        #region result SimpleLerp(start, end) {...}
        public float SimpleLerp(float start, float end)
        {
            return Mathf.Lerp(start, end, TweenValue);
        }

        public int SimpleLerp(int start, int end)
        {
            return (int)Mathf.Lerp(start, end, TweenValue);
        }

        public Vector2 SimpleLerp(Vector2 start, Vector2 end)
        {
            return Vector2.Lerp(start, end, TweenValue);
        }

        public Vector3 SimpleLerp(Vector3 start, Vector3 end)
        {
            return Vector3.Lerp(start, end, TweenValue);
        }

        public Vector4 SimpleLerp(Vector4 start, Vector4 end)
        {
            return Vector4.Lerp(start, end, TweenValue);
        }

        public Color SimpleLerp(Color start, Color end)
        {
            return Color.Lerp(start, end, TweenValue);
        }

        public Color32 SimpleLerp(Color32 start, Color32 end)
        {
            return Color32.Lerp(start, end, TweenValue);
        }

        public Quaternion SimpleLerp(Quaternion start, Quaternion end)
        {
            return Quaternion.Lerp(start, end, TweenValue);
        }
        #endregion
        
        public enum TweenType
        {
            EasyIn,
            EasyOut,
            EasyInOut,
            Linear
        }
        public enum LoopType
        {
            Once,
            Loop,
            PingPong
        }
    }
}