using UnityEngine;

public class SubPanel : MonoBehaviour
{
    [Header("Sub Panels")]
    public GameObject fryingPanPanel;
    public GameObject saucePanPanel;

    void Start()
    {
        ShowFryingPan(); // Default tampilkan Frying Pan
    }

    // Fungsi untuk tombol NEXT ➜ ke Sauce Pan
    public void ShowSaucePan()
    {
        if (fryingPanPanel != null) fryingPanPanel.SetActive(false);
        if (saucePanPanel != null) saucePanPanel.SetActive(true);
    }

    // Fungsi untuk tombol LEFT ➜ kembali ke Frying Pan
    public void ShowFryingPan()
    {
        if (saucePanPanel != null) saucePanPanel.SetActive(false);
        if (fryingPanPanel != null) fryingPanPanel.SetActive(true);
    }
}
