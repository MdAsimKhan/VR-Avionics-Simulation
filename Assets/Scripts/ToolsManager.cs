using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolsManager : MonoBehaviour
{

    public Slider controllerAltitude;
    public Slider controllerHeading;
    public TMP_Text controllerAltitudeText;
    public Slider handAltitude;
    public Slider handHeading;
    public TMP_Text handAltitudeText;
    public GameObject headingNeedle;

    private Slider altitude;
    private Slider heading;
    private TMP_Text altitudeText;

    public void SetHandElements()
    {
        altitude = handAltitude;
        heading = handHeading;
        altitudeText = handAltitudeText;
        FixListeners();
    }

    public void SetControllerElements()
    {
        altitude = controllerAltitude;
        heading = controllerHeading;
        altitudeText = controllerAltitudeText;
        FixListeners();
    }


    private void FixListeners()
    {
        // Remove old listeners from previous controls and add new ones from current controls
        altitude.onValueChanged.RemoveAllListeners();
        altitude.onValueChanged.AddListener(OnAltitudeChanged);
        heading.onValueChanged.RemoveAllListeners();
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
