![Ana Sayfa](Screenshots/anasayfa.png)

Dream & Do - ASP.NET MVC Trello Clone

Dream & Do, modern iş akışlarını yönetmek için tasarlanmış, N-Tier Architecture (N-Katmanlı Mimari) prensiplerine dayalı profesyonel bir web uygulamasıdır. Backend'deki kurumsal kod standartlarını, frontend'deki estetik ve hızla birleştirir.

Öne Çıkan Özellikler

Dinamik Kategori & Görev Yönetimi: Kullanıcılar sınırsız pano (Board) açabilir ve bu panolar altında görevlerini (Card) yönetebilir.Otomatik 

Liste Mimarisi: Her yeni pano oluşturulduğunda, BusinessLayer arka planda otomatik olarak bir "Genel" liste tanımlar.Anlık Durum 

Güncelleme (AJAX): Görevlerin tamamlanma durumu, sayfa yenilenmeden Fetch API üzerinden asenkron olarak MSSQL veritabanında güncellenir.Gelişmiş Arama Motoru: JavaScript tabanlı keyup olayları ile panolar arasında anlık filtreleme yapılabilir. 

Modern Onay Mekanizması: Silme gibi kritik işlemler için projeye özel tasarlanmış, animasyonlu ModernConfirm modal sistemi.

Eager Loading Performansı: Include metodolojisi ile Board -> List -> Card hiyerarşisi performans kaybı yaşanmadan tek bir sorgu ile çekilir.

Teknik Stack

Backend: ASP.NET MVC, C# (.NET Framework 4.7.2+)
Veritabanı: MSSQL Server (Entity Framework 6 / LINQ)
Mimari: N-Tier Architecture (Entity, DataAccess, Business, UI)
Frontend: JavaScript (ES6+), CSS3 (Custom Theme Logic), HTML5, FontAwesomeTasarım 
Pattern: Generic Repository Pattern 

Proje Katman Yapısı
EntityLayerVeritabanı tablolarının POCO sınıfları (Board, Card, List, Admin).

DataAccessLayerContext yapılandırması, GenericRepository ve tabloya özel Dal sınıfları.

BusinessLayerİş mantığı denetimleri (Validation) ve Manager sınıfları üzerinden servis yönetimi.

Presentation (UI)Controller yönetimi (BoardController), asenkron JS dosyaları ve estetik View yapıları.

KurulumTrelloClone.sql dosyasını SQL Server'da çalıştırarak veritabanını hazırlayın.DataAccessLayer/Concrete/Context.cs içindeki Connection String bilgisini kendi sunucunuza göre güncelleyin.Visual Studio'da projeyi derleyip (Build) çalıştırın.

Yol Haritası (Roadmap)
[ ] Kullanıcı Giriş & Yetkilendirme Sistemi (Identity).
[ ] Drag & Drop (Sürükle-Bırak) ile kartların listeler arası taşınması.
[ ] Kartlara özel detaylı açıklama (Description) ve Son Tarih (Deadline) desteği.
Bu proje, modern yazılım mimarilerini ve temiz kod prensiplerini uygulamak amacıyla geliştirilmiştir.



Dream&Do Projesi - Kurulum ve Çalıştırma Rehberi

Bu proje, C# (Entity Framework) ve SQL Server altyapısı kullanılarak geliştirilmiş bir görev yönetim sistemidir. Projenin yerel ortamınızda sorunsuz çalışması için aşağıdaki adımları sırasıyla uygulayınız.


1. Veritabanı Kurulumu

Proje klasörü içinde yer alan **TrelloClone.sql** dosyası, hem tablo yapılarını hem de başlangıç verilerini içermektedir.

1. **SQL Server Management Studio (SSMS)** uygulamasını açın.
2. `TrelloClone.sql` dosyasını editöre sürükleyin.
3. **Önemli:** Dosya başındaki `FILENAME` yolları geliştirici bilgisayarına özeldir. Eğer çalıştırmada hata alırsanız:
   - Önce boş bir `TrelloClone` veritabanı oluşturun.
   - SQL dosyasındaki `CREATE TABLE` ve `INSERT` satırlarından itibaren seçerek bu veritabanında çalıştırın.
4. Sorguyu başarıyla çalıştırdıktan sonra tabloların ve örnek verilerin (Boardlar, Kartlar vb.) oluştuğunu teyit edin.


2. Bağlantı Ayarları (Connection String)

Projenin veritabanınıza erişebilmesi için bağlantı adresini güncellemeniz gerekebilir:

1. Visual Studio'da **Web.config** veya **App.config** dosyasını açın.
2. `<connectionStrings>` bölümündeki `Data Source` kısmını kontrol edin.
3. Eğer varsayılan SQL örneğini kullanıyorsanız `Data Source=.` olarak bırakın. Özel bir isim kullanıyorsanız (örn: `.\SQLEXPRESS`) bu kısmı güncelleyin.

```xml
<add name="Context" connectionString="data source=.;initial catalog=TrelloClone;integrated security=True;" providerName="System.Data.SqlClient" />

3. Projeyi Başlatma
TrelloClone.sln dosyasına çift tıklayarak projeyi Visual Studio ile açın.

Proje üzerinde sağ tıklayıp "Restore NuGet Packages" seçeneğine tıklayarak eksik kütüphaneleri indirin.

Üst menüden Build > Rebuild Solution diyerek projeyi derleyin.

F5 tuşuna basarak projeyi ayağa kaldırın.

Olası Sorunlar ve Çözümleri
Giriş Bilgileri: Veritabanındaki Admins tablosunda varsayılan olarak kullanıcı adı admin, şifre 12345 olarak tanımlanmıştır.

Versiyon Hatası: Eğer SQL Server sürümünüz çok eskiyse, dosyadaki bazı modern SQL komutları hata verebilir. Bu durumda sadece tablo oluşturma kodlarını çalıştırmanız yeterlidir.

Boş Ekran: Eğer veriler gelmiyorsa, SQL Server servislerinizin (MSSQLSERVER) çalıştığından emin olun.

