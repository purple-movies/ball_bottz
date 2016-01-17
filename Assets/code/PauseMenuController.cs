using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : BaseUiController
{
    [SerializeField] Button resetLevelButton;

    protected override void onStart()
    {
        base.onStart();
        resetLevelButton.onClick.RemoveAllListeners();
        resetLevelButton.onClick.AddListener(resetLevel);
    }

    void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(Application.loadedLevel);
        finish();
    }
}
