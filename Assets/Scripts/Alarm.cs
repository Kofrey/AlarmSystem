using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _volumeFactor = 0.25f;

    private float _maxVolume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        _volumeFactor = 0.25f;
        StartCoroutine(ChangeVolume());
    }

    private void OnTriggerExit(Collider other)
    {
        _volumeFactor = -0.25f;
    }

    private IEnumerator ChangeVolume()
    {
        while (enabled)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _maxVolume, _volumeFactor * Time.deltaTime);

            if(_alarmSound.volume == 0f)
                break;

            yield return null;
        }
    }
}
