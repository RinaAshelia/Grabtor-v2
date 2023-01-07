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
 headRig = rig.transform.Find("ViveCameraRig/Camera");
 leftHandRig = rig.transform.Find("ViveCameraRig/LeftHand");
 rightHandRig = rig.transform.Find("ViveCameraRig/RightHand");
 }
 void Update()
 {
 if (photonView.IsMine)
 {
 MapPosition(Head, headRig);
 MapPosition(LeftHand, leftHandRig);
 MapPosition(RightHand, rightHandRig);
 }
 }
 void MapPosition(Transform target, Transform rigTransform)
 {
 target.position = rigTransform.position;
 target.rotation = rigTransform.rotation;
 }
}