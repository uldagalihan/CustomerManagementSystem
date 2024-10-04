const tabs = document.querySelectorAll('.tab');
const contents = document.querySelectorAll('.tab-content');

tabs.forEach(tab => {
    tab.addEventListener('click', () => {
        // Aktif sekmeyi ve içeriklerini güncelle
        tabs.forEach(t => t.classList.remove('active'));
        contents.forEach(content => content.classList.remove('active'));

        tab.classList.add('active');
        const contentId = tab.id.replace('Tab', 'Content');
        document.getElementById(contentId).classList.add('active');
    });
});

document.querySelector('#temizleBtn').addEventListener('click', function() {
 
    document.getElementById('vergiKimlikNo').value = "";
    document.getElementById('unvan').value = "";
    document.getElementById('calisanSayisi').value = "";
    document.getElementById('nominalSermaye').value = "";
    document.getElementById('firmaKurulusTarihi').value = "";
    document.getElementById('musteriNo').value = "";
    document.getElementById('musteriTuru').selectedIndex = -1;
    document.getElementById('adres').value = "";
    document.getElementById('eadres').value = "";
    document.getElementById('alanKodu').value = "";
    document.getElementById('telNo').value = "";
    document.getElementById('musteriNoReadonly').value = "";
    document.getElementById('adresTipi').selectedIndex = -1;
    document.getElementById('eadresTipi').selectedIndex = -1;
    document.getElementById('telefonTipi').selectedIndex = -1;
    document.getElementById('hatTipi').selectedIndex = -1;
});


document.querySelector('#kaydetBtn').addEventListener('click', function () {
   
    let vergiKimlikNo = document.getElementById('vergiKimlikNo').value;
    let unvan = document.getElementById('unvan').value;
    let calisanSayisi = document.getElementById('calisanSayisi').value;
    let nominalSermaye = document.getElementById('nominalSermaye').value;
    let firmaKurulusTarihi = document.getElementById('firmaKurulusTarihi').value;
    let musteriTuruKod = document.getElementById('musteriTuru').value;

    let adresBilgisi = document.getElementById('adres').value;
    let eadresBilgisi = document.getElementById('eadres').value;
    let alanKod = document.getElementById('alanKodu').value;
    let telNo = document.getElementById('telNo').value;
    let adresTipKd = document.getElementById('adresTipi').value;
    let eadresTipKd = document.getElementById('eadresTipi').value;
    let telefonTipKd = document.getElementById('telefonTipi').value;
    let hatTipiKd = document.getElementById('hatTipi').value;

    if (!vergiKimlikNo) {
        alert('Vergi Kimlik Numarası boş bırakılamaz.');
        return;
    }
    if (vergiKimlikNo.length !== 10) {
        alert('Vergi Kimlik Numarası 10 haneli olmalıdır.');
        return;
    }
    if (!unvan) {
        alert('Unvan boş bırakılamaz.');
        return;
    }
    if (!calisanSayisi) {
        alert('Çalışan Sayısı boş bırakılamaz.');
        return;
    }
    if (!nominalSermaye) {
        alert('Nominal Sermaye boş bırakılamaz.');
        return;
    }
    if (!firmaKurulusTarihi) {
        alert('Firma Kuruluş Tarihi boş bırakılamaz.');
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

    // DTO objesi
    let dto = {
       kurumsalMusteri: [{
            vergiKimlikNo: vergiKimlikNo,
            unvan: unvan,
            calisanSayisi: calisanSayisi,
            nominalSermaye: nominalSermaye,
            firmaKurulusTarihi: firmaKurulusTarihi,
            musteriTuruKod: musteriTuruKod
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
        }]
    };

    // Web API'ye POST isteği gönderme
    fetch('http://localhost:5121/api/KurumsalMusteri/ekle', {
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
            throw new Error('Bu Vergi Kimlik Numarasına Kayıtlı Müşteri Zaten Var.');
        }
    })
    .then(result => {
        // Müşteri numarasını almak için GET isteği gönder
        return fetch(`http://localhost:5121/api/KurumsalMusteri/musteriNoGetir/${vergiKimlikNo}`);
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Müşteri numarası alınırken hata oluştu.');
        }
        return response.json();
    })
    .then(musteriNo => {
        // Müşteri numarasını tbox'a yaz
        document.getElementById('musteriNo').value = musteriNo;
        alert('Müşteri başarıyla kaydedildi. Müşteri No: ' + musteriNo);
    })
    .catch(error => {
        alert(error.message);
    });
});
