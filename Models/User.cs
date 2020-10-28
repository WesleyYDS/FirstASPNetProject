using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FirstASPNetProject.Models
{
    public class User
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }

        public bool ShowBirthDate => !string.IsNullOrEmpty(dataNascimento.ToShortDateString());

        public string ExibirTempoDeVida(){
            double totalDeDiasVivoAteHoje, diasPorAno = 365.2425, diasPorMes = 30.4167;
            string anosDeVidaCompletos, mesesDeVidaCompletos, diasDeVidaCompletos;

            totalDeDiasVivoAteHoje = (DateTime.Today - dataNascimento).TotalDays;
            anosDeVidaCompletos =  Math.Truncate( totalDeDiasVivoAteHoje / diasPorAno).ToString();
            mesesDeVidaCompletos = Math.Truncate((totalDeDiasVivoAteHoje % diasPorAno) / diasPorMes).ToString();
            diasDeVidaCompletos =  Math.Truncate((totalDeDiasVivoAteHoje % diasPorAno) % diasPorMes).ToString();

            return "Você está vivo(a) a " + anosDeVidaCompletos + " ano(s), " + mesesDeVidaCompletos + " mes(es) e " + diasDeVidaCompletos + " dia(s).";
        }

        public string ExibirDiaDaSemana(){
            return (dataNascimento.ToString("dddd", new CultureInfo("pt-BR")));
        }

        public string DescobrirSigno(){
            int[] dataInicio = { 21, 19, 21, 21, 21, 21, 23, 23, 23, 23, 22, 22 };
            string[] signos = { "Capricórnio", "Aquário", "Peixes", "Áries", "Touro", "Gêmeos", "Câncer", "Leão", "Virgem", "Libra", "Escorpião", "Sagitário", "Capricórnio" };
            if (dataNascimento.Day < dataInicio[dataNascimento.Month - 1])
                return signos[dataNascimento.Month - 1];
            return signos[dataNascimento.Month];
        }

        public string DesejarFelizAniversario(){
            if ((dataNascimento.Month == DateTime.Today.Month)
             && (dataNascimento.Day == DateTime.Today.Day))
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
