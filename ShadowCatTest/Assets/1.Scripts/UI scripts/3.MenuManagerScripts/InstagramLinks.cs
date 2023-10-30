using UnityEngine;

public class InstagramLinks : MonoBehaviour
{
    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }
}
