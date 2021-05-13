using HRManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HRManagement.Data.Repositories.Concrete
{
    public class CompanyRepository
    {
        private static CompanyRepository companyFactory = null;

        private HttpClient client;

        public static CompanyRepository CompanRep
        {
            get
            {
                if (companyFactory == null)
                {
                    companyFactory = new CompanyRepository();
                }
                return companyFactory;
            }
        }

        private CompanyRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64860/");
        }

        public HttpResponseMessage GetOffCompanies(out IEnumerable<Company> companies)
        {
            var responseTask = client.GetAsync("api/Companies");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<IList<Company>>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                companies = readTask.Result;
                return result;

            }
            else
            {
                companies = Enumerable.Empty<Company>();
                return result;
            }
        }

        public Company GetCompanyByID (long ID)
        {
            Company company = new Company();
            var responseTask = client.GetAsync("api/Companies/" + ID);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                //sonuçtan gelen veriyi çekiyoruz
                var readTask = result.Content.ReadAsAsync<Company>();
                readTask.Wait();
                //geri dönecek olan listeyi yüklüyoruz
                company = readTask.Result;
                return company;
            }
            else
            {
                //işlem başarılı olmadığında if(result.IsSuccessStatusCode) boş bir liste döndürüyoruz ki crash olmasın hata dönsün sadece
                company = null;
                return company;
            }
        }

        public void Update(Company company)
        {
            var PutTask = client.PutAsJsonAsync<Company>("api/Companies/" + company.ID, company);
            PutTask.Wait();
            var result = PutTask.Result;

            if (!result.IsSuccessStatusCode)
                throw new Exception(result.ReasonPhrase);
        }







    }


    
}
