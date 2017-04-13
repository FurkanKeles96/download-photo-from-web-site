# download-photo-from-web-site
Web site bot. Used c# and htmlAgility. There are too many errors

C# kullanılarak yazılmış bir web sitesindeki fotoğrafları indirme kodu. Koddaki eksiklikler şunlar:
-Her site için kodun değiştirilmesi gerekiyor.
-Site ismi kodun içinde belirtiliyor.
-Xpath kodun içinde belirtiliyor.
-Kaç fotoğraf alacağı kodun içinde belirtiliyor.
-Butonların isimleri yok
-Yorum satırları yok

İlerleyen zamanlarda kodu elimden geldiğince güncellemeye çalışacağım.

Koddaki butonların işlevleri:
Button1: Kendisine verilen linkte bulunan fotoğrafların sayfalarının linklerini getiriyor. Listbox1'e yazıyor.
Button2: ListBox1'deki linklere gidip fotoğrafların asıl yüklenmiş olduğu linkleri alıp listBox2'ye yazıyor.
Button3: ListBox2'ye yazılmış olan linkleri kullanarak o adresteki fotoğrafları indiriyor.
