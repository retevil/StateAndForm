﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerController : MonoBehaviour
{
    public Form formSelected;

    public float reloadReformTime = 1f;

    private CinemachineVirtualCamera VC;

    private ObjectMovement OM;

    private float timeToReform = 0f;


    // Start is called before the first frame update
    void Start()
    {

        VC = GetComponentInChildren<CinemachineVirtualCamera>();

        SetFormActive(formSelected);

        OM = GetComponentInChildren<ObjectMovement>();
        if (OM != null)
        {
            OM.SetCamera(VC);
        }

    }

    private void SetFormActive(Form formToChange)
    {
        formSelected = formToChange;
        ObjectMovement[] arr = GetComponentsInChildren<ObjectMovement>(true);
        foreach (var obj in arr)
        {
            obj.Activate(false);
            if (obj.FormInUse == formToChange)
            {
                SetNewForm(obj);
            }
        }

    }

    private void SetNewForm(ObjectMovement obj)
    {
        obj.Activate(true);
        if (OM != null)
        {
            obj.transform.SetPositionAndRotation(OM.transform.position, OM.transform.rotation);
        }

        OM = obj;
        OM.SetCamera(VC);

    }

    private void SwitchForm()
    {



        switch (formSelected)
        {
            case Form.CUBE:

                SetFormActive(Form.SPHERE);
                break;
            case Form.SPHERE:
                SetFormActive(Form.CONE);
                break;
            case Form.CONE:

                SetFormActive(Form.CUBE);
                break;
            default:
                break;
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(GameManager.GM.forward))
        {
            OM.MoveTo(new Vector3(0, 0, 1));
        }

        if (Input.GetKey(GameManager.GM.backward))
        {

            OM.MoveTo(new Vector3(0, 0, -1));
        }

        if (Input.GetKey(GameManager.GM.left))
        {

            OM.MoveTo(new Vector3(-1, 0, 0));
        }

        if (Input.GetKey(GameManager.GM.right))
        {
            OM.MoveTo(new Vector3(1, 0, 0));
        }

        if (Input.GetKey(GameManager.GM.jump))
        {
            OM.Jump();
        }

        if (Input.GetKey(GameManager.GM.formChange) && Time.time >= timeToReform)
        {
            timeToReform = Time.time + reloadReformTime;
            SwitchForm();
        }
        //gameObject.transform.SetPositionAndRotation(OM.transform., new Quaternion());
    }

}
