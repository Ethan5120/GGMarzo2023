using UnityEngine;
using UnityEngine.UI;

public class FullScreenToggle : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;
    [Header("UI")]
    [SerializeField]Toggle toggle;

    void Start()
    {
        toggle.isOn = GM.isFullScreen;
    }

    public void FullScreen(bool is_fullScreen)
    {
        GM.isFullScreen = is_fullScreen;
        Screen.fullScreen = is_fullScreen;
        Debug.Log("FullScreen is" + is_fullScreen);
    }
}
