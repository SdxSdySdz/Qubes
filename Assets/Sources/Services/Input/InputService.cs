using System;
using UnityEngine;
using UnityEngine.Events;

namespace Sources.Services.Input
{
    public class InputService : MonoBehaviour
    {

        public bool IsMouseButtonHeld => UnityEngine.Input.GetMouseButton(0);
        
        public event UnityAction MouseButtonUp; 
        public event UnityAction MouseButtonDown;

        

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonUp(0))
                MouseButtonUp?.Invoke();
            
            if (UnityEngine.Input.GetMouseButtonDown(0))
                MouseButtonDown?.Invoke();
        }

        
        
        /*private Vector2 GetAxes()
        {
            float maxLength = Screen.height / 2f;
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 mousePosition = UnityEngine.Input.mousePosition;
            Vector2 axes = mousePosition - screenCenter;
            
            if (axes.magnitude > maxLength)
                axes.Normalize();
            else
                axes /= maxLength;

            return axes;
        }*/
    }
}
