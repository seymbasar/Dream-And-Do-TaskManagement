# 🚀 Dream & Do - Task Management System (Trello Clone)

<img width="1885" height="879" alt="Image" src="https://github.com/user-attachments/assets/8aa5d5a9-2893-4c8b-90e9-fb0bb4e89508" />

## 🇹🇷 Proje Hakkında (TR)
**Dream & Do**, modern iş akışlarını yönetmek için tasarlanmış, kurumsal kod standartlarını estetik ve hızla birleştiren profesyonel bir web uygulamasıdır. Bu proje, **Arı Bilgi** bünyesinde tamamladığım 250 saatlik Yazılım Uzmanlığı eğitimi kapsamında, temiz kod prensipleri uygulanarak geliştirilmiştir.

### ✨ Öne Çıkan Özellikler
* **Dinamik Yönetim:** Kullanıcılar sınırsız pano (Board) oluşturabilir ve bu panolar altında görevlerini (Card) yönetebilir.
* **Asenkron Veri Akışı (AJAX):** Görev durumları, sayfa yenilenmeden Fetch API üzerinden MSSQL veritabanında anlık olarak güncellenir.
* **Gelişmiş Arama:** JavaScript tabanlı filtreleme ile panolar arasında anlık arama yapılabilir.
* **Kurumsal Mimari:** Proje; Entity, DataAccess, Business ve Presentation olmak üzere **4 katmanlı (N-Tier)** yapı üzerine kurulmuştur.
* **Performans Optimizasyonu:** Veri çekme süreçlerinde **Eager Loading (Include)** metodolojisi kullanılarak sorgu maliyetleri minimize edilmiştir.

---

## 🇺🇸 About The Project (EN)
**Dream & Do** is a professional task management system built on enterprise architecture principles, combining high-quality backend standards with a modern frontend experience. It was developed as a capstone project during my 250-hour Software Specialist training at **Arı Bilgi**.

### ✨ Key Features
* **Dynamic Management:** Users can create unlimited boards and manage tasks within these boards.
* **Asynchronous Data Flow (AJAX):** Task statuses are updated instantly in the MSSQL database via Fetch API without page reloads.
* **Advanced Search:** Instant filtering across boards using JavaScript-based search logic.
* **Enterprise Architecture:** Built on a **4-layer (N-Tier)** structure including Entity, DataAccess, Business, and Presentation layers.
* **Performance:** Optimized data fetching with **Eager Loading (Include)** to minimize query costs.

---

## 🛠️ Teknik Stack / Tech Stack
* **Backend:** ASP.NET MVC, C# (.NET Framework 4.7.2+)
* **Database:** MSSQL Server (Entity Framework 6 / LINQ)
* **Pattern:** Generic Repository Pattern
* **Frontend:** JavaScript (ES6+), CSS3 (Custom Theme), HTML5, FontAwesome

---

## ⚙️ Kurulum / Installation
1.  **Veritabanı:** `TrelloClone.sql` dosyasını SQL Server'da çalıştırın.
2.  **Bağlantı Ayarı:** `DataAccessLayer/Concrete/Context.cs` veya `Web.config` içerisindeki Connection String bilgisini güncelleyin.
3.  **Çalıştırma:** Visual Studio'da projeyi derleyip (Build) `F5` ile ayağa kaldırın.

---

## 🗺️ Yol Haritası (Roadmap)
- [ ] Identity ile Kullanıcı Giriş & Yetkilendirme.
- [ ] Sürükle-Bırak (Drag & Drop) desteği.
- [ ] Kartlara özel Deadline (Son Tarih) sistemi.
