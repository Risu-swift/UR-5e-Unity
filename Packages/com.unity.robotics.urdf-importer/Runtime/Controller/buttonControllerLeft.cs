using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace RosSharp.Control
{
    public class buttonControllerLeft : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public bool isPressed;
        public int index;
        public Controller controller;
        private void Start()
        {
            controller = GameObject.FindGameObjectWithTag("robot").GetComponent<Controller>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
            controller.moveDirection = 0;
        }


    }
}