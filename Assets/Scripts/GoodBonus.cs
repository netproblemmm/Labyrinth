using UnityEngine;

public sealed class GoodBonus: InteractiveObject, IFly, IFlicker
{
    private Material _material;
    private float _flyHeight;
    private int _levelTargets;
    private DisplayBonuses _displayBonuses;
    //private float _m_MovePower = Ball.m_MovePower;
    public GameObject exitWall;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _flyHeight = Random.Range(1.0f, 5.0f);
        _displayBonuses = new DisplayBonuses();
    }

    protected override void Interaction()
    {
        //base.Interaction();
        if (gameObject.tag == "Ring")
            GameController.levelTargets -= 1;
        if (gameObject.tag == "SpeedUp")
            Ball.m_MovePower = 550.0f;
        //_displayBonuses.Display(5);
        if (GameController.levelTargets == 0)
            //exitWall.transform.position = new Vector3(transform.position.x+50.0f, transform.position.y + 50.0f, transform.position.z+50.0f);
            Destroy(exitWall);
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
