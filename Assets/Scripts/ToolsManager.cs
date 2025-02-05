using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolsManager : MonoBehaviour
{
    public Slider altitude;
    public Slider heading;
    public TMP_Text altitudeText;
    public GameObject headingNeedle;

    private void Start()
    {
        altitude.onValueChanged.AddListener(OnAltitudeChanged);
        heading.onValueChanged.AddListener(OnHeadingChanged);
    }

    private void OnAltitudeChanged(float value)
    {
        altitudeText.text = value + " m";
    }

    private void OnHeadingChanged(float value)
    {
        headingNeedle.transform.rotation = Quaternion.Euler(0, 0, value);
    }
}
