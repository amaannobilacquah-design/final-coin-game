using TMPro;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject coinButton;
    public TMP_Text messageText;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text goalText;

    public int goal = 8;
    public float gameTime = 10f;

    int score;
    float timeLeft;
    bool playing;

    void Start()
    {
        goalText.text = "Goal : " + goal;
        messageText.text = "Click the coin! Get " + goal + " in " + gameTime + " seconds!";
        coinButton.SetActive(false);
    }

    // Start button calls this
    public void StartGame()
    {
        score = 0;
        timeLeft = gameTime;
        playing = true;
        scoreText.text = "Score : 0";
        messageText.text = "";
        startButton.SetActive(false);
        coinButton.SetActive(true);
        MoveCoin();
    }

    // Coin button calls this
    public void CoinClicked()
    {
        if (!playing) return;
        score++;
        scoreText.text = "Score : " + score;
        MoveCoin();
    }

    void MoveCoin()
    {
        float x = Random.Range(-700f, 700f);
        float y = Random.Range(-300f, 250f);
        coinButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
    }

    void Update()
    {
        if (!playing) return;

        timeLeft -= Time.deltaTime;
        timerText.text = "Time : " + Mathf.Max(timeLeft, 0f).ToString("0.0");

        if (timeLeft <= 0f) EndGame();
    }

    void EndGame()
    {
        playing = false;
        coinButton.SetActive(false);
        startButton.SetActive(true);

        if (score >= goal)
            messageText.text = "You win! Score : " + score;
        else
            messageText.text = "You lose! Score : " + score;
    }
}