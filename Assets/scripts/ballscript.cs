using System.Collections;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    public Rigidbody2D ballbody2D;
    public float initialvelocity = 10;
    public Vector2 direction;

    public float panglecontroller = 1;
    public float nanglecontroller = -1;

    public float ballresettimer = 3;
    public float timer = 0;

    public AudioSource paddleeffect;
    public AudioSource walleffect;

    void randomizeddirection()
    {
        direction = new Vector2(Random.Range(panglecontroller, nanglecontroller),Random.Range(panglecontroller, nanglecontroller));
        direction = direction.normalized;
        ballbody2D.velocity = direction * initialvelocity;
    }

    [ContextMenu("Reset ball")]
    void resetballposition()
    {
       transform.position = Vector2.zero;

        ballbody2D.velocity = Vector2.zero;

        randomizeddirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("paddle1") || collision.gameObject.CompareTag("paddle2"))
        {
            Debug.Log("Ball collided with paddle");

            direction = new Vector2(-direction.x, direction.y);
            ballbody2D.velocity = direction * initialvelocity;
            paddleeffect.Play();
        } 
        else if (collision.gameObject.CompareTag("wall"))
        {
            Debug.Log("Ball collided with wall");
            direction = new Vector2(direction.x,-direction.y);
            ballbody2D.velocity = direction * initialvelocity;
            walleffect.Play();
        }
    }

   



    // Start is called before the first frame update
    void Start()
    {
        randomizeddirection();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x > 13 || transform.position.x < -13) || (transform.position.y > 6 || transform.position.y < -6))
        {
            if (timer < ballresettimer)
            {
                Debug.Log("Ball reset has started");
                timer = timer + Time.deltaTime;
            }
            else
            {
                Debug.Log("Ball reset has finalised");
                resetballposition();
                timer = 0;
            }

        } 
    }
}
