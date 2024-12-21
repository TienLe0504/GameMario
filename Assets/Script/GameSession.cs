using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Tilemaps;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI liveText;
    [SerializeField] TextMeshProUGUI scoreText;
    private void Start()
    {
        liveText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    // Start is called before the first frame update
    void Awake()
    {
        int numSession = FindObjectsOfType<GameSession>().Length;
        if (numSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void addpoint(int point)
    {
        score += point;
        scoreText.text = score.ToString();

    }
    public void ProcessPlayer()
    {
        if (playerLives > 1)
        {
            takeLife();
        }
        else
        {
            resetGameSession();
        }
    }
    public void takeLife()
    {
        playerLives--;
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current);
        liveText.text = playerLives.ToString();
    }
    public void resetGameSession()
    {
        FindObjectOfType<ScencePersist>().ResetPersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
