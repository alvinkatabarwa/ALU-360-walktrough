using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonHandler : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public FadeManager fadeManager;          // drag your FadeCanvas here
    public string sceneToLoad = "LeadershipCentreDownstairs";

    // Called by the Button OnClick
    public void OnStartPressed()
    {
        if (fadeManager != null)
        {
            fadeManager.StartFadeOutAndAction(() => LoadSceneByName(sceneToLoad));
        }
        else
        {
            LoadSceneByName(sceneToLoad);
        }
    }

    void LoadSceneByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("StartButtonHandler: sceneToLoad is empty.");
            return;
        }
        SceneManager.LoadScene(name);
    }
}
