using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    public bool isBowled = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Bowl(Vector3 targetPitchPoint, float force)
    {
        transform.parent = null; // Detach from bowler's hand
        rb.isKinematic = false;
        isBowled = true;

        // Calculate direction towards pitch point
        Vector3 direction = (targetPitchPoint - transform.position).normalized;
        rb.AddForce(direction * force, ForceMode.Impulse);

        if (MatchManager.Instance != null)
        {
            MatchManager.Instance.OnBallBowled();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            Debug.Log("Bat Contact!");
        }
        else if (collision.gameObject.CompareTag("Pitch"))
        {
            Debug.Log("Ball Bounced on Pitch!");
        }
    }
}