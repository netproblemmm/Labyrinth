using UnityEngine;

public sealed class BadBonus : InteractiveObject, IFly, IRotation
{
    private float _speedRotation;
    private float _flyHeight;

    public delegate void CaughtInteractionDelegate(object value);
    public event CaughtInteractionDelegate CaughtInteraction;

    private void Awake()
    {
        _speedRotation = Random.Range(10.0f, 50.0f);
        _flyHeight = Random.Range(0.2f, 0.5f);
    }

    protected override void Interaction()
    {
        //base.Interaction();
        if (gameObject.CompareTag("Skull"))
        {
            Debug.Log("Dead!");
        }
        if (gameObject.CompareTag("SpeedDown"))
            Ball.m_MovePower = 0.3f;
        CaughtInteraction?.Invoke(this);
    }

    public void Fly()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _flyHeight), transform.localPosition.z);
    }

    public void Rotation()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime*_speedRotation), Space.World);
    }
}
