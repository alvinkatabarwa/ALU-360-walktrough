using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderWithFade : MonoBehaviour
{
    [Tooltip("Assign the FadeManager in this scene (optional). If empty, scene will load immediately.")]
    public FadeManager fadeManager;
    [Tooltip("Scene name to load (exactly as in Build Settings).")]
    public string sceneToLoad;

    // Call this from Button OnClick or events
    public void LoadScene()
    {
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogError("SceneLoaderWithFade: sceneToLoad is empty.");
            return;
        }

        if (fadeManager != null)
        {
            fadeManager.StartFadeOutAndAction(() => SceneManager.LoadScene(sceneToLoad));
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
