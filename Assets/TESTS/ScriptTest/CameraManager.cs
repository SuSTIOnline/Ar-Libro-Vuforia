using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    public GameObject closeGift;
    public GameObject openGift;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            if (hit.transform.tag == "gift")
            {
                closeGift.SetActive(true);
                hit.transform.GetComponent<BoxCollider>().enabled = false;
                Debug.DrawRay(transform.position, Vector3.down + hit.point, Color.green);
            }
            else if (hit.transform.tag == "CloseGift")
            {
                OpenGift();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down + hit.point, Color.red);
            //closeGift.SetActive(false);
        }

    }

    private void OpenGift()
    {
        bool isPressOpenButton = Input.GetKey(KeyCode.Space);
        if (isPressOpenButton)
        {
            closeGift.SetActive(false);
            openGift.SetActive(true);
        }
    }
}
