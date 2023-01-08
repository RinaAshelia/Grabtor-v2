using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviourPun
{
    public Transform Head;
    public Transform LeftHand;
    public Transform RightHand;
    private PhotonView photonView;
    private Transform headRig;
    private Transform rightHandRig;
    private Transform leftHandRig;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();

        if (rig) {
            Debug.Log("rig.transform " + rig.transform.Find("CameraOffset/MainCamera").transform);


            headRig = rig.transform.Find("CameraOffset/MainCamera").transform;
            leftHandRig = rig.transform.Find("CameraOffset/LeftHand").transform;
            rightHandRig = rig.transform.Find("CameraOffset/RigthHand").transform;

            return;
        }

         Debug.Log("rig ist null " + rig);

    }

    void Update()
    {
        if (photonView.IsMine)
        {
            // MapPosition(Head, headRig);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        if (rigTransform) {
            target.position = rigTransform.position; // + cameraoffset;
            target.position = new Vector3(target.position.x, GetComponent<Rigidbody>().position.y, target.position.z);

            target.rotation = rigTransform.rotation;
            target.rotation = Quaternion.Euler(0.0f, target.eulerAngles.y, 0.0f);

            return;
        }

        Debug.Log("rigTransform ist null " + rigTransform);
    }
}