using UnityEngine;

/// <summary>
/// Added to the main push button parent GO (as no collision or trigger to be detected)
/// </summary>
public class NavigationToggleButton : MonoBehaviour
{
    public bool isOn = false;
    public GameObject light1;
    public GameObject light2;

    public void ToggleLights()
    {
        isOn = !isOn;
        light1.SetActive(isOn);
        light2.SetActive(isOn);
    }
}
