using System.Collections;
using UnityEngine;

public class LEDSequence : MonoBehaviour
{
    public Renderer[] ledRenderers;
    public float blinkDuration = 3f; // Blinking duration
    public float maxAlpha = 1f; // Maximum glow intensity
    private Material[] ledMaterials;
    private bool isRunning = false;

    void Start()
    {
        maxAlpha = maxAlpha / 255; // Convert from 0-255 to 0-1
        // Store materials
        ledMaterials = new Material[ledRenderers.Length];
        for (int i = 0; i < ledRenderers.Length; i++)
        {
            ledMaterials[i] = ledRenderers[i].material;
            SetAlpha(ledMaterials[i], 0f); // Turn off all LEDs at start
        }
    }

    // Public funtion to start the blinking sequence
    public void StartUpSequence()
    {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(BlinkingSequence());
        }
    }

    // Public function to stop the blinking sequence
    public void StopSequence()
    {
        StopAllCoroutines();
        isRunning = false;
        foreach (Material mat in ledMaterials)
        {
            SetAlpha(mat, 0f); // Turn off all LEDs
        }
    }

    private IEnumerator BlinkingSequence()
    {
        float startTime = Time.time;

        while (Time.time - startTime < blinkDuration)
        {
            int randomIndex = Random.Range(0, ledMaterials.Length);
            float randomAlpha = Random.Range(0.3f, maxAlpha); // Random glow intensity

            SetAlpha(ledMaterials[randomIndex], randomAlpha);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            SetAlpha(ledMaterials[randomIndex], 0f); // Fade out
        }

        // Ensure all LEDs fully turn on at the end
        foreach (Material mat in ledMaterials)
        {
            SetAlpha(mat, maxAlpha);
        }

        isRunning = false;
    }

    private void SetAlpha(Material mat, float alpha)
    {
        if (mat != null) // Null check
        {
            Color color = mat.color;
            color.a = alpha;
            mat.color = color;
        }
    }
}
