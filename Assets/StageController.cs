﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform playerHolder;

    public bool CurrentLoop = false;

    private Material initMat;
    private Material selectedMat;


    public float rotateSpeed;



    private void Start()
    {
        initMat = GetComponentInChildren<Renderer>().material;
        selectedMat = LevelController.Instance.selectedMat;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        GetComponentInChildren<Renderer>().material = LevelController.Instance.selectedMat;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInChildren<Renderer>().material = initMat;
    }




    void Update()
    {
        if (CurrentLoop)
        {
            float rotX = Input.GetAxis("Mouse X") * rotateSpeed;

            // float rotY = Input.GetAxis("Mouse Y") * rotateSpeed;

            if (transform.localEulerAngles.x - 90f < 5f)
            {
                // rotX = 0f;
                transform.Rotate(Vector3.forward, rotX);
                transform.localRotation = Quaternion.Euler(90f, transform.localEulerAngles.y, transform.localEulerAngles.z);



                if (Mathf.Abs(Vector3.Dot((LevelController.Instance.cylinder.position - transform.position).normalized, transform.up) - 1f) < 0.01f)
                {
                    LevelController.Instance.StageComplete(this);
                }


                rotX = 0f;
            }







            transform.Rotate(Vector3.up, rotX);





            // transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x + rotX, transform.localEulerAngles.y/*+ rotX*/, transform.localEulerAngles.z /*+ rotY*/);
        }
    }




}
