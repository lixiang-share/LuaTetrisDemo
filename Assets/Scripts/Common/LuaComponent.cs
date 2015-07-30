using UnityEngine;
using System.Collections;
using LuaInterface;

/// <summary>
/// 通用的C#与lua交互的粘合层
/// </summary>
public class LuaComponent : LuaBehaviour {
    
    void Awake()
    {
        base.Awake();
        CallMethod("Awake");
    }

  
	void Start () {
        print(luaFilename);
        InitParams();
        CallMethod("Start");
	}
    private void InitParams()
    {
        LuaState ls = Dto.LuaMgr.lua;
        ls[moduleName + ".curInstance"] = this;
        foreach (ParamItem pi in m_params)
        {
            ls[moduleName + "." + pi.name] = pi.value;
        }
    }
	// Update is called once per frame
	void Update () {
        CallMethod("Update");
	}

    public void FixedUpdate()
    {
        CallMethod("FixedUpdate");
    }

    public void LateUpdate()
    {
        CallMethod("LateUpdate");
    }



    public void OnDestroy()
    {
        CallMethod("OnDestroy");
    }

    public void OnDisable()
    {
        CallMethod("OnDisable");
    }


    public void OnTriggerExit(Collider other)
    {
        CallMethod("OnTriggerExit", other);
    }


    public void OnTriggerEnter(Collider other)
    {
        CallMethod("OnTriggerEnter", other);
    }

    public void OnGUI()
    {
        CallMethod("OnGUI");
    }


    public void OnEnable()
    {
        CallMethod("OnEnable");
    }




























    public void OnAnimatorIK(int layerIndex)
    {
        CallMethod("OnAnimatorIK" , layerIndex);
    }

    public void OnAnimatorMove()
    {
        CallMethod("OnAnimatorMove");
    }

    public void OnApplicationFocus(bool focus)
    {
        CallMethod("OnApplicationFocus" , focus);
    }

    public void OnApplicationPause(bool pause)
    {
        CallMethod("OnApplicationPause" , pause);
    }

    public void OnApplicationQuit()
    {
        CallMethod("OnApplicationQuit");
    }

    public void OnAudioFilterRead(float[] data, int channels)
    {
        CallMethod("OnAudioFilterRead",data,channels);
    }

    public void OnBecameInvisible()
    {
        CallMethod("OnBecameInvisible");
    }

    public void OnBecameVisible()
    {
        CallMethod("OnBecameVisible");
    }

    public void OnBeforeTransformParentChanged()
    {
        CallMethod("OnBeforeTransformParentChanged");
    }

    public void OnCanvasGroupChanged()
    {
        CallMethod("OnCanvasGroupChanged");
    }

    public void OnCollisionEnter(Collision collision)
    {
        CallMethod("OnCollisionEnter",collision);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        CallMethod("OnCollisionEnter2D", collision);
    }

    public void OnCollisionExit(Collision collision)
    {
        CallMethod("OnCollisionExit", collision);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        CallMethod("OnCollisionExit2D", collision);
    }

    public void OnCollisionStay(Collision collision)
    {
        CallMethod("OnCollisionStay", collision);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        CallMethod("OnCollisionStay2D", collision);
    }

    public void OnConnectedToServer()
    {
        CallMethod("OnConnectedToServer");
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        CallMethod("OnControllerColliderHit", hit);
    }


    public void OnDisconnectedFromMasterServer(NetworkDisconnection info)
    {
        CallMethod("OnDisconnectedFromMasterServer", info);
    }

    public void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        CallMethod("OnDisconnectedFromServer", info);
    }

    public void OnDrawGizmos()
    {
        CallMethod("OnDrawGizmos");
    }

    public void OnDrawGizmosSelected()
    {
        CallMethod("OnDrawGizmosSelected");
    }


    public void OnFailedToConnect(NetworkConnectionError error)
    {
        CallMethod("OnFailedToConnect", error);
    }

    public void OnFailedToConnectToMasterServer(NetworkConnectionError error)
    {
        CallMethod("OnFailedToConnectToMasterServer", error);
    }



    public void OnJointBreak(float breakForce)
    {
        CallMethod("OnJointBreak", breakForce);
    }

    public void OnLevelWasLoaded(int level)
    {
        CallMethod("OnLevelWasLoaded", level);
    }

    public void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        CallMethod("OnMasterServerEvent", msEvent);
    }

    public void OnMouseDown()
    {
        CallMethod("OnMouseDown");
    }

    public void OnMouseDrag()
    {
        CallMethod("OnMouseDrag");
    }

    public void OnMouseEnter()
    {
        CallMethod("OnMouseEnter");
    }

    public void OnMouseExit()
    {
        CallMethod("OnMouseExit");
    }

    public void OnMouseOver()
    {
        CallMethod("OnMouseOver");
    }

    public void OnMouseUp()
    {
        CallMethod("OnMouseUp");
    }

    public void OnMouseUpAsButton()
    {
        CallMethod("OnMouseUpAsButton");
    }

    public void OnNetworkInstantiate(NetworkMessageInfo info)
    {
        CallMethod("OnNetworkInstantiate", info);
    }

    public void OnParticleCollision(GameObject other)
    {
        CallMethod("OnParticleCollision", other);
    }

    public void OnPlayerConnected(NetworkPlayer player)
    {
        CallMethod("OnPlayerConnected", player);
    }

    public void OnPlayerDisconnected(NetworkPlayer player)
    {
        CallMethod("OnPlayerDisconnected", player);
    }

    public void OnPostRender()
    {
        CallMethod("OnPostRender");
    }

    public void OnPreCull()
    {
        CallMethod("OnPreCull");
    }

    public void OnPreRender()
    {
        CallMethod("OnPreRender");
    }

    public void OnRectTransformDimensionsChange()
    {
        CallMethod("OnRectTransformDimensionsChange");
    }

    public void OnRectTransformRemoved()
    {
        CallMethod("OnRectTransformRemoved");
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        CallMethod("OnRenderImage",source , destination);
    }

    public void OnRenderObject()
    {
        CallMethod("OnRenderObject");
    }

    public void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        CallMethod("OnSerializeNetworkView",stream , info);
    }

    public void OnServerInitialized()
    {
        CallMethod("OnServerInitialized");
    }

    public void OnTransformChildrenChanged()
    {
        CallMethod("OnTransformChildrenChanged");
    }

    public void OnTransformParentChanged()
    {
        CallMethod("OnTransformParentChanged");
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        CallMethod("OnTriggerEnter2D",collision);
    }



    public void OnTriggerExit2D(Collider2D collision)
    {
        CallMethod("OnTriggerExit2D",collision);
    }

    public void OnTriggerStay(Collider other)
    {
        CallMethod("OnTriggerStay",other);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        CallMethod("OnTriggerStay2D",collision);
    }

    public void OnValidate()
    {
        CallMethod("OnValidate");
    }

    public void OnWillRenderObject()
    {
        CallMethod("OnWillRenderObject");
    }

    public void Reset()
    {
        CallMethod("Reset");
    }


}
