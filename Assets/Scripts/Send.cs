using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class Send : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public int index;
    private getRadians rads;
    private float[] targetVal;
    private UTF8Encoding utf8 = new UTF8Encoding();
    
  

    // Start is called before the first frame update
    void Start()
    {
        rads = GameObject.Find("Joint Monitor").GetComponent<getRadians>();
        targetVal = rads.returnrot();
    }
    
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
            GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + targetVal[0]/*0.00349066*/ + "," + targetVal[1] + "," + targetVal[2]
                                                                            + "," + targetVal[3] + "," + targetVal[4] + "," + targetVal[5] + "], a =" + "2" + ", v =" + "2" + ")" + "\n";
            GlobalVariables_TCP_IP_client.command = utf8.GetBytes(GlobalVariables_TCP_IP_client.aux_command_str);
            GlobalVariables_TCP_IP_client.button_pressed[1] = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {

        GlobalVariables_TCP_IP_client.button_pressed[1] = false;
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

    
  

