using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 prevousCameraPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        prevousCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - prevousCameraPosition.x) * 0.5f;
        transform.Translate(new Vector3(deltaX, 0, 0));
        prevousCameraPosition = cameraTransform.position;
    }
}
