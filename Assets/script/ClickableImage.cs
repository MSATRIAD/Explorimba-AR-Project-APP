using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableImage : MonoBehaviour, IPointerClickHandler
{
    [Tooltip("URL yang ingin dibuka saat gambar diklik")]
    public string url;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
        else
        {
            Debug.LogWarning("URL belum diatur untuk " + gameObject.name);
        }
    }
}