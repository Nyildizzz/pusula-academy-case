# Pusula Academy Case Study

Bu repository, Pusula Academy case çalışması kapsamında verilen kod sorularının çözümlerini içermektedir.

## Proje Yapısı

```
pusula-academy-case/
├── MaxIncreasingSubArrayAsJson.cs
├── LongestVowelSubsequenceAsJson.cs
├── FilterPeopleFromXml.cs
├── FilterEmployees.cs
├── test.cs
├── TestProject/
│   ├── Program.cs (Test Runner)
│   ├── MaxIncreasingSubArrayAsJson.cs
│   ├── LongestVowelSubsequenceAsJson.cs
│   ├── FilterPeopleFromXml.cs
│   ├── FilterEmployees.cs
│   └── TestProject.csproj
└── README.md
```

## Kod Soruları ve Çözümleri

### 1. MaxIncreasingSubArrayAsJson.cs
**Problem:** Verilen bir integer listesinde en uzun artan alt diziyi bulup JSON formatında döndüren fonksiyon.

**Çözüm Yaklaşımı:**
- Tek geçişte (O(n)) algoritma kullanılmıştır
- Mevcut artan diziyi takip ederken, en uzun olanı kaydeder
- Sonuç JSON string olarak döndürülür

**Örnek Kullanım:**
```csharp
MaxIncreasingSubArray.MaxIncreasingSubArrayAsJson(new List<int> { 1, 2, 3, 1, 2 })
// Sonuç: "[1,2,3]"
```

### 2. LongestVowelSubsequenceAsJson.cs
**Problem:** Verilen kelime listesinde en uzun sesli harf alt dizisine sahip kelimeyi bulup JSON formatında döndüren fonksiyon.

**Çözüm Yaklaşımı:**
- Her kelimenin sesli harflerini sırayla ayıklar
- En uzun sesli harf dizisini bulur
- Sonucu detaylı JSON objesi olarak döndürür

**Örnek Kullanım:**
```csharp
LongestVowelSubsequence.LongestVowelSubsequenceAsJson(new List<string> { "aeiou", "bcd", "aaa" })
// Sonuç: JSON objesi (word, sequence, length içerir)
```

### 3. FilterPeopleFromXml.cs
**Problem:** XML formatındaki kişi verilerini filtreleyen ve sonucu JSON formatında döndüren fonksiyon.

**Çözüm Yaklaşımı:**
- LINQ to XML kullanarak XML parse edilir
- Yaş >= 30 ve Departman == "IT" filtresi uygulanır
- İstatistik bilgileri hesaplanır (toplam, ortalama, max maaş)
- Sonuç JSON formatında döndürülür

**Filtreleme Kriterleri:**
- Yaş >= 30
- Departman == "IT"

### 4. FilterEmployees.cs
**Problem:** Tuple listesi şeklindeki çalışan verilerini çoklu kriterlere göre filtreleyen fonksiyon.

**Çözüm Yaklaşımı:**
- Çoklu LINQ Where filtreleri uygulanır
- Özel sıralama: İsim uzunluğu (azalan) → İsim alfabetik (artan)
- İstatistikler hesaplanır
- Unicode karakterler için özel JSON encoder kullanılır

**Filtreleme Kriterleri:**
- Yaş: 25-40 arası
- Departman: "IT" veya "Finance"
- Maaş: 5000-9000 arası
- İşe Giriş: 2017-01-01'den sonra

## Test Yapısı

### Test Runner (TestProject/Program.cs)
- Tüm fonksiyonlar için unit testler içerir
- Basit Assert sınıfı ile test sonuçları kontrol edilir
- Her test grubunun sonuçları konsola yazdırılır

### Test Çalıştırma
```bash
cd TestProject
dotnet run
```

### Test Sonuçları
✅ **MaxIncreasingSubarrayAsJson Tests**: 5/5 PASS  
✅ **LongestVowelSubsequenceAsJson Tests**: 8/8 PASS  
✅ **FilterPeopleFromXml Tests**: 3/3 PASS  
✅ **FilterEmployees Tests**: 4/4 PASS  

**Toplam: 20/20 test başarılı**

## Teknik Detaylar

### Kullanılan Teknolojiler
- .NET 6.0+
- System.Text.Json (JSON serialization)
- System.Xml.Linq (XML processing)
- LINQ (veri filtreleme ve işleme)

### Özel Çözümler
- **Unicode Karakter Desteği**: Türkçe karakterler (ş, ğ, ü, etc.) için `UnsafeRelaxedJsonEscaping` encoder kullanılmıştır
- **Clean Code Prensipleri**: Her fonksiyon tek sorumluluk prensibi ile yazılmıştır
- **Performans**: Tüm çözümler optimal zaman karmaşıklığında (O(n)) çalışır
- **Null Safety**: Tüm fonksiyonlarda null kontrolleri mevcuttur

### Kod Kalitesi
- **Okunabilirlik**: Açıklayıcı değişken isimleri ve yapı
- **Modülerlik**: Her problem ayrı sınıfta çözülmüş
- **Test Edilebilirlik**: Tüm fonksiyonlar static ve bağımsız
- **Hata Yönetimi**: Edge case'ler (boş liste, null değer) ele alınmış

## Geliştirici Notları

### Sınıf İsimlendirme Sorunu Çözümü
Orijinal kodlarda sınıf adları ile metot adlarının aynı olması nedeniyle C# derleyici hatası alınıyordu (CS0542). Bu sorun şu şekilde çözüldü:
- Sınıf isimleri değiştirildi (örn: `MaxIncreasingSubArray` vs `MaxIncreasingSubArrayAsJson`)
- Test runner'da uygun referanslar güncellendi

### JSON Serialization Ayarları
Türkçe karakterlerin doğru görüntülenmesi için:
```csharp
var options = new JsonSerializerOptions 
{ 
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
};
```

## Teslim Formatı
Repository aşağıdaki dosyaları içermektedir:
- ✅ MaxIncreasingSubArrayAsJson.cs
- ✅ LongestVowelSubsequenceAsJson.cs  
- ✅ FilterPeopleFromXml.cs
- ✅ FilterEmployees.cs
- ✅ test.cs (ek test dosyası)
- ✅ README.md (bu dosya)

---

