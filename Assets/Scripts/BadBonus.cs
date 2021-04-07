using UnityEngine;

public sealed class BadBonus : InteractiveObject, IFly, IRotation
{
    private float _speedRotation;
    private float _flyHeight;
    public GameObject ball;

    private void Awake()
    {
        _speedRotation = Random.Range(10.0f, 50.0f);
        _flyHeight = Random.Range(1.0f, 5.0f);
    }

    protected override void Interaction()
    {
        //base.Interaction();
        if (gameObject.tag == "Skull")
        {
            Debug.Log("Dead!");
            //Destroy(ball);
        }
        if (gameObject.tag == "SpeedDown")
            Ball.m_MovePower = 0.3f;
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
