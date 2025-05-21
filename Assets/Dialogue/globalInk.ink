
// Variabel ending global
VAR berani_berubah = 0
VAR rasional = 0
VAR terjebak = 0

== chap1scene1 ==

Ayo cepat! Sudah siang! Jangan kelamaan di kamar! #speaker:Ibu #portrait:Ibu_memanggil #layout:right
-> END

== chap1scene2 ==
Hari ini bakal ada apa yang ditunggu di sekolah? #speaker:Ibu #portrait:Ibu_neutral #layout:right
+ [pengumuman lomba puisi] Ada pengumuman lomba puisi. #speaker:Rara #portrait:Rara_neutral #layout:left
    ~berani_berubah +=1
    Lomba puisi? Emangnya itu penting? #speaker:Ayah #portrait:Ayah_kesal #layout:right
    Kamu kan udah kelas akhir, fokus ke nilai akademik dulu #speaker:Ibu #portrait:Ibu_neutral #layout:right
    
    **  [Tetap ikut.] Aku tetap ikut, terserah. #speaker:Rara #portrait:Rara_kesal #layout:left
        ~berani_berubah +=1
        Nanti kamu mau hidup dari cuma nulis puisi? Ayah kasih tahu, dunia kerja itu keras. #speaker:Ayah #portrait:Ayah_sinis #layout:right
        
        Iya, daripada kamu buang-buang waktu untuk itu lebih baik fokus sama yang penting dulu. #speaker:Ibu #portrait:Ibu_sinis #layout:right
        -> END
        
    **  [Iya iya...] Ya udah, aku ga usah daftar. #speaker:Rara #portrait:Rara_sedih #layout:left
    ~ rasional +=1
        Iya kamu lebih baik fokus ke pelajaran di sekolah dulu. #speaker:Ibu #portrait:Ibu_neutral #layout:right
        -> END
    
+ Ulangan harian matematika #speaker:Rara #portrait:Rara_neutral #layout:left
    Ulangan harian matematika ya? Sudah belajar belum kamu? #speaker:Ayah #portrait:Ayah_neutral #layout:right
    
    Kamu harus belajar yang rajin ya, supaya nanti dapat kerja yang menghasilkan banyak uang. #speaker:Ayah #portrait:Ayah_neutral2 #layout:right
    
    Nanti hasilnya juga bisa kamu nikmati sendiri. #speaker:Ayah #portrait:Ayah_neutral2 #layout:right
    Nah benar itu, Ibu setuju sama Ayah. #speaker:Ibu #portrait:Ibu_senyum #layout:right
    -> END
    

== sceneruangtamu ==
Aku, berangkat sekolah dulu ya bang. #speaker:Rara #portrait:Rara_neutral #layout:left
Iya ra, hati hati ya #speaker:Jaki #portrait:Jaki_neutral #layout:right
-> END
    
    
== sceneruangkelas ==
Eh rara, lu jadi ikut lomba puisi kan? #speaker:Ega #portrait:Ega_neutral #layout:right
+ [Ikut] Ikut, kalo lu? #speaker:Rara #portrait:Rara_neutral #layout:left
    Ikutlah, masa engga. #speaker:Ega #portrait:Ega_neutral #layout:right
    Eh, <i>by the way</i> lu mau buat puisi temanya apa, ra?" #speaker:Ega #portrait:Ega_neutral #layout:right
    ** Ada deh rahasia, nanti lu juga tau kok #speaker:Rara #portrait:Rara_happy #layout:left
    -> END
    ** Gatau nih masih bingung, nanti deh gua pikirin lagi #speaker:Rara #portrait:Rara_sad #layout:left
    -> END

+ [Engga] Engga ikut dulu ga, gua fokus belajar dulu buat persiapan daftar kuliah nanti #speaker:Rara #portrait:Rara_neutral #layout:left
    Yah sayang bgt, padahal tugas puisi lu bagus bagus semua. #speaker:Ega #portrait:Ega_neutral #layout:right
    Yaudah, ra. <i>goodluck</i> ya semoga dapet jurusan kuliah yang lu mau. #speaker:Ega #portrait:Ega_neutral #layout:right
    (Bel istirahat berbunyi)
-> END

