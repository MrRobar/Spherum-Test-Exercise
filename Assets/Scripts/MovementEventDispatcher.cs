using System;
using UnityEngine;

public class MovementEventDispatcher : MonoBehaviour
{
    [SerializeField] private Movement[] _players = new Movement[2];

    public event Action<float> OnMove;

    private void Awake()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            Subscribe(_players[i]);
        }
    }

    private void Subscribe(Movement movement)
    {
        movement.OnMove += HandleMove;
    }

    private void HandleMove()
    {
        OnMove?.Invoke(Vector3.Distance(_players[0].transform.position, _players[1].transform.position));
    }
}