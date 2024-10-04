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


// TC Kimlik No alanı değiştiğinde
document.getElementById('vergiKimlikNo').addEventListener('change', function() {
    const vergiKimlikNo = this.value.trim();

   
    if (vergiKimlikNo && (vergiKimlikNo.length !== 10 )) {
        alert('Vergi Kimlik Numarası 10 haneli olmalıdır.');
        return;
    }
   
    // API isteği yapmak için fetch kullanıyoruz
    fetch(`http://localhost:5121/api/KurumsalMusteri/KNOmusteriGetir/${vergiKimlikNo}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Ağ isteği başarısız oldu');
            }
            return response.json();
        })
        .then(data => {
            // Gelen verileri forma doldur
            if (data && data.kurumsalMusteri.length > 0) {
                const kurumsalMusteri = data.kurumsalMusteri[0];
                document.getElementById('unvan').value = kurumsalMusteri.unvan || '';
                document.getElementById('calisanSayisi').value = kurumsalMusteri.calisanSayisi || '';
                document.getElementById('nominalSermaye').value = kurumsalMusteri.nominalSermaye || '';
                document.getElementById('firmaKurulusTarihi').value = kurumsalMusteri.firmaKurulusTarihi ? kurumsalMusteri.firmaKurulusTarihi.split('T')[0] : '';
                document.getElementById('musteriNo').value = kurumsalMusteri.musteriNo || '';
                document.getElementById('musteriTuru').value = kurumsalMusteri.musteriTuruKod.toString() || '';

                const irtibatMusteri = data.irtibatMusteri[0];
                document.getElementById('adres').value = irtibatMusteri.adresBilgisi || '';
                document.getElementById('eadres').value = irtibatMusteri.eadresBilgisi || '';
                document.getElementById('alanKodu').value = irtibatMusteri.alanKod || '';
                document.getElementById('telNo').value = irtibatMusteri.telNo || '';

                document.getElementById('adresTipi').value =  irtibatMusteri.adresTipKd;
                document.getElementById('eadresTipi').value = irtibatMusteri.eadresTipKd; 
                document.getElementById('telefonTipi').value =irtibatMusteri.telefonTipKd; 
                document.getElementById('hatTipi').value = irtibatMusteri.hatTipiKd;

            } else {
                alert('Müşteri bulunamadı.');
              ;
            }
        })
        .catch(error => {
            console.error('Hata:', error);
            alert('Bir hata oluştu. Lütfen tekrar deneyin.');
        });
});

// Müşteri No alanı değiştiğinde
document.getElementById('musteriNo').addEventListener('change', function() {
    const musteriNo = this.value.trim();

    // Müşteri No'nun geçerli bir tamsayı olup olmadığını kontrol et
    if (musteriNo && isNaN(musteriNo)) {
        alert('Müşteri No geçerli bir tamsayı olmalıdır.');
        return;
    }
    
    // API isteği yapmak için fetch kullanıyoruz
    fetch(`http://localhost:5121/api/KurumsalMusteri/musteriGetir/${musteriNo}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Ağ isteği başarısız oldu');
            }
            return response.json();
        })
        .then(data => {
            // Gelen verileri forma doldur
            if (data && data.kurumsalMusteri.length > 0) {
                const kurumsalMusteri = data.kurumsalMusteri[0];
                document.getElementById('unvan').value = kurumsalMusteri.unvan || '';
                document.getElementById('calisanSayisi').value = kurumsalMusteri.calisanSayisi || '';
                document.getElementById('nominalSermaye').value = kurumsalMusteri.nominalSermaye || '';
                document.getElementById('firmaKurulusTarihi').value = kurumsalMusteri.firmaKurulusTarihi ? kurumsalMusteri.firmaKurulusTarihi.split('T')[0] : '';
                document.getElementById('vergiKimlikNo').value = kurumsalMusteri.vergiKimlikNo || '';
                document.getElementById('musteriTuru').value = kurumsalMusteri.musteriTuruKod.toString() || '';

                const irtibatMusteri = data.irtibatMusteri[0];
                document.getElementById('adres').value = irtibatMusteri.adresBilgisi || '';
                document.getElementById('eadres').value = irtibatMusteri.eadresBilgisi || '';
                document.getElementById('alanKodu').value = irtibatMusteri.alanKod || '';
                document.getElementById('telNo').value = irtibatMusteri.telNo || '';

                document.getElementById('adresTipi').value =  irtibatMusteri.adresTipKd;
                document.getElementById('eadresTipi').value = irtibatMusteri.eadresTipKd; 
                document.getElementById('telefonTipi').value =irtibatMusteri.telefonTipKd; 
                document.getElementById('hatTipi').value = irtibatMusteri.hatTipiKd;
            } else {
                alert('Müşteri bulunamadı.');
                
            }
        })
        .catch(error => {
            console.error('Hata:', error);
            alert('Bir hata oluştu. Lütfen tekrar deneyin.');
            
        });
});

