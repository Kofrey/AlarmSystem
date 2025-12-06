using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5.5f;
    [SerializeField] private Rigidbody _rigidbody;
    
    private string _horizontalAxisName = "Horizontal";
    private string _verticalAxisName = "Vertical";
    private Vector3 _moveVector;

    private void Update()
    {
        _moveVector.z = Input.GetAxis(_horizontalAxisName);
        _moveVector.x = Input.GetAxis(_verticalAxisName);
        _rigidbody.MovePosition(_rigidbody.position + _moveVector * _speed * Time.deltaTime);
    }
}
