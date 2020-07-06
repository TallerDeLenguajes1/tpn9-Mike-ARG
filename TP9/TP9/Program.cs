using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace TP9
{
    class Program
    {
        static void Main(string[] args)
        {
            string Directorio = @"C:\Repogit\tp9\";

            if (!Directory.Exists(Directorio + @"bin\debug\"))
            {
                Directory.CreateDirectory(Directorio + @"bin\debug\");
            }

            if (!Directory.Exists(Directorio + @"Morse\"))
            {
                Directory.CreateDirectory(Directorio + @"Morse\");
            }

            List<string> ListaDeArchivos = Directory.GetFiles(Directorio + @"\bin\debug\").ToList();

            SoporteParaConfiguracion.CrearArchivoDeConfiguracion(Directorio + @"Morse\");

            Console.WriteLine("---------- Lista de Archivos ----------");
            Console.WriteLine("");

            foreach(string archivo in ListaDeArchivos)
            {
                Console.WriteLine(archivo);

                if(Path.GetExtension(archivo) == ".mp3" || Path.GetExtension(archivo) == ".txt")
                {
                    Directory.Move(archivo, Directorio + @"Morse\" + Path.GetFileName(archivo));
                }
            }

            string ruta = Directorio + @"Morse\";

            Console.WriteLine("\nIngrese una cadena de texto: ");
            string cadena = Console.ReadLine();

            string codigoMorse = ConversorDeMorse.TextoAMorse(cadena);
            string fecha = DateTime.Now.ToString("dd-MM-yy");

            string rutaAux = ruta + "morse_[" + fecha + "].txt";

            File.WriteAllText(rutaAux, codigoMorse);

            string codigoMorse2 = File.ReadAllText(rutaAux);
            string textoOriginal = ConversorDeMorse.MorseATexto(codigoMorse2);
            string rutaTexto = ruta + "morseTraducido_[" + fecha + "].txt";
            File.WriteAllText(rutaTexto, textoOriginal);
            Console.WriteLine("Texto original: " + textoOriginal);
        }
    }
}
