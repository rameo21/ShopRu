# ShopsRUs Retail Store Discounts

Bu proje, ShopsRUs adlı bir perakende mağazası için müşterilere indirimler hesaplama ve fatura oluşturma yeteneklerini sağlayan bir RESTful API'yi içerir.

## Proje Açıklaması

ShopsRUs, müşterilerine aşağıdaki indirimleri sağlamak istemektedir:

1. Mağaza çalışanı ise, %30 indirim alır.
2. Mağaza ortağı ise, %10 indirim alır.
3. Kullanıcı 2 yıldan uzun süredir müşteri ise, %5 indirim alır.
4. Her $100 harcamada $5 indirim uygulanır.
5. Yüzde bazlı indirimler gıda ürünleri üzerinde uygulanmaz.
6. Bir kullanıcı bir fatura üzerinde yalnızca yüzde bazlı bir indirim alabilir.

## Proje Yapısı

Proje, aşağıdaki ana sınıfları içerir:

- `Bill`: Fatura bilgilerini ve müşteri bilgisini içerir.
- `Product`: Ürün bilgilerini içerir.
- `User`: Kullanıcı bilgilerini içerir.
- `BillService`: Fatura hesaplamalarını yapar ve indirimleri uygular.
- `Startup`: API'yi yapılandırır ve hizmetleri kaydeder.

ShopRuUML.drawio dosyasını https://app.diagrams.net/ üzerinden açabilirsiniz

## Proje Kurulumu

1. .NET Core SDK'yi yükleyin: https://dotnet.microsoft.com/download
2. Projeyi bilgisayarınıza klonlayın.
3. Terminal veya komut istemcisini açın ve proje dizinine gidin.
4. Projeyi derlemek ve çalıştırmak için aşağıdaki komutları kullanın:

```bash
dotnet build
dotnet run```

## API Kullanımı

API'yi test etmek için bir API istemcisi (örneğin, Postman) kullanabilirsiniz. Aşağıda, POST /api/discount/calculate endpoint'i için bir örnek istek bulunmaktadır:

POST /api/discount/calculate

{
    "user": {
        "userType": "Employee",
        "insertDate": "2022-01-01"
    },
    "products": [
        {
            "name": "Product1",
            "price": 100,
            "isGrocery": false
        },
        {
            "name": "Product2",
            "price": 50,
            "isGrocery": true
        }
    ]
}

## Testler

Projede, NUnit kullanılarak yazılmış bir dizi test bulunmaktadır. Testleri çalıştırmak için aşağıdaki komutu kullanabilirsiniz:

``` dotnet test
