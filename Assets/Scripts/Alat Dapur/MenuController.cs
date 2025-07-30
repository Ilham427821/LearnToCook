using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Main Panels")]
    public GameObject pilihanMenuPanel;
    public GameObject panPanel;
    public GameObject cuttingBoardPanel;
    public GameObject spatulaPanel;
    public GameObject microwavePanel;

    [Header("Pan Sub Panels")]
    public GameObject fryingPan;
    public GameObject saucePan;

    // Menampilkan panel PAN, default ke Frying Pan
    public void ShowPanPanel()
    {
        pilihanMenuPanel.SetActive(false);
        panPanel.SetActive(true);

        // Tampilkan Frying Pan, sembunyikan Sauce Pan
        if (fryingPan != null) fryingPan.SetActive(true);
        if (saucePan != null) saucePan.SetActive(false);
    }

    public void ShowCuttingBoardPanel()
    {
        pilihanMenuPanel.SetActive(false);
        cuttingBoardPanel.SetActive(true);
    }

    public void ShowSpatulaPanel()
    {
        pilihanMenuPanel.SetActive(false);
        spatulaPanel.SetActive(true);
    }

    public void ShowMicrowavePanel()
    {
        pilihanMenuPanel.SetActive(false);
        microwavePanel.SetActive(true);
    }

    // Kembali ke menu utama
    public void BackToMenu()
    {
        // Nonaktifkan semua panel
        if (panPanel != null) panPanel.SetActive(false);
        if (cuttingBoardPanel != null) cuttingBoardPanel.SetActive(false);
        if (spatulaPanel != null) spatulaPanel.SetActive(false);
        if (microwavePanel != null) microwavePanel.SetActive(false);

        // Nonaktifkan juga subpanel di dalam Pan
        if (fryingPan != null) fryingPan.SetActive(false);
        if (saucePan != null) saucePan.SetActive(false);

        // Aktifkan menu utama
        if (pilihanMenuPanel != null) pilihanMenuPanel.SetActive(true);
    }

    // Untuk tombol NEXT ke Sauce Pan
    public void ShowSaucePan()
    {
        if (fryingPan != null) fryingPan.SetActive(false);
        if (saucePan != null) saucePan.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
