namespace DPA.Model
{
    public class TokenModel
    {
        public TokenModel(string token, ListUserModel userInfo)
        {
            Token = token;
            UserInfo = userInfo;
        }

        public string Token { get; }

        public ListUserModel UserInfo { get; set; }
    }
}