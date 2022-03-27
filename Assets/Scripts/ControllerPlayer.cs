using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour , CharaterController
{
    public static ControllerPlayer instance;
    public Rigidbody2D PlayerRigibody;
    public float fMaxWalkHorizontalSpeed;
    public float fMaxRunHorizontalSpeed;

    private float fHorizontalMove;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            
        }
        else
        {            
            Debug.Log("Button was released");            
            PlayerRigibody.velocity = new Vector2(0, PlayerRigibody.velocity.y);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Jump(float speed)
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        float currentLimitSpeed;
        if (Input.GetButton("Horizontal") && Input.GetButton("Run"))
        {
            Debug.Log("Running");
            currentLimitSpeed = fMaxRunHorizontalSpeed;
        }
        else 
            currentLimitSpeed = fMaxWalkHorizontalSpeed;


        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            PlayerRigibody.transform.localScale = new Vector3(1, 1, 1);
            PlayerRigibody.velocity = new Vector2(currentLimitSpeed, PlayerRigibody.velocity.y);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            PlayerRigibody.transform.localScale = new Vector3(-1, 1, 1);
            PlayerRigibody.velocity = new Vector2(-currentLimitSpeed, PlayerRigibody.velocity.y);
        }

        
    }
}
public interface CharaterController
{
    //Player¤ô¥­²¾°Ê
    public void Move();

    //Player¸õÅD
    public void Jump(float speed);
}


