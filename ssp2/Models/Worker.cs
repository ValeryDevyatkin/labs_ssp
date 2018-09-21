namespace ssp2.Models
{
    public class Worker
    {
        public int Id { get; private set; }
        public string Fio { get; set; }
        public int Age { get; set; }
        public string Speciality { get; set; }

        public Worker(string fio, int age, string speciality)
        {
            Fio = fio;
            Age = age;
            Speciality = speciality;
        }

        public Worker()
        {
            
        }
    }
}