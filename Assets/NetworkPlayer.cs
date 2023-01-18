using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviour
{
    
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        XRRig rig = FindObjectOfType<XRRig>();
        headRig.transform.Find("Camera Offset/Main Camera");
        leftHandRig.transform.Find("Camera Offset/Left Hand");
        rightHandRig.transform.Find("Camera Offset/Right Hand");

        if(photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
       
    }

    void Update()
    {
        if(photonView.IsMine)
        {
       
        MapPosition(head, headRig);
        MapPosition(leftHand, leftHandRig);
        MapPosition(rightHand, rightHandRig);

        UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand),leftHandAnimator);  
        UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand),rightHandAnimator);  

        }
    
    }

//fix Handmodel grip and trigger animation 
    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
    target.position = rigTransform.position;
    target.rotation = rigTransform.rotation;
    }
}