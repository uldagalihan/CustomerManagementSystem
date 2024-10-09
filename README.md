# Bankalar için Müşteri Yönetim Sistemi

Bu proje, bireysel ve kurumsal müşterileri destekleyen kapsamlı bir müşteri yönetim sistemi tasarlanmıştır. Hem Windows Forms uygulaması hem de web arayüzü üzerinden tam CRUD işlemleri yapılmasını sağlar.

## Özellikler
- Bireysel ve kurumsal müşteri kayıtlarını ekleme, güncelleme veya silme
- Otomatik olarak oluşturulan müşteri numaraları
- Müşteri numarası veya ID'ye göre müşteri verilerini alma
- Kullanıcı dostu bir arayüzden müşteri bilgilerini listeleme ve yönetme

## Proje Yapısı
- **Backend:** C# WebAPI
- **Frontend:** HTML, CSS, JavaScript
- **Veritabanı:** SQL Server (tablo, tetikleyici ve başlangıç verisi oluşturma komut dosyaları ile birlikte)

## Kullanılan Teknolojiler
- Frontend: HTML, CSS, JavaScript
- Backend: C#, WebAPI
- Veritabanı: SQL Server

## Başlarken

### Gereksinimler
- .NET SDK'nın yüklü olması
- SQL Server'ın yüklü olması
- Modern bir web tarayıcısı

### Kurulum
1. Depoyu klonlayın:
    ```bash
    git clone https://github.com/uldagalihan/CustomerManagementSystem.git
    cd CustomerManagementSystem
    ```
2. **Backend Kurulumu:**
   - Visual Studio'da `/backend` klasörünü açın
   - WebAPI projesini oluşturun ve çalıştırın

3. **Frontend Kurulumu:**
   - `AnaForm.html` dosyasını bir web tarayıcısında açın veya bir web sunucusuna dağıtın.

4. **Veritabanı Kurulumu:**
   - SQL Server veritabanınızı ayarlamak için `/database` klasöründeki komut dosyalarını çalıştırın.

## Kullanım
1. Web arayüzünü açın veya API çağrıları yapmak için Postman kullanın.
2. UI veya API üzerinden müşterileri ekleyin, güncelleyin, okuyun veya silin.


## Screenshots
![Main Form](images/screenshots/mainForm.png)
![Individual Customer Listing](images/screenshots/individualCustomerList.png)


