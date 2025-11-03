using UnityEngine;
using UnityEngine.UIElements;

public class SettingsUIManager : MonoBehaviour
{
    private static SettingsUIManager _instance;
    public static SettingsUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SettingsUIManager is not initialized!");
            }
            return _instance;
        }
    }
    
    private UIDocument _uiDocument;
    private VisualElement _root;
    private Slider _slider;
    private Toggle _toggle;
    private Button _okButton;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        
        _uiDocument = GetComponent<UIDocument>();
        if (_uiDocument == null)
        {
            Debug.LogError("No UIDocument found on SettingsUIManager");
        }
        else
        {
            _root = _uiDocument.rootVisualElement;
            _slider = _uiDocument.rootVisualElement.Q<Slider>("Volume_Slider");
            _toggle = _uiDocument.rootVisualElement.Q<Toggle>("Mute_Toggle");
            _okButton = _uiDocument.rootVisualElement.Q<Button>("Ok_Button");

            _slider.RegisterValueChangedCallback(OnSliderValueChanged);
            _toggle.RegisterValueChangedCallback(OnToggleValueChanged);
            _okButton.RegisterCallback<ClickEvent>(_ => SetInvisible());
                        
            SetInvisible();
        }
    }

    public void SetVisible()
    {
        _root.RemoveFromClassList("hide");
        _slider.value = SoundManager.Instance.GetCurrentVolume();
        _toggle.value = SoundManager.Instance.IsMuted();
    }

    private void SetInvisible()
    {
        _root.AddToClassList("hide");
    }

    private void OnToggleValueChanged(ChangeEvent<bool> evt)
    {
        SoundManager.Instance.ToggleMute(evt.newValue);
    }

    private void OnSliderValueChanged(ChangeEvent<float> evt)
    {
        SoundManager.Instance.AdjustSoundVolume(evt.newValue);
    }
}