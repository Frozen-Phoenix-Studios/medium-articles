using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Button _playButton;
    private Button _settingsButton;
    private Button _creditsButton;
    
    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        if (_uiDocument == null)
        {
            Debug.LogError("No UIDocument found on MainMenuManager");
        }
        
        _playButton = _uiDocument.rootVisualElement.Q<Button>("Play_Button");
        _playButton.RegisterCallback<ClickEvent>(LoadGameScene);

        
        _settingsButton = _uiDocument.rootVisualElement.Q<Button>("Settings_Button");
        _settingsButton.RegisterCallback<ClickEvent>(ShowSettingsUI);
        
        _creditsButton = _uiDocument.rootVisualElement.Q<Button>("Credits_Button");
        _creditsButton.RegisterCallback<ClickEvent>(ShowCreditsUI);
        
    }

    private void ShowCreditsUI(ClickEvent evt)
    {
        CreditsUIManager.Instance.SetVisible();
    }

    private void ShowSettingsUI(ClickEvent evt)
    {
        SettingsUIManager.Instance.SetVisible();
    }

    private void LoadGameScene(ClickEvent evt)
    {
        SceneManager.LoadScene("Game");
    }
}
//
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UIElements;
//
// public class MainMenuManager : MonoBehaviour
// {
//     private UIDocument _uiDocument;
//     private VisualElement _playButton;
//
//     private void Awake()
//     {
//         _uiDocument = GetComponent<UIDocument>();
//         if (_uiDocument == null)
//             Debug.LogError("No UIDocument found on MainMenuManager");
//         
//         _playButton = _uiDocument.rootVisualElement.Q<Button>("PlayButton");
//         if (_playButton == null)
//             Debug.LogError("No PlayButton found on MainMenuManager");
//         
//         _playButton.RegisterCallback<ClickEvent>(HandlePlayButtonClicked);
//
//     }
//
//     private void HandlePlayButtonClicked(ClickEvent evt) => SceneManager.LoadScene("Game");
// }
//