document.querySelector('#guncelleBtn').addEventListener('click', function () {
  
    let vergiKimlikNo = document.getElementById('vergiKimlikNo').value.trim();
    let unvan = document.getElementById('unvan').value.trim();
    let calisanSayisi = document.getElementById('calisanSayisi').value.trim();
    let nominalSermaye = document.getElementById('nominalSermaye').value.trim();
    let firmaKurulusTarihi = document.getElementById('firmaKurulusTarihi').value.trim();
    let musteriNo = document.getElementById('musteriNo').value.trim();

    let adresBilgisi = document.getElementById('adres').value.trim();
    let eadresBilgisi = document.getElementById('eadres').value.trim();
    let alanKod = document.getElementById('alanKodu').value.trim();
    let telNo = document.getElementById('telNo').value.trim();
    let adresTipKd = document.getElementById('adresTipi').value.trim();
    let eadresTipKd = document.getElementById('eadresTipi').value.trim();
    let telefonTipKd = document.getElementById('telefonTipi').value.trim();
    let hatTipiKd = document.getElementById('hatTipi').value.trim();

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

    let dto = {
        kurumsalMusteri: [{
            vergiKimlikNo: vergiKimlikNo,
            unvan: unvan,
            calisanSayisi: calisanSayisi,
            nominalSermaye: nominalSermaye,
            firmaKurulusTarihi: firmaKurulusTarihi,
            musteriNo: musteriNo
        }],
        irtibatMusteri: [{
            musteriNo: musteriNo,
            adresBilgisi: adresBilgisi,
            eadresBilgisi: eadresBilgisi,
            alanKod: alanKod,
            telNo: telNo,
            adresTipKd: adresTipKd,
            eadresTipKd: eadresTipKd,
            telefonTipKd: telefonTipKd,
            hatTipiKd: hatTipiKd
        }],
        bireyselMusteri: null
    };

    fetch('http://localhost:5121/api/KurumsalMusteri/guncelle', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dto)
    })
    .then(response => {
        if (response.ok) {
            return response.text();
        } else {
            throw new Error('Kurumsal müşteri güncellenirken hata oluştu.');
        }
    })
    .then(result => {
        alert(result);
        
    })
    .catch(error => {
        alert(error.message);
    });
});


document.getElementById("musteriIptalbtn").addEventListener("click", function() {
    const musteriNo = document.getElementById("musteriNo").value;

    if (!musteriNo) {
        alert("Lütfen müşteri numarasını girin.");
        return;
    }

    fetch(`http://localhost:5121/api/KurumsalMusteri/sil/${musteriNo}`, {
        method: "DELETE"
    })
    .then(response => {
        if (response.ok) {
            alert(`${musteriNo} numaralı müşteri başarıyla iptal edildi!`);
        } else {
            throw new Error("Müşteri silinemedi.");
        }
    })
    .catch(error => {
        alert(error.message);
    });
});