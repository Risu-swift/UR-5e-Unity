using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class realtimeControl : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public int index;
    private getRadians rads;
    private float[] targetVal;
    private UTF8Encoding utf8 = new UTF8Encoding();
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        rads = GameObject.Find("Joint Monitor").GetComponent<getRadians>();
        targetVal = rads.returnrot();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GlobalVariables_TCP_IP_client.button_pressed[index] = false;
        isPressed = false;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {

        isPressed = true;
    }
    private void FixedUpdate()
    {
        if(isPressed)
        {
            /*if (index == 1)
            {
                GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + targetVal[0]*//*0.00349066*//* + "," + targetVal[1] + "," + targetVal[2]
                                                                            + "," + targetVal[3] + "," + targetVal[4] + "," + targetVal[5] + "], a =" + "5" + ", v =" + "5" + ")" + "\n";
            }
            if (index == 2)
            {
                GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + targetVal[0] + "," + targetVal[1] + "," + targetVal[2]
                                                                            + "," + targetVal[3] + "," + targetVal[4] + "," + targetVal[5] + "], a =" + "5" + ", v =" + "5" + ")" + "\n";
            }
            if (index == 3)
            {
                GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + targetVal[0] + "," + targetVal[1] + "," + targetVal[2]
                                                                            + "," + targetVal[3] + "," + targetVal[4] + "," + targetVal[5] + "], a =" + "5" + ", v =" + "5" + ")" + "\n";
            }
            if (index == 4)
            {
                GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + targetVal[0] + "," + targetVal[1] + "," + targetVal[2]
                                                                            + "," + targetVal[3] + "," + targetVal[4] + "," + targetVal[5] + "], a =" + "5" + ", v =" + "5" + ")" + "\n";
            }
            if (index == 5)
            {
                GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + targetVal[0] + "," + targetVal[1] + "," + targetVal[2]
                                                                            + "," + targetVal[3] + "," + targetVal[4] + "," + targetVal[5] + "], a =" + "5" + ", v =" + "5" + ")" + "\n";
            }
            if (index == 6)
            {
                GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + targetVal[0] + "," + targetVal[1] + "," + targetVal[2]
                                                                            + "," + targetVal[3] + "," + targetVal[4] + "," + targetVal[5] + "], a =" + "5" + ", v =" + "5" + ")" + "\n";
            }*/

            GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + targetVal[0]/*0.00349066*/ + "," + targetVal[1] + "," + targetVal[2]
                                                                            + "," + targetVal[3] + "," + targetVal[4] + "," + targetVal[5] + "], a =" + "5" + ", v =" + "5" + ")" + "\n";
            GlobalVariables_TCP_IP_client.command = utf8.GetBytes(GlobalVariables_TCP_IP_client.aux_command_str);
            GlobalVariables_TCP_IP_client.button_pressed[index] = true;
        }

    }
    }

