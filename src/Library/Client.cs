using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualBasic;

namespace Library
{
    public class Client
    {
        public List<Oportunitie> Oportunities = new List<Oportunitie>();
        public List<Interaction> Interactions = new List<Interaction>();
        public Client(string id, string name, string lastName, string email, string phone, gender gender, string birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Inactive = false;
            this.Waiting = true;
            this.Gender = gender;
            this.BirthDate = birthDate;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Tag { get; set; }
        public string Phone { get; set; }
        public bool Inactive { get; set; }
        public bool Waiting { get; set; }
        public gender Gender { get; set; }
        public string BirthDate { get; set; }

        public enum gender
        {
            male,female
        }
        public enum TypeOfData
        {
            Name,LastName,Email,Phone
        }

        public void ModifyClient(TypeOfData modified, string modification)
        {
            if (modified == TypeOfData.Name)
            {
                this.Name = modification;
            }
            else if (modified == TypeOfData.LastName)
            {
                this.LastName = modification;
            }
            else if (modified == TypeOfData.Email)
            {
                this.Email = modification;
            }
            else
            {
                this.Phone = modification;
            }
        }

        public void AddInteraction(Interaction interaction)
        {
            Interactions.Add(interaction);
        }
    }
}