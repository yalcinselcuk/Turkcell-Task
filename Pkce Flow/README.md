<strong> Pkce Flow Nedir ? </strong><br/>
Client id ve secret değerleri ile oluşabilecek güvenlik zaafiyet üzerine geliştirilen önlemdir. <br/>
SPA ve Mobil App'lere kritik olan değerleri göndermek oldukça tehlikelidir. <br/>
Örnek olarak SPA'lar aslında JS'lerdir ve JS'ye gönderilen bilgiler tarayıcıda tutulur ve işlemlerini tarayıcı üzerinde gerçekleştirir. <br/>
Tarayıcı üzerinde tutulan verilere erişilebilmektedir.Bu durumda kötü niyetli kişiler tarafından bu bilgiler elde edilebilir, türlü saldırılara veya sızıntılara yol verebilir.<br/>
Mobil uygulamalar da tersine mühendislik ile çok rahat çözülebilmekte ve kendileri üzerindeki kritik bilgileri kötü niyetli kişilere kaptırabilmektedirler. 
İşte IdentityServer4 gibi framework'lerde çalışırken client'a gönderilmesi gereken kritik değerleri mevcudiyette olan böyle bir riske atmak yerine Proff Key for Code Exchange yöntemi tasarlanmıştır.
<br/> <br/>

Pkce, kullanıcı kimliğinin doğrulanmasını talep eden client'ın, Access Token elde edebilmesi için tutması gereken secret gibi kritik bilgiler yerine farklı değerler üreterek doğrulama işleminin güvenli bir şekilde yapılmasını sağlamaktadır.
Server, kendisine gelen talep içerisinde kod değişimi yapılabilecek bir doğrulayıcı ile yapacağı doğrulama neticesinde güvenli bir kullanıcı doğrulaması gerçekleştirecek ve kötü niyetli client'lardan korunmuş olur.
<br/> <br/>

PKCE uygulanmasında işlevsellik gösterecek iki etken vardır ; <br/><br/>
<strong> 1.code_verifier </strong> : Client tarafından yapılan access token talebi neticesinde doğrulama işlemi için kullanılan random üretilmiş bir kod.(43-128 karakterlik dizi) <br/>
<br/>
<strong> 2.code_challenge </strong> : code_verifier'ı doğrulamak için client'a gönderilmiş olan random üretilmiş bir kod. Bu kodu SHA256 hash algoritması ile yapabiliriz <br/> 
<br/> <br/>

<strong>ASP.NET Core'da Pkce </strong><br/>
<br/>
ASP.NET Core'da Pkce kullanımı araştırırken ASP.NET Core 2'deki  kullanımını buldum.ASP.NET Core 2'deki kullanımını ele alıcam. <br/>
<br/> <br/>
ASP.NET Core 2, kullanıma hazır yerleşik PKCE desteği içermez. <br/>

ASP.NET Core 2'de PKCE <br/>
Rastgele değer oluşturma ve Base64 URL kodlaması gibi ortak işlevlerde IdentityModel kitaplığı kullanılmıştır ve bu kitaplığı yüklemek için de ; <br/>
```
install-package IdentityModel <br/>
```
kodu kullanılmıştır. <br/>

Pkce kullanan bir yetkilendirme talebinde bulunmak için, yetkilendirme talebi bir code_challenge içermeli.Bunun için de önce code_verifier değeri oluşturulur, hash yapılır ve yetkilendirme talebine eklenir. <br/> <br/>
```
metodumuz(){ 
	// context = yetkilendirme işleminde kullandığımız instance
	if (context.ProtocolMessage.RequestType == OpenIdConnectRequestType.Authentication)
	{
		// code_verifier oluşturulur
		var codeVerifier = CryptoRandom.CreateUniqueId(32);

		// codeVerifier daha sonra kullanmak üzere saklanılır
		context.Properties.Items.Add("code_verifier", codeVerifier);

		// code_challenge oluşturulur
		string codeChallenge;
		using (var sha256 = SHA256.Create())
		{
		    var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
		    codeChallenge = Base64Url.Encode(challengeBytes);
		}

		// request'e ekleniyor
		context.ProtocolMessage.Parameters.Add("code_challenge", codeChallenge);
		context.ProtocolMessage.Parameters.Add("code_challenge_method", "S256");
	}
	return Task.CompletedTask;
}
```
<br/>

Token Talebine Pkce Desteği Ekleme <br/>
```
metodumuz(){
	if (context.TokenEndpointRequest?.GrantType == OpenIdConnectGrantTypes.AuthorizationCode){
		// code_verifier'ı alıyoruz
		if (context.Properties.Items.TryGetValue("code_verifier", out var codeVerifier))
		{
		    // token request'ine code_verifier'i ekliyoruz
		    context.TokenEndpointRequest.Parameters.Add("code_verifier", codeVerifier);
		}
	}
	return Task.CompletedTask;
}
```
