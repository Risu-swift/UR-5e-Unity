using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.Control;
using UnityEngine.UI;


public class change : MonoBehaviour
{
    public Toggle _Toggle;
    private ur3_link1[] _link1;
    
    private void Start()
    {
        _Toggle.onValueChanged.AddListener((value => check(_Toggle.isOn)));
        _link1 = GetComponentsInChildren<ur3_link1>();
    }
    

    private void check(bool val)
    {
        foreach (var links in _link1)
        {
            if(val)
            {
                links.enabled = true;
            }
            else
            {
                links.enabled = false;

            }
            
        }
        
    }

    
}
