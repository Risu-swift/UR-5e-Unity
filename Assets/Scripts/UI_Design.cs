using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Design : MonoBehaviour
{
    //---------------------UI Fields---------------------------------//
    [FormerlySerializedAs("AutoModePanel")] [SerializeField] private GameObject autoModePanel;
    [SerializeField] private TMP_Text currentMode;
    [SerializeField] private TMP_InputField ipAddrText;
    [SerializeField] private TMP_Text connectionStatus;
    [SerializeField] private GameObject freeHandPanel;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentMode.text = "FreeHand";
            GlobalVariables_Main_Control.isAuto = false;
        }
        else if(Input.GetKeyDown(KeyCode.G))
        {
            currentMode.text = "Auto";
            GlobalVariables_Main_Control.isAuto = true;
        }
        
        if (Input.GetKeyDown(KeyCode.K) && !isConnected)
        {
            _uiControl.TaskOnClick_ConnectBTN(ipAddrText.text);
            connectionStatus.color = Color.green;
            connectionStatus.text = "Connected";
            isConnected = true;
        }
        else if(Input.GetKeyDown(KeyCode.L) && isConnected)
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
            if (Input.GetKeyDown(KeyCode.S))
            {
                _uiControl.TaskOnClick_SendScript();
                Debug.Log("Linear Mode");
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                _uiControl.TaskOnClick_SendScript();
                Debug.Log("Curved Mode");
            }
            else if(Input.GetKeyDown(KeyCode.D))
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
