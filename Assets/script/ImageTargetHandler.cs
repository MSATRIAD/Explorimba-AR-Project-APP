using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;

public class InfoTargetHandler : MonoBehaviour
{
    public GameObject scanUIPanel;
    public Button buttonInformasi;
    public GameObject infoPanel;
    public TextMeshProUGUI teksInformasi;
    public UnityEngine.UI.Image infoImage;
    public AudioSource suaraObjek;

    public Sprite gambarInfo; // satu gambar tetap

    private string informasi = "";
    public string detectedName;
    public QuizPanelController quizPanel;
    private void Start()
    {
        buttonInformasi.gameObject.SetActive(false);

        var observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            string namaTarget = behaviour.TargetName;
            SetInformasi(namaTarget);
            if (quizPanel != null)
            {
                quizPanel.ReceiveTarget(namaTarget.ToLower()); // ganti HandleTargetDetected
            }
            buttonInformasi.gameObject.SetActive(true);
            if (suaraObjek != null && !suaraObjek.isPlaying){
            {
                suaraObjek.Play();
            }
        }
        else
        {
            if (suaraObjek != null && suaraObjek.isPlaying)
            {
                suaraObjek.Stop();
            }
        }
            buttonInformasi.onClick.RemoveAllListeners();
            buttonInformasi.onClick.AddListener(() =>
            {
                scanUIPanel.SetActive(false);
                infoPanel.SetActive(true);
                teksInformasi.text = informasi;
                infoImage.sprite = gambarInfo;
            });
        }
        else
        {
            buttonInformasi.gameObject.SetActive(false);
        }
    }

    private void SetInformasi(string namaTarget)
    {
        switch (namaTarget)
        {
            case "badakjawa2":
                detectedName = "badak";
         informasi = @"Badak Jawa
Rhinoceros sondaicus
Javan Rhinoceros

1. Klasifikasi dan Morfologi
Klasifikasi Ilmiah:
Ordo: Perissodactyla
Famili: Rhinocerotidae
Genus: Rhinoceros
Spesies: R. sondaicus

Ciri Fisik:
Cula tunggal (pada jantan) sepanjang 20–25 cm; betina sering tidak memiliki cula.
Berat 900–2.300 kg, tinggi 1,2–1,7 m, panjang tubuh 3–3,4 m.
Kulit abu-abu dengan lipatan tebal seperti pelindung baja.
Bibir atas runcing, kaki berjari tiga, dan kuku besar untuk berjalan di lahan berlumpur.

2. Populasi dan Persebaran
Habitat Terakhir: Taman Nasional Ujung Kulon (TNUK), Banten, Indonesia.
Populasi: 74–77 individu (data 2022–2023).
Status: Kritis (Critically Endangered, IUCN).
Dulu tersebar: Dari India, Myanmar, Thailand, Vietnam, Sumatra, dan Jawa.
Kini: Punah di luar Jawa, termasuk subspesies annamiticus (Vietnam, 2010).

3. Ancaman dan Tantangan
Perburuan: Cula bernilai tinggi (hingga $30.000/kg) di pasar gelap.
Hilangnya habitat: Tanaman langkap mendominasi dan mengurangi makanan alami.
Masalah genetik: Populasi kecil → inbreeding → penurunan keragaman genetik.
Kritik konservasi: Anggaran lebih banyak terserap untuk infrastruktur, bukan aksi lapangan.

4. Perilaku dan Ekologi
Pola makan: Tumbuhan (browser) – ranting, daun, dan semak.
Sifat: Soliter; hanya bersama saat kawin atau mengasuh anak.
Aktivitas: Gemar berkubang untuk mendinginkan tubuh.
Reproduksi: Kehamilan 15–16 bulan, anak tinggal dengan induk hingga 2 tahun.

5. Upaya Konservasi
TNUK: Situs Warisan Dunia UNESCO.
Pemantauan: Kamera jebak & patroli intensif.
JRSCA: Javan Rhino Study and Conservation Area untuk menambah habitat (menuai pro-kontra).
Kolaborasi: LSM (WWF, YABI) dan masyarakat lokal dilibatkan dalam konservasi.

Fakta Unik
Salah satu spesies badak paling langka dan misterius di dunia.
Tidak ada satu pun yang dipelihara di kebun binatang.
Sulit dipelajari karena habitatnya terpencil dan jumlahnya sangat sedikit.";

                break;

            case "beruangmadu2":
            detectedName = "beruang";
                informasi = @"Beruang Madu  
Helarctos malayanus  
Sun Bear

1. Klasifikasi dan Ciri Fisik  
Klasifikasi Ilmiah:  
Ordo: Carnivora  

Famili: Ursidae  

Genus: Helarctos  

Spesies: H. malayanus  

Ciri Fisik:  
Ukuran kecil: Panjang ±1,4 m, tinggi ±70 cm, berat 50–65 kg.  
Bulu hitam mengilap dengan tanda berwarna oranye/krem di dada (seperti matahari terbit).  
Lidah panjang (>25 cm) untuk menjilat madu dan serangga.  
Kuku melengkung dan telapak kaki tanpa bulu → memanjat pohon sangat baik.

2. Habitat dan Persebaran  
Habitat: Hutan hujan tropis (primer dan sekunder), juga terlihat di perkebunan dan sekitar pemukiman.  
Persebaran: Sumatra, Kalimantan, Semenanjung Malaya, Indocina, hingga Tiongkok Selatan.  
Sarang: Dibuat di atas pohon dari ranting dan daun.

3. Perilaku dan Ekologi  
Aktif: Nokturnal (malam hari), tapi bisa aktif siang hari di penangkaran.  
Sifat: Soliter, kecuali induk dengan anak.  
Jelajah: Bisa menempuh 8 km/hari mencari makanan.  
Makanan: Omnivora – buah (durian, cempedak), madu, rayap, semut, dan hewan kecil.  
Peran ekologis: Penyebar biji yang penting bagi regenerasi hutan.

4. Ancaman dan Konservasi  
Ancaman:  
Deforestasi: Konversi hutan jadi kebun sawit/karet.  
Perburuan: Diambil empedunya untuk pengobatan tradisional.  
Konflik manusia: Sering merusak kebun warga.  

Konservasi:  
Dilindungi: CITES Appendix I, UU No. 5 Tahun 1990.  
Pemantauan: Kamera jebak dan drone thermal (contoh di Agam, Sumatera Barat).  
Edukasi: Sosialisasi ke masyarakat untuk mengurangi konflik.

Fakta Unik  
Beruang terkecil di dunia.  
Tidak berhibernasi karena makanan tersedia sepanjang tahun.  
Anak beruang lahir tanpa bulu dan sangat tergantung pada induk.  
Menjadi maskot resmi Kota Balikpapan (Kalimantan Timur) dan Provinsi Bengkulu.";
                break;
            case "anjingjagag2":
            detectedName = "ajag";
informasi = @"Anjing Ajag  
Cuon alpinus  
Dhole, Asiatic Wild Dog

1. Klasifikasi dan Ciri Fisik  
Klasifikasi Ilmiah:  
Ordo: Carnivora  

Famili: Canidae  

Genus: Cuon  

Spesies: Cuon alpinus  

Ciri Fisik:  
Ukuran: Panjang tubuh 90–110 cm, tinggi bahu 40–50 cm, berat 10–21 kg.  
Bulu: Rata-rata berwarna merah karat atau cokelat kemerahan dengan bagian perut lebih pucat, ujung ekor berwarna hitam.  
Fisik Khas: Lebih ramping dari serigala, dengan telinga bulat dan kaki panjang. Tidak menggonggong, melainkan melolong, menjerit, dan bersiul sebagai bentuk komunikasi.  
Gigi: Memiliki gigi premolar tambahan (jumlah gigi total 42), berbeda dari anjing lainnya.

2. Habitat dan Persebaran  
Habitat:  
Menyukai hutan lebat tropis dan subtropis, padang rumput berhutan, dan daerah pegunungan hingga ketinggian 4.000 m.  
Umumnya ditemukan di area berhutan yang memiliki pasokan mangsa cukup, terutama rusa dan babi hutan.  

Persebaran:  
Tersebar di Asia Selatan dan Asia Tenggara, termasuk India, Nepal, Bhutan, Bangladesh, Myanmar, Thailand, Laos, Kamboja, Vietnam, Malaysia, dan Indonesia (Sumatra dan Jawa).  
Populasi menurun tajam di sebagian besar wilayah akibat hilangnya habitat dan tekanan manusia.

3. Perilaku dan Ekologi  
Aktivitas:  
Sosial: Hidup dalam kelompok keluarga berjumlah 5–12 ekor, kadang hingga 30 ekor.  
Berburu: Pemburu aktif di siang hari (diurnal). Mengandalkan kerja sama kelompok untuk menjatuhkan mangsa besar.  
Komunikasi: Tidak menggonggong, tapi menggunakan suara siulan khas untuk berkoordinasi saat berburu.

Makanan:  
Karnivora. Mangsa utama termasuk rusa, kijang, babi hutan, dan kadang hewan kecil seperti kelinci.  
Juga dapat memakan buah-buahan bila mangsa langka.

Reproduksi:  
Musim kawin bervariasi tergantung wilayah.  
Masa kehamilan 60–63 hari. Melahirkan 4–6 anak dalam sarang bawah tanah.  
Anak disusui hingga 2 bulan, dan mulai ikut berburu pada usia 6 bulan.

4. Ancaman dan Konservasi  
Ancaman Utama:  
Hilangnya Habitat: Konversi hutan menjadi pertanian dan perkebunan, terutama di Sumatra dan Jawa.  
Penurunan Mangsa: Perburuan mangsa alami menyebabkan kelangkaan makanan.  
Konflik Manusia: Dituduh memangsa ternak dan kadang dibunuh oleh petani.  
Penyakit: Rentan terhadap penyakit dari anjing peliharaan seperti rabies dan distemper.

Status Konservasi:  
Dinyatakan Endangered (Terancam Punah) oleh IUCN Red List.  
Dilindungi penuh di berbagai negara termasuk Indonesia melalui UU No. 5/1990 tentang Konservasi Sumber Daya Alam Hayati.

Upaya Konservasi:  
Pemantauan dengan kamera jebak di habitat seperti Taman Nasional Gunung Halimun Salak dan Taman Nasional Ujung Kulon.  
Rehabilitasi kawasan hutan dan perlindungan satwa mangsa.  
Edukasi masyarakat dan penegakan hukum terhadap perburuan liar.

Fakta Unik  
Salah satu karnivora sosial paling efisien di Asia, mampu berburu mangsa yang jauh lebih besar dari ukuran tubuhnya.  
Dikenal sebagai ""whistling hunter"" karena suaranya yang unik seperti siulan.  
Tidak menggonggong, tidak bersuara seperti anjing biasa.  
Jejak kakinya sering disalahartikan sebagai milik anjing atau serigala, padahal bentuknya lebih oval dan halus.";

                break;
            case "rusabawean":
            detectedName = "rusa";
informasi = @"Rusa Bawean  
Axis kuhlii  
Bawean Deer

1. Klasifikasi dan Ciri Fisik  
Klasifikasi Ilmiah:  
Ordo: Artiodactyla  

Famili: Cervidae  

Genus: Axis  

Spesies: Axis kuhlii  

Ciri Fisik:  
Ukuran: Rusa kecil, panjang tubuh 140 cm, tinggi bahu sekitar 60–70 cm, dan berat 50–60 kg.  
Bulu: Cokelat tua keabu-abuan dengan bagian perut lebih terang. Anak rusa lahir dengan bercak putih.  
Tanduk: Hanya jantan yang bertanduk, bercabang tiga (seperti rusa timor), dengan panjang sekitar 30 cm.  
Mata & Telinga: Bermata besar dan bertelinga lebar, adaptasi terhadap lingkungan hutan yang gelap.  
Ekor: Pendek, berwarna keputihan di bagian bawah dan sering diangkat saat alarm atau terancam.

2. Habitat dan Persebaran  
Habitat:  
Menyukai hutan sekunder, semak belukar, dan kawasan perbukitan.  
Aktif terutama di malam hari (nokturnal) dan pada waktu senja atau pagi hari (krepuskular).  
Membuat jalur tetap (rute jelajah) di dalam hutan untuk mencari makan.

Persebaran:  
Endemik Pulau Bawean, Kabupaten Gresik, Jawa Timur.  
Total habitat diperkirakan hanya sekitar 45 km², menjadikannya salah satu rusa paling terbatas distribusinya di dunia.

3. Perilaku dan Ekologi  
Aktivitas:  
Soliter atau hidup berpasangan. Jantan bersifat teritorial, terutama saat musim kawin.  
Pemalu dan waspada, jarang terlihat secara langsung dan lebih sering terekam melalui kamera jebak.  
Menunjukkan perilaku menggali tanah untuk mencari garam mineral.

Makanan:  
Herbivora—memakan dedaunan, tunas muda, buah, dan rumput.  
Juga mengonsumsi kulit pohon dan tumbuhan semak saat musim kemarau.

Reproduksi:  
Musim kawin tidak terlalu jelas, tetapi anak biasanya lahir menjelang musim hujan.  
Masa kehamilan 6–7 bulan, melahirkan 1 anak per kelahiran.  
Anak rusa disembunyikan di semak-semak dan akan diasuh induk hingga mandiri dalam beberapa bulan.

4. Ancaman dan Konservasi  
Ancaman Utama:  
Kehilangan Habitat: Konversi hutan menjadi kebun dan permukiman di Pulau Bawean.  
Populasi Kecil: Diperkirakan hanya sekitar 200–300 individu tersisa, menyebabkan rawan inbreeding.  
Perburuan Liar: Meski sudah dilindungi, perburuan masih terjadi, terutama untuk daging atau karena konflik dengan petani.

Status Konservasi:  
Critically Endangered (Kritis) menurut IUCN Red List.  
Dilindungi penuh oleh hukum Indonesia (UU No. 5 Tahun 1990 dan PP No. 7 Tahun 1999).  
Terdaftar di CITES Appendix I (tidak boleh diperdagangkan secara internasional).

Upaya Konservasi:  
Monitoring populasi secara rutin dengan kamera jebak oleh BKSDA dan LSM.  
Pendidikan dan pelibatan masyarakat lokal dalam upaya konservasi (misalnya melalui program konservasi berbasis masyarakat).  
Pembangunan Kawasan Suaka Margasatwa Bawean sebagai zona perlindungan utama.  
Penelitian genetik dan reproduksi untuk mencegah kepunahan.

Fakta Unik  
Rusa Bawean dijuluki ""Putri Bawean"" karena keanggunannya dan statusnya yang langka.  
Salah satu mamalia paling terisolasi di dunia karena hidup hanya di satu pulau kecil.  
Tidak ditemukan di kebun binatang internasional manapun—upaya pelestariannya hanya dilakukan in-situ (di alam aslinya).  
Populasi sangat sensitif terhadap gangguan manusia dan perubahan lingkungan.";

                break;
            case "komodo2":
            detectedName = "komodo";
informasi = @"Komodo/Varanus komodoensis

1. Klasifikasi dan Ciri Fisik
Klasifikasi Ilmiah:
Ordo: Squamata

Famili: Varanidae

Genus: Varanus

Spesies: Varanus komodoensis

Ciri Fisik:
Ukuran: Panjang tubuh mencapai 2–3 meter, berat rata-rata 70–90 kg, bahkan bisa lebih dari 100 kg pada jantan dewasa.
Kulit: Bersisik kasar, berwarna cokelat keabu-abuan atau kehitaman.
Lidah: Panjang dan bercabang seperti ular, digunakan untuk mendeteksi bau menggunakan organ Jacobson.
Gigi: Tajam dan bergerigi, mirip gigi hiu, cocok untuk mencabik daging.
Kelenjar Racun: Mengandung kelenjar yang menghasilkan bisa (venom) yang menyebabkan pendarahan dan menurunkan tekanan darah mangsa.
Indra: Penglihatan dan penciuman tajam, dapat mencium bangkai dari jarak 4–9 km.

2. Habitat dan Persebaran
Habitat:
Menyukai habitat sabana kering, hutan monsun tropis, semak belukar, dan kawasan berbatu di daerah pesisir.
Komodo adalah satwa endemik Kepulauan Nusa Tenggara Timur, Indonesia.

Persebaran:
Hanya ditemukan di beberapa pulau: Komodo, Rinca, Padar, Gili Motang, dan sebagian kecil Flores.
Sebagian besar populasi berada di dalam kawasan Taman Nasional Komodo, yang merupakan Situs Warisan Dunia UNESCO.

3. Perilaku dan Ekologi
Aktivitas:
Diurnal (aktif di siang hari), namun dapat aktif malam hari dalam kondisi tertentu.
Umumnya soliter, kecuali saat makan, kawin, atau bertarung memperebutkan pasangan.
Komodo dewasa bersifat teritorial dan agresif terhadap individu lain.

Makanan:
Karnivora dan scavenger (pemakan bangkai). Memakan rusa, babi hutan, kerbau, burung, dan bahkan sesama komodo.
Anak komodo sering memakan serangga, kadal kecil, dan hewan kecil lainnya.

Reproduksi:
Musim kawin: Mei–Agustus.
Masa inkubasi telur: 7–9 bulan. Betina bertelur 15–30 butir dalam sarang tanah atau lubang bekas sarang megapoda.
Anak komodo menetas sekitar Maret–April, dan langsung memanjat pohon untuk menghindari pemangsa (termasuk komodo dewasa).
Komodo mampu berkembang biak secara partenogenesis (tanpa pejantan), meskipun sangat jarang terjadi.

4. Ancaman dan Konservasi
Ancaman Utama:
Fragmentasi habitat akibat pembangunan dan aktivitas manusia.
Penurunan populasi mangsa alami seperti rusa timor dan babi hutan.
Perubahan iklim: Kenaikan suhu dan kekeringan ekstrem berdampak pada kelangsungan hidup telur dan vegetasi.
Pariwisata berlebih dan gangguan manusia berpotensi menurunkan kualitas habitat alami.

Status Konservasi:
Endangered (Terancam Punah) menurut IUCN Red List.
Dilindungi penuh oleh hukum Indonesia (UU No. 5 Tahun 1990) dan CITES Appendix I.

Upaya Konservasi:
Taman Nasional Komodo (TNK): Perlindungan ekosistem, pengaturan kunjungan wisata, patroli, dan riset berkelanjutan.
Pemantauan populasi menggunakan teknologi seperti kamera jebak, chip tagging, dan pemetaan sarang.
Pendidikan lingkungan bagi masyarakat lokal dan pelibatan dalam ekowisata berkelanjutan.
Penangkaran terbatas dilakukan di beberapa kebun binatang untuk cadangan genetik.

Fakta Unik
Kadal terbesar di dunia, satu-satunya kadal yang berburu mangsa besar secara aktif.
Mampu berlari hingga 20 km/jam dalam jarak pendek dan berenang antar pulau.
Daya cengkeram dan gigitan sangat kuat, ditambah bisa racun membuat mangsa mati perlahan jika tidak langsung terbunuh.
Diperkirakan telah hidup sejak zaman Pleistosen dan disebut sebagai ""naga terakhir di dunia"".";

                break;
            case "cendrawasih":
            detectedName = "cendrawasih";
informasi = @"Burung cendrawasih

1. Klasifikasi dan Ciri Fisik
Klasifikasi Ilmiah (Umum untuk genus Paradisaea):
Ordo: Passeriformes

Famili: Paradisaeidae

Genus: Paradisaea (salah satu dari beberapa genus)

Contoh Spesies: Paradisaea apoda (Cendrawasih kuning besar)

Ciri Fisik:
Ukuran: Panjang tubuh 30–43 cm tergantung spesies.
Bulu: Jantan memiliki bulu cerah dan memikat seperti kuning emas, merah marun, hijau zamrud, dan putih bersih.
Ekor: Jantan sering memiliki ekor panjang atau hiasan bulu menjuntai sebagai bagian dari atraksi kawin.
Paruh: Tajam dan sedikit melengkung, berwarna biru atau hitam tergantung spesies.
Dimorfisme Seksual: Sangat jelas, di mana betina berwarna lebih kusam dan tidak memiliki hiasan bulu mencolok.

2. Habitat dan Persebaran
Habitat:
Hutan hujan tropis dataran rendah dan pegunungan, biasanya di daerah terpencil dan sulit dijangkau manusia.
Sarang dibangun di cabang pohon tinggi atau semak rimbun.

Persebaran:
Endemik di wilayah Papua (Indonesia dan Papua Nugini), termasuk pulau-pulau seperti Misool, Waigeo, dan Aru.
Beberapa spesies juga ditemukan di Kepulauan Maluku bagian selatan.

3. Perilaku dan Ekologi
Aktivitas:
Diurnal (aktif siang hari), sangat aktif saat pagi untuk mencari makan dan menunjukkan atraksi kawin.
Jantan memamerkan bulu melalui tarian kawin di ""arena"" khusus untuk menarik betina.

Makanan:
Omnivora, terutama memakan buah-buahan, serangga kecil, dan nektar.
Beberapa spesies juga memakan arthropoda kecil atau katak pohon.

Reproduksi:
Betina memilih jantan berdasarkan atraksi visual dan suara.
Setelah kawin, betina membangun sarang dan mengerami telur sendirian.
Jumlah telur: 1–3 butir, dierami selama 15–20 hari.

4. Ancaman dan Konservasi
Ancaman Utama:
Perburuan liar untuk bulu (meskipun sekarang menurun karena perlindungan hukum).
Perdagangan satwa liar ilegal, terutama spesimen jantan yang menarik.
Hilangnya habitat akibat pembalakan hutan dan konversi lahan.
Fragmentasi populasi karena isolasi geografis dan gangguan manusia.

Status Konservasi:
Beberapa spesies tergolong Hampir Terancam (Near Threatened) hingga Rentan (Vulnerable) menurut IUCN.
Dilindungi oleh UU No. 5 Tahun 1990 dan CITES Appendix II (beberapa spesies Appendix I).

Upaya Konservasi:
Cagar Alam dan Taman Nasional: seperti TN Lorentz dan Pegunungan Cyclops.
Pelestarian budaya lokal: beberapa komunitas adat melarang perburuan cendrawasih.
Edukasi dan ekowisata: meningkatkan kesadaran dan ekonomi lokal melalui wisata burung.
Program penangkaran terbatas di lembaga konservasi.

Fakta Unik
Cendrawasih dikenal sebagai ""Bird of Paradise"" karena keindahannya yang luar biasa.
Jantan memiliki tarian dan nyanyian khas yang berbeda antar spesies.
Bulu cendrawasih pernah digunakan dalam hiasan kepala suku dan upacara adat.
Tarian jantan bisa berlangsung selama berjam-jam, bahkan berhari-hari untuk memikat betina.
Burung cendrawasih menjadi simbol Provinsi Papua Barat dan tampil pada lambang daerah.";

                break;
            case "raflessia":
            detectedName = "raflessia";
informasi = @"Rafflesia arnoldii: Bunga Langka yang Dijuluki ""Bunga Terbesar di Dunia""

1. Klasifikasi dan Ciri Fisik
Klasifikasi Ilmiah:

Genus: Rafflesia

Spesies: R. arnoldii

Ditemukan pertama kali oleh Sir Thomas Stamford Raffles dan Dr. Joseph Arnold di Sumatra tahun 1818.

Ciri Khas:

Diameter bunga mencapai 91 cm–1 meter, dengan berat hingga 10 kg.
Warna: Kelopak merah hati dengan bintik putih, mengeluarkan aroma daging busuk untuk menarik lalat penyerbuk.
Tidak memiliki akar, batang, atau daun. Hidup sebagai parasit obligat pada tanaman inang (Tetrastigma, sejenis anggur hutan).

2. Habitat dan Persebaran
Lokasi:

Sumatera Barat: Cagar Alam Batang Palupuh (3,4 hektar), Agam, Bukit Nak Dingin di Sitingkai.
Kalimantan Barat: Gunung Poteng, Singkawang.
Juga ditemukan di Malaysia, Filipina, dan Thailand.

Populasi:

Di Batang Palupuh, 12 individu mekar periode Januari–Mei 2025.
Di Gunung Poteng, 9–10 individu tercatat musim mekar terakhir.

3. Siklus Hidup dan Perilaku Unik
Masa Mekar: 5–7 hari saja, setelah itu membusuk.

Proses Pertumbuhan:

Kuncup membutuhkan 9–12 bulan untuk matang sebelum mekar.
Hanya 20% kuncup yang berhasil mekar sempurna.

Reproduksi: Bergantung pada penyerbukan oleh lalat, dengan tingkat keberhasilan rendah.

4. Ancaman dan Upaya Konservasi
Ancaman Utama:

Deforestasi dan alih fungsi hutan.
Gangguan manusia: Pengunjung tak bertanggung jawab merusak habitat.

Upaya Perlindungan:

Dilindungi UU No. 5/1990 dan CITES.
Pagar pelindung saat mekar (contoh: rencana di Gunung Poteng).
Pemantauan oleh BKSDA dan masyarakat lokal.

5. Fakta Menarik
Bunga terbesar di dunia, dijuluki Padma Raksasa.
Mekar bersamaan dengan bunga bangkai (Amorphophallus titanum) di Batang Palupuh—fenomena langka.

Daya tarik wisata:

Wisatawan mancanegara (Prancis, Eropa) sering berkunjung.
Membantu ekonomi lokal melalui ekowisata.";

                break;
            case "bangkairaksasa":
            detectedName = "bangkai";
informasi = @"Amorphophallus titanum (Titan Arum atau Corpse Flower): Tumbuhan Unik dan Langka

1. Klasifikasi dan Ciri Fisik
Klasifikasi Ilmiah:

Famili: Araceae (suku talas-talasan)

Genus: Amorphophallus

Spesies: A. titanum

Nama Lain: Bunga bangkai, titan arum, corpse flower.

Ciri Khas:

Infloresensia terbesar di dunia (struktur bunga tak bercabang), mencapai 3–3,2 meter.
Bau menyengat seperti daging busuk, berasal dari senyawa kimia (dimethyl trisulfide, isovaleric acid) untuk menarik lalat dan kumbang bangkai sebagai penyerbuk.
Spathe (seludang) berwarna merah marun di bagian dalam dan hijau di luar, dengan tekstur berlipat.
Spadix (tongkol) menghasilkan panas hingga 37°C untuk menyebarkan bau.

2. Siklus Hidup dan Reproduksi
Fase Vegetatif:

Menghasilkan daun tunggal setinggi 4–7 meter yang menyerupai pohon kecil. Daun ini menyimpan energi di umbi (corm) yang bisa mencapai 150 kg.
Fase ini berlangsung 4–10 tahun sebelum berbunga.

Fase Generatif:

Mekar hanya 24–48 jam, dengan bau paling kuat di malam hari.
Penyerbukan: Bunga betina terbuka lebih dulu, diikuti jantan untuk mencegah penyerbukan sendiri. Serangga membawa pollen dari tanaman lain.
Buah: Jika berhasil diserbuki, menghasilkan 400+ buah merah yang disebarkan burung rangkong.

3. Habitat dan Konservasi
Habitat Alami: Hutan hujan Sumatera Barat (Indonesia), di ketinggian 120–365 mdpl.

Status Konservasi: Terancam Punah (Endangered) oleh IUCN, dengan <1.000 individu tersisa di alam akibat deforestasi dan perkebunan kelapa sawit.

Upaya Konservasi:

Kebun Raya Dunia (e.g., Kew, AS, Bogor) membudidayakannya dan berbagi pollen untuk menjaga keragaman genetik.
Proyek Database Genetik oleh Chicago Botanic Garden untuk mencegah inbreeding.

4. Fakta Menarik
Rekor: Infloresensia tertinggi tercatat 3,225 meter di Belgia (2024).

Budidaya: Pertama kali mekar di Kew Gardens (1889). Sekarang, 5–10 mekar terjadi tiap tahun di kebun raya global.

Nama Ilmiah: Berasal dari bahasa Yunani amorphos (tak berbentuk) + phallos (penis) + titan (raksasa).";

                break;
            case "kantongsemar":
            detectedName = "semar";
informasi = @"Kantong Semar (Nepenthes spp.): Tumbuhan Karnivora Ikonik Indonesia

1. Klasifikasi dan Ciri Fisik
Klasifikasi Ilmiah:

Famili: Nepenthaceae (famili monotipik)

Genus: Nepenthes

Spesies: Terdapat 168 spesies yang diakui secara global, dengan 64 jenis di Indonesia (32 jenis endemik Kalimantan).

Ciri Khas:

Kantong perangkap: Modifikasi dari ujung daun, berisi cairan asam dan enzim (nepenthesin) untuk mencerna mangsa (serangga, kodok kecil, bahkan tikus).

Bentuk kantong:

Kantong bawah: Berbentuk bulat dengan ""sayap"" untuk memandu serangga tanah.

Kantong atas: Silindris tanpa sayap, menangkap serangga terbang.

Kantong roset: Ditemukan pada spesies seperti N. ampullaria.

Tinggi tanaman: Mencapai 15–20 meter dengan memanjat pohon inang.

2. Habitat dan Persebaran
Lokasi:

Indonesia: Kalimantan (pusat keanekaragaman) dan Sumatra.

Global: Asia Tenggara, Australia utara, Cina selatan, Madagaskar.

Kondisi Habitat:

Tumbuh di tanah miskin hara (gambut, kapur, rawa) dengan kelembapan >75%.

Beberapa spesies hidup epifit (menempel di pohon) atau di daerah beracun (logam berat, pasir pantai).

Spesies tertinggi: N. lamii ditemukan di ketinggian 3.520 mdpl.

3. Mekanisme Perangkap dan Simbiosis
Strategi Berburu:

Nektar manis di bibir kantong menarik mangsa.

Permukaan licin dan cairan asam mencerna mangsa dalam 24–48 jam.

Simbiosis Mutualisme:

Kelelawar berbulu wol (Kerivoula spp.) tidur di kantong, memberikan nutrisi dari kotorannya.

4. Manfaat dan Ancaman
Manfaat:

Obat tradisional: Cairan kantong digunakan untuk batuk, luka bakar, dan sakit mata.

Kuliner: Kantong dipakai sebagai wadah kue tradisional (e.g., kue lemang di Kalimantan).

Indikator ekologi: Menandakan daerah dengan kelembapan tinggi dan tanah asam.

Ancaman:

Deforestasi dan alih fungsi lahan untuk sawit.

Perdagangan ilegal sebagai tanaman hias.

5. Upaya Konservasi
Status Perlindungan: Dilindungi UU No. 5/1990 dan CITES.

Penelitian: Pemantauan genetik dan habitat (e.g., di Rawa Gambut Hulu Sungai Utara).

Budidaya: Kebun raya dan kolektor mengembangbiakkan spesies langka seperti N. rajah dan N. clipeata.

Fakta Menarik
Air kantong tertutup bisa diminum (pH 6–7), sedangkan yang terbuka sangat asam.

Spesies baru masih sering ditemukan, seperti N. pudica (2022) yang menangkap mangsa di bawah tanah.";

                break;
            case "acungjangkung":
            detectedName = "acung";
informasi = @"Acung Jangkung (Amorphophallus decus-silvae): Tumbuhan Endemik Langka Indonesia

1. Klasifikasi dan Ciri Fisik
Klasifikasi Ilmiah:

Famili: Araceae (suku talas-talasan)

Genus: Amorphophallus

Spesies: A. decus-silvae

Nama Lain: Bunga bangkai jangkung, Acung Jangkung

Ciri Khas:

Tinggi: Mencapai 2–3,5 meter, dengan tangkai daun berwarna keabu-abuan dan bercak cokelat tua.

Bunga: Infloresensia besar (mirip Amorphophallus titanum) dengan bau bangkai menyengat saat mekar untuk menarik penyerbuk (lalat/kumbang).

Umbi: Berukuran besar dan berpotensi sebagai sumber karbohidrat.

2. Habitat dan Persebaran
Lokasi: Endemik Jawa Barat dan Jawa Tengah bagian barat, terutama di kawasan hutan hujan tropis dataran rendah hingga tinggi.

Kondisi Habitat:

Menyukai lingkungan lembap dan teduh di bawah naungan pohon hutan.

Terancam oleh fragmentasi hutan dan alih fungsi lahan untuk pertanian/perkebunan.

3. Status Konservasi dan Ancaman
Populasi: Kurang dari 10.000 individu di alam (catatan LIPI), dengan tren penurunan.

Ancaman Utama:

Deforestasi: Perluasan lahan pertanian dan industri.

Pembudidayaan Terbatas: Sulit dikembangbiakkan di luar habitat alami.

Upaya Perlindungan:

Dilindungi UU No. 5/1990 dan masuk daftar prioritas konservasi LIPI.

Konservasi In Situ: Di Taman Nasional Gunung Ciremai dan hutan lindung Jawa Barat.

4. Fakta Unik
Bau Busuk: Hanya muncul saat mekar (24–48 jam) untuk menarik penyerbuk.

Kerabat Dekat: Berada dalam genus yang sama dengan bunga bangkai raksasa (Amorphophallus titanum), tetapi ukurannya lebih kecil.

Pemanfaatan Tradisional: Umbinya pernah digunakan sebagai sumber pangan alternatif oleh masyarakat lokal.";

                break;
                
            
            
            default:
                informasi = "Informasi tidak tersedia.";
                break;
        }
    }
}
