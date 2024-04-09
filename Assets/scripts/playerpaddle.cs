using UnityEngine;

public class player1paddle : MonoBehaviour
{

    public Rigidbody2D paddlebody;
    public float paddlespeed = 10;

    public KeyCode upward = KeyCode.W;
    public KeyCode downward = KeyCode.S;

    public float upylimit = 5;
    public float downylimit = -5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movepaddle();
    }


    void movepaddle()
    {

        if (Input.GetKey(upward) && transform.position.y < upylimit)
        {
            transform.position = transform.position + (Vector3.up * paddlespeed) * Time.deltaTime;
        }
        
        if (Input.GetKey(downward) && transform.position.y > downylimit)
        { 
            transform.position = transform.position + (Vector3.down * paddlespeed) * Time.deltaTime;
        } 
    }
}
