using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float _currentTime = 0;
    public float CurrentTime { get { return _currentTime; } }
    private TextMeshProUGUI textMeshProText;

    private void Awake()
    {
        textMeshProText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        IncrementTime();
        UpdateTimeUI();
    }

    private void IncrementTime()
    {
        _currentTime += (1 * Time.deltaTime);
    }

    private void UpdateTimeUI()
    {
        textMeshProText.text = _currentTime.ToString("#.00");
    }
}
