using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol.Core.Service
{
    public class Time
    {
        public int Horas { get; set; }

        public int Minutos { get; set; }

        public Time() { }

        /// <summary>
        /// Constructor a partir de enteros horas y minutos
        /// </summary>
        /// <param name="horas"></param>
        /// <param name="minutos"></param>
        public Time(int horas, int minutos)
        {
            if (!IsValid(horas, minutos))
                throw new Exception("El campo Horas fuera de rango");

            Horas = horas;
            Minutos = minutos;
        }

        /// <summary>
        /// Constructor del objeto Time a partir de un string
        /// </summary>
        /// <param name="horaMinuto"></param>
        public Time(string horaMinuto)
        {
            if (!IsValid(horaMinuto))
                throw new ArgumentException("Formato invalido.");

            Horas = Convert.ToInt32(horaMinuto.Split(':')[0]);
            Minutos = Convert.ToInt32(horaMinuto.Split(':')[1]);
        }

        /// <summary>
        /// Reescribe para mostrar el formato de Tiem: HH:mm.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}:{1}"
                , Horas.ToString().PadLeft(2, '0')
                , Minutos.ToString().PadLeft(2, '0'));
        }

        /// <summary>
        /// Devuelve si el formato se corresponde con hora y minuto
        /// </summary>
        /// <param name="horaMinuto"></param>
        /// <returns></returns>
        static public bool IsValid(string horaMinuto)
        {
            if (string.IsNullOrWhiteSpace(horaMinuto))
                return false;

            else if (!(horaMinuto.Contains(":") && horaMinuto.Split(':').Length == 2
                && horaMinuto.Split(':')[0].Length >= 1 && horaMinuto.Split(':')[0].Length <= 2
                && horaMinuto.Split(':')[1].Length >= 1 && horaMinuto.Split(':')[1].Length <= 2))
                return false;

            // Verifica que sean números
            else if (!(Tools.IsNumber(horaMinuto.Split(':')[0]) && Tools.IsNumber(horaMinuto.Split(':')[0])
                && Tools.IsNumber(horaMinuto.Split(':')[1]) && Tools.IsNumber(horaMinuto.Split(':')[1])))
                return false;

            // Verifica los rangos de Hora
            else if (Convert.ToInt32(horaMinuto.Split(':')[0]) < 1 || Convert.ToInt32(horaMinuto.Split(':')[0]) > 24)
                return false;

            // Verifica los rangos de Minuto
            else if (Convert.ToInt32(horaMinuto.Split(':')[1]) < 0 || Convert.ToInt32(horaMinuto.Split(':')[1]) > 60)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Devuelve si el rango de Horas y Minutos son correctos.
        /// </summary>
        /// <param name="horas"></param>
        /// <param name="minutos"></param>
        /// <returns></returns>
        static public bool IsValid(int horas, int minutos)
        {
            if (horas >= 1 && horas <= 24 && minutos >= 0 && minutos <= 59)
                return true;
            else
                return false;
        }

        public int Compare(object a, object b)
        {
            Time hora1 = (Time)a;
            Time hora2 = (Time)b;
            //Primero comparo las horas
            if (hora1.Horas > hora2.Horas)
                return 1;
            else if (hora1.Horas < hora2.Horas)
                return -1;
            else
            {
                //Si las horas son iguales paso a la compración de los minutos
                if (hora1.Minutos > hora2.Minutos)
                    return 1;
                else if (hora1.Minutos < hora2.Minutos)
                    return -1;
                //Si las horas y los minutos son iguales, entonces los objetos tienen el mismo valor
                else
                    return 0;
            }
        }

        /// <summary>
        /// Wrapper del método compare,
        /// devuelve 1 si la hora1 es mayor a la hora2
        /// devuelve 0 si las horas son iguales
        /// devuelve -1 si la hora1 es menor a la hora2
        /// </summary>
        /// <param name="hora1"></param>
        /// <param name="hora2"></param>
        /// <returns></returns>
        public static int Comparar(Time hora1, Time hora2)
        {
            return new Time().Compare(hora1, hora2);
        }

        public static DateTime ConvertirFecha(DateTime f)
        {
            int año = f.Year;
            int mes = f.Month;
            int dia = f.Day;
            string fecha = año + "/" + mes + "/" + dia + " 00:00:00.000";
            return f = Convert.ToDateTime(fecha);           
        }

        public static bool operator >(Time hora1, Time hora2)
        {
            if (new Time().Compare(hora1, hora2) == 1)
                return true;
            else return false;
        }

        public static bool operator <(Time hora1, Time hora2)
        {
            if (new Time().Compare(hora2, hora1) == 1)
                return true;
            else return false;
        }

        public static bool operator ==(Time hora1, Time hora2)
        {
            if (new Time().Compare(hora2, hora1) == 0)
                return true;
            else return false;
        }

        public static bool operator !=(Time hora1, Time hora2)
        {
            if (new Time().Compare(hora2, hora1) != 0)
                return true;
            else return false;
        }

    }
}
