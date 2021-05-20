// ------------------------------------------------------------------------------------------------------------------------ //
// ----------------------------------------------------- LIBRARIES -------------------------------------------------------- //
// ------------------------------------------------------------------------------------------------------------------------ //

// -------------------- System -------------------- //
using System.Text;
// -------------------- Unity -------------------- //
using UnityEngine.EventSystems;
using UnityEngine;

public class SendJointValues : MonoBehaviour// IPointerDownHandler, IPointerUpHandler
{
    // -------------------- String -------------------- //
    public string acceleration = "0.15";
    public string time = "0.03";
    public string[] speed_param = new string[6] { "0.0", "0.0", "0.0", "0.0", "0.0", "0.0" };
    private float[] rads;
    private getRadians rad;
    // -------------------- Int -------------------- //
    public int index;
    // -------------------- UTF8Encoding -------------------- //
    private UTF8Encoding utf8 = new UTF8Encoding();

    void Start()
    {
        rad = this.gameObject.GetComponent<getRadians>();
        rads = rad.returnrot();
    }



    // -------------------- Button -> Pressed -------------------- //
    /*public void OnPointerDown(PointerEventData eventData)
    {
        //create auxiliary command string for speed control UR robot
        GlobalVariables_TCP_IP_client.aux_command_str = "movel([" + speed_param[0] + "," + speed_param[1] + "," + speed_param[2]
                                                                   + "," + speed_param[3] + "," + speed_param[4] + "," + speed_param[5] + "], a =" + acceleration + ", t =" + time + ")" + "\n";
    }

    // -------------------- Button -> Un-Pressed -------------------- //
    public void OnPointerUp(PointerEventData eventData)
    {
        // confirmation variable -> is un-pressed
        GlobalVariables_TCP_IP_client.button_pressed[index] = false;
    }*/
    public void Sendjointvalue()
    {
        //create auxiliary command string for speed control UR robot
        GlobalVariables_TCP_IP_client.aux_command_str = "movej([" + rads[0] + "," + rads[1] + "," + rads[2]
                                                                   + "," + rads[3] + "," + rads[4] + "," + rads[5] + "], a =" + "5" + ", v =" + "5" + ")" + "\n";
        GlobalVariables_TCP_IP_client.command = utf8.GetBytes(GlobalVariables_TCP_IP_client.aux_command_str);
        GlobalVariables_TCP_IP_client.button_pressed[index] = true;
    }

}
