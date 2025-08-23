using UnityEngine;
using UnityEngine.UI;

public class AutoSlider : MonoBehaviour
{
    public Sprite[] tutorialImages; // Masukkan 3 gambar tutorial di Inspector
    public Image imageHolder;       // Referensi ke UI Image tempat menampilkan gambar
    public Image[] ellipses;        // Referensi ke 3 lingkaran indikator
    public Color activeColor = Color.white;
    public Color inactiveColor = Color.gray;
    public float changeInterval = 3f; // ganti gambar setiap 3 detik

    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        ShowImage(currentIndex);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            currentIndex = (currentIndex + 1) % tutorialImages.Length;
            ShowImage(currentIndex);
            timer = 0f;
        }
    }

    void ShowImage(int index)
    {
        imageHolder.sprite = tutorialImages[index];

        for (int i = 0; i < ellipses.Length; i++)
        {
            ellipses[i].color = (i == index) ? activeColor : inactiveColor;
        }
    }
}
