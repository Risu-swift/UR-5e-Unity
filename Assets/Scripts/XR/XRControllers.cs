using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRControllers : MonoBehaviour
{
    public InputDeviceCharacteristics DeviceCharacter;
    public List<GameObject> ControllerPrefabs;
    private GameObject SpawnedController;
    public InputDevice TargetDevice { get; set; }
    private List<InputDevice> Devices;
    GameObject CurrentController;
    public bool isRight;
    public GameObject UI_Des;
    private UI_Design UI_Design;
    // Start is called before the first frame update
    void Start()
    {
        UI_Design = UI_Des.GetComponent<UI_Design>();
        Devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(DeviceCharacter, Devices);
        if (Devices.Count > 0)
        {
            Debug.Log("Device Found");
            TargetDevice = Devices[0];
            Debug.Log(TargetDevice.name);
            if (!isRight)
            {
                CurrentController = ControllerPrefabs[1];
            }
            else if (isRight)
            {
                CurrentController = ControllerPrefabs[2];
            }
        }

        if (CurrentController)
        {
            SpawnedController = Instantiate(CurrentController, transform);
        }
    }

        
    }


