using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Web.Models;

namespace Web.Controllers
{
	public class Main : Controller
	{
		[HttpPost]
		public ActionResult Register(string email, string password)
		{
			// E-posta ve şifre bilgilerini SQL veritabanına kaydetmek için gerekli işlemleri burada yapabilirsiniz.

			// Örnek olarak Entity Framework kullanarak kayıt işlemini gerçekleştirelim.
			try
			{
				using (var dbContext = new ShopContext()) // DbContext'inizi burada yerine koyun
			{
				string hashedPassword = HashPasword(password,out var salt);

				var custom = new Customer()
				{
					Email = email,
					Password = hashedPassword
				};

				dbContext.Customs.Add(custom);
				dbContext.SaveChanges();
			}
			}
			catch (System.Exception e)
			{
				
				Console.WriteLine(e);
			}
			// Kayıt işlemi başarılı olduysa başka bir sayfaya yönlendirin
			return RedirectToAction("RegistrationSuccess");
		}

		const int keySize = 64;
const int iterations = 350000;
HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
public string HashPasword(string password, out byte[] salt)
{
    salt = RandomNumberGenerator.GetBytes(keySize);
    var hash = Rfc2898DeriveBytes.Pbkdf2(
        Encoding.UTF8.GetBytes(password),
        salt,
        iterations,
        hashAlgorithm,
        keySize);
     return Convert.ToHexString(hash);
}
	
	}
}
