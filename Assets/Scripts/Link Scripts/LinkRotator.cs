using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class LinkRotator
{
    public static List<double> joints = new List<double>();

  
    public static void setJointPos(List<double> pos)
    {
        joints = pos;
    }
}
