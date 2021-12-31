using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR;

public class UI_Design : MonoBehaviour
{
    //---------------------UI Fields---------------------------------//
    [FormerlySerializedAs("AutoModePanel")] [SerializeField] private GameObject autoModePanel;
    [SerializeField] private TMP_Text currentMode;
    [SerializeField] private TMP_InputField ipAddrText;
    [SerializeField] private TMP_Text connectionStatus;
    [SerializeField] private GameObject freeHandPanel;
    public GameObject LController;
    public GameObject RController;
    private InputDevice LeftController;
    private InputDevice RightController;

    //---------------------MainUIControl Script Object----------------//
    [SerializeField] private UI_Control _uiControl;
    
    //---------------------Bool to check values-----------------------//
    private bool isConnected = false;
    private void Start()
    {
        currentMode.text = "Auto";
        GlobalVariables_Main_Control.isAuto = true;
        autoModePanel.SetActive(true);
        freeHandPanel.SetActive(false);
        LeftController = LController.GetComponent<XRControllers>().TargetDevice;
        RightController = RController.GetComponent<XRControllers>().TargetDevice;
    }

    private void Update()
    {
        bool LXPressed,LYPressed,LGripPressed;
        bool RAPressed,RBPressed,RGripPressed;
        LeftController.TryGetFeatureValue(CommonUsages.primaryButton, out LXPressed);
        LeftController.TryGetFeatureValue(CommonUsages.secondaryButton, out LYPressed);
        LeftController.TryGetFeatureValue(CommonUsages.gripButton, out LGripPressed);
        RightController.TryGetFeatureValue(CommonUsages.primaryButton, out RAPressed);
        RightController.TryGetFeatureValue(CommonUsages.secondaryButton, out RBPressed);
        RightController.TryGetFeatureValue(CommonUsages.gripButton, out RGripPressed);

        if (Input.GetKeyDown(KeyCode.F)||LGripPressed)
        {
            currentMode.text = "FreeHand";
            GlobalVariables_Main_Control.isAuto = false;
        }
        else if(Input.GetKeyDown(KeyCode.G)||LYPressed)
        {
            currentMode.text = "Auto";
            GlobalVariables_Main_Control.isAuto = true;
        }
        
        if (Input.GetKeyDown(KeyCode.K) && !isConnected||(LXPressed&& !isConnected))
        {
            _uiControl.TaskOnClick_ConnectBTN(ipAddrText.text);
            connectionStatus.color = Color.green;
            connectionStatus.text = "Connected";
            isConnected = true;
        }
        else if((Input.GetKeyDown(KeyCode.K)&&isConnected) || (isConnected&&LXPressed))
        {
            _uiControl.TaskOnClick_DisconnectBTN();
            connectionStatus.color = Color.red;
            connectionStatus.text = "Disconnected";
            isConnected = false;
        }
        
        if (GlobalVariables_Main_Control.isAuto && isConnected)
        {
            freeHandPanel.SetActive(!GlobalVariables_Main_Control.isAuto);
            autoModePanel.SetActive(GlobalVariables_Main_Control.isAuto);
            if (Input.GetKeyDown(KeyCode.S)||RGripPressed)
            {
                _uiControl.TaskOnClick_SendScript();
                Debug.Log("Linear Mode");
            }
            else if(Input.GetKeyDown(KeyCode.A)||RAPressed)
            {
                _uiControl.TaskOnClick_SendScript();
                Debug.Log("Curved Mode");
            }
            else if(Input.GetKeyDown(KeyCode.D)||RBPressed)
            {
                _uiControl.TaskOnClick_SendScript();
                Debug.Log("Hybrid Mode");
            }
            
                
        }
        else if(!GlobalVariables_Main_Control.isAuto)
        {
            freeHandPanel.SetActive(!GlobalVariables_Main_Control.isAuto);
            autoModePanel.SetActive(GlobalVariables_Main_Control.isAuto);

            if (Input.GetKeyDown(KeyCode.S))
            {
                _uiControl.TaskOnClick_FreeHand();
            }
        }

 
       
        
    }
}
