using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Menu;
    public GameObject graphicsMenu;
    public GameObject generalMenu;

    public Slider VolumeSlider;
    public Slider SensitivitySlider;
    public Slider BrightnessSlider;
    public Toggle Toggle_crosshair;
    public Toggle Toggle_headbob;
    public TMP_Dropdown LangugeDropDown;
    public Toggle Toggle_fullscreen;
    public TMP_Dropdown GraphicsDropDown;
    public Toggle Toggle_vsync;

    private float volume = 1f;
    private float mouse_sens = 2.5f;
    private float brightness = 0;
    private bool crosshair = true;
    private bool headbob = false;
    private Int32 Language = 0;
    private bool fullscreen = true;
    private Int32 Graphics = 2;
    private bool VSync = false;

    public GameObject[] audios;

    public GameObject brightobj;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Hub")
        {
            LoadSettings();
        }
        SetSettings();
    }
    public void Settings_On()
    {
        Settings.SetActive(true);
        Menu.SetActive(false);
    }

    public void Settings_Off()
    {
        Settings.SetActive(false);
        Menu.SetActive(true);
    }

    public void ChangeGrapics()
    {
        graphicsMenu.SetActive(true);
        generalMenu.SetActive(false);
    }

    public void ChangeGeneral()
    {
        graphicsMenu.SetActive(false);
        generalMenu.SetActive(true);
    }

    public void GetVolume(float vol)
    {
        volume = vol;
    }

    public void GetSens(float sens)
    {
        mouse_sens = sens;
    }

    public void GetBrightness(float bright)
    {
        brightness = bright;
    }

    public void GetCrossHair(bool cross)
    {
        crosshair = cross;
    }

    public void GetHeadBob(bool head)
    {
        headbob = head;
    }

    public void GetLanguage(Int32 val)
    {
        Language = val;
    }

    public void GetFullScreen(bool val)
    {
        fullscreen = val;
    }

    public void GetGraphicSettings(Int32 val)
    {
        Graphics = val;
    }

    public void GetVsync(bool val)
    {
        VSync = val;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            VolumeSlider.value = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            VolumeSlider.value = 1f;
        }



        if (PlayerPrefs.HasKey("sensitivity"))
        {
            SensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
        }
        else
        {
            SensitivitySlider.value = 2.5f;
        }



        if (PlayerPrefs.HasKey("brightness"))
        {
            BrightnessSlider.value = PlayerPrefs.GetFloat("brightness");
        }
        else
        {
            BrightnessSlider.value = 0;
        }



        if (PlayerPrefs.HasKey("crosshair"))
        {
            Toggle_crosshair.isOn = PlayerPrefs.GetInt("crosshair") == 1 ? true : false;
        }
        else
        {
            Toggle_crosshair.isOn = true;
        }



        if (PlayerPrefs.HasKey("headbob"))
        {
            Toggle_headbob.isOn = PlayerPrefs.GetInt("headbob") == 1 ? true : false;
            
        }
        else
        {
            Toggle_headbob.isOn = false;
        }



        if (PlayerPrefs.HasKey("language"))
        {
            LangugeDropDown.value = PlayerPrefs.GetInt("language");
        }
        else
        {
            LangugeDropDown.value = 0;
        }



        if (PlayerPrefs.HasKey("fullscreen"))
        {
            Toggle_fullscreen.isOn = PlayerPrefs.GetInt("fullscreen") == 1 ? true : false;
        }
        else
        {
            Toggle_fullscreen.isOn = true;
        }



        if (PlayerPrefs.HasKey("graphics"))
        {
            GraphicsDropDown.value = PlayerPrefs.GetInt("graphics");
        }
        else
        {
            GraphicsDropDown.value = 2;
        }

        if (PlayerPrefs.HasKey("vsync"))
        {
            Toggle_vsync.isOn = PlayerPrefs.GetInt("vsync") == 1 ? true : false;
        }
        else
        {
            Toggle_vsync.isOn = false;
        }
    }

    public void SaveButton()
    {
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("sensitivity", mouse_sens);
        PlayerPrefs.SetFloat("brightness", brightness);
        PlayerPrefs.SetInt("crosshair", crosshair ? 1 : 0);
        PlayerPrefs.SetInt("headbob", headbob ? 1 : 0);
        PlayerPrefs.SetInt("language", Language);
        PlayerPrefs.SetInt("fullscreen", fullscreen ? 1 : 0);
        PlayerPrefs.SetInt("graphics", Graphics);
        PlayerPrefs.SetInt("vsync", VSync ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void DefaultButton()
    {
        VolumeSlider.value = 1f;
        SensitivitySlider.value = 2.5f;
        BrightnessSlider.value = 0;
        Toggle_crosshair.isOn = true;
        Toggle_headbob.isOn = false;
        LangugeDropDown.value = 0;
        Toggle_fullscreen.isOn = true;
        GraphicsDropDown.value = 2;
        Toggle_vsync.isOn = false;
    }
    public void SetSettings()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (PlayerPrefs.HasKey("sensitivity"))
            {
                GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().mouseSensitivity = PlayerPrefs.GetFloat("sensitivity");
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().mouseSensitivity = 2.5f;
            }

            if (PlayerPrefs.HasKey("crosshair"))
            {
                GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().crosshair = PlayerPrefs.GetInt("crosshair") == 1 ? true : false;
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().crosshair = true;
            }

            if (PlayerPrefs.HasKey("headbob"))
            {
                GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enableHeadBob = PlayerPrefs.GetInt("headbob") == 1 ? true : false;
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enableHeadBob = false;
            }
        }

        if (PlayerPrefs.HasKey("volume"))
        {
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
            }
        }
        else
        {
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].GetComponent<AudioSource>().volume = 1f;
            }
        }

        if (PlayerPrefs.HasKey("brightness"))
        {
            brightobj.GetComponent<Image>().color = new Color(0, 0, 0, PlayerPrefs.GetFloat("brightness")/255);
        }
        else
        {
            brightobj.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (PlayerPrefs.HasKey("language"))
        {
            //LangugeDropDown.value = PlayerPrefs.GetInt("language");
        }
        else
        {
            //LangugeDropDown.value = 0;
        }

        if (PlayerPrefs.HasKey("fullscreen"))
        {
            Screen.fullScreen = PlayerPrefs.GetInt("fullscreen") == 1 ? true : false;
        }
        else
        {
            Screen.fullScreen = true;
        }

        if (PlayerPrefs.HasKey("graphics"))
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("graphics"));
        }
        else
        {
            QualitySettings.SetQualityLevel(2);
        }

        if (PlayerPrefs.HasKey("vsync"))
        {
            QualitySettings.vSyncCount = PlayerPrefs.GetInt("vsync");
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
    
}
