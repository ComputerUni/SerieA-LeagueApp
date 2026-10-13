# SerieA League Management Application

Profesyonel futbol liginin tüm verilerini yönetmek ve takip etmek için tasarlanmış tam özellikli bir web uygulaması.

## 📋 Proje Özellikleri

- **Takım Yönetimi**: Ligateki tüm takımları ekleyin, düzenleyin ve yönetin
- **Oyuncu Yönetimi**: Takım oyuncularının bilgilerini detaylı şekilde yönetin
- **Maç Yönetimi**: Maçları planlayın, sonuçlarını girin ve detaylı istatistikler takip edin
- **Puan Durumu**: Canlı puan tablosu ve sıralamaları görüntüleyin
- **İstatistikler**: En çok gol atan oyuncular, en çok asist yapanlar ve diğer performans metriklerini takip edin
- **Haftalık Fikstür**: Yaklaşan maçları hafta hafta görüntüleyin
- **Maç Detayları**: Gol, kartlar, ikame oyuncular ve istatistikler gibi detaylı maç bilgilerini kaydedin
- **Yönetim Paneli**: Admin panelinde tüm yönetim işlemleri için merkezi arayüz

## 🛠 Teknoloji Stack

### Backend (SerieA.API)
- **.NET 8**: Modern C# çerçevesi
- **ASP.NET Core**: REST API geliştirme
- **Entity Framework Core**: Veri tabanı yönetimi
- **AutoMapper**: DTO eşlemeleri
- **Swagger/OpenAPI**: API dokümantasyonu

### Frontend (SerieA.WebUI)  
- **ASP.NET Core MVC**: İçerik sunumu
- **Bootstrap 5**: Responsive tasarım
- **jQuery**: İstemci tarafı işlemleri
- **Razor Pages/View Components**: Dinamik içerik

## 📂 Proje Yapısı

```
SerieA/
├── SerieA.API/              # REST API Projesi
│   ├── Controllers/         # API Endpoints
│   ├── Context/            # Veritabanı Bağlamı
│   ├── DTOs/               # Data Transfer Objects
│   ├── Entities/           # Veritabanı Modelleri
│   ├── Mappings/           # AutoMapper Konfigürasyonları
│   └── Migrations/         # EF Core Migrasyonları
│
└── SerieA.WebUI/            # Web Arayüzü Projesi
	├── Controllers/        # MVC Controllers
	├── Views/              # Razor Views
	├── ViewComponents/     # Yeniden kullanılabilir Komponentler
	└── wwwroot/           # Statik dosyalar (CSS, JS, kütüphaneler)
```

## 🖼️ Uygulama Görünümleri

### Gol Krallığı
![Gol Krallığı](screenshots/Ekran%20görüntüsü%202026-10-13%20131032.png)

### Asist Krallığı
![Asist Krallığı](screenshots/Ekran%20görüntüsü%202026-10-13%20131044.png)

### Maç Detayı
![Maç Detayı](screenshots/Ekran%20görüntüsü%202026-10-13%20131127.png)

### Maç Detayı Genel
![Maç Detayı Genel](screenshots/Ekran%20görüntüsü%202026-10-13%20131152.png)

### Haftalık Fikstür
![Haftalık Fikstür](screenshots/Ekran%20görüntüsü%202026-10-13%20131214.png)

### Puan Durumu
![Puan Durumu](screenshots/Ekran%20görüntüsü%202026-10-13%20131308.png)

### Dashboard
![Dashboard](screenshots/Ekran%20görüntüsü%202026-10-13%20155055.png)

### Maçlar
![Maçlar](screenshots/Ekran%20görüntüsü%202026-10-13%20155106.png)

### Goller
![Goller](screenshots/Ekran%20görüntüsü%202026-10-13%20155115.png)

### Kartlar
![Kartlar](screenshots/Ekran%20görüntüsü%202026-10-13%20155131.png)

### İstatistikler 
![İstatistikler](screenshots/Ekran%20görüntüsü%202026-10-13%20155142.png)

### Oyuncular
![Oyuncular](screenshots/Ekran%20görüntüsü%202026-10-13%20155203.png)

### Panel Puan Durumu
![Panel Puan Durumu](screenshots/Ekran%20görüntüsü%202026-10-13%20155219.png)

## 🚀 Kullanmaya Başlama

### Gereksinimler
- .NET 8 SDK
- Visual Studio 2022 veya VS Code
- SQL Server (varsayılan) veya başka bir desteklenen DB

### Kurulum Adımları

1. **Repoyu klonlayın**
   ```bash
   git clone https://github.com/ComputerUni/SerieA-LeagueApp.git
   cd SerieA
   ```

2. **Veritabanı migrasyonlarını uygulayın**
   ```bash
   cd SerieA.API
   dotnet ef database update
   ```

3. **API'ı başlatın**
   ```bash
   cd SerieA.API
   dotnet run
   ```
   API: `https://localhost:5001` adresinde çalışacaktır

4. **WebUI'ı başlatın**
   ```bash
   cd SerieA.WebUI
   dotnet run
   ```
   Uygulama: `https://localhost:7001` adresinde açılacaktır

## 📡 API Endpoints

### Takımlar
- `GET /api/teams` - Tüm takımları listele
- `GET /api/teams/{id}` - Takım detaylarını getir
- `POST /api/teams` - Yeni takım oluştur
- `PUT /api/teams/{id}` - Takımı güncelle
- `DELETE /api/teams/{id}` - Takımı sil

### Oyuncular
- `GET /api/players` - Tüm oyuncuları listele
- `GET /api/players/{id}` - Oyuncu detaylarını getir
- `POST /api/players` - Yeni oyuncu oluştur
- `PUT /api/players/{id}` - Oyuncuyu güncelle
- `DELETE /api/players/{id}` - Oyuncuyu sil

### Maçlar
- `GET /api/matches` - Tüm maçları listele
- `GET /api/matches/{id}` - Maç detaylarını getir
- `POST /api/matches` - Yeni maç oluştur
- `PUT /api/matches/{id}` - Maçı güncelle

### Puan Durumu & İstatistikler
- `GET /api/standings` - Puan tablosunu getir
- `GET /api/stats/top-scorers` - En çok gol atanları getir
- `GET /api/stats/top-assists` - En çok asist yapanları getir
- `GET /api/match-statistics/{matchId}` - Maç istatistiklerini getir

## 🔧 Mimari Özellikleri

### API Tasarımı
- RESTful standartlarına uygun endpoint yapısı
- CORS desteği ile frontend entegrasyonu
- AutoMapper ile DTO transformasyonları
- Entity Framework Core ile ORM

### Frontend Tasarımı
- View Components ile bileşenleştirilmiş yapı
- Bootstrap grid sistemi ile responsive layout
- Admin ve public arayüz ayrımı
- Modal ve form validasyonları

## 🌐 Ana Sayfalar

- `/` - Genel bilgi ve luga genel bakış
- `/standing` - Puan durumu ve sırlamalar
- `/stat/top-goals` - En çok gol atan oyuncular
- `/stat/top-assists` - En çok asist yapan oyuncular
- `/weekly-fixture` - Haftalık maçlar
- `/match/list` - Tüm maçlar
- `/dashboard` - Admin paneli (Yönetim)

