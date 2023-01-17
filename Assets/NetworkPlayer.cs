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
    }

    void Update()
    {
        if(photonView.IsMine)
        {
        head.gameObject.SetActive(false);
        leftHand.gameObject.SetActive(false);
        rightHand.gameObject.SetActive(false);

        MapPosition(head, headRig);
        MapPosition(leftHand, leftHandRig);
        MapPosition(rightHand, rightHandRig);
        }
    
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
    target.position = rigTransform.position;
    target.rotation = rigTransform.rotation;
    }
}
