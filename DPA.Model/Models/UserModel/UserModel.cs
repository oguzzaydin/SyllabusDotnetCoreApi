namespace DPA.Model
{
    public class UserModel
    {
        public long UserId { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public Roles Roles { get; set; }

        public Title Title { get; set; }
    }
}