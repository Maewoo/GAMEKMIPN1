
// Variabel ending global
VAR berani_berubah = 0
VAR rasional = 0
VAR terjebak = 0

== chap1scene1 ==

Ayo cepat! Sudah siang! Jangan kelamaan di kamar! #speaker:Ibu #portrait:Ibu_neutral #layout:right
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
    ~ rasional +=2
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
Iya ra, hati hati ya #speaker:Jaki #portrait:Jaki_neutral #layout:right #UI_Anim:UI_Objective, Popped
-> END  
    
    
== sceneruangkelas ==
Eh rara, lu jadi ikut lomba puisi kan? #speaker:Ega #portrait:Ega_neutral #layout:right
+ [Ikut] Ikut, kalo lu? #speaker:Rara #portrait:Rara_neutral #layout:left
~berani_berubah +=1
    Ikutlah, masa engga. #speaker:Ega #portrait:Ega_neutral #layout:right
    Eh, <i>by the way</i> lu mau buat puisi temanya apa, ra?" #speaker:Ega #portrait:Ega_neutral #layout:right
    ** Ada deh rahasia, nanti lu juga tau kok #speaker:Rara #portrait:Rara_happy #layout:left
    -> END
    ** Gatau nih masih bingung, nanti deh gua pikirin lagi #speaker:Rara #portrait:Rara_sad #layout:left
    -> END

+ [Engga] Engga ikut dulu ga, gua fokus belajar dulu buat persiapan daftar kuliah nanti #speaker:Rara #portrait:Rara_neutral #layout:left
~rasional +=2
    Yah sayang banget, padahal tugas puisi lu bagus-bagus semua. #speaker:Ega #portrait:Ega_neutral #layout:right
    Yaudah, ra. <i>Goodluck</i> ya semoga dapet jurusan kuliah yang lu mau. #speaker:Ega #portrait:Ega_neutral #layout:right
    Iya, makasih banyak ya, Ga. #speaker:Rara #portrait:Rara_happy #layout:left
    (Bel istirahat berbunyi) #speaker:  #portrait:blank #layout:center
    (Rara kemudian melanjutkan kegiatan belajar mengajar sampai sore hari.) #speaker:  #portrait:blank #layout:center
-> END

