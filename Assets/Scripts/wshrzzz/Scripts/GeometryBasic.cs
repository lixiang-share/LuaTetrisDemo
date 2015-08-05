using UnityEngine;
using System.Collections;

namespace Wshrzzz.UnityUtil
{
    public class GeometryBasic : MonoBehaviour
    {
        public static Quaternion LookToQuaternion(Vector3 forward, Vector3 up, bool upIsPrimary = false)
        {
            Vector3 myForward = forward.normalized;
            Vector3 myUp = up.normalized;
            float reg = Vector3.Angle(myForward, myUp);
            float rad = Mathf.Deg2Rad * reg;

            if (upIsPrimary)
            {
                myForward -= Mathf.Cos(rad) * myUp;
                myForward.Normalize();
                return Quaternion.LookRotation(myForward, myUp);
            }
            else
            {
                myUp -= Mathf.Cos(rad) * myForward;
                myUp.Normalize();
                return Quaternion.LookRotation(myForward, myUp);
            }
        }
    }
}
