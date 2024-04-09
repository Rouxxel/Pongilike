using Unity.VisualScripting;
using UnityEngine;

public class leftwallscorer : MonoBehaviour
{
    public logicscript logic;
    public int pointtoadd = 1;

    public AudioSource pointeffect;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pointeffect.Play();
        if (collision.GameObject().tag == "ball" && gameObject.CompareTag("ltriggerwall") == true)
        {
            logic.addscoreplayer2(pointtoadd);

        } else if (collision.GameObject().tag == "ball" && gameObject.CompareTag("rtriggerwall") == true)
        {
            logic.addscoreplayer1(pointtoadd);
        }
    }
}
