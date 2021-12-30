using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCmd: MonoBehaviour 
{
    public String[] lines;
    //public float waitTime = 5f;
    
    
    
    public void MultiParse(String Cmd,float waitTime)
    {
        lines = Cmd.Split(new string[] {"\r\n", "\n"}, StringSplitOptions.None);
            
        StartCoroutine(WaitAndAnimate(waitTime));

        }
    
     IEnumerator WaitAndAnimate(float waitTime) {
         foreach (var line in lines)
         {   
             Debug.Log(line);
             Dictionary<char, float> param = new Dictionary<char, float>();
             if (line.Contains("movej"))
             {
                 CommandParse.CmdParse(line, out param);
                 yield return new WaitForSeconds(waitTime);
             }
             else if (line != "")
             {
                 Debug.LogWarning("Enter Valid MoveJ Commands");
             }
         }

     }
  
}
