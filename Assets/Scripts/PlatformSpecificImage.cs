using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformSpecificImage : MonoBehaviour
{
    public Image platformImage;
    public Sprite androidSprite;
    public Sprite windowsSprite;

    private void Start()
    {
        #if UNITY_ANDROID
            platformImage.sprite = androidSprite;
        #elif UNITY_STANDALONE_WIN
            platformImage.sprite = windowsSprite;
        #endif
    }
}
