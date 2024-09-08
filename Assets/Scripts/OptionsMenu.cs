using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;

    private bool originalInvertedState;

    private void Start()
    {
        originalInvertedState = PlayerPrefs.GetInt("isInverted", 0) == 1;
        invertYToggle.isOn = originalInvertedState;
    }

    public void Apply()
    {
        PlayerPrefs.SetInt("isInverted", invertYToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        string previousScene = PlayerPrefs.GetString("previousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }

    public void Back()
    {
        invertYToggle.isOn = originalInvertedState;
        string previousScene = PlayerPrefs.GetString("previousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }
}
