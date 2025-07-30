using UnityEngine;

public class KitchenToolSwitcher : MonoBehaviour
{
    [Header("Kitchen Tools")]
    public GameObject fryingPan;
    public GameObject saucePan;
    public GameObject spatula;
    public GameObject microwave;
    public GameObject cuttingBoard;

    // Nonaktifkan semua terlebih dahulu
    private void DeactivateAllTools()
    {
        if (fryingPan != null) fryingPan.SetActive(false);
        if (saucePan != null) saucePan.SetActive(false);
        if (spatula != null) spatula.SetActive(false);
        if (microwave != null) microwave.SetActive(false);
        if (cuttingBoard != null) cuttingBoard.SetActive(false);
    }

    public void ShowFryingPan()
    {
        DeactivateAllTools();
        if (fryingPan != null) fryingPan.SetActive(true);
    }

    public void ShowSaucePan()
    {
        DeactivateAllTools();
        if (saucePan != null) saucePan.SetActive(true);
    }

    public void ShowSpatula()
    {
        DeactivateAllTools();
        if (spatula != null) spatula.SetActive(true);
    }

    public void ShowMicrowave()
    {
        DeactivateAllTools();
        if (microwave != null) microwave.SetActive(true);
    }

    public void ShowCuttingBoard()
    {
        DeactivateAllTools();
        if (cuttingBoard != null) cuttingBoard.SetActive(true);
    }
}
