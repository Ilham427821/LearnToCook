using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;      // UI panel tutorial
    public Text tutorialText;             // UI text di panel
    public PlayerTutor playerTutor;       // Drag GameObject Player ke sini

    private string[] messages = {
        "Gunakan tombol WASD untuk bergerak.",
        "Gunakan klik kanan tahan mouse untuk melihat sekitar.",
        "Tekan Enter untuk memulai permainan."
    };

    private int index = 0;

    void Start()
    {
        tutorialPanel.SetActive(true);
        tutorialText.text = messages[index];
        playerTutor.canMove = false; // Nonaktifkan gerakan saat tutorial aktif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            index++;

            if (index < messages.Length)
            {
                tutorialText.text = messages[index];
            }
            else
            {
                tutorialPanel.SetActive(false);
                playerTutor.canMove = true; // Aktifkan gerakan
            }
        }
    }
}
