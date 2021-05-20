using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


namespace RosSharp.Control
{
    public enum RotationDirection { None = 0, Positive = 1, Negative = -1 };
    public enum ControlType { PositionControl };

    public class Controller : MonoBehaviour
    {
        public ArticulationBody[] articulationChain;
   
        // Stores original colors of the part being highlighted
        private Color[] prevColor;
        private int previousIndex;
        private JointControl current;
        public MouseHoldRight[] mouseClickR;
        public MouseHoldLeft[] mouseClickL;

        [InspectorReadOnly(hideInEditMode: true)]
        public string selectedJoint;
        //[HideInInspector]
        public  int selectedIndex;

        public ControlType control = ControlType.PositionControl;
        public float stiffness;
        public float damping;
        public float forceLimit;
        public float speed = 5f; // Units: degree/s
        public float torque = 100f; // Units: Nm or N
        public float acceleration = 5f;// Units: m/s^2 / degree/s^2
        public float moveDirection;
        public GameObject currentJoint;
        public Vector3[] alljoints;
      

        [Tooltip("Color to highlight the currently selected join")]
        public Color highLightColor = new Color(255, 0, 0, 255);
       // private List<float> target;
        // public MouseHold shoulder_link=GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).GetComponent<MouseHold>();

        void Start()
        {
            previousIndex = selectedIndex = 1;
            this.gameObject.AddComponent<FKRobot>();
            articulationChain = this.GetComponentsInChildren<ArticulationBody>();
            int defDyanmicVal = 10;
            foreach (ArticulationBody joint in articulationChain)
            {
                joint.gameObject.AddComponent<JointControl>();
                joint.jointFriction = defDyanmicVal;
                joint.angularDamping = defDyanmicVal;
                ArticulationDrive currentDrive = joint.xDrive;
                currentDrive.forceLimit = forceLimit;
                joint.xDrive = currentDrive;
            }
            DisplaySelectedJoint(selectedIndex);
            // StoreJointColors(selectedIndex);
            /*for (int i = 0; i <= 5; i++)
            {
                mouseClickR[i] = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(i).transform.GetChild(3).GetComponent<MouseHoldRight>();
                *//*mouseClickR[0] = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(0).GetComponent<MouseHoldRight>();
               mouseClickR[1] = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(1).GetComponent<MouseHoldRight>();
                   mouseClickR[2] = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(2).GetComponent<MouseHoldRight>();
                   mouseClickR[3] = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(3).GetComponent<MouseHoldRight>();
                   mouseClickR[4] = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(4).GetComponent<MouseHoldRight>();
                   mouseClickR[5] = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(0).GetComponent<MouseHoldRight>();*//*
                //}


            }*/
            /*for (int i = 0; i <= 5; i++)
            {
                mouseClickL[i] = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(i).transform.GetChild(4).GetComponent<MouseHoldLeft>();
            }*/
        }

        void Update()
        {
            if(mouseClickR[0].pointerDown)
            {
                Debug.Log("ShoulderLinKRightMove");
               selectedIndex = 2;
                moveDirection = -1;
            }
            if (mouseClickL[0].pointerDown)
            {
                Debug.Log("ShoulderLinKLeftMove");
                selectedIndex = 2;
                moveDirection = 1;
            }
            if (mouseClickR[1].pointerDown)
            {
                selectedIndex = 3;
                moveDirection = -1;
            }
            if (mouseClickL[1].pointerDown)
            {
                selectedIndex = 3;
                moveDirection = 1;
            }
            if (mouseClickR[2].pointerDown)
            {
                selectedIndex = 4;
                moveDirection = -1;
            }
            if (mouseClickL[2].pointerDown)
            {
                selectedIndex = 4;
                moveDirection = 1;
            }
            if (mouseClickR[3].pointerDown)
            {
                selectedIndex = 5;
                moveDirection = -1;
            }
            if (mouseClickL[3].pointerDown)
            {
                selectedIndex = 5;
                moveDirection = 1;
            }
            
            if (mouseClickR[4].pointerDown)
            {
                selectedIndex = 6;
                moveDirection = -1;
            }
            if (mouseClickL[4].pointerDown)
            {
                selectedIndex = 6;
                moveDirection = 1;
            }
            if (mouseClickR[5].pointerDown)
            {
                Debug.Log("Wrist3_link");
                selectedIndex = 7;
                moveDirection = -1;
            }
            if (mouseClickL[5].pointerDown)
            {
                Debug.Log("Wrist3_link");
                selectedIndex = 7;
                moveDirection = 1;
            }
            /*Debug.Log("Position of objec"+articulationChain[2].transform.position);
            int l = 0;
            for(int g=2;g<=7;g++)
            {
               
                alljoints[l]= articulationChain[g].transform.position;
                
                l++;

            }
            jointValueMonitor.getvalues(alljoints);
*/


            UpdateDirection(selectedIndex);
            /*bool SelectionInput1 = Input.GetButtonDown("Base");
            bool SelectionInput2 = Input.GetButtonDown("Shoulder");

            UpdateDirection(selectedIndex);

            if (SelectionInput2)
            {
                if (selectedIndex == 1)
                {
                    selectedIndex = articulationChain.Length - 1;
                }
                else
                {
                    selectedIndex = selectedIndex - 1;
                }
                Highlight(selectedIndex);
            }
            else if (SelectionInput1)
            {
                if (selectedIndex == articulationChain.Length - 1)
                {
                    selectedIndex = 1;
                }
                else
                {
                    selectedIndex = selectedIndex + 1;
                }
                Highlight(selectedIndex);
            }

            UpdateDirection(selectedIndex);*/
            Highlight(selectedIndex);
           // Debug.Log("Joint Target for Shoulder is "+articulationChain[2].GetDriveTargets(target));*/

        }

