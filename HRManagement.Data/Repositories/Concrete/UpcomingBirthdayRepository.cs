using HRManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HRManagement.Data.Repositories.Concrete
{
    public class UpcomingBirthdaysRepository
    {
        private static UpcomingBirthdaysRepository birtdaysFactory = null;

        private HttpClient client;
        public static UpcomingBirthdaysRepository BirthdaysRepository
        {
            get
            {
                if (birtdaysFactory == null)
                {
                    birtdaysFactory = new UpcomingBirthdaysRepository();
                }
                return birtdaysFactory;
            }
        }

        private UpcomingBirthdaysRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64860/");

        }

        public HttpResponseMessage GetUpComingBirthdays(out IEnumerable<Personel> upcomingBirthdays)
        {
            var responseTask = client.GetAsync("api/personel/personeldogumgunleri");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var day = DateTime.Now.Day;
                var month = DateTime.Now.Month;

                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<IList<Personel>>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                upcomingBirthdays = readTask.Result;
                return result;


            }
            else
            {
                upcomingBirthdays = Enumerable.Empty<Personel>();
                return result;
            }
           
        }

        public HttpResponseMessage GetUpComingBirthdays2(out IEnumerable<Personel> upcomingBirthdays)
        {
            var responseTask = client.GetAsync("api/personel/personeldogumgunleri");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var day = DateTime.Now.Day;
                var month = DateTime.Now.Month;

                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<IList<Personel>>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                upcomingBirthdays = readTask.Result.Where(a => a.IsActive == true && a.BirthDay.Day >= day && a.BirthDay.Month == month).Take(5).ToList(); ; ;
                return result;


            }
            else
            {
                upcomingBirthdays = Enumerable.Empty<Personel>();
                return result;
            }

        }


    }
}
