
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
        Iya kamu lebih baik fokus ke pelajaran di sekolah dulu. #speaker:Ibu #portrait:Ibu_neutral #layout:right
        -> END
    
+ Ulangan harian matematika #speaker:Rara #portrait:Rara_neutral #layout:left
    Ulangan harian matematika ya? Sudah belajar belum kamu? #speaker:Ayah #portrait:Ayah_neutral #layout:right
    
    Kamu harus belajar yang rajin ya, supaya nanti dapat kerja yang menghasilkan banyak uang. #speaker:Ayah #portrait:Ayah_neutral2 #layout:right
    
    Nanti hasilnya juga bisa kamu nikmati sendiri. #speaker:Ayah #portrait:Ayah_neutral2 #layout:right
    Nah benar itu, Ibu setuju sama Ayah. #speaker:Ibu #portrait:Ibu_senyum #layout:right
    -> END
    




