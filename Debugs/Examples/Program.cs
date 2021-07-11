using System;
using System.Threading.Tasks;
using Nulab.Backlog.Api;
using Nulab.Backlog.Api.Data.Responses;

namespace Examples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Client client = new Client("https://<your backlog page url>.backlog.com");
            client.AddCredentials(new ApiTokenCredentials("<your backlog api token>"));

            BacklogResponse<LoginUser> response = await client.Users.GetMySelfAsync();
            LoginUser loginUser = response.Content;

            Console.WriteLine($"ID:{loginUser.id}, Name:{loginUser.name}, MailAddress:{loginUser.mailAddress}");
        }
    }
}
