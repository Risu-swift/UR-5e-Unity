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
        private buttonControllerLeft[] LB;
        [InspectorReadOnly(hideInEditMode: true)]
        public string selectedJoint;
        //[HideInInspector]
        public int selectedIndex;
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
        void Start()
        {
            previousIndex = selectedIndex = 1;
            this.gameObject.AddComponent<FKRobot>();
            articulationChain = this.GetComponentsInChildren<ArticulationBody>();
            LB = GameObject.Find("User Interface").GetComponentsInChildren<buttonControllerLeft>();
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
            
        }
        void Update()
        {
            
            foreach(buttonControllerLeft l in LB)
            {
                if (l.isPressed == true)
                {

                    selectedIndex = l.index;
                    Debug.LogWarning("Instance is " + l.index);
                    
                    if (l.gameObject.name == "Left_Button")
                    {
                        moveDirection = -1;
                    }
                    else
                    {
                        moveDirection = 1;
                    }
                    
                }
                
            }
            
            UpdateDirection(selectedIndex);
            Highlight(selectedIndex);
        }
        public void Highlight(int selectedIndex)
        {
           

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

        
        public void UpdateDirection(int jointIndex)
        { 
            
            JointControl current = articulationChain[jointIndex].GetComponent<JointControl>();

            

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
        }
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
