using UnityEngine;
using UnityEngine.UI;

public class UIElementController : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle soundToggle;
    public Toggle lightToggle; // This will now control the tinted panel.
    public GameObject tintedPanel; // Reference to the tinted panel GameObject.
    public Slider sizeSlider;
    public GameObject objectToResize;
    public Button applyButton;

    private AudioSource backgroundMusic;

    void Start()
    {
        GameObject backgroundMusicObject = GameObject.Find("BackgroundMusic");
        if (backgroundMusicObject != null)
        {
            backgroundMusic = backgroundMusicObject.GetComponent<AudioSource>();

            if (volumeSlider != null)
            {
                float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
                volumeSlider.value = savedVolume;
                backgroundMusic.volume = savedVolume;
            }

            if (soundToggle != null)
            {
                bool isSoundOn = PlayerPrefs.GetInt("isSoundOn", 1) == 1;
                soundToggle.isOn = isSoundOn;
                backgroundMusic.mute = !isSoundOn;
            }
        }

        if (lightToggle != null && tintedPanel != null)
        {
            bool isPanelVisible = PlayerPrefs.GetInt("isPanelVisible", 1) == 1;
            lightToggle.isOn = isPanelVisible;
            tintedPanel.SetActive(isPanelVisible); 
        }

        if (sizeSlider != null && objectToResize != null)
        {
            sizeSlider.value = objectToResize.transform.localScale.x;
        }

        if (applyButton != null)
        {
            applyButton.onClick.AddListener(ApplyChanges);
        }
    }

    void Update()
    {
        if (backgroundMusic != null && volumeSlider != null)
        {
            backgroundMusic.volume = volumeSlider.value;
        }

        if (soundToggle != null && backgroundMusic != null)
        {
            backgroundMusic.mute = !soundToggle.isOn;
        }

        if (lightToggle != null && tintedPanel != null)
        {
            tintedPanel.SetActive(lightToggle.isOn); 
        }

        if (sizeSlider != null && objectToResize != null)
        {
            objectToResize.transform.localScale = Vector3.one * sizeSlider.value;
        }
    }

    public void ApplyChanges()
    {
        if (volumeSlider != null)
        {
            PlayerPrefs.SetFloat("volume", volumeSlider.value);
        }

        if (soundToggle != null)
        {
            PlayerPrefs.SetInt("isSoundOn", soundToggle.isOn ? 1 : 0);
        }

        if (lightToggle != null)
        {
            PlayerPrefs.SetInt("isPanelVisible", lightToggle.isOn ? 1 : 0); 
        }

        PlayerPrefs.Save();
    }
}