== scenekamarsore ==
Ibu ngapain ada di kamar aku? #speaker:Rara #portrait:Rara_neutral2 #layout:left
(Ibu berdiri dari duduknya. Sambil memegang kumpulan lembar kertas di tangan kanannya) #speaker:Ibu #portrait:Ibu_neutral #layout:right
Ibu hanya membereskan kamarmu saja. #speaker:Ibu #portrait:Ibu_neutral #layout:right
(Ibu kemudian mengangkat lembaran kertas itu, memberi isyarat tidak menyangka.) #speaker:Ibu #portrait:Ibu_neutral2 #layout:right
Ibu melihat ada kertas puisi. Kamu mengikuti lomba puisi? #speaker:Ibu #portrait:Ibu_kesal #layout:right
(<i>Rara merasakan badannya sedikit menegang</i>) #speaker:Rara #portrait:Rara_neutral #layout:left
... #speaker:Rara #portrait:Rara_sad #layout:left
Iya, bu. aku ikut lomba puisi. #speaker:Rara #portrait:Rara_sad #layout:left
Bagaimana dengan tugas harian mu? #speaker:Ibu #portrait:Ibu_neutral #layout:right
(Ibu mulai menaikkan nada bicaranya.) #speaker:Ibu #portrait:Ibu_kesal #layout:right
(Udara di kamar yang mulai gerah dirasakan oleh Rara.) #speaker:Rara #portrait:Rara_sad #layout:left
Pasti terganggu kan? harusnya kamu fokus saja ke tugas harian mu dulu agar nilai rapot mu bagus. #speaker:Ibu #portrait:Ibu_kesal #layout:right
    + [berontak] (Mengambil nafas dalam-dalam) #speaker:Rara #portrait:Rara_neutral #layout:left
    ~ berani_berubah +=2
    Aku... #speaker:Rara #portrait:Rara_sad #layout:left
    Aku ngga mau memilih jurusan yang ibu dan ayah tentukan. #speaker:Rara #portrait:Rara_marah #layout:left
    Aku mau jurusan yang aku mau. #speaker:Rara #portrait:Rara_marah #layout:left
    (Ibu tidak menyangka anaknya akan menjawab dengan begitu tegas.) #speaker:Ibu #portrait:Ibu_kesal #layout:right
    Apa? #speaker:Ibu #portrait:Ibu_kesal #layout:right
    Emangnya apasih gunanya mempelajari seni? #speaker:Ibu #portrait:Ibu_kesal #layout:right
    Lagian prospek kerjanya juga kurang dibandingkan jurusan kuliah yang ibu ayah pilih #speaker:Ibu #portrait:Ibu_kesal #layout:right
    Ini demi masa depan kamu juga, Ra! #speaker:Ibu #portrait:Ibu_kesal #layout:right
    (Rara merasakan tenggorokannya seperti tercekik.) #speaker:Rara #portrait:Rara_marah #layout:left
        
        ** [Ngga mau]Ngga mau bu, aku tetap mau memilih jurusan yang aku mau. #speaker:Rara #portrait:Rara_marah #layout:left
        ~ berani_berubah +=1
            Ya pokonya ibu ngga mau tau, kamu harus masuk jurusan yang ayah dan ibu pilih. #speaker:Ibu #portrait:Ibu_kesal #layout:right #UI_Anim:UI_Objective, Popped
            (Ibu beranjak keluar dari kamar Rara.)
        
            
            -> END
        ** [Iya bu]Iya bu, nanti ku pikirkan lagi jurusan yang akan aku ambil. #speaker:Rara #portrait:Rara_sad #layout:left
        ~ rasional +=2
            Ya pokoknya ibu ngga mau tau. Kamu harus masuk jurusan yang ayah dan ibu pilih. #speaker:Ibu #portrait:Ibu_kesal #layout:right #UI_Anim:UI_Objective, Popped
        
         -> END
    + [tidak terganggu] Tugasku tidak terganggu kok, lagian nilai ku gabakal turun karena lomba doang. #speaker:Rara #portrait:Rara_neutral #layout:left
    ~terjebak +=1
        Ya pokonya ibu ngga mau tau. Kamu harus masuk jurusan yang ayah dan ibu pilih. #speaker:Ibu #portrait:Ibu_kesal #layout:right
        (Ibu kemudian meletakkan kumpulan kertas yang dipegangnya tadi secara sembarang.) #speaker:Ibu #portrait:Ibu_kesal #layout:right
        (Ibu beranjak keluar dari kamar Rara.) #speaker:Ibu #portrait:Ibu_kesal #layout:right #UI_Anim:UI_Objective, Popped
    -> END 

== tempattidur ==
Apakah kamu ingin tidur? #speaker:... #portrait:blank #layout:center
+ [Iya]
(Kamu tidur.) #scene:kamartidur3
-> END

== kamartidur3 ==
Ayo cepat! Sudah siang! Jangan kelamaan di kamar! #speaker:Ibu #portrait:Ibu_neutral #layout:right
-> END

