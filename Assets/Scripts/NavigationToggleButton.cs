using UnityEngine;

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
        Debug.Log(isOn ? "Nav Lights Off..." : "Nav Lights On");
    }
}