        /// <summary>
        /// Highlights the color of the robot by changing the color of the part to a color set by the user in the inspector window
        /// </summary>
        /// <param name="selectedIndex">Index of the link selected in the Articulation Chain</param>
        public void Highlight(int selectedIndex)
        {
           /* if (selectedIndex == previousIndex)
            {
                return;
            }*/

            // reset colors for the previously selected joint
           // ResetJointColors(previousIndex);

            // store colors for the current selected joint
            //StoreJointColors(selectedIndex);

            DisplaySelectedJoint(selectedIndex);
            Renderer[] rendererList = articulationChain[selectedIndex].transform.GetChild(0).GetComponentsInChildren<Renderer>();

            // set the color of the selected join meshes to the highlight color
            foreach (var mesh in rendererList)
            {
                if (IsHDR())
                {
                    mesh.material.SetColor("_BaseColor", highLightColor);
                }
                else
                {
                    mesh.material.color = highLightColor;
                }
            }
        }

        void DisplaySelectedJoint(int selectedIndex)
        {
            selectedJoint = articulationChain[selectedIndex].name + " (" + selectedIndex + ")";
        }

        /// <summary>
        /// Sets the direction of movement of the joint on every update
        /// </summary>
        /// <param name="jointIndex">Index of the link selected in the Articulation Chain</param>
        public void UpdateDirection(int jointIndex)
        {
            /*GameObject currentJoint = articulationChain[jointIndex].gameObject;
           Vector3 currentJointangles = currentJoint.transform.localEulerAngles;*/
           // Debug.LogWarning(currentJointangles);
          //  Vector3 current_angle = currentJointangles.localEulerAngles;
            
            
             
           // GetJointAngles(currentJoint,currentJointangles);
            
            
            
           /* float moveDirection = Input.GetAxisRaw("Elbow");
           //  moveDirection = Input.GetAxisRaw("left");
                moveDirection = Input.GetAxisRaw("Horizontal");*/
            ;
            JointControl current = articulationChain[jointIndex].GetComponent<JointControl>();
           // Debug.Log("The joint target is"+current.joint.GetDriveTargets(target));

            /*if (previousIndex != jointIndex)
            {
                JointControl previous = articulationChain[previousIndex].GetComponent<JointControl>();
                previous.direction = RotationDirection.None;
                previousIndex = jointIndex;
            }*/

            if (current.controltype != control)
                UpdateControlType(current);

            if (moveDirection > 0)
            {
                current.direction = RotationDirection.Positive;
            }
            else if (moveDirection < 0)
            {
                current.direction = RotationDirection.Negative;
            }
            else
            {
                current.direction = RotationDirection.None;
            }

            //  returnCurrentJoint(currentJoint);
            
            
        }
       /* private void GetJointAngles(GameObject currentJoint, Vector3 current_angle)
        {
           
         

            Debug.Log(currentJoint.name + " " + current_angle) ;
        }*/
      
 
        /// <summary>
        /// Stores original color of the part being highlighted
        /// </summary>
        /// <param name="index">Index of the part in the Articulation chain</param>
       /* private void StoreJointColors(int index)
        {
            Renderer[] materialLists = articulationChain[index].transform.GetChild(0).GetComponentsInChildren<Renderer>();
            prevColor = new Color[materialLists.Length];
            for (int counter = 0; counter < materialLists.Length; counter++)
            {
                if (IsHDR())
                {
                    prevColor[counter] = materialLists[counter].material.GetColor("_BaseColor");
                }
                else
                {
                    prevColor[counter] = materialLists[counter].sharedMaterial.GetColor("_Color");
                }
            }
        }*/

        /// <summary>
        /// Resets original color of the part being highlighted
        /// </summary>
        /// <param name="index">Index of the part in the Articulation chain</param>
       /* private void ResetJointColors(int index)
        {
            Renderer[] previousRendererList = articulationChain[index].transform.GetChild(0).GetComponentsInChildren<Renderer>();
            for (int counter = 0; counter < previousRendererList.Length; counter++)
            {
                if (IsHDR())
                {
                    previousRendererList[counter].material.SetColor("_BaseColor", prevColor[counter]);
                }
                else
                {
                    previousRendererList[counter].material.color = prevColor[counter];
                }
            }
        }*/
       

        public void UpdateControlType(JointControl joint)
        {
            joint.controltype = control;
            if (control == ControlType.PositionControl)
            {
                ArticulationDrive drive = joint.joint.xDrive;
                drive.stiffness = stiffness;
                drive.damping = damping;
                joint.joint.xDrive = drive;
              
            }
        }

        /// Checks if current render pipeline is HDR 
        /// Used for setting the color of highlighted joint
        private bool IsHDR()
        {
            //TODO: should we also return true for Universal Render pipeline?
            return GraphicsSettings.renderPipelineAsset != null && GraphicsSettings.renderPipelineAsset.GetType().ToString().Contains("HighDefinition");
        }

        public void OnGUI()
        {
            GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(Screen.width / 2 - 200, 10, 400, 20), "Press left/right arrow keys to select a robot joint.", centeredStyle);
            GUI.Label(new Rect(Screen.width / 2 - 200, 30, 400, 20), "Press up/down arrow keys to move " + selectedJoint + ".", centeredStyle);
        }
    }

    
}
