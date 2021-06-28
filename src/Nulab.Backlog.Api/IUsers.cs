namespace Nulab.Backlog.Api
{
    using System.Threading.Tasks;
    using Data.Responses;

    public interface IUsers
    {
        /// <summary>
        /// ユーザー情報を取得します。
        /// </summary>
        /// <param name="id">ユーザーのID</param>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-user/#
        /// </remarks>
        Task<BacklogResponse<User>> GetAsync(int id);

        /// <summary>
        /// 認証ユーザー情報を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://developer.nulab.com/ja/docs/backlog/api/2/get-own-user/#
        /// </remarks>
        Task<BacklogResponse<LoginUser>> GetMySelfAsync();
    }

    public sealed class LoginUser
    {
        public int id { get; set; }
        
        public string userId { get; set; }
        
        public string name { get; set; }
        
        public int roleType { get; set; }
        
        public string lang { get; set; }
        
        public string mailAddress { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(userId)}: {userId}, {nameof(name)}: {name}, {nameof(roleType)}: {roleType}, {nameof(lang)}: {lang}, {nameof(mailAddress)}: {mailAddress}";
        }
    }
}