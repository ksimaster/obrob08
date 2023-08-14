using StarterAssets;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject menuButton;
    public StarterAssetsInputs input;
    public AutoSwitchDevices autoSwitchDevices;

    private void Awake()
    {
    }
    void Start()
    {
    }

    public void CollapseMenu()
    {
        gameObject.SetActive(false);
        if (!autoSwitchDevices.IsDesktop())
        {
            menuButton.SetActive(true);
        }
        input.SetCursorState(true);
    }
}
