using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class QuizPanelController : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] options = new string[4];
        public int correctIndex;
    }

    public TextMeshProUGUI questionIndicator;
    public TextMeshProUGUI questionName;
    public Button[] optionButtons;
    public GameObject bayanganPanel;
    public GameObject bayanganPanelGagal;
    public GameObject scanUIPanel;

    private List<Question> selectedQuestions;
    private int currentQuestionIndex = 0;
    private int correctAnswers = 0;
    public Button buttonScanLagi;

    void Start()
    {
        buttonScanLagi.onClick.AddListener(ScanLagi);
    }
public void ReceiveTarget(string targetName)
    {
        Debug.Log("[QuizPanel] Menerima target: " + targetName);

        selectedQuestions = GetQuestionsByName(targetName.ToLower());
        if (selectedQuestions == null || selectedQuestions.Count == 0)
        {
            questionName.text = $"Tidak ada soal untuk objek '{targetName}'.";
        }
        else
        {
            currentQuestionIndex = 0;
            correctAnswers = 0;
            DisplayQuestion();
        }
    }

    void DisplayQuestion()
    {
        if (selectedQuestions == null || selectedQuestions.Count == 0) return;

        var q = selectedQuestions[currentQuestionIndex];
        questionIndicator.text = $"Soal {currentQuestionIndex + 1} dari {selectedQuestions.Count}";
        questionName.text = q.questionText;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;
            optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == selectedQuestions[currentQuestionIndex].correctIndex)
        {
            correctAnswers++;
        }

        currentQuestionIndex++;

        if (currentQuestionIndex >= selectedQuestions.Count)
        {
            if (correctAnswers >= 2)
            {
                bayanganPanel.SetActive(true);
            }
            else
            {
                StartCoroutine(ShowGagalThenRestart());
            }
        }
        else
        {
            DisplayQuestion();
        }
    }

    IEnumerator ShowGagalThenRestart()
    {
        bayanganPanelGagal.SetActive(true);
        yield return new WaitForSeconds(5f);
        bayanganPanelGagal.SetActive(false);
        currentQuestionIndex = 0;
        correctAnswers = 0;
        DisplayQuestion();
    }

    public void ScanLagi()
    {

        this.gameObject.SetActive(false); // Tutup panel kuis
        scanUIPanel.SetActive(true);      // Tampilkan kembali scan panel

        bayanganPanel.SetActive(false);        // Tutup panel berhasil
        bayanganPanelGagal.SetActive(false);   // Tutup panel gagal
    }


    List<Question> GetQuestionsByName(string name)
    {
        List<Question> list = new List<Question>();

        if (name == "badakjawa2")
        {
            list.Add(new Question { questionText = "Badak Jawa hanya ditemukan di mana?", options = new[] { "Taman Nasional Gunung Halimun Salak", "Taman Nasional Ujung Kulon", "Pulau Bawean", "Nusa Tenggara Timur" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Ciri khas Badak Jawa adalah?", options = new[] { "Memiliki dua cula panjang", "Kulit tebal berlipat seperti pelindung baja", "Berbulu merah karat", "Memiliki sayap kecil" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Badak Jawa biasanya hidup dengan cara?", options = new[] { "Berkelompok besar", "Soliter (sendiri)", "Hidup di air", "Terbang di udara" }, correctIndex = 1 });
        }
        else if (name == "anjingjagag2")
        {
            list.Add(new Question { questionText = "Anjing Ajag biasanya hidup berkelompok sampai berapa ekor?", options = new[] { "2 ekor", "5 ekor", "12 ekor", "20 ekor" }, correctIndex = 2 });
            list.Add(new Question { questionText = "Anjing Ajag berkomunikasi dengan cara?", options = new[] { "Menggonggong keras", "Melalui siulan khas", "Mengibaskan ekor", "Menari" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Anjing Ajag berburu hewan apa?", options = new[] { "Rusa dan babi hutan", "Ikan dan katak", "Burung dan kelinci", "Serangga dan buah" }, correctIndex = 0 });
        }
        else if (name == "rusabawean")
        {
            list.Add(new Question { questionText = "Rusa Bawean adalah hewan endemik yang hanya ditemukan di?", options = new[] { "Pulau Bawean", "Pulau Jawa", "Pulau Sumatra", "Pulau Kalimantan" }, correctIndex = 0 });
            list.Add(new Question { questionText = "Rusa Bawean aktif pada waktu?", options = new[] { "Siang hari", "Malam hari (nokturnal)", "Pagi hari", "Sepanjang hari" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Ciri khas bulu Rusa Bawean adalah?", options = new[] { "Berwarna putih seluruh tubuh", "Cokelat gelap dengan bintik putih di leher dan perut", "Hitam dan tebal", "Merah cerah" }, correctIndex = 1 });
        }
        else if (name == "komodo2")
        {
            list.Add(new Question { questionText = "Komodo adalah kadal terbesar di dunia dengan panjang bisa mencapai?", options = new[] { "1 meter", "2 meter", "3 meter", "4 meter" }, correctIndex = 2 });
            list.Add(new Question { questionText = "Komodo hidup di habitat?", options = new[] { "Sabana dan hutan tropis", "Gurun pasir", "Pegunungan salju", "Lautan" }, correctIndex = 0 });
            list.Add(new Question { questionText = "Air liur Komodo mengandung?", options = new[] { "Racun", "Air bersih", "Enzim pencernaan", "Pewarna alami" }, correctIndex = 0 });
        }
        else if (name == "kantongsemar")
        {
            list.Add(new Question { questionText = "Kantong Semar menangkap apa sebagai sumber nutrisi tambahan?", options = new[] { "Burung", "Serangga", "Ikan", "Tikus" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Bentuk daun Kantong Semar seperti?", options = new[] { "Jarum tajam", "Kantong atau perangkap", "Bulat seperti bola", "Pipih dan lebar" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Kantong Semar mencerna mangsa dengan?", options = new[] { "Air laut", "Enzim di dalam kantong", "Sinar matahari", "Angin" }, correctIndex = 1 });
        }
        else if (name == "acungjangkung")
        {
            list.Add(new Question { questionText = "Warna bunga Acung Jangkung adalah?", options = new[] { "Merah muda", "Ungu tua", "Kuning cerah", "Putih" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Bau bunga Acung Jangkung menyerupai?", options = new[] { "Bunga mawar", "Bangkai", "Buah manis", "Daun segar" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Acung Jangkung tumbuh dari?", options = new[] { "Umbi besar", "Batang kayu", "Daun kecil", "Akar gantung" }, correctIndex = 0 });
        }
        else if (name == "cendrawasih")
        {
            list.Add(new Question { questionText = "Burung Cenderawasih terkenal dengan?", options = new[] { "Suara keras", "Bulu warna-warni mencolok", "Paruh panjang", "Sayap besar" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Cenderawasih hidup di?", options = new[] { "Gurun pasir", "Hutan hujan tropis dataran rendah Papua", "Pegunungan salju", "Lautan" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Makanan Cenderawasih adalah?", options = new[] { "Daging", "Buah, serangga, dan nektar", "Rumput", "Ikan" }, correctIndex = 1 });
        }
        else if (name == "beruangmadu2")
        {
            list.Add(new Question { questionText = "Beruang Madu adalah beruang yang paling?", options = new[] { "Terbesar di dunia", "Terkecil di dunia", "Tercepat di dunia", "Terberat di dunia" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Beruang Madu suka menjilat?", options = new[] { "Air", "Madu dan serangga", "Daun", "Batu" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Beruang Madu aktif pada?", options = new[] { "Siang hari", "Malam hari", "Pagi hari", "Sepanjang hari" }, correctIndex = 1 });
        }
        else if (name == "raflessia")
        {
            list.Add(new Question { questionText = "Padma Raksasa terkenal sebagai bunga?", options = new[] { "Terbesar di dunia", "Terkecil di dunia", "Paling harum", "Paling cepat tumbuh" }, correctIndex = 0 });
            list.Add(new Question { questionText = "Bau bunga Padma Raksasa seperti?", options = new[] { "Harum bunga", "Daging membusuk", "Buah manis", "Daun segar" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Padma Raksasa hidup menempel pada?", options = new[] { "Batu", "Tumbuhan inang", "Tanah", "Air" }, correctIndex = 1 });
        }
        else if (name == "bangkairaksasa")
        {
            list.Add(new Question { questionText = "Bangkai Raksasa memiliki bunga setinggi?", options = new[] { "1 meter", "2 meter", "Lebih dari 3 meter", "5 meter" }, correctIndex = 2 });
            list.Add(new Question { questionText = "Aroma bunga Bangkai Raksasa seperti?", options = new[] { "Harum bunga", "Bangkai busuk", "Buah manis", "Daun segar" }, correctIndex = 1 });
            list.Add(new Question { questionText = "Setelah mekar, bunga Bangkai Raksasa akan layu dalam waktu?", options = new[] { "1-2 hari", "1 minggu", "1 bulan", "1 tahun" }, correctIndex = 0 });
        }

        return list;
    }
}
