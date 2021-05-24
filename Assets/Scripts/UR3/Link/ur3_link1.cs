// ------------------------------------------------------------------------------------------------------------------------//
// ----------------------------------------------------- LIBRARIES --------------------------------------------------------//
// ------------------------------------------------------------------------------------------------------------------------//

// -------------------- Unity -------------------- //
using UnityEngine;

public class ur3_link1 : MonoBehaviour
{
    public ArticulationDrive currentJoint;
    private ArticulationBody chain;
    private void Start()
    {
        chain = this.gameObject.GetComponent<ArticulationBody>();

    }


    void Update()
    {
        //  transform.localEulerAngles = new Vector3(0f, (-1) * GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0], 0f);
        currentJoint = chain.xDrive;
        currentJoint.target = GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0];
        Debug.LogWarning(GlobalVariables_TCP_IP_client.robotBaseRotLink_UR3_j[0]);
        
    }
    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
