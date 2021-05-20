using UnityEngine;
public class getRadians : MonoBehaviour
{
    // public GameObject[] joints=new GameObject[6];
    public float[] rotval;
    private ArticulationBody[] joints;
     // Start is called before the first frame update
    void Start()
    {
        joints = GameObject.Find("UR5").GetComponentsInChildren<ArticulationBody>();
    }
   

    // Update is called once per frame
    void Update()
    {
        rotval[0] = (float)(joints[2].xDrive.target) * (Mathf.PI /180);
        rotval[1] = (float)(joints[3].xDrive.target) * (Mathf.PI / 180);
        rotval[2] = (float)(joints[4].xDrive.target) * (Mathf.PI / 180);
        rotval[3] = (float)(joints[5].xDrive.target) * (Mathf.PI / 180);
        rotval[4] = (float)(joints[6].xDrive.target) * (Mathf.PI / 180);
        rotval[5] = (float)(joints[7].xDrive.target) * (Mathf.PI / 180);
        /*for (int i = 0; i <= 5; i++)
        {
            Debug.Log(rotval[i]);
    }*/
        
    }
    public float[] returnrot()
    {
        return rotval;
    }
}
