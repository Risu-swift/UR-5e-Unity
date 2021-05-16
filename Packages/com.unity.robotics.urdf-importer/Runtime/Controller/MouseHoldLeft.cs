using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Rendering;

namespace RosSharp.Control
{
    public class MouseHoldLeft : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public RosSharp.Control.Controller Controller;
        public bool pointerDown;
        public void Start()
        {
            Controller = GameObject.Find("UR5").transform.GetChild(0).GetComponent<Controller>();
        }
        public void OnPointerDown(PointerEventData pointereventData)
        {
            //pointerDown = true;

            if (this.gameObject.transform.parent.name == "Shoulder_link")
            {
                //Controller.selectedIndex = 2;
                pointerDown = true;
            }

            if (this.gameObject.transform.parent.name == "Upper_arm_link")
            {
                //Controller.selectedIndex = 3;
                pointerDown = true;
            }
            if (this.gameObject.transform.parent.name == "forarm_link")
            {
                // Controller.selectedIndex = 4;
                pointerDown = true;
            }
            if (this.gameObject.transform.parent.name == "wrist1_link")
            {
                // Controller.selectedIndex = 5;
                pointerDown = true;
            }
            if (this.gameObject.transform.parent.name == "wrist2_link")
            {
                // Controller.selectedIndex = 6;
                pointerDown = true;
            }
            if (this.gameObject.transform.parent.name == "wrist3_link")
            {
                // Controller.selectedIndex = 7;
                pointerDown = true;
            }

        }

        public void OnPointerUp(PointerEventData pointereventData)
        {
           // pointerDown = false;
            if (this.gameObject.transform.parent.name == "Shoulder_link")
            {
                // Controller.selectedIndex = 2;
                pointerDown = false;
                Controller.moveDirection = 0;
                Debug.Log("ShoulderlinkPointerUP");
            }
            if (this.gameObject.transform.parent.name == "Upper_arm_link")
            {
                //Controller.selectedIndex = 3;
                pointerDown = false;
                Controller.moveDirection = 0;
                Debug.Log("UpperArmLinkPointerUP");
            }
            if (this.gameObject.transform.parent.name == "forarm_link")
            {
                // Controller.selectedIndex = 4;
                pointerDown = false;
                Controller.moveDirection = 0;
            }
            if (this.gameObject.transform.parent.name == "wrist1_link")
            {
                // Controller.selectedIndex = 5;
                pointerDown = false;
                Controller.moveDirection = 0;
            }
            if (this.gameObject.transform.parent.name == "wrist2_link")
            {
                //Controller.selectedIndex = 6;
                pointerDown = false;
                Controller.moveDirection = 0;
            }
            if (this.gameObject.transform.parent.name == "wrist3_link")
            {
                //Controller.selectedIndex = 7;
                pointerDown = false;
                Controller.moveDirection = 0;
            }
        }



    }
}