== ruangmakan2 ===
(Rara berjalan menuju meja makan untuk sarapan.) #speaker: #portrait:blank #layout:center
(Ia melihat kedua orang tuanya sudah berada di sana.) #speaker: #portrait:blank #layout:center
(Suasana hening menyelimuti ruang makan itu.) #speaker: #portrait:blank #layout:center
(Rara merasakan perasaan tidak nyaman karena dia masih dihantui perasaan bimbang masalah pemilihan jurusan kuliahnya.) #speaker: #portrait:blank #layout:center
... #speaker:Ayah #portrait:Ayah_neutral #layout:right
Besok pendaftaran sudah di mulai. Gimana dengan pilihanmu? #speaker:Ibu #portrait:Ibu_kesal #layout:right
Kamu masih mau ambil jurusan lain? #speaker:Ibu #portrait:Ibu_kesal #layout:right
    + [Masih ragu] Masih ku pikirkan bu. #speaker:Rara #portrait:Rara_sad #layout:left
        ... #speaker:Ayah #portrait:Ayah_neutral #layout:right
        (Ayah menatap Rara dengan ekspresi marah) #speaker:Ayah #portrait:Ayah_kesal #layout:right
        Apa yang perlu kamu pikirkan, Rara? #speaker:Ayah #portrait:Ayah_kesal #layout:right
        Jurusan yang ibu dan ayah pilih lebik baik dan memiliki prospek kerja yang lebih jelas dibandingkan kamu masuk sastra. #speaker:Ayah #portrait:Ayah_kesal #layout:right
        Sudah, Rara. Pilih saja jurusan yang ibu dan ayah pilih dan jangan pilih <b>jurusan tidak jelas</b>. #speaker:Ibu #portrait:Ibu_neutral #layout:right
        
        ** [Iya, bu]Iya bu, Rara pilih jurusan ibu dan ayah pilih #speaker:Rara #portrait:Rara_sad #layout:left
        ~terjebak +=3
            (Rara beranjak dari duduknya dan bersiap berangkat ke sekolah.) #speaker:Rara #portrait:Rara_sad #layout:left
        
        -> END
        ** [Gatau]Gatau, Bu. Rara bingung. #speaker:Rara #portrait:Rara_neutral #layout:left
        ~terjebak +=1
            (Mendengar perdebatan itu, Jaki berniat melerai mereka.) #speaker:Jaki #portrait:Jaki_kesal #layout:right
            Sudahlah, yah, bu. Biarkan Rara berfikir dulu sendiri. #speaker:Jaki #portrait:Jaki_kesal #layout:right
            Lagian Rara bisa telat sekolah kalau dipaksa menjawab pertanyaan ayah dan ibu. #speaker:Jaki #portrait:Jaki_neutral2 #layout:right
    
            Aku berangkat sekolah dulu ya. #speaker:Rara #portrait:Rara_neutral #layout:left
            
            Iya Ra, hati-hati ya. #speaker:Jaki #portrait:Jaki_neutral #layout:right
        -> END
    +  [Sudah] (Nampaknya Rara sudah mengantisipasi pertanyaan ini sebelumnya) #speaker:Rara #portrait:Rara_neutral #layout:left
        ~berani_berubah +=2
        Iya bu aku mau ambil jurusan impian ku, Sastra Indonesia #speaker:Rara #portrait:Rara_neutral #layout:left
        
        Sudah Rara, pilih saja jurusan yang ibu dan ayah pilih dan jangan pilih <b>jurusan tidak jelas</b>. #speaker:Ibu #portrait:Ibu_neutral #layout:right
        Ayah dan ibu mau kamu terarah ke depannya. #speaker:Ibu #portrait:Ibu_neutral #layout:right
        Kenapa kamu tetap kokoh dengan pilihanmu itu? #speaker:Ibu #portrait:Ibu_neutral #layout:right
        Tentu saja, karena aku mau! #speaker:Rara #portrait:Rara_neutral #layout:left
        Karena aku suka! #speaker:Rara #portrait:Rara_neutral2 #layout:left
        Aku mau menjadi penyair yang hebat suatu saat nanti. #speaker:Rara #portrait:Rara_neutral2 #layout:left
        
        Sudahlah, yah, bu. Biarkan Rara berfikir dulu sendiri. #speaker:Jaki #portrait:Jaki_kesal #layout:right
            Lagian Rara bisa telat sekolah kalau dipaksa menjawab pertanyaan ayah dan ibu. #speaker:Jaki #portrait:Jaki_neutral2 #layout:right
    
            Aku berangkat sekolah dulu ya. #speaker:Rara #portrait:Rara_neutral #layout:left
            
            Iya Ra, hati-hati ya. #speaker:Jaki #portrait:Jaki_neutral #layout:right
        ->END
        
