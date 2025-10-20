namespace Library
{
    public class Client
    {
        public Client(string name, string lastName, string email, string phone)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Inactive { get; set; }
        public bool Waiting { get; set; }
    }
}