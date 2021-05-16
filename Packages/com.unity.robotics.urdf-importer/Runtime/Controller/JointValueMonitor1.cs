using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RosSharp.Control
{
    public class JointValueMonitor1 : MonoBehaviour
    {
        public Controller Controller;
        [SerializeField] private Text[] pos_Values;
        [SerializeField] private Text[] rot_Values;
        [SerializeField] private GameObject[] Joints;
        private Vector3[] positions;


        private int i, j = 0;
        private bool run;
        // Start is called before the first frame update
        void Start()
        {

           


        }

        // Update is called once per frame
        void Update()
        {
            for (i = 0; i <= 5; i++)
            {
               // positions[i] = Joints[i].transform.localPosition;
                pos_Values[i].text = Joints[i].transform.position.ToString();
                rot_Values[i].text = Joints[i].transform.eulerAngles.ToString();
            }
        }
        
    }
}
