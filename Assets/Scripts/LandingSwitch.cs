using UnityEngine;

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
