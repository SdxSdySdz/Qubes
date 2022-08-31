using System;
using Sources.Services.Input;
using UnityEngine;

namespace Sources
{
    public class TimeSlower : MonoBehaviour
    {
        private float _originFixedDeltaTime;

        private void Awake()
        {
            _originFixedDeltaTime = Time.fixedDeltaTime;
        }

        public void NormalizeTime()
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = _originFixedDeltaTime;
        }

        public void SlowTime()
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}
