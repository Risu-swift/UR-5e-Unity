using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggler : MonoBehaviour
{
    private bool isPressed;
    public Text Text1;
    public Text Text2;

    public ur3_link1[] link;
    public static bool scriptsEnabled;
    // Start is called before the first frame update
    void Start()
    {
        link = this.gameObject.GetComponentsInChildren<ur3_link1>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!scriptsEnabled&&GlobalVariables_Main_Control.connect)
        {
            Text2.text = "State : Unity to URSIM";
        }else if(scriptsEnabled&&!GlobalVariables_Main_Control.connect)
        {
            Text2.text = "Connect to the URSim";
        }else if(!scriptsEnabled&&!GlobalVariables_Main_Control.connect)
        {
            Text2.text = "Only Unity";
        }else if(scriptsEnabled&&GlobalVariables_Main_Control.connect)
        {
            Text2.text="State : URSIM to Unity";
        }
    }
    public void OneWay()
    {
        
        foreach(ur3_link1 l in link)
        {
            isPressed=true;
            if(l.enabled&&isPressed)
            {
               scriptsEnabled=false;
                Text1.text="Switch to URSIM";
                l.enabled = false;
                isPressed = false;
            }
            else{
                scriptsEnabled=true;
                Text1.text="Switch to Unity";
                l.enabled=true;
                 
            }

           
        }
        
        
    }
}
