using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppTimer : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime = 0f;
    private bool isTimerRunning = true;

    private static AppTimer instance;
    private float stopTimeInSeconds = 80f; // 1 minute 20 seconds is 80 seconds

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(timerText.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= stopTimeInSeconds)
            {
                StopTimer();
                UpdateTimerTextWithTimeUp();
            }
            else
            {
                UpdateTimerDisplay();
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (timerText == null)
        {
            timerText = GameObject.Find("TimerText")?.GetComponent<Text>();
        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int hours = Mathf.FloorToInt(elapsedTime / 3600f);
            int minutes = Mathf.FloorToInt((elapsedTime % 3600f) / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
    }

    private void UpdateTimerTextWithTimeUp()
    {
        if (timerText != null)
        {
            timerText.text = "Time Up";
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        isTimerRunning = true;
        UpdateTimerDisplay();
    }

    public void ResumeTimer()
    {
        isTimerRunning = true;
    }
}
