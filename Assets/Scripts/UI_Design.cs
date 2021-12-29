using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Design : MonoBehaviour
{
    [SerializeField]private GameObject AutoModePanel;
    [SerializeField] private TMP_Text currentMode;
    private bool isAutoMode = true;

    private void Start()
    {
        currentMode.text = "Auto";
        isAutoMode = true;
        AutoModePanel.SetActive(true);
    }

    private void Update()
    {
        if (isAutoMode)
        {
            AutoModePanel.SetActive(isAutoMode);
            if (Input.GetKeyDown(KeyCode.S))
            {
                //TODO ADD code for linear mode.
                Debug.Log("Linear Mode");
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                //TODO add code for Curved mode.
                Debug.Log("Curved Mode");
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                //TODO add code for Hybrid Mode.
                Debug.Log("Hybrid Mode");
            }
            
                
        }
        else
        {
            AutoModePanel.SetActive(isAutoMode);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            currentMode.text = "FreeHand";
            isAutoMode = false;
        }
        else if(Input.GetKeyDown(KeyCode.G))
        {
            currentMode.text = "Auto";
            isAutoMode = true;
        }
       
        
    }
}
