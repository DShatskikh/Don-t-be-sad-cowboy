using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Game
{
    public class PPEffectManager : MonoBehaviour
    {
        [SerializeField]
        private VolumeProfile _timeStopProfile;

        private ColorAdjustments _timeStopParameter;

        private void Start()
        {
            if (_timeStopProfile.TryGet(out ColorAdjustments colorAdjustments)) 
                _timeStopParameter = colorAdjustments;
        }

        public void PlayTimeStop()
        {
            _timeStopParameter.saturation.value = -100;
        }
        
        public void StopTimeStop()
        {
            _timeStopParameter.saturation.value = 0;
        }
    }
}