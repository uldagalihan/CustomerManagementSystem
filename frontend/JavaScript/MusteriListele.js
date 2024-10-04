document.getElementById("btnBireysel").addEventListener("click", function() {
    fetch("http://localhost:5121/api/BireyselMusteri/tumMusterileriGetir") 
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response was not ok");
            }
            return response.json();
        })
        .then(data => {
            console.log(data); 

            // Tablo içeriğini temizle
            const tablesContainer = document.getElementById("tablesContainer");
            tablesContainer.innerHTML = ""; // Önceki tablo içeriğini kaldır

            // Bireysel müşteri tablosu oluştur
            const customerList = document.createElement("table");
            customerList.innerHTML = `
                <tr>
                    <th>Müşteri No</th>
                    <th>TC Kimlik No</th>
                    <th>Ad</th>
                    <th>Soyad</th>
                    <th>Baba Adı</th>
                    <th>Anne Adı</th>
                    <th>Doğum Tarihi</th>
                    <th>Şahıs Firma Drm</th>
                    <th>KKTC Kimlik No</th>
                </tr>
            `;

            // Bireysel müşterileri tabloya ekle
            data.bireyselMusteri.forEach(musteri => {
                const row = customerList.insertRow();
                row.insertCell(0).textContent = musteri.musteriNo;
                row.insertCell(1).textContent = musteri.tcKimlikNo;
                row.insertCell(2).textContent = musteri.musteriAd;
                row.insertCell(3).textContent = musteri.musteriSoyad;
                row.insertCell(4).textContent = musteri.musteriBabaAdi;
                row.insertCell(5).textContent = musteri.musteriAnneAdi;
                row.insertCell(6).textContent = new Date(musteri.dogumTarihi).toLocaleDateString();
                row.insertCell(7).textContent = musteri.sahisFirmaDrm;
                row.insertCell(8).textContent = musteri.kktcKimlikNo;
            });

            // İrtibat tablosu oluştur
            const contactList = document.createElement("table");
            contactList.innerHTML = `
                <tr>
                    <th>Müşteri No</th>
                    <th>Adres Bilgisi</th>
                    <th>E-Adres Bilgisi</th>
                    <th>Alan Kod</th>
                    <th>Telefon No</th>
                    <th>Adres Tipi</th>
                    <th>E-Adres Tipi</th>
                    <th>Telefon Tipi</th>
                    <th>Hat Tipi</th>
                </tr>
            `;

            // İrtibat müşteri bilgilerini tabloya ekle
            data.irtibatMusteri.forEach(irtibat => {
                const row = contactList.insertRow();
                row.insertCell(0).textContent = irtibat.musteriNo;
                row.insertCell(1).textContent = irtibat.adresBilgisi;
                row.insertCell(2).textContent = irtibat.eadresBilgisi;
                row.insertCell(3).textContent = irtibat.alanKod;
                row.insertCell(4).textContent = irtibat.telNo;
                row.insertCell(5).textContent = irtibat.adresTipKd;
                row.insertCell(6).textContent = irtibat.eadresTipKd;
                row.insertCell(7).textContent = irtibat.telefonTipKd;
                row.insertCell(8).textContent = irtibat.hatTipiKd;
            });

            // Tabloları sayfaya ekle
            tablesContainer.appendChild(customerList);
            tablesContainer.appendChild(contactList);
        })
        .catch(error => {
            console.error("Fetch işlemi sırasında bir hata oluştu:", error);
        });
});


document.getElementById("btnKurumsal").addEventListener("click", function() {
    fetch("http://localhost:5121/api/KurumsalMusteri/tumMusterileriGetir")
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response was not ok");
            }
            return response.json();
        })
        .then(data => {
            console.log(data); // Gelen veriyi konsola yazdır

            // Tablo içeriğini temizle
            const tablesContainer = document.getElementById("tablesContainer");
            tablesContainer.innerHTML = ""; // Önceki tablo içeriğini kaldır

            // Kurumsal müşteri tablosu oluştur
            const corporateCustomerList = document.createElement("table");
            corporateCustomerList.innerHTML = `
                <tr>
                    <th>Müşteri No</th>
                    <th>Vergi Kimlik No</th>
                    <th>Firma Kuruluş Tarihi</th>
                    <th>Müşteri Türü Kodu</th>
                    <th>Çalışan Sayısı</th>
                    <th>Nominal Sermaye</th>
                    <th>Kayıt Durumu</th>
                    <th>Unvan</th>
                    <th>Kısa Unvan</th>
                    <th>Gerçek/Tüzel Durumu</th>
                </tr>
            `;

            // Kurumsal müşterileri tabloya ekle
            data.kurumsalMusteri.forEach(musteri => {
                const row = corporateCustomerList.insertRow();
                row.insertCell(0).textContent = musteri.musteriNo;
                row.insertCell(1).textContent = musteri.vergiKimlikNo;
                row.insertCell(2).textContent = new Date(musteri.firmaKurulusTarihi).toLocaleDateString();
                row.insertCell(3).textContent = musteri.musteriTuruKod;
                row.insertCell(4).textContent = musteri.calisanSayisi;
                row.insertCell(5).textContent = musteri.nominalSermaye;
                row.insertCell(6).textContent = musteri.kayitDrm;
                row.insertCell(7).textContent = musteri.unvan;
                row.insertCell(8).textContent = musteri.kisaUnvan;
                row.insertCell(9).textContent = musteri.gercekTuzelDrm;
            });

            // İrtibat tablosu oluştur
            const contactList = document.createElement("table");
            contactList.innerHTML = `
                <tr>
                    <th>Müşteri No</th>
                    <th>Adres Bilgisi</th>
                    <th>E-Adres Bilgisi</th>
                    <th>Alan Kod</th>
                    <th>Telefon No</th>
                    <th>Adres Tipi</th>
                    <th>E-Adres Tipi</th>
                    <th>Telefon Tipi</th>
                    <th>Hat Tipi</th>
                </tr>
            `;

            // İrtibat müşteri bilgilerini tabloya ekle
            data.irtibatMusteri.forEach(irtibat => {
                const row = contactList.insertRow();
                row.insertCell(0).textContent = irtibat.musteriNo;
                row.insertCell(1).textContent = irtibat.adresBilgisi;
                row.insertCell(2).textContent = irtibat.eadresBilgisi; 
                row.insertCell(3).textContent = irtibat.alanKod; 
                row.insertCell(4).textContent = irtibat.telNo;
                row.insertCell(5).textContent = irtibat.adresTipKd;
                row.insertCell(6).textContent = irtibat.eadresTipKd;
                row.insertCell(7).textContent = irtibat.telefonTipKd;
                row.insertCell(8).textContent = irtibat.hatTipiKd;
            });

            // Tabloları sayfaya ekle
            tablesContainer.appendChild(corporateCustomerList);
            tablesContainer.appendChild(contactList);
        })
        .catch(error => {
            console.error("Fetch işlemi sırasında bir hata oluştu:", error);
        });
});
