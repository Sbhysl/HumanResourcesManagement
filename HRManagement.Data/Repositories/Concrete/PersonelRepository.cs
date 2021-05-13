using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using HRManagement.Data.Entities;

namespace HRManagement.Data.Repositories.Concrete
{

    public class PersonelRepository
    {
        private static PersonelRepository personelRep = null;


        private HttpClient client;

        public static PersonelRepository PersonelsRepository
        {
            get
            {
                if (personelRep==null)
                {
                    personelRep=new PersonelRepository();
                }

                return personelRep;
            }
        }
        public PersonelRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64860/");
        }


        public List<DepartmanCountView> GetDepartmanInfo()
        {
            List<DepartmanCountView> departmanCountViews = new List<DepartmanCountView>();

            var responseTask = client.GetAsync("api/personels");//personeli çektik
            responseTask.Wait();//bekledik hepsi geldiyse

            var result = responseTask.Result;//gelenler result a doldu
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Personel>>();//listeyi aldık
                readTask.Wait();

                //for (int i = 1; i < 5; i++)
                //{
                //    DepartmanCountView departmanCountView = new DepartmanCountView();
                //    departmanCountView.DepartmanID = i.ToString();
                //    departmanCountView.DepartmanEmployeeCount = 0;
                //    departmanCountViews.Add(departmanCountView);
                //}


                //foreach (Personel item in readTask.Result)
                //{
                //    foreach (DepartmanCountView item2 in departmanCountViews)
                //    {
                //        if (item2.DepartmanID == item.Departments.ToString())
                //        {
                //            item2.DepartmanEmployeeCount++;
                //        }
                //    }
                //}

                return departmanCountViews;
            }
            else//boşsa liste çekilmediyse
            {
                //boş personel yolladık
                return departmanCountViews;//boşu döndürdük
            }
        }

        public HttpResponseMessage GetPersonels1(out IEnumerable<Personel> Personels)
        {
            var responseTask = client.GetAsync("api/personels");//personeli çektik
            responseTask.Wait();//bekledik hepsi geldiyse

            var result = responseTask.Result;//gelenler result a doldu
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Personel>>();//listeyi aldık
                readTask.Wait();
                Personels = readTask.Result;
                return result;
            }
            else//boşsa liste çekilmediyse
            {
                Personels = Enumerable.Empty<Personel>();//boş personel yolladık
                return result;//boşu döndürdük
            }
        }

        public HttpResponseMessage GetPersonelsByOffDay(out IEnumerable<Personel> Personels)
        {
            var responseTask = client.GetAsync("api/personels/");//personeli çektik
            responseTask.Wait();//bekledik hepsi geldiyse

            var result = responseTask.Result;//gelenler result a doldu
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Personel>>();//listeyi aldık
                readTask.Wait();
                Personels = readTask.Result.Where(a => a.IsActive == true).ToList();
                return result;
            }
            else//boşsa liste çekilmediyse
            {
                Personels = Enumerable.Empty<Personel>();//boş personel yolladık
                return result;//boşu döndürdük
            }
        }

        public Personel GetPersonelByID(long ID)
        {
            Personel personel= new Personel();
            var getByID = client.GetAsync("api/personels/" + ID);
            getByID.Wait();
            var result = getByID.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Personel>();
                readTask.Wait();
                personel = readTask.Result;
                return personel;
            }
            else
            {
                personel = null;
                return personel;
            }
        }
        public void Add(Personel personel)
        {

           var PutTask = client.PostAsJsonAsync<Personel>("api/personels", personel);
            PutTask.Wait();

            var result = PutTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }
        public void Update(Personel personel)
        {
            var PutTask = client.PutAsJsonAsync<Personel>("api/personels/" + personel.ID, personel);
            PutTask.Wait();
            var result = PutTask.Result;

            if (!result.IsSuccessStatusCode)
                throw new Exception(result.ReasonPhrase);

        }
        public void Delete(long ID)
        {
            var DeleteTask = client.DeleteAsync("api/personels/" + ID);
            DeleteTask.Wait();
            var result = DeleteTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }
        public HttpResponseMessage GetPersonels2(out IEnumerable<Personel> Personels)
        {
            var day = DateTime.Now.Day;
            var month = DateTime.Now.Month;


            var responseTask = client.GetAsync("api/personels");//personeli çektik
            responseTask.Wait();//bekledik hepsi geldiyse

            var result = responseTask.Result;//gelenler result a doldu
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Personel>>();//listeyi aldık
                readTask.Wait();
                Personels = readTask.Result.Where(a => a.IsActive == true && a.BirthDay.Day >= day && a.BirthDay.Month == month).ToList();
                return result;
            }
            else//boşsa liste çekilmediyse
            {
                Personels = Enumerable.Empty<Personel>();//boş personel yolladık
                return result;//boşu döndürdük
            }
        }
    }
}
