using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RosSharp.Urdf
{
    public class WhichButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        
        }
    }
}
