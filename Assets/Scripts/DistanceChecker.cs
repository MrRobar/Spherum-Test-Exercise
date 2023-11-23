using UnityEngine;
using UnityEngine.SceneManagement;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private MovementEventDispatcher _dispatcher;
    [SerializeField] private GameObject _spheresKeeper;

    private void OnEnable()
    {
        _dispatcher.OnMove += CheckDistance;
    }

    private void OnDisable()
    {
        _dispatcher.OnMove -= CheckDistance;
    }

    private void CheckDistance(float distance)
    {
        _spheresKeeper.SetActive(distance < 2);
        if (distance < 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}
