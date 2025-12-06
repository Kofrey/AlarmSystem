using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Sensor _sensor;
    [SerializeField] private Speaker _speaker;

    private void OnEnable()
    {
        _sensor.Activated += OnSensorActivated;
    }

    private void OnDisable() 
    {
        _sensor.Activated -= OnSensorActivated;
    }

    private void OnSensorActivated(bool _isSensorActivated)
    {
        if(_isSensorActivated)
        {
            _speaker.gameObject.SetActive(true);
            _speaker.Activate();
        }
        else
        {
            _speaker.Deactivate();
        }
    }
}