== scenekamarsore ==
Ibu ngapain ada di kamar aku? #speaker:Rara #portrait:Rara_curious #layout:left
Ibu hanya membereskan kamarmu saja. (berdiri dari duduknya. Sambil memegang kumpulan lembar kertas di tangan kanannya)
Ibu melihat ada kertas puisi. Kamu mengikuti lomba puisi?
(<i>Rara merasakan badannya sedikit menegang</i>) Iya, bu. aku ikut lomba puisi. #speaker:Rara #portrait:Rara_neutral #layout:left
Bagaimana dengan tugas harian mu? #speaker:Ibu #portrait:Ibu_neutral #layout:right
(Udara di kamar yang mulai gerah dirasakan oleh Rara.) #speaker:Rara #portrait:Rara_neutral #layout:left
Pasti terganggu kan? harusnya kamu fokus saja ke tugas harian mu dulu agar nilai rapot mu bagus. #speaker:Ibu #portrait:Ibu_kesal #layout:right
    + [berontak] (Mengambil nafas dalam-dalam) #speaker:Rara #portrait:Rara_neutral #layout:left
    Aku tidak ingin memilih jurusan yang ibu dan ayah tentukan. Aku mau jurusan yang aku mau. #speaker:Rara #portrait:Rara_marah #layout:left
    ~ berani_berubah +=1
    
    Emangnya apasih gunanya mempelajari seni? #speaker:Ibu #portrait:Ibu_kesal #layout:right
    Lagian prospek kerjanya juga kurang dibandingkan jurusan kuliah yang ibu ayah pilih #speaker:Ibu #portrait:Ibu_kesal #layout:right 
        
        ** Gamau bu, aku tetep mau jurusan yang aku mau #speaker:Rara #portrait:Rara_marah #layout:left
            ya pokonya ibu gamau tau, kamu harus masuk jurusan yang ayah dan ibu pilih. #speaker:Ibu #portrait:Ibu_kesal #layout:right
        ~ berani_berubah +=1
            -> END
        ** iya bu, nanti ku pikirkan lagi jurusan yang akan aku ambil #speaker:Rara #portrait:Rara_neutral2 #layout:left
            ya pokonya ibu gamau tau, kamu harus masuk jurusan yang ayah dan ibu pilih. #speaker:Ibu #portrait:Ibu_kesal #layout:right
        ~ rasional +=1
         -> END
    + [tidak terganggu] Tugasku tidak terganggu kok, lagian nilai ku gabakal turun karena lomba doang. #speaker:Rara #portrait:Rara_neutral #layout:left
        ya pokonya ibu gamau tau, kamu harus masuk jurusan yang ayah dan ibu pilih. #speaker:Ibu #portrait:Ibu_kesal #layout:right
        (Ibu beranjak keluar dari kamar Rara.)
    -> END
    
-> END

== tempattidur ==
Apakah kamu ingin tidur?
+ Iya
-> END

== ruangmakan2 ===
besok pendaftaran sudah di mulai, kamu masih mau ambil jurusan lain? #speaker:Ibu #portrait:Ibu_kesal #layout:right
    + masih ku pikirkan bu. #speaker:Rara #portrait:Rara_neutral2 #layout:left
        Apa yang perlu kamu pikirkan? #speaker:Ayah #portrait:Ayah_kesal #layout:right
        Jurusan yang ibu dan ayah pilih lebik baik dan memiliki prospek kerja yang lebih jelas dibandingkan kamu masuk sastra #speaker:Ayah #portrait:Ayah_kesal #layout:right
        
        Sudah rara, pilih saja jurusan yang ibu bapak pilih dan jangan pilih jurusan tidak jelas #speaker:Ibu #portrait:Ibu_neutral #layout:right
        
        ** Iya bu, rara pilih jurusan ibu dan bapak pilih #speaker:Rara #portrait:Rara_neutral2 #layout:left
        -> END
        ** Gatau, Bu. Rara bingung. #speaker:Rara #portrait:Rara_neutral #layout:left
        
            Sudahlah, yah, bu. Biarkan Rara berfikir dulu sendiri. #speaker:Jaki #portrait:Jaki_neutral #layout:right
            Lagian Rara bisa telat sekolah kalau dipaksa menjawab pertanyaan ayah dan ibu. #speaker:Jaki #portrait:Jaki_neutral #layout:right
    
            Aku berangkat sekolah dulu ya. #speaker:Rara #portrait:Rara_neutral #layout:left
            
            Iya Ra, hati-hati ya. #speaker:Jaki #portrait:Jaki_neutral #layout:right
        -> END
        
