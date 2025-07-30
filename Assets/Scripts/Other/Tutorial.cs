using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [Header("Panel Menu")]
    public GameObject panelMenu;  // panel awal yang berisi pilihan menu

    [Header("Panel Tutorial")]
    public GameObject bingke;
    public GameObject hotdog;
    public GameObject burger;

    [Header("Resep Images")]
    public GameObject resepBingke;
    public GameObject resepHotdog;
    public GameObject resepBurger;

    // Kembali ke Main Menu Scene
    public void BackToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Tampilkan video Bingke
    public void CaraMasakBingke()
    {
        panelMenu.SetActive(false);
        bingke.SetActive(true);
        hotdog.SetActive(false);
        burger.SetActive(false);
    }

    // Tampilkan video Hotdog
    public void CaraMasakHotdog()
    {
        panelMenu.SetActive(false);
        bingke.SetActive(false);
        hotdog.SetActive(true);
        burger.SetActive(false);
    }

    // Tampilkan video Burger
    public void CaraMasakBurger()
    {
        panelMenu.SetActive(false);
        bingke.SetActive(false);
        hotdog.SetActive(false);
        burger.SetActive(true);
    }

    // Tombol Back: kembali ke panel menu
    public void BackToMenu()
    {
        panelMenu.SetActive(true);
        bingke.SetActive(false);
        hotdog.SetActive(false);
        burger.SetActive(false);

        resepBingke.SetActive(false);
        resepHotdog.SetActive(false);
        resepBurger.SetActive(false);
    }

    // ======= RESEP BUTTON =======

    public void TampilkanResepBingke()
    {
        resepBingke.SetActive(true);
    }

    public void TampilkanResepHotdog()
    {
        resepHotdog.SetActive(true);
    }

    public void TampilkanResepBurger()
    {
        resepBurger.SetActive(true);
    }

    // Optional: Tombol Tutup Resep (semua)
    public void SembunyikanSemuaResep()
    {
        resepBingke.SetActive(false);
        resepHotdog.SetActive(false);
        resepBurger.SetActive(false);
    }
}
