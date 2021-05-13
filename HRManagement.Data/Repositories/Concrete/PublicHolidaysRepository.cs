using HRManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HRManagement.Data.Repositories.Concrete
{
    public class PublicHolidaysRepository
    {
        private static PublicHolidaysRepository holidaysFactory = null;

        //Singleton yapısı kullanıyoruz direk olarak PublicHolidaysRepository.HolidaysRepository dediğimizde tüm fonksiyonlara herhangi bir globalde atama işlemi yapmadan sadece using ekleyerek tüm burdaki fonksiyonları kullanabilimek için

        private HttpClient client;
        public static PublicHolidaysRepository HolidaysRepository
        {
            get
            {
                if (holidaysFactory == null)
                {
                    holidaysFactory = new PublicHolidaysRepository();
                }

                return holidaysFactory;
            }
        }

        private PublicHolidaysRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64860/");
        }

        //Burdaki yapı HttResponseMessage return değeri olarak işlem başarılımı döndürsün ama aynı zamanda out diyerek çağırıldığı yerdeki listeyi doldurması için

        public HttpResponseMessage GetPublicHolidays(out IEnumerable<PublicHolidays> publicHolidays)
        {
            //Constructer da tanımladığımız api linkinden apinin controllerına erişiyoruz api/publicholidays ile

            var responseTask = client.GetAsync("api/publicholidays");
            // yapılan işlem asycrn olduğu için cevabı beklemeliyiz bu yüzden var responseTask ataması yaptıktan sonra wait kullanılmalı
            responseTask.Wait();

            var result = responseTask.Result;

            //gelen yapıdan sonucu çekiyoruz
            if (result.IsSuccessStatusCode)
            {
                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<IList<PublicHolidays>>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                publicHolidays = readTask.Result;
                return result;
            }
            else
            {
                //işlem başarılı olmadığında if(result.IsSuccessStatusCode) boş bir liste döndürüyoruz ki crash olmasın hata dönsün sadece
                publicHolidays = Enumerable.Empty<PublicHolidays>();
                return result;
            }


        }

        public PublicHolidays GetPublicHolidaysByID(long ID)
        {
            //Constructer da tanımladığımız api linkinden apinin controllerına erişiyoruz api/publicholidays/id ile
            PublicHolidays publicHolidays = new PublicHolidays();
            var responseTask = client.GetAsync("api/publicholidays/" + ID);
            // yapılan işlem asycrn olduğu için cevabı beklemeliyiz bu yüzden var responseTask ataması yaptıktan sonra wait kullanılmalı
            responseTask.Wait();

            var result = responseTask.Result;

            //gelen yapıdan sonucu çekiyoruz
            if (result.IsSuccessStatusCode)
            {
                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<PublicHolidays>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                publicHolidays = readTask.Result;
                return publicHolidays;
            }
            else
            {
                //işlem başarılı olmadığında if(result.IsSuccessStatusCode) boş bir liste döndürüyoruz ki crash olmasın hata dönsün sadece
                publicHolidays = null;
                return publicHolidays;
            }
        }

        public void Add(PublicHolidays publicHolidays)
        {

            //Burada gelen objeyi post metodu ile apiye yönlendiriyoruz.
            var PostTask = client.PostAsJsonAsync<PublicHolidays>("api/publicholidays", publicHolidays);
            PostTask.Wait();

            var result = PostTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }

        public void Update(PublicHolidays publicHolidays)
        {

            //burada pu işlemi ile yönlendirme yapıyoruz. 
            var PutTask = client.PutAsJsonAsync<PublicHolidays>("api/publicholidays/" + publicHolidays.ID, publicHolidays);
            PutTask.Wait();
            var result = PutTask.Result;

            if (!result.IsSuccessStatusCode)
                throw new Exception(result.ReasonPhrase);

        }


        public void Delete(long ID)
        {
            //Delete işlemi
            var DeleteTask = client.DeleteAsync("api/publicholidays/" + ID);
            DeleteTask.Wait();
            var result = DeleteTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }

    }
}