== scenekelas2 ==
(Rara menghampiri Ega yang berada di depan kelas.) #speaker:Rara #portrait:Rara_neutral #layout:left
Eh lagi ngapain ga? #speaker:Rara #portrait:Rara_neutral #layout:left
(Ega membalikkan badannya menuju suara itu berasal) #speaker:Ega #portrait:Ega_neutral #layout:right
Ah? Ini... abis ngapus papan tulis nih. #speaker:Ega #portrait:Ega_neutral #layout:right
Eh, <i>by the way</i> pendaftaran perguruan tinggi udah dibuka, kan ya buat jalur prestasi? #speaker:Ega #portrait:Ega_neutral #layout:right
Lu udah tau jurusan apa yang mau diambil? #speaker:Ega #portrait:Ega_neutral #layout:right

    + [Sastra] Umm... Gua jadinya ambil jurusan sastra indonesia. #speaker:Rara #portrait:Rara_neutral #layout:left
        Wah, gilaaa! keren! #speaker:Ega #portrait:Ega_happy #layout:right
        sesuai passion lu ya berarti! #speaker:Ega #portrait:Ega_happy #layout:right
        Iya! hehehe! #speaker:Rara #portrait:Rara_happy #layout:left
        
        Keren deh, mantap! #speaker:Ega #portrait:Ega_neutral #layout:right
        Semoga lolos ya, Ra! Semangat! Gua dukung lu! #speaker:Ega #portrait:Ega_neutral #layout:right
        Ahahaha, iyaa! makasih banyak ya, Ega! #speaker:Rara #portrait:Rara_happy #layout:left
        Semoga lu juga dapet jurusan yang lu mau juga. Semangat! #speaker:Rara #portrait:Rara_smile #layout:left
        (Bel pulang berbunyi.)#scene: ruangTV2
        
    -> END
    + [Pilihan orang tua]Gua ambil jurusan sesuai pilihan orang tua gua #speaker:Rara #portrait:Rara_sad #layout:left
        Oh! serius? gua kira lu bakal ambil jurusan sastra! #speaker:Ega #portrait:Ega_neutral #layout:right
        
        ** [Engga deh] Engga deh, orang tua gua maunya gua masuk pilihan mereka #speaker:Rara #portrait:Rara_sad #layout:left
            Wah... #speaker:Ega #portrait:Ega_sad #layout:right
            Ini mungkin berat banget buat lu, Ra. #speaker:Ega #portrait:Ega_sad #layout:right
            Gua cuma bisa kasih lu semangat dari sini. #speaker:Ega #portrait:Ega_neutral #layout:right
            Semangat ya, Ra. #speaker:Ega #portrait:Ega_happy #layout:right
            Coba diambil sisi positifnya aja, mungkin orang tua lu mau yang terbaik buat anaknya. #speaker:Ega #portrait:Ega_sad #layout:right
            Semoga jurusannya cocok sama lu ya! #speaker:Ega #portrait:Ega_neutral #layout:right
            Semangat! semangat! semangat! Lu pasti bisa! #speaker:Ega #portrait:Ega_happy #layout:right
            
            (Bel pulang berbunyi.)#scene: ruangTV2
            
            -> END
            
        ** [Ragu] (Rara menundukkan kepalanya, menatap kedua sepatunya.)#speaker:Rara #portrait:Rara_sad #layout:left
            ~rasional +=1
            (Bergumam) Gua sebenernya belum tau, Ga. #speaker:Rara #portrait:Rara_sad #layout:left
            Gua masih belum bisa nentuin masuk jurusan mana.#speaker:Rara #portrait:Rara_sad #layout:left
            
            Kalo gua boleh kasih saran yaa... #speaker:Ega #portrait:Ega_neutral #layout:right
            Mending pikirin dari sekarang sih, Ra. Soalnya waktu pemilihan jurusannya ga lama, kan? #speaker:Ega #portrait:Ega_neutral #layout:right
            Pilih sesuai hati nurani lu aja, Ra. #speaker:Ega #portrait:Ega_neutral #layout:right
            (Menghela napas) #speaker:Ega #portrait:Ega_neutral #layout:right
            Emang berat, sih. Semuanya harus dipikirin baik-baik biar ga salah langkah. #speaker:Ega #portrait:Ega_neutral #layout:right
            Semoga ketemu jurusan yang sesuai ya! #speaker:Ega #portrait:Ega_neutral #layout:right
        
            (Bel pulang berbunyi.)#scene: ruangTV2
        -> END
        
