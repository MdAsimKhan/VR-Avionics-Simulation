using UnityEngine;
using System.Collections;

/// <summary>
/// Attached to the trigger collider GO that is the child of the Battery Switch's grab handle
/// </summary>
public class BatterySwitch : MonoBehaviour
{
    public AudioClip onSound;
    public AudioClip offSound;
    public AudioClip warningSound;
    public float maxUpTime = 5f;
    public float warningDuration = 2f;
    public GameObject handle; // Battery switch grab handle
    public GameObject warningCanvas;
    public LEDSequence LEDSequence;
    public LEDGlow LEDGlow;

    private float upTime = 0f;
    private bool isOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("On"))
        {
            isOn = true;
            upTime = 0f; // Reset uptime when turned on
            LEDSequence.StartUpSequence(); // Blink LEDs
            StartCoroutine(CheckBattery()); // Starting warning sequence check
            AudioManager.Instance.PlayClip(onSound);
        }
        else if (other.CompareTag("Off"))
        {
            isOn = false;
            LEDSequence.StopSequence(); // Turn off LEDs
            StopAllCoroutines();
            AudioManager.Instance.PlayClip(offSound);
        }
    }

    private IEnumerator CheckBattery()
    {
        while (isOn)
        {
            upTime += Time.deltaTime;
            if (upTime >= maxUpTime)
            {
                warningCanvas.SetActive(true);
                LEDGlow.StartGlow();
                AudioManager.Instance.PlayClip(warningSound);
                yield return new WaitForSeconds(warningDuration);
                AutoTurnOffEvents();
                yield break;
            }
            yield return null;
        }
    }

    private void AutoTurnOffEvents()
    {
        LEDGlow.StopGlow();
        isOn = false;
        warningCanvas.SetActive(false);
        AudioManager.Instance.PlayClip(offSound);
        handle.transform.rotation = Quaternion.Euler(0f, 0f, -90f); // rotate the handle back to off (depends on the rotn of parent GO or the angles in runtime)
        LEDSequence.StopSequence(); // Turn off LEDs
    }
}
