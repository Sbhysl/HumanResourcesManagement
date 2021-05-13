using HRManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HRManagement.Data.Repositories.Concrete
{
    public class SuggestionRepository
    {
        private static SuggestionRepository suggestionFactory = null;
        private HttpClient client;
        public static SuggestionRepository SuggestionRep
        {
            get
            {
                if (suggestionFactory==null)
                {
                    suggestionFactory = new SuggestionRepository();
                }
                return suggestionFactory;
            }
        }

        private SuggestionRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64860/");

        }

        public HttpResponseMessage GetSuggestions(out IEnumerable<Suggestion> suggestions)
        {
            var responseTask = client.GetAsync("api/Suggestions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Suggestion>>();
                readTask.Wait();
                suggestions = readTask.Result;
                return result;
            }
            else
            {
                suggestions = Enumerable.Empty<Suggestion>();
                return result;
            }
        }
        public Suggestion GetSuggestionByID(long ID)
        {
            Suggestion suggestion = new Suggestion();
            var responseTask = client.GetAsync("api/Suggestions/" + ID);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)//http yanıtı başarılıysa demek
            {
                var readTask = result.Content.ReadAsAsync<Suggestion>();
                readTask.Wait();
                suggestion = readTask.Result;
                return suggestion;
            }
            else
            {
                suggestion = null;
                return suggestion;
            }
        }
        public void Add(Suggestion suggestion)
        {
            var PostTask = client.PostAsJsonAsync<Suggestion>("api/Suggestions", suggestion);
            PostTask.Wait();
            var result = PostTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }
        public void Update(Suggestion suggestion)
        {
            var PutTask = client.PutAsJsonAsync<Suggestion>("api/Suggestions/" + suggestion.ID, suggestion);
            PutTask.Wait();
            var result = PutTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }
        public void Delete(long ID)
        {
            var DeletTask = client.DeleteAsync("api/Suggestions/" + ID);
            DeletTask.Wait();
            var result = DeletTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.ReasonPhrase);
            }
        }
    }
    
}
