using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuHandler : MonoBehaviour
{
    [Header("Set in Inspector or leave -1 to auto-find")]
    public int restartBuildIndex = -1; // set this in inspector to the index you noted

    // Restart the tour (load LeadershipCentreDownstairs again)
    public void OnRestartPressed()
    {
        if (restartBuildIndex >= 0 && restartBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(restartBuildIndex);
            return;
        }

        // Fallback: try to find the scene by name if index wasn't set
        string targetName = "LeadershipCentreDownstairs";
        int found = GetBuildIndexForSceneName(targetName);
        if (found >= 0)
        {
            SceneManager.LoadScene(found);
            return;
        }

        Debug.LogError($"CreditsMenuHandler: Could not load scene. restartBuildIndex={restartBuildIndex}, and scene '{targetName}' not found in Build Settings.");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
        Debug.Log("Quit pressed - will only close in build, not in Editor.");
    }

    int GetBuildIndexForSceneName(string sceneName)
    {
        int count = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < count; i++)
        {
            string path = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == sceneName) return i;
        }
        return -1;
    }
}
