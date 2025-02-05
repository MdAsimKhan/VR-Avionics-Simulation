using System.Collections;
using UnityEngine;

public class LEDGlow : MonoBehaviour
{
    public Renderer ledRenderer;
    public float glowSpeed = 2f;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1f;

    private Material ledMaterial;
    private bool isGlowing = false;

    void Start()
    {
        minAlpha /= 255; // Convert from 0-255 to 0-1
        maxAlpha /= 255;
        ledMaterial = ledRenderer.material;
    }

    public void StartGlow()
    {
        if (!isGlowing)
        {
            isGlowing = true;
            StartCoroutine(GlowEffect());
        }
    }

    public void StopGlow()
    {
        isGlowing = false;
        StopAllCoroutines();
        SetAlpha(ledMaterial, minAlpha); // Reset LED to minimum brightness
    }

    private IEnumerator GlowEffect()
    {
        while (true)
        {
            yield return StartCoroutine(FadeAlpha(minAlpha, maxAlpha, glowSpeed)); // Fade in
            yield return StartCoroutine(FadeAlpha(maxAlpha, minAlpha, glowSpeed)); // Fade out
        }
    }

    private IEnumerator FadeAlpha(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            SetAlpha(ledMaterial, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        SetAlpha(ledMaterial, endAlpha);
    }

    private void SetAlpha(Material mat, float alpha)
    {
        if (mat != null)
        {
            Color color = mat.color;
            color.a = alpha;
            mat.color = color;
        }
    }
}
