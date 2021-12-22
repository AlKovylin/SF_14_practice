namespace SF_14_practice
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }        
        public long Phone { get; set; }

        public Contact(string FirstName, string Patronymic, string LastName, long Phone)
        {
            this.FirstName = FirstName;
            this.Patronymic = Patronymic;
            this.LastName = LastName;            
            this.Phone = Phone;
        }
    }
}