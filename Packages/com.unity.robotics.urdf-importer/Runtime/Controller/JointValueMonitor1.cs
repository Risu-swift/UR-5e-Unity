using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RosSharp.Control
{
    public class JointValueMonitor1 : MonoBehaviour
    {
        public Controller Controller;
        
        [SerializeField] private Text[] rot_Values;
        
       
        private ArticulationBody[] chain;


       
        // Start is called before the first frame update
        void Start()
        {
            chain = GameObject.Find("UR5").GetComponentsInChildren<ArticulationBody>();
            Debug.LogWarning("chain len"+chain.Length);
           


        }

        // Update is called once per frame
        void Update()
        {
            
            rot_Values[0].text = System.Math.Round(chain[2].xDrive.target,2).ToString();
            rot_Values[1].text = System.Math.Round(chain[3].xDrive.target,2).ToString();
            rot_Values[2].text = System.Math.Round(chain[4].xDrive.target,2).ToString();
            rot_Values[3].text = System.Math.Round(chain[5].xDrive.target,2).ToString();
            rot_Values[4].text = System.Math.Round(chain[6].xDrive.target,2).ToString();
            rot_Values[5].text = System.Math.Round(chain[7].xDrive.target,2).ToString();
            

        }
        
    }
}
