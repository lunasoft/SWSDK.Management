namespace SW.Services.User
{
    public class UserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public ProfileAccountEnum Profile = ProfileAccountEnum.User;
        public bool Active = true;
    }

    public enum ProfileAccountEnum
    {
     
        None = 0,
        Admin = 1,
        Dealer = 2, 
        User = 3,
        Other = 4
    }

    public class UserUnlimit : UserRequest
    {
        public bool Unlimited = true;
    }
    public class UserStamp : UserRequest
    {
        public int Stamps { get; set; }
        public bool Unlimited = false;
    }

    public class UserUpdate 
    {
        public string Name { get; set; }
        public string RFC { get; set; }
        public bool Unlimited { get; set; }
        public bool Active { get; set; }
    }
}
