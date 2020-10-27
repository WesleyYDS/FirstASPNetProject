using System;
using System.ComponentModel.DataAnnotations;

namespace FirstASPNetProject.Models
{
    public class User
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }

        public bool ShowBirthDate => !string.IsNullOrEmpty(dataNascimento.ToShortDateString());

        public double CompararData(DateTime nascimento){
            return (Math.Truncate((DateTime.Today - nascimento).TotalDays / 365.2425));
        }

        public string HappyBirthday(DateTime nascimento){
            if ((nascimento.Month == DateTime.Today.Month)
             && (nascimento.Day == DateTime.Today.Day))
            {
                return "Aliás, feliz aniversário! 🎉🎊🥳";
            }
            else
            {
                return "";
            }
        }
    }
}
