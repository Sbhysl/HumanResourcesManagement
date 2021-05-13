using HRManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HRManagement.Data.Repositories.Concrete
{
    public class OffDayRepository
    {
        private static OffDayRepository offDaysFactory = null;

        private HttpClient client;
        public static OffDayRepository OffDayRep
        {
            get
            {
                if (offDaysFactory == null)
                {
                    offDaysFactory = new OffDayRepository();
                }
                return offDaysFactory;
            }
        }

        private OffDayRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64860/");

        }

        public HttpResponseMessage GetOffDays(out IEnumerable<OffDay> offDays)
        {
            var responseTask = client.GetAsync("api/OffDays");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<IList<OffDay>>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                offDays = readTask.Result;
                return result;

            }
            else
            {
                offDays = Enumerable.Empty<OffDay>();
                return result;
            }
        }
        public OffDay GetOffDaysByID(long ID)
        {
            OffDay offDay = new OffDay();
            var responseTask = client.GetAsync("api/OffDays/" + ID);
            responseTask.Wait();

            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<OffDay>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                offDay = readTask.Result;
                return offDay;
            }
            else
            {
                //işlem başarılı olmadığında if(result.IsSuccessStatusCode) boş bir liste döndürüyoruz ki crash olmasın hata dönsün sadece
                offDay = null;
                return offDay;
            }
        }
        public void Add(OffDay offDay)
        {

            //Burada gelen objeyi post metodu ile apiye yönlendiriyoruz.
            var PostTask = client.PostAsJsonAsync<OffDay>("api/OffDays", offDay);
            PostTask.Wait();

            var result = PostTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }

        public void Update(OffDay offDay)
        {

            var PutTask = client.PutAsJsonAsync<OffDay>("api/OffDays/" + offDay.ID,offDay);
            PutTask.Wait();
            var result = PutTask.Result;

            if (!result.IsSuccessStatusCode)
                throw new Exception(result.ReasonPhrase);

        }


        public void Delete(long ID)
        {
            //Delete işlemi
            var DeleteTask = client.DeleteAsync("api/OffDays/" + ID);
            DeleteTask.Wait();
            var result = DeleteTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }
    }
}
