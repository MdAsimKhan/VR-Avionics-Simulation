using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CamViewSwitch : MonoBehaviour
{
    public Transform fpv;
    public Transform tpv;
    public Transform mainCam;

    private bool isFPV = true;

    public void SwitchView()
    {
        isFPV = !isFPV;
        gameObject.transform.position = isFPV ? fpv.position : tpv.position;
        mainCam.GetComponent<TrackedPoseDriver>().enabled = false;
        mainCam.transform.rotation = isFPV ? fpv.rotation : tpv.rotation;
        mainCam.GetComponent<TrackedPoseDriver>().enabled = true;
    }
}
