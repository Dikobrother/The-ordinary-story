using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown qualityDropdown;

    void Start()
    {
        List<string> options = new List<string>();
        LoadSettings();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("fullscreen"); 
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("quality");
    }

    public void ExitSettings()
    {
        SceneManager.LoadScene("Hub");
        Debug.Log("exit");
    }

    public void SaveSettings()
    {
        Debug.Log("save");
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        }
        else
        {
            qualityDropdown.value = 3;
        }
        if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}
