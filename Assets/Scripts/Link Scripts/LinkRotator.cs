using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LinkRotator : MonoBehaviour
{
    public List<double> joints = new List<double>();

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            joints.Add(0);    
        }
        
    }
    public void setJointPos(List<double> pos)
    {
        joints = pos;
    }
}
