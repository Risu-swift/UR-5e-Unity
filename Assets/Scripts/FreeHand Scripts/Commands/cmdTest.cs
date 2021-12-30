using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cmdTest : MonoBehaviour
{
    [SerializeField]private InputField _inputField;
    public MultiCmd MultiCmd;
    public float waitTime = 0.16f;
    public TextAsset plan1;
    public TextAsset plan2;
    public TextAsset plan3;

    private String HomePos = "movej([0,0,0,0,0,0],a = 0.15,v = 0.15,r = 0.01)";
    /// <summary>
    /// Test function to test if the command parsing works
    /// </summary>
    public void testcmd()
    {
        MultiCmd.MultiParse(_inputField.text,waitTime);
       // List<double> joints = CommandParse.CmdParse(_inputField.text,out Dictionary<char,float> parameterDictionary);
      /*  foreach (var ctx in parameterDictionary)
        {
            Debug.Log(ctx.Key +  " " + ctx.Value);
        }
        if (joints == null)
        {
            Debug.Log("Error in provided Command String");
        }
        foreach (var VARIABLE in joints)
        {
            Debug.Log("Joints :" + VARIABLE);
        }
        */
    }
    
    public void plana()
    {
        MultiCmd.MultiParse(plan1.text,waitTime);
    }

    public void homePos()
    {
        MultiCmd.MultiParse(HomePos,waitTime);
    }
    
    
    public void planb()
    {
        MultiCmd.MultiParse(plan2.text,waitTime);
    }

    public void planc()
    {
        MultiCmd.MultiParse(plan3.text,waitTime);
    }
    
}
