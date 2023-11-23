using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private MovementEventDispatcher _dispatcher;

    private void OnEnable()
    {
        _dispatcher.OnMove += UpdateText;
    }

    private void OnDisable()
    {
        _dispatcher.OnMove -= UpdateText;
    }

    private void UpdateText(float distance)
    {
        _distanceText.text = "Distance: " + (int)distance;
    }
}
