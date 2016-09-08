using bzale.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Diagnostics.Contracts;
using System.Text;

namespace bzale.Core.TestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CategoryDTO category = new CategoryDTO
            //{
            //    Name = "Main category 3 ",
            //    Description = "My third main",
            //    Image = new ImageDTO()
            //};
            //CreateMainCategory(category);

            AccountCreateDTO acc = new AccountCreateDTO
            {
                Email = "test@test.dk",
                FirstName = "Chris",
                LastName = "Søren",
                ConfirmEmail = "test@test.dk",
                Password = "qwerty"
                
            };
            CreateAccount(acc);

            Console.Read();
        }


        readonly static string baseuri = "http://localhost:52481/api/category/create";

        public static async Task<List<CategoryDTO>> GetCategoriesAsync()
        {

            using (HttpClient httpClient = new HttpClient())
            {

                return JsonConvert.DeserializeObject<List<CategoryDTO>>(
                    await httpClient.GetStringAsync(baseuri)
                );
            }
        }

        public static void CreateMainCategory( CategoryDTO emp)
        {

            using (var client = new HttpClient())
            {
                var jsonstring = JsonConvert.SerializeObject(emp);

                var response =  client.PostAsync(baseuri, new StringContent(jsonstring, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Document posted successfully.");
                }
                else
                {
                    Console.WriteLine("Document NOT posted successfully.");
                }
            }
        }
        public static void CreateAccount(AccountCreateDTO acc)
        {

            using (var client = new HttpClient())
            {
                var jsonstring = JsonConvert.SerializeObject(acc);

                var response = client.PostAsync(baseuri, new StringContent(jsonstring, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Document posted successfully.");
                }
                else
                {
                    Console.WriteLine("Document NOT posted successfully.");
                }
            }
        }
    }
}
