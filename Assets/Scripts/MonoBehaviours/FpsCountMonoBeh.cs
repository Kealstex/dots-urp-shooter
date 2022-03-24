using System;
using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class FpsCountMonoBeh : MonoBehaviour
    {
        public Text fpsTextArea;
        private float timer = 0f;
        private float limitTimer = 2f;
        private void Update()
        {
            
            if (timer < limitTimer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                UpdateTextArea();
                timer = 0;
            }
        }

        private int GetCountFPS()
        {
            var deltaTime = Time.deltaTime;
            return (int) (1 / deltaTime);
        }

        private void UpdateTextArea()
        {
            fpsTextArea.text = GetCountFPS().ToString();
        }
    }
}