using UnityEngine;

public sealed class GoodBonus: InteractiveObject, IFly, IFlicker
{
    private Material _material;
    private float _flyHeight;
    private DisplayBonuses _displayBonuses;
    public GameObject exitWall;
    
    public delegate void CaughtInteractionDelegate(object value);
    public event CaughtInteractionDelegate CaughtInteraction;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _flyHeight = Random.Range(0.2f, 0.5f);
        _displayBonuses = new DisplayBonuses();
    }

    protected override void Interaction()
    {
        //base.Interaction();
        if (gameObject.CompareTag("Ring"))
            GameController.levelTargets -= 1;
        if (gameObject.CompareTag("SpeedUp"))
            Ball.m_MovePower = 550.0f;
        //_displayBonuses.Display(5);
        if (GameController.levelTargets == 0)
            //exitWall.transform.position = new Vector3(transform.position.x+50.0f, transform.position.y + 50.0f, transform.position.z+50.0f);
            Destroy(exitWall);
        CaughtInteraction?.Invoke(this);
    }

    public void Fly()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _flyHeight), transform.localPosition.z);
    }

    public void Flicker()
    {
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
    }
}
