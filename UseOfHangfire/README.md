<strong> Hangfire Nedir? </strong> <br/>
Arka plan işleri (Background jobları) oluşturmamıza, 
yürütmemize ve yönetmemize kolaylık sağlayan açık kaynaklı kütüphanedir.
Depolama alanı olarak birçok veritabanı 
(SQL Server, SQL Server + MSMQ, Redis ve daha fazlası),
IoC Container ve UnitTest desteklemektedir.

<strong> Hangfire Kullanmanın Avantajı </strong> <br/>
<strong> 1. </strong> Kullanımı kolay <br/>
<strong> 2. </strong> Birkaç satırla tüm .NET uygulamalarımızda çalıştırabiliriz <br/>
<strong> 3. </strong> Yönetilebilirlik ve görülebilirlik sağlar <br/>
<strong> 4. </strong> İşler veritabanında tutulduğu için güvenilirdir <br/>
<strong> 5. </strong> İş tamamlanmadıkça tamamlandı durumuna geçmez, kod bloğunun bitimine kadar çıkacak 
herhangi bir sorunda iş tekrar çalışacaktır.(Background jobların 
yarım kalması ve tekrarlanmaması)
<br/> <br/> <br/>
<strong> Hangfire job türleri </strong>
<img src="https://miro.medium.com/v2/resize:fit:1100/format:webp/1*-kltPD7LFeqwWBF6X0vXLA.png"></img>

<strong> Hangfire Kullanım Örnekleri </strong> <br/>
<strong> 1. </strong> Veritabanını güncelleme işlemleri <br/>
<strong> 2. </strong> Fatura oluşturma <br/>
<strong> 3. </strong> Aylık raporları otomatik yenileme <br/>
<strong> 4. </strong> Kaydolduktan sonra e-posta atılması <br/> <br/> 

<strong> Hangfire Örnek Kodlama </strong> <br/> <br/>
1.MVC projesi açıyoruz <br/>
![1 mvc projesinin açılması](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/b8249bb0-7d11-4228-9f96-87d11790c743)
<br/><br/>

2.Açılan MVC projesinde Hangfire kütüphanesini kullanmak için <strong> Dependecies/Manage NuGet Packages </strong> kısmına gidiyoruz  
![2 paketlere gidiş](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/1f98b363-448b-4707-a741-fc19447bddda)
<br/><br/>

3.Açılan paketler kısmından <strong> Hangfire </strong> paketini bulup yüklüyoruz
![3 hangfire paketinin yüklenmesi](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/0292dd1c-3d2f-47f1-b402-e45525105269)
<br/><br/>

4.Projemizde <strong>Data</strong> diye bir klasör açıp içine DB işlemlerimizi yapacağımız class'ı ekliyoruz <br/>
![4 klasör ve class yüklenmesi](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/9cf6ea8d-1240-4562-bc97-c9ef3f784b13)
<br/><br/>

5.DB için açtığımız class'ın içini fake olarak dolduruyoruz.Normalde DB işlemlerini de yazabiliriz
![5 class içi](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/47566b2a-2c58-4f80-91c5-9749918fd1fa)
<br/><br/>

6.Şimdi de Program.cs'de <strong> connection string </strong> 'i tanımlıyoruz
![6 connection tanımlanması](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/b754a259-54a8-44c2-9ee1-0d45eee8e045)
<br/> <br/>

7.Connection String'te tanımladığımız DB adında (HangfireDemo) bir DB oluşturuyoruz.<br/>
Çünkü Hangfire DB oluşturmaz, tables oluşturur <br/>
![7 coonection'da verdiğimiz adda bir db oluşturmak](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/f76eb245-4ab0-42e0-9948-bc6116712c4a)
<br/> <br/>

8.Hangfire kütüphanemizi servise ekliyoruz
![8 hangfire'ı servise eklemek](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/9c0871b2-fe16-4482-b0da-418e9990fdfc)
<br/> <br/>

9.Servise ekledikten sonra DB ile bağlantı kurması için UseSqlServerStorage() metoduna connectionString'i veriyoruz 
![9 hangi sql'i kullanacağını belirttik](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/d7aa461e-6b42-4680-b849-55a384883f9e)
<br/> <br/>

10.Hangfire Job Türlerinden <strong> Recurring Job </strong> 'ı kullanıyoruz. <br/>
Bu job'ın AddOrUpdate<>()  generic metodunu kullanıyoruz. Önceden varsa güncelle yoksa ekleme işlemini yap diyoruz DB'ye <br/>
Bu Generic Metod'a hangi class'la çalışacağını belirttik. <br/>
Parametre olarak da class'ın içinde hangi metodu kullanacağını verdik ve Cron Expression'ı belirttik <br/>
Cron Expression : ne kadar sürede bu işlem tekrar edecek <br/>
Cron Expression'lar ile ilgili detaylı bilgi için : <a href="https://crontab.cronhub.io/"> Crontab </a>
![10 hangi job türünü kullanacağımı söyledik](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/d0a5d7c1-f147-4992-8060-02c46840f4e6)
<br/> <br/>

11.HangfireServer ve Hangfire Dasboard'ını görmek için Program.cs'ye; <br/>
-builder.Services.AddHangfireServer(); <br/>
-app.UseHangfireDashboard(); <br/>
ekliyoruz
<br/> <br/>

Projemiz fake DB class'ı üzerinden çalışmaya hazır ve çalıştırabiliriz IIS üzerinden <br/>
Proje çalışınca belirttiğimiz DB üzerinden kendi tablolarını oluşturacaktır. <br/>
İlgili DB'ye giderek bunu da görebilirsiniz <br/>


> **Warning**
> Bende çalışırken Microsoft.Data.SqlClient paketini yüklemem de gerekti
<br/> <br/>

Açılan proje sayfasından Hangfire'ın Dashboard'ına gitmek için Default Url'sinin sonuna <strong> /hangfire </strong> ekliyoruz
<br/> <br/>

Hangfire Dashboard Ana Sayfası <br/>
![hangfire1](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/c40abe1f-3397-4ba8-b74c-89d6d9c466b5)

<br/> <br/>
Başarılı, Başarısız işlemlerin Göründüğü Kısım <br/>
![hangfire2](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/d28b8841-6536-4fa8-9531-5fa1b3104b08)

<br/> <br/>
Recurring Job olarak çalıştıracağı işlem <br/>
![hangfire3](https://github.com/yalcinselcuk/Turkcell-Task/assets/81808916/00c9a63b-73ec-4015-bba7-b8318d6d74e5)


