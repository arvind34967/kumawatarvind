using UnityEngine;

public class BattingController : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;
    public Transform batTransform;

    void Update()
    {
        // Simple Input for prototype (A/D or Arrow keys for direction)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayShot("StraightDrive");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayShot("PullShot");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayShot("CoverDrive");
        }
    }

    void PlayShot(string shotType)
    {
        if (animator != null)
        {
            animator.SetTrigger(shotType);
            Debug.Log("Playing Shot: " + shotType);
        }
    }
}