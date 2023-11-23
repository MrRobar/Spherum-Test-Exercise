using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actions;
    [SerializeField] private string _mapName, _moveActionsName;
    [SerializeField] private float _speed = 3f;
    private InputAction _moveAction;
    private Vector2 _moveVector;
    private Vector3 _resVector;

    public event Action OnMove;

    private void Awake()
    {
        _moveAction = _actions.FindActionMap(_mapName).FindAction(_moveActionsName);
        _resVector = new Vector3();
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveVector = _moveAction.ReadValue<Vector2>();
        _resVector.x = _moveVector.x;
        _resVector.z = _moveVector.y;
        transform.Translate(_resVector * (Time.deltaTime * _speed));
        if (_resVector != Vector3.zero)
        {
            OnMove?.Invoke();
        }
    }
}