== sceneruangtv2 ==
(Jaki menyadari kehadiran adiknya di dekatnya.) #speaker:Jaki #portrait:Jaki_neutral #layout:right
(Kehadiran Rara yang datang tiba-tiba seperti ini membuat Jaki merasa ada yang aneh terjadi pada adiknya.) #speaker:Jaki #portrait:Jaki_neutral #layout:right
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
        ~berani_berubah+=2
        Aku ga siap kalo mempelajari hal baru. #speaker:Rara #portrait:Rara_sad #layout:left
        Aku bakal tetap milih jurusan aku sendiri, bang. #speaker:Rara #portrait:Rara_sad #layout:left
        Mending aku kembangin aja skill berpuisi ku daripada harus ikut jurusan yang ayah dan ibu pilih. #speaker:Rara #portrait:Rara_sad #layout:left
        
        Kalo seperti itu, cobalah yakinin ayah sama ibu untuk terakhir kalinya. #speaker:Jaki #portrait:Jaki_neutral #layout:right
        Atau kamu akan tetap memilih jurusan yang kamu inginkan tanpa restu dari orang tua? #speaker:Jaki #portrait:Jaki_neutral #layout:right
        Kamu yang menerima konsekuensinya. Tapi apapun itu pilihannya, abang akan terus selalu dukung kamu, kok. Tenang aja. #speaker:Jaki #portrait:Jaki_neutral #layout:right
    
        -> checkending
    + [Bingung](Rara menundukkan kepalanya) Ngga tau sih, bang. Aku tetep masih bingung. #speaker:Rara #portrait:Rara_sad #layout:left
        ~rasional+=1
        Coba kamu pikir ulang, Ra. Pikir dengan baik-baik. #speaker:Jaki #portrait:Jaki_neutral #layout:right
        Karena pasti restu orang tua juga bisa mempengaruhi kamu nanti dalam menimba ilmu.#speaker:Jaki #portrait:Jaki_neutral #layout:right
        
        Kamu lebih baik masuk ke jurusan yang ayah dan ibu pilih atau #speaker:Jaki #portrait:Jaki_neutral #layout:right
        Kamu bisa memilih jurusan seperti yang mereka mau tetapi dengan syarat #speaker:Jaki #portrait:Jaki_neutral #layout:right
        Kamu harus bisa yakinin mereka kalau kamu bisa menjalankan itu secara berdampingan! #speaker:Jaki #portrait:Jaki_neutral #layout:right
    
        ** [Setuju!]
        ~rasional +=4
            (Rara mengangkat kepalanya dengan sangat cepat) #speaker:Rara #portrait:Rara_happy #layout:left
            Ah iya! #speaker:Rara #portrait:Rara_happy #layout:left
            Ide bagus, ide bagus! #speaker:Rara #portrait:Rara_happy #layout:left
            Benar juga, bang! Aku coba bujuk ayah dan ibu buat ngebolehin aku untuk menyalurkan hobi nulis puisi aku dan aku juga masuk ke jurusan yang ayah dan ibu mau, bang!. #speaker:Rara #portrait:Rara_happy #layout:left
            Oke! Terima kasih, bang atas sarannya. (Kemudian Rara beranjak menemui orang tuanya.) #speaker:Rara #portrait:Rara_happy #layout:left
        -> checkending
        ** [Terpaksa] Aku... #speaker:Rara #portrait:Rara_sad #layout:left
            ~terjebak +=2
                ... #speaker:Rara #portrait:Rara_sad #layout:left
                Aku kayaknya bakal ikut kemauan ayah dan ibu aja, bang. #speaker:Rara #portrait:Rara_sad #layout:left
                (Rara berdiam diri untuk waktu yang lama) #speaker:Rara #portrait:Rara_sad #layout:left
                ... #speaker:Rara #portrait:Rara_sad #layout:left
                Iya... #speaker:Rara #portrait:Rara_sad #layout:left
                Iya, aku akan mengikuti jurusan yang mereka mau saja. #speaker:Rara #portrait:Rara_sad #layout:left
        -> checkending

== checkending ==
#checkdominantending
-> END

==berani_ending ==
#scene:EndingBerani
->END

==terjebak_ending==
#scene:EndingTerjebak
-> END

==rasional_ending ==
#scene:EndingRasional
-> END