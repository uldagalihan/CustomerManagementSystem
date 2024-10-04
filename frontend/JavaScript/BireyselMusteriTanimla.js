const tabs = document.querySelectorAll('.tab');
const contents = document.querySelectorAll('.tab-content');

tabs.forEach(tab => {
    tab.addEventListener('click', () => {
        tabs.forEach(t => t.classList.remove('active'));
        contents.forEach(content => content.classList.remove('active'));

        tab.classList.add('active');
        const contentId = tab.id.replace('Tab', 'Content');
        document.getElementById(contentId).classList.add('active');
    });
});

// Temizle butonu
document.querySelector('#temizleBtn').addEventListener('click', function() {
    document.getElementById('tcKimlikNo').value = "";
    document.getElementById('ad').value = "";
    document.getElementById('soyad').value = "";
    document.getElementById('babaAdi').value = "";
    document.getElementById('anneAdi').value = "";
    document.getElementById('dogumTarihi').value = "";
    document.getElementById('sahisFirmaDurum').selectedIndex = -1;
    document.getElementById('kktcKimlikNo').value = "";
    document.getElementById('adres').value = "";
    document.getElementById('eadres').value = "";
    document.getElementById('alanKodu').value = "";
    document.getElementById('telNo').value = "";
    document.getElementById('adresTipi').selectedIndex = -1;
    document.getElementById('eadresTipi').selectedIndex = -1;
    document.getElementById('telefonTipi').selectedIndex = -1;
    document.getElementById('hatTipi').selectedIndex = -1;
});


document.querySelector('#kaydetBtn').addEventListener('click', function () {
  
    let tcKimlikNo = document.getElementById('tcKimlikNo').value;
    let musteriAd = document.getElementById('ad').value;
    let musteriSoyad = document.getElementById('soyad').value;
    let musteriBabaAdi = document.getElementById('babaAdi').value;
    let musteriAnneAdi = document.getElementById('anneAdi').value;
    let dogumTarihi = document.getElementById('dogumTarihi').value;
    let sahisFirmaDrm = document.getElementById('sahisFirmaDurum').value;
    let KKTCKimlikNo = document.getElementById('kktcKimlikNo').value;

   
    let adresBilgisi = document.getElementById('adres').value;
    let eadresBilgisi = document.getElementById('eadres').value;
    let alanKod = document.getElementById('alanKodu').value;
    let telNo = document.getElementById('telNo').value;
    let adresTipKd = document.getElementById('adresTipi').value;
    let eadresTipKd = document.getElementById('eadresTipi').value;
    let telefonTipKd = document.getElementById('telefonTipi').value;
    let hatTipiKd = document.getElementById('hatTipi').value;

    if (!tcKimlikNo) {
        alert('TC Kimlik Numarası boş bırakılamaz.');
        return;
    }
    if (tcKimlikNo.length !== 11) {
        alert('TC Kimlik Numarası 11 haneli olmalıdır.');
        return;
    }
    if (!musteriAd) {
        alert('Ad kısmı boş bırakılamaz.');
        return;
    }
    if (!musteriSoyad) {
        alert('Soyad kısmı boş bırakılamaz.');
        return;
    }
    if (!musteriBabaAdi) {
        alert('Baba Adı kısmı boş bırakılamaz.');
        return;
    }
    if (!musteriAnneAdi) {
        alert('Anne Adı kısmı boş bırakılamaz.');
        return;
    }
    if (!dogumTarihi) {
        alert('Doğum Tarihi boş bırakılamaz.');
        return;
    }
    if (!adresBilgisi) {
        alert('Adres Bilgisi boş bırakılamaz.');
        return;
    }
    if (!eadresBilgisi) {
        alert('E-Adres Bilgisi boş bırakılamaz.');
        return;
    }
    if (!eadresBilgisi.includes('@')) {
        alert('E-Adres geçerli bir e-posta adresi olmalıdır (\'@\' içermelidir).');
        return;
    }
    if (!alanKod) {
        alert('Alan Kodu boş bırakılamaz.');
        return;
    }
    if (alanKod.length !== 3 && alanKod.length !== 4) {
        alert('Alan Kodu 3 veya 4 haneli olmalıdır.');
        return;
    }
    if (!telNo) {
        alert('Telefon Numarası boş bırakılamaz.');
        return;
    }
    if (telNo.length !== 7) {
        alert('Telefon Numarası 7 haneli olmalıdır.');
        return;
    }


    let dto = {
        bireyselMusteri: [{
            tcKimlikNo: tcKimlikNo,
            musteriAd: musteriAd,
            musteriSoyad: musteriSoyad,
            musteriBabaAdi: musteriBabaAdi,
            musteriAnneAdi: musteriAnneAdi,
            dogumTarihi: dogumTarihi,
            sahisFirmaDrm: sahisFirmaDrm,
            KKTCKimlikNo: KKTCKimlikNo 
        }],
        irtibatMusteri: [{
            adresBilgisi: adresBilgisi,
            eadresBilgisi: eadresBilgisi,
            alanKod: alanKod,
            telNo: telNo,
            adresTipKd: adresTipKd,
            eadresTipKd: eadresTipKd,
            telefonTipKd: telefonTipKd,
            hatTipiKd: hatTipiKd
        }],
        kurumsalMusteri: null 
    };

   
    fetch('http://localhost:5121/api/BireyselMusteri/ekle', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dto)
    })
    .then(response => {
        if (response.ok) {
            return response.text();
        } else {
            throw new Error('Bu TC Kimlik Numarasına Kayıtlı Müşteri Zaten Var.');
        }
    })
    .then(result => {
        alert(result);
        
        // Müşteri No'yu almak için GET isteği
        return fetch(`http://localhost:5121/api/BireyselMusteri/musteriNoGetir/${tcKimlikNo}`);
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Müşteri numarası alınırken hata oluştu.');
        }
        return response.json();
    })
    .then(musteriNo => {
        // Müşteri numarasını HTML sayfasına yazdırma
        document.getElementById('musteriNo').value = musteriNo; 
        alert(`Müşteri Numarası: ${musteriNo}`);
    })
    .catch(error => {
        alert(error.message);
    });
});
