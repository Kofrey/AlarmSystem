using System;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public event Action<bool> Activated;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Mover>(out Mover mover))
            Activated?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Mover>(out Mover mover))
            Activated?.Invoke(false);
    }
}
