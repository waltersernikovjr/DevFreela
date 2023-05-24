using System;

namespace DevFreela.Aplication.InputModels
{
    public class NewUserInputModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }
    }
}
