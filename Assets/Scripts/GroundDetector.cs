using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayer;

    public bool isGrounded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!Utilities.CheckLayerInMask(playerLayer, collision.gameObject.layer)) {
            isGrounded = true;
        }
    }
}
