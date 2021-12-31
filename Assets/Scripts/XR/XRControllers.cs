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
    // Start is called before the first frame update
    void Start()
    {
        Devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(DeviceCharacter,Devices);
        if (Devices.Count > 0)
        {
            TargetDevice = Devices[0];
            foreach (var d in Devices)
            {
                if (d.characteristics == InputDeviceCharacteristics.Controller)
                {
                    if (d.characteristics == InputDeviceCharacteristics.Left)
                    {
                        CurrentController = ControllerPrefabs[1];
                    }
                    else if (d.characteristics == InputDeviceCharacteristics.Right)
                    {
                        CurrentController = ControllerPrefabs[2];
                    }
                    else
                    {
                        CurrentController = ControllerPrefabs[0];
                    }
                }
            }


            if (CurrentController)
            {
                SpawnedController = Instantiate(CurrentController, transform);
            }
           

        }
        
    }

}