== scenekelas2 ==
Eh lagi ngapain ga? #speaker:Rara #portrait:Rara_neutral #layout:left
(Ega membalikkan badannya menuju suara itu berasal) #speaker:Ega #portrait:Ega_neutral #layout:right
Abis ngapus papan tulis nih #speaker:Ega #portrait:Ega_neutral #layout:right
eh btw lu dan tau jurusan apa yang mau di ambil? #speaker:Ega #portrait:Ega_neutral #layout:right

    + Gua jadinya ambil jurusan sastra indonesia. #speaker:Rara #portrait:Rara_neutral #layout:left
        Wah, sesuai passion lu ya berarti! #speaker:Ega #portrait:Ega_neutral #layout:right
        Iya! hehehe! #speaker:Rara #portrait:Rara_smile #layout:left
        
        Keren deh, mantap! #speaker:Ega #portrait:Ega_neutral #layout:right
        
        (Bel pulang berbunyi.)
    -> END
    + Gua ambil jurusan sesuai pilihan orang tua gua #speaker:Rara #portrait:Rara_sad #layout:left
        Oh! serius? gua kira lu bakal ambil jurusan sastra! #speaker:Ega #portrait:Ega_neutral #layout:right
        
        ** [Engga deh] Engga deh, orang tua gua maunya gua masuk pilihan mereka #speaker:Rara #portrait:Rara_sad #layout:left
            Wah, semoga jurusannya cocok sama lu ya! #speaker:Ega #portrait:Ega_neutral #layout:right
            
            (Bel pulang berbunyi.)
            -> END
            
        ** [Ragu] (Rara menundukkan kepalanya, menatap kedua sepatunya.)#speaker:Rara #portrait:Rara_sad #layout:left
            (Bergumam) Gua sebenernya belum tau, Ga. #speaker:Rara #portrait:Rara_sad #layout:left
            Gua masih belum bisa nentuin masuk jurusan mana.#speaker:Rara #portrait:Rara_sad #layout:left
            
            Kalo gua boleh kasih saran yaa... #speaker:Ega #portrait:Ega_neutral #layout:right
            Mending pikirin dari sekarang sih, Ra. Soalnya udah sebentar lagi tuh mau ditutup, kan? #speaker:Ega #portrait:Ega_neutral #layout:right
            Pilih sesuai hati nurani lu aja, Ra. #speaker:Ega #portrait:Ega_neutral #layout:right
            (Menghela napas) #speaker:Ega #portrait:Ega_neutral #layout:right
            Emang berat, sih. Semuanya harus dipikirin baik-baik biar ga salah langkah. #speaker:Ega #portrait:Ega_neutral #layout:right
            Semoga ketemu jurusan yang sesuai ya! #speaker:Ega #portrait:Ega_neutral #layout:right
            
            (Bel pulang berbunyi.)
    
        -> END
        
== sceneruangtamu2 ==
(Jaki menyadari kehadiran adiknya di dekatnya.)
(Kehadiran Rara yang datang tiba-tiba seperti ini membuat Jaki merasa ada yang aneh terjadi pada adiknya.)
Kenapa, Ra? #speaker:Jaki #portrait:Jaki_neutral #layout:right
Keliatan bingung gitu. #speaker:Jaki #portrait:Jaki_neutral #layout:right

(Rara menghela napasnya kasar.) #speaker:Rara #portrait:Rara_sad #layout:left
Iya bang, aku masih bingung milih jurusan kuliah apa padahal malem ini terakhir #speaker:Rara #portrait:Rara_sad #layout:left

