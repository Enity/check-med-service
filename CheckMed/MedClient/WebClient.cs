using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CheckMed.MedClient
{
    /*
     * Прост обертка над http клиентом
     */
    public static class WebClient
    {
        public static async Task<string> PostAsync(string uri, ClientCommand body)
        {
            var client = new HttpClient();
            var encoding = CodePagesEncodingProvider.Instance.GetEncoding(1251);
            var httpContent = new StringContent(body.ToForm(), encoding, "application/x-www-form-urlencoded");
            var resp = await client.PostAsync(uri, httpContent);
            return await ParseResult(resp.Content);
        }
    
        /*
         * Ответ от сервера прилетает в говнокодировке, пришлось даже зависимость тянуть.
         * Парсим тут
         */
        private static async Task<string> ParseResult(HttpContent c)
        {
            var encoding = CodePagesEncodingProvider.Instance.GetEncoding(1251);
            
            using (TextReader reader = new StreamReader((await c.ReadAsStreamAsync()), encoding))
            {
                return reader.ReadToEnd();
            }
        }        
    }
}