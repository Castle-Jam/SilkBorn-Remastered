using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;

    private VisualElement _root;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _root = uiDocument.rootVisualElement;

        var playBtn = _root.Q<VisualElement>("Start");
        playBtn.RegisterCallback<ClickEvent>(OnClickEvent);

        var quitBtn = _root.Q<VisualElement>("Quit");
        quitBtn.RegisterCallback<ClickEvent>(QuitEvent);
    }

    // Update is called once per frame
    private static void OnClickEvent(ClickEvent _)
    {
        Debug.Log("Play Button Clicked");
        SceneManager.LoadScene("Tutorial");
    }

    private static void QuitEvent(ClickEvent _)
    {
        Debug.Log("Quit Button Clicked");
        Application.Quit();
    }
}
