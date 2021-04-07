using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    public Ball ball;
    private Vector3 _offset;

    // Start is called before the first frame update
    private void Start()
    {
        _offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = ball.transform.position + _offset;
    }
}
