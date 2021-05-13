using HRManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HRManagement.Data.Repositories.Concrete
{
    public class UpcomingPaymentRep
    {
        private static UpcomingPaymentRep paymentsFactory = null;

        private HttpClient client;
        public static UpcomingPaymentRep PaymentRep
        {
            get
            {
                if (paymentsFactory == null)
                {
                    paymentsFactory = new UpcomingPaymentRep();
                }
                return paymentsFactory;
            }
        }

        private UpcomingPaymentRep()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64860/");

        }

        public HttpResponseMessage GetUpComingPayments(out IEnumerable<Personel> upcomingPayments)
        {
            var responseTask = client.GetAsync("api/personel/YaklasanOdemeBilgileri");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<IList<Personel>>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                upcomingPayments = readTask.Result;
                return result;

            }
            else
            {
                upcomingPayments = Enumerable.Empty<Personel>();
                return result;
            }

        }
    }
}
