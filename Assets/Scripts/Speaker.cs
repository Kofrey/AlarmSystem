using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Speaker : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _volumeChangeSpeed = 0.25f;
    [SerializeField] private float _maxVolume = 1f;

    private Coroutine _coroutine;

    public void Activation()
    {
        _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void Deactivation()
    {
        StopCoroutine(_coroutine);
        StartCoroutine(ChangeVolume(0f));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        bool isActive = true;

        while (isActive)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);

            if(_alarmSound.volume == 0f)
                isActive = false;

            yield return null;
        }

        this.gameObject.SetActive(false);
    }
}
