using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
   

    public AudioSource musicSource;
    public AudioSource backMusic;
    public AudioClip musicClipLoss;
    public AudioClip musicClipWin;

    public float timeLeft;
    public Text Timer;

    public bool gameOver;
    private bool restart;
    public bool timer;
    public int score;



    void Start()
    {
        gameOver = false;
        restart = false;
        timer = true;

        restartText.text = "";
        gameOverText.text = "";
        Timer.text = "";

        timeLeft = 60.0f;
       
        score = 0;
       
        UpdateScore();
        
        StartCoroutine(SpawnWaves());
        AudioSource[] audios = GetComponents<AudioSource>();
        musicSource = audios[0];
        backMusic = audios[1];


    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        timeLeft -= Time.deltaTime;
        Timer.text = (timeLeft).ToString("0");
        if (timeLeft <= 0f)
        {
            gameOver = true;

            restart = true;
            backMusic.Stop();
            gameOverText.text = "Game Over! Game created by Jason Vento";
           
        }
    }



    
    



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
 


    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 1000)
        {
           
                winText.text = "You Win!";
                gameOverText.text = "Game Over! Game created by Jason Vento";
                gameOver = true;
                restart = true;
                backMusic.Stop();
                musicSource.clip = musicClipWin;
                musicSource.Play();
            }
        

        if (score < 200)
        {
            if (gameOver)
            {
                musicSource.clip = musicClipLoss;
                musicSource.Play();
            }

        }
     
    }


        public void GameOver()
        {
        gameOverText.text = "Game Over! Game created by Jason Vento";
        gameOver = true;
        musicSource.clip = musicClipLoss;
        musicSource.Play();
    }

  
}

