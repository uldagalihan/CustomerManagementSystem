const tabs = document.querySelectorAll('.tab');
const contents = document.querySelectorAll('.tab-content');

tabs.forEach(tab => {
    tab.addEventListener('click', () => {
        tabs.forEach(t => t.classList.remove('active'));
        contents.forEach(content => content.classList.remove('active'));

        tab.classList.add('active');
        document.getElementById(tab.id.replace('Tab', 'Content')).classList.add('active');
    });
});


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



// TC Kimlik No alanı değiştiğinde
document.getElementById('tcKimlikNo').addEventListener('change', function() {
    const tcKimlikNo = this.value.trim();

    // TC Kimlik No'nun 11 haneli olup olmadığını kontrol et
    if (tcKimlikNo && (tcKimlikNo.length !== 11 )) {
        alert('TC Kimlik Numarası 11 haneli olmalıdır.');
        return;
    }
   
    // API isteği yapmak için fetch kullanıyoruz
    fetch(`http://localhost:5121/api/BireyselMusteri/KNOmusteriGetir/${tcKimlikNo}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Ağ isteği başarısız oldu');
            }
            return response.json();
        })
        .then(data => {
            // Gelen verileri forma doldur
            if (data && data.bireyselMusteri.length > 0) {
                const bireyselMusteri = data.bireyselMusteri[0];
                document.getElementById('ad').value = bireyselMusteri.musteriAd || '';
                document.getElementById('soyad').value = bireyselMusteri.musteriSoyad || '';
                document.getElementById('babaAdi').value = bireyselMusteri.musteriBabaAdi || '';
                document.getElementById('anneAdi').value = bireyselMusteri.musteriAnneAdi || '';
                document.getElementById('musteriNo').value = bireyselMusteri.musteriNo || '';
                document.getElementById('kktcKimlikNo').value = bireyselMusteri.KKTCKimlikNo || '';
                document.getElementById('dogumTarihi').value = bireyselMusteri.dogumTarihi ? bireyselMusteri.dogumTarihi.split('T')[0] : '';
                document.getElementById('sahisFirmaDurum').value = bireyselMusteri.sahisFirmaDrm;

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

// Müşteri No alanı değiştiğinde
document.getElementById('musteriNo').addEventListener('change', function() {
    const musteriNo = this.value.trim();

    // Müşteri No'nun geçerli bir tamsayı olup olmadığını kontrol et
    if (musteriNo && isNaN(musteriNo)) {
        alert('Müşteri No geçerli bir tamsayı olmalıdır.');
        return;
    }
    
    // API isteği yapmak için fetch kullanıyoruz
    fetch(`http://localhost:5121/api/BireyselMusteri/musteriGetir/${musteriNo}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Ağ isteği başarısız oldu');
            }
            return response.json();
        })
        .then(data => {
            // Gelen verileri forma doldur
            if (data && data.bireyselMusteri.length > 0) {
                const bireyselMusteri = data.bireyselMusteri[0];
                document.getElementById('ad').value = bireyselMusteri.musteriAd || '';
                document.getElementById('soyad').value = bireyselMusteri.musteriSoyad || '';
                document.getElementById('babaAdi').value = bireyselMusteri.musteriBabaAdi || '';
                document.getElementById('anneAdi').value = bireyselMusteri.musteriAnneAdi || '';
                document.getElementById('musteriNo').value = bireyselMusteri.musteriNo || '';
                document.getElementById('kktcKimlikNo').value = bireyselMusteri.KKTCKimlikNo || '';
                document.getElementById('tcKimlikNo').value = bireyselMusteri.tcKimlikNo || ''; 
                document.getElementById('dogumTarihi').value = bireyselMusteri.dogumTarihi ? bireyselMusteri.dogumTarihi.split('T')[0] : '';
                document.getElementById('sahisFirmaDurum').value =bireyselMusteri.sahisFirmaDrm;

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
  
    let tcKimlikNo = document.getElementById('tcKimlikNo').value.trim();
    let musteriAd = document.getElementById('ad').value.trim();
    let musteriSoyad = document.getElementById('soyad').value.trim();
    let musteriBabaAdi = document.getElementById('babaAdi').value.trim();
    let musteriAnneAdi = document.getElementById('anneAdi').value.trim();
    let dogumTarihi = document.getElementById('dogumTarihi').value.trim();
    let sahisFirmaDrm = document.getElementById('sahisFirmaDurum').value.trim();
    let KKTCKimlikNo = document.getElementById('kktcKimlikNo').value.trim();
    let musteriNo = document.getElementById('musteriNo').value.trim();

   
    let adresBilgisi = document.getElementById('adres').value.trim();
    let eadresBilgisi = document.getElementById('eadres').value.trim();
    let alanKod = document.getElementById('alanKodu').value.trim();
    let telNo = document.getElementById('telNo').value.trim();
    let adresTipKd = document.getElementById('adresTipi').value.trim();
    let eadresTipKd = document.getElementById('eadresTipi').value.trim();
    let telefonTipKd = document.getElementById('telefonTipi').value.trim();
    let hatTipiKd = document.getElementById('hatTipi').value.trim();

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
            KKTCKimlikNo: KKTCKimlikNo,
            musteriNo:musteriNo
        }],
        irtibatMusteri: [{
            musteriNo:musteriNo,
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

   
    fetch('http://localhost:5121/api/BireyselMusteri/guncelle', {
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
            throw new Error('Müşteri eklenirken hata oluştu.');
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

    fetch(`http://localhost:5121/api/BireyselMusteri/sil/${musteriNo}`, {
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
