using UnityEngine;
using UnityEngine.InputSystem;

public class UIGameManager : MonoBehaviour
{
    public InputSystem_Actions inputs;
    public WindowManager wmanager = new WindowManager();

    private void Awake()
    {
        inputs = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.UI.Escape.performed += HideCurrentPanel;

        wmanager.OnElementAdded += OnElementAdded;
        wmanager.OnElementRemoved += OnElementRemoved;
    }

    private void OnDisable()
    {
        inputs.UI.Escape.performed -= HideCurrentPanel;

        wmanager.OnElementAdded -= OnElementAdded;
        wmanager.OnElementRemoved -= OnElementRemoved;

        inputs.Disable();
    }

    private void OnElementAdded(Window window)
    {
        window.window.SetActive(true);
        window.window.transform.SetAsLastSibling();
    }

    private void OnElementRemoved(Window window)
    {
        window.window.SetActive(false);
    }

    private void HideCurrentPanel(InputAction.CallbackContext context)
    {
        if (wmanager.Count > 0)
        {
            wmanager.Pop();
        }
    }

    public void BtnOpenPanel(GameObject panel)
    {
        if (panel == null) return;

        if (panel.activeSelf)
        {
            panel.transform.SetAsLastSibling();
            return;
        }

        Window window = new Window(panel);
        wmanager.Push(window);
    }

    public void PeekFromStack()
    {
        if (wmanager.Count > 0)
            Debug.Log(wmanager.Peek().window.name);
    }

    public void Count()
    {
        Debug.Log(wmanager.Count);
    }
}