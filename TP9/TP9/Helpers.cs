using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class SoporteParaConfiguracion
    {
        public static void CrearArchivoDeConfiguracion(string Destino)
        {
            BinaryWriter Binario = new BinaryWriter(File.Open(Destino + @"\destino.dat", FileMode.OpenOrCreate));
            Binario.Write(Destino);
            Binario.Close();
        }
        public static string LeerConfiguracion(string Destino)
        {
            BinaryReader LeerBinario = new BinaryReader(File.Open(Destino + @"\destino.dat", FileMode.Open));
            string contenido = LeerBinario.ReadString();
            LeerBinario.Close();
            return contenido;
        }
    }

    public static class ConversorDeMorse
    {

        static Dictionary<string, string> DiccionarioMorse = new Dictionary<string, string>()
        {
            {"a", ".-"}, {"b", "-..."}, {"c", "-.-."}, {"d", "-.."}, {"e", "."},
            {"f", "..-." }, {"g", "--."}, {"h", "...."}, {"i", ".."}, {"j", ".---"},
            {"k", "-.-" }, {"l", ".-.."}, {"m", "--"}, {"n", "-."}, {"ñ", "--.--"},
            {"o", "---"}, {"p", ".--."}, {"q", "--.-"}, {"r", "-.-"}, {"s", "..."},
            {"t", "-"}, {"u", "..-"}, {"v", "...-"}, {"w", ".--"}, {"x", "-..-"},
            {"y", "-.--"}, {"z","--.."}, {"1", ".----"}, {"2", "..---"}, {"3", "...--"},
            {"4", "....-"}, {"5", "....."}, {"6", "-...."}, {"7", "--..."}, {"8", "---.."},
            {"9", "----."}, {"0", "-----"}, {" ", "/"}
        };


        public static string MorseATexto(string cadena)
        {
            string traduccion = "";

            foreach (char simbolo in cadena)
            {
                foreach(KeyValuePair<string, string> elemento in DiccionarioMorse)
                {
                    if(elemento.Value == Convert.ToString(simbolo))
                    {
                        traduccion = traduccion + elemento.Key;
                        break;
                    }
                }
            }

            return traduccion;
        }

        public static string TextoAMorse(string cadena)
        {
            string traduccion = "";

            cadena = cadena.ToLower();

            foreach(char letra in cadena)
            {
                foreach(KeyValuePair<string, string> elemento in DiccionarioMorse)
                {
                    if(Convert.ToChar(elemento.Key) == letra)
                    {
                        traduccion = traduccion + elemento.Value;
                        break;
                    }
                }
            }

            return traduccion;
        }
    }
}