(Benar dugaan Jaki, ternyata adiknya sedang bimbang memilih jurusan kuliah.) #speaker:Jaki #portrait:Jaki_neutral #layout:right
Ooh, masalah itu ya? #speaker:Jaki #portrait:Jaki_neutral #layout:right
Menurut abang nih ya, dek. Kamu harus mikirin baik-baik jurusan kamu nanti. #speaker:Jaki #portrait:Jaki_neutral #layout:right
Abang ada satu pertanyaan yang mungkin bisa bantu kamu buat milih jurusan kuliah nanti. #speaker:Jaki #portrait:Jaki_neutral #layout:right
Kira-kira... #speaker:Jaki #portrait:Jaki_neutral #layout:right
Kamu siap ga untuk belajar yang mungkin hal baru buat kamu seandainya kalo masuk jurusan pilihan ibu dan ayah? #speaker:Jaki #portrait:Jaki_neutral #layout:right

+ [Kokoh] Engga sih bang #speaker:Rara #portrait:Rara_sad #layout:left
    ~berani_berubah+=1
    Aku ga siap kalo mempelajari hal baru. #speaker:Rara #portrait:Rara_sad #layout:left
    Aku bakal tetap milih jurusan aku sendiri, bang. #speaker:Rara #portrait:Rara_sad #layout:left
    Mending aku kembangin aja skill berpuisi ku daripada harus ikut jurusan yang ayah dan ibu pilih. #speaker:Rara #portrait:Rara_sad #layout:left
    
    Kalo seperti itu, cobalah yakinin ayah sama ibu untuk terakhir kalinya. #speaker:Jaki #portrait:Jaki_neutral #layout:right
    Atau kamu akan tetap memilih jurusan yang kamu inginkan tanpa restu dari orang tua? #speaker:Jaki #portrait:Jaki_neutral #layout:right
    Kamu yang menerima konsekuensinya. Tapi apapun itu pilihannya, abang akan terus selalu dukung kamu, kok. Tenang aja. #speaker:Jaki #portrait:Jaki_neutral #layout:right
    
-> END
+ [Bingung](Rara menundukkan kepalanya) Ngga tau sih, bang. Aku tetep masih bingung. #speaker:Rara #portrait:Rara_sad #layout:left
    
    Coba kamu pikir ulang, Ra. Pikir dengan baik-baik. #speaker:Jaki #portrait:Jaki_neutral #layout:right
    Karena pasti restu orang tua juga bisa mempengaruhi kamu nanti dalam menimba ilmu.#speaker:Jaki #portrait:Jaki_neutral #layout:right
    
    Kamu lebih baik masuk ke jurusan yang ayah dan ibu pilih atau #speaker:Jaki #portrait:Jaki_neutral #layout:right
    Kamu bisa memilih jurusan seperti yang mereka mau tetapi dengan syarat #speaker:Jaki #portrait:Jaki_neutral #layout:right
    Kamu harus bisa yakinin mereka kalau kamu bisa menjalankan itu secara berdampingan! #speaker:Jaki #portrait:Jaki_neutral #layout:right
    
    ** [Setuju!]
    ~rasional +=1
        (Rara mengangkat kepalanya dengan sangat cepat) #speaker:Rara #portrait:Rara_happy #layout:left
        Ah iya! #speaker:Rara #portrait:Rara_happy #layout:left
        Ide bagus, ide bagus! #speaker:Rara #portrait:Rara_happy #layout:left
        Benar juga, bang! Aku coba bujuk ayah dan ibu buat ngebolehin aku untuk menyalurkan hobi nulis puisi aku dan aku juga masuk ke jurusan yang ayah dan ibu mau, bang!. #speaker:Rara #portrait:Rara_happy #layout:left
        Oke! Terima kasih, bang atas sarannya. (Kemudian Rara beranjak menemui orang tuanya.) #speaker:Rara #portrait:Rara_happy #layout:left
    -> END
    ** [Terpaksa] Aku... #speaker:Rara #portrait:Rara_sad #layout:left
        ~terjebak +=1
            ... #speaker:Rara #portrait:Rara_sad #layout:left
            Aku kayaknya bakal ikut kemauan ayah dan ibu aja, bang. #speaker:Rara #portrait:Rara_sad #layout:left
            (Rara berdiam diri untuk waktu yang lama) #speaker:Rara #portrait:Rara_sad #layout:left
            ... #speaker:Rara #portrait:Rara_sad #layout:left
            Iya... #speaker:Rara #portrait:Rara_sad #layout:left
            Iya, aku akan mengikuti jurusan yang mereka mau saja. #speaker:Rara #portrait:Rara_sad #layout:left
    -> END


