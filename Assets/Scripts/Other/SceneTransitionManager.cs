using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager instance;

    [Header("Fade Overlay")]
    public Image fadeOverlay;
    public float fadeDuration = 1.5f;

    void Awake()
    {
        // Singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Hook event saat scene selesai dimuat
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Inisialisasi overlay jika sudah diassign
        if (fadeOverlay != null)
        {
            fadeOverlay.gameObject.SetActive(true);
            fadeOverlay.color = new Color(0, 0, 0, 1f);
        }
        else
        {
            Debug.LogWarning("FadeOverlay belum di-assign di inspector.");
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cari fadeOverlay ulang jika null
        if (fadeOverlay == null)
        {
            GameObject foundOverlay = GameObject.Find("FadeOverlay"); // nama persis
            if (foundOverlay != null)
            {
                fadeOverlay = foundOverlay.GetComponent<Image>();
            }
            else
            {
                Debug.LogWarning("FadeOverlay tidak ditemukan di scene: " + scene.name);
                return;
            }
        }

        // Mulai fade in saat scene selesai dimuat
        StartCoroutine(FadeInAfterLoad());
    }

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(DoSceneTransition(sceneName));
    }

    private IEnumerator DoSceneTransition(string sceneName)
    {
        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogError("Scene '" + sceneName + "' tidak ada dalam Build Settings!");
            yield break;
        }

        if (fadeOverlay == null)
        {
            Debug.LogWarning("FadeOverlay null, langsung pindah scene tanpa efek fade.");
            SceneManager.LoadScene(sceneName);
            yield break;
        }

        // Fade out
        fadeOverlay.gameObject.SetActive(true);
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeOverlay.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Pindah scene
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeInAfterLoad()
    {
        // Tunggu sedikit agar scene stabil
        yield return new WaitForSeconds(0.1f);

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            fadeOverlay.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Sembunyikan overlay setelah selesai fade
        fadeOverlay.color = new Color(0, 0, 0, 0);
        fadeOverlay.gameObject.SetActive(false);
    }
}
