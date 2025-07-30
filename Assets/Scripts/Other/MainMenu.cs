using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public string name;
        public Sprite image;
    }

    [Header("Level Data")]
    public Level[] levels;
    public Image levelImage;
    private int levelSelected = 1;

    [Header("UI Panels")]
    public GameObject Controls;
    public GameObject Credits;
    public GameObject Tutorial;
    public GameObject OnionKing;
    public GameObject LevelsMenu;
    public GameObject mainMenu;

    [Header("Extra Buttons")]
    public GameObject caraMasakButton;
    public GameObject alatDapurButton;

    void Start()
    {
        Debug.Log("Jumlah level dalam array: " + (levels != null ? levels.Length : 0));
        if (levels != null)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                Debug.Log("Level[" + i + "]: " + levels[i].name + ", Sprite: " + levels[i].image);
            }
        }
        else
        {
            Debug.LogError("Array levels masih null. Harap isi di Inspector.");
        }
    }

    public void SelectLevel(int level)
    {
        if (levels == null || levels.Length == 0)
        {
            Debug.LogError("Levels array kosong! Harap isi di Inspector.");
            return;
        }

        if (level <= 0 || level > levels.Length)
        {
            Debug.LogError("Index level tidak valid! Diminta: " + level + ", tapi jumlah level: " + levels.Length);
            return;
        }

        levelSelected = level;
        levelImage.sprite = levels[level - 1].image;
        Debug.Log("Level " + level + " dipilih: " + levels[level - 1].name);
    }

    public void ShowCredits()
    {
        Credits.SetActive(true);
        Controls.SetActive(false);
        OnionKing.SetActive(false);
        Tutorial.SetActive(false);
    }

    public void ShowControls()
    {
        Controls.SetActive(true);
        Credits.SetActive(false);
        OnionKing.SetActive(false);
        Tutorial.SetActive(false);
    }

    public void ShowTutorial()
    {
        Tutorial.SetActive(true);
        Controls.SetActive(false);
        Credits.SetActive(false);
        OnionKing.SetActive(false);
    }

    public void PlaySelectedLevel()
    {
        if (levels == null || levels.Length == 0)
        {
            Debug.LogError("Tidak bisa memuat level. Array levels kosong.");
            return;
        }

        if (levelSelected <= 0 || levelSelected > levels.Length)
        {
            Debug.LogError("Level yang dipilih tidak valid.");
            return;
        }

        ChangeScene(levels[levelSelected - 1].name);
    }

    public void ShowLevelMenu()
    {
        LevelsMenu.SetActive(true);
        mainMenu.SetActive(false);

        // Sembunyikan tombol "Cara Masak" dan "Alat Dapur"
        if (caraMasakButton != null) caraMasakButton.SetActive(false);
        if (alatDapurButton != null) alatDapurButton.SetActive(false);
    }

    public void ShowMainMenu()
    {
        LevelsMenu.SetActive(false);
        mainMenu.SetActive(true);

        // Tampilkan kembali tombol "Cara Masak" dan "Alat Dapur"
        if (caraMasakButton != null) caraMasakButton.SetActive(true);
        if (alatDapurButton != null) alatDapurButton.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("Pindah ke scene: " + sceneName);

        if (SceneTransitionManager.instance != null)
        {
            SceneTransitionManager.instance.TransitionToScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Quit()
    {
        Debug.Log("Keluar dari game.");
        Application.Quit();
    }

    public void LoadPeralatanDapurScene()
    {
        ChangeScene("Alat Dapur");
    }

    public void LoadCaraMasakScene()
    {
        ChangeScene("Cara Masak");
    }
}
