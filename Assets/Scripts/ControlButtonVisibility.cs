using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlButtonVisibility : MonoBehaviour
{
    [Header("Input actions for buttons")]
    [SerializeField] private InputActionReference gripBtnReference;

    [Header("Mesh renders for buttons")]
    [SerializeField] private MeshRenderer gripBtnRender;


    #region Listen for buttons
    private void Awake()
    {
        // grip
        gripBtnReference.action.performed += GripPressed;
        gripBtnReference.action.canceled += GripCancelled;
    }
    #endregion

    #region Cancel Listners
    private void OnDisable()
    {
        // grip
        gripBtnReference.action.performed -= GripPressed;
        gripBtnReference.action.canceled -= GripCancelled;
    }
    #endregion

    #region Grip
    private void GripPressed(InputAction.CallbackContext obj) => gripBtnRender.enabled = true;
    private void GripCancelled(InputAction.CallbackContext obj) => gripBtnRender.enabled = false;
    #endregion

}
