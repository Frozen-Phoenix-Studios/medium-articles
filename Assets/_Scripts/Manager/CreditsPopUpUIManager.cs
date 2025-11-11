using UnityEngine;
using UnityEngine.UIElements;

public class CreditsPopUpUIManager : MonoBehaviour
{
    private static CreditsPopUpUIManager _instance;

    public static CreditsPopUpUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("CreditsPopUpUIManager is null");
            }
            return _instance;
        }
    }
    
    private UIDocument _uiDocument;
    private VisualElement _root;
    private Button _closeButton;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        
        _uiDocument = GetComponent<UIDocument>();
        if (_uiDocument == null)
        {
            Debug.LogError("No UIDocument found on CreditsPopUpUIManager.");
        }

        _root = _uiDocument.rootVisualElement;
        _closeButton = _uiDocument.rootVisualElement.Q<Button>("Close_Button");
        _closeButton.RegisterCallback<ClickEvent>(_ => SetInvisible());
        
        SetInvisible();
    }
    
    public void SetVisible()
    {
        _root.RemoveFromClassList("hide");
    }
    
    private void SetInvisible()
    {
        _root.AddToClassList("hide");
    }
}