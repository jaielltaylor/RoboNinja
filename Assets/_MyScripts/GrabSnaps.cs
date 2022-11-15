using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabSnaps : MonoBehaviour
{
    public static GrabSnaps handler;

    public InputDeviceCharacteristics rightHandCharacteristics;
    private InputDevice rightControllerDevice;
    private XRRig myRig;
    public bool secondaryBtnVal;

    public GameObject snap;
    public GameObject snapped;
    private bool cantStore;
    private Transform tempTransform;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(rightHandCharacteristics, devices);
        if (devices.Count > 0) rightControllerDevice = devices[0];

        cantStore = false;
        tempTransform = snapped.transform.parent;

    }

    void Update()
    {
        rightControllerDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryBtnVal);    // Test 'B' for storage
    }

    private void FixedUpdate()
    {
        if (secondaryBtnVal)
        {
            if (cantStore == false)
            {
                snapped.transform.parent = snap.transform;
                snap.SetActive(false);
                cantStore = true;
            }
            else
            {
                snap.SetActive(true);
                snapped.transform.parent = tempTransform;
                cantStore = false;
            }
        }
    }
}
