using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CineMachineCameraMod : MonoBehaviour
{

    Cinemachine.CinemachineFreeLook cam_Freelook;


    public void Awake()
    {
        cam_Freelook = GetComponent<Cinemachine.CinemachineFreeLook>();
        MainCustomNetworkManager.NetworkInstance.localPlayerJoinedEvent.AddListener(HandleLocalPlayerJoined);
        this.enabled = false;
    }

    public void HandleLocalPlayerJoined(MainPlayerNetworkState localPlayerState)
    {
        cam_Freelook.m_LookAt = localPlayerState.gameObject.transform;
        cam_Freelook.m_Follow = localPlayerState.gameObject.transform;
        this.enabled = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(cam_Freelook.m_LookAt == null)
        {

            cam_Freelook.m_LookAt = MainPlayerNetworkState.LocalPlayer.gameObject.transform;
            cam_Freelook.m_Follow = MainPlayerNetworkState.LocalPlayer.gameObject.transform;



        }



    }


}
