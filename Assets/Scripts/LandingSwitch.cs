using UnityEngine;

/// <summary>
/// Attached to the trigger colllider GO of the landing switch's grab handle
/// </summary>
public class LandingSwitch : MonoBehaviour
{
    public Animator animator;
    public AnimationClip up;
    public AnimationClip down;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Up"))
        {
            animator.Play(up.name);
        }
        else if (other.CompareTag("Down"))
        {
            animator.Play(down.name);
        }
    }
}
