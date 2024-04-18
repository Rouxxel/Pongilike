using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class logicscript : MonoBehaviour
{

    public Text player1scoretext;
    public Text player2scoretext;

    public int player1score=0;
    public int player2score=0;
    private float screentime;

    public GameObject pausebutton;
    public GameObject pausescreen;
    public GameObject pointscoredscreen;

    public Text playerscores;

    public AudioSource buttoneffect;
    /*public AudioSource backgroundmusic;*/

    public ballscript balllogic;


    public void addscoreplayer1(int pointtoadd)
    {
        Debug.Log("player1 scored a point");
        player1score = player1score + pointtoadd;
        player1scoretext.text = player1score.ToString();      
        
        pointscoredscreen.SetActive(true);  
        playerscores.text = "Player 1 scores";

        StartCoroutine(HidePointsScoredScreen());
    }

    public void addscoreplayer2(int pointtoadd)
    {
        Debug.Log("player2 scored a point");
        player2score = player2score + pointtoadd;
        player2scoretext.text = player2score.ToString();

        pointscoredscreen.SetActive(true);
        playerscores.text = "Player 2 scores";

        StartCoroutine(HidePointsScoredScreen());
    }

    IEnumerator HidePointsScoredScreen()
    {
        yield return new WaitForSecondsRealtime(screentime);
        pointscoredscreen.SetActive(false);
    }

    public void pausegame()
    {
        Debug.Log("Game paused");
        pausebutton.SetActive(false);
        pausescreen.SetActive(true);
        buttoneffect.Play();
        Time.timeScale = 0f;  
        /*backgroundmusic.Pause();*/
    }

    public void resumegame()
    {
        Debug.Log("Game resumed");
        pausebutton.SetActive(true);
        pausescreen.SetActive(false);
        buttoneffect.Play();
        Time.timeScale = 1f;
        /*backgroundmusic.Play();*/
    }

    public void restartgame() 
    {
        Debug.Log("Game restarted");
        Time.timeScale = 1f;
        buttoneffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitgame()
    {
        Debug.Log("Game quitted");
        buttoneffect.Play();
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        /*backgroundmusic.Play();*/
        balllogic = GameObject.FindGameObjectWithTag("ball").GetComponent<ballscript>();

        screentime = balllogic.ballresettimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
