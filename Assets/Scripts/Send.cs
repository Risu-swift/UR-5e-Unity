using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Send : MonoBehaviour
{
    public int index;
    private getRadians rads;
    private float[] targetVal;
    private UTF8Encoding utf8 = new UTF8Encoding();
    public TransformRead transformRead;
    List<string> Commands;
    
  

    // Start is called before the first frame update
    void Start()
    {
        Commands = new List<string>();
        
    }
    
    public void SendScript()
    {
        Commands = transformRead.Commands;
        StartCoroutine(Sending());
    }
    private void Finished()
    {

        GlobalVariables_TCP_IP_client.button_pressed[1] = false;
    }
    private IEnumerator Sending()
    {
        if (GlobalVariables_Main_Control.connect)
        {
            foreach(var l in Commands)
            { 
                GlobalVariables_TCP_IP_client.aux_command_str = l + "\n";
                GlobalVariables_TCP_IP_client.command = utf8.GetBytes(GlobalVariables_TCP_IP_client.aux_command_str);
                yield return new WaitForSeconds(0.00016f);
                Debug.Log(GlobalVariables_TCP_IP_client.command);
                GlobalVariables_TCP_IP_client.button_pressed[1] = true;
                
            }
            Finished();
        }
    }
   /* void Update() {
        if(GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0]==0&&GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[1]==0&&
    GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[2]==0&&GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[3]==0
    &&GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[4]==0&&GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[5]==0)
    {
        GlobalVariables_TCP_IP_client.button_pressed[1] = false;

    }
    }*/

}

    
  

