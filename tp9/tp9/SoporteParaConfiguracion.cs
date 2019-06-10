using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helper
{
    public static class SoporteParaConfiguracion
    {
        public static string CrearArchivo()
        {
            string carpeta = @"E:\taller_1\repo9\";
            string NombreArch = "prueba";
            string RutarArch = carpeta + NombreArch + ".DAT";
            File.Create(RutarArch); // Crea un archivo Prueba .dat
                           
            if (File.Exists(RutarArch)) // Crea un Comprueba si existe el archivo
            {
                Console.WriteLine("Existe "+NombreArch+".DAT");
            }
            
            return RutarArch;
        }
        public static void LeerConfiguracion()
        {
            string carpeta = @"E:\taller_1\repo9\prub.dat";
            if (File.Exists(carpeta))
            {
                using (BinaryWriter lectura = new BinaryWriter(File.Open(carpeta, FileMode.Open)))
                {
                    lectura.Write("hola cele :D");

                }

                using (BinaryReader lectura = new BinaryReader(File.Open(carpeta, FileMode.Open)))
                {
                    
                    string salida = lectura.ReadString();
                   Console.Write(salida);

                }
             
            }
            else
            {
                File.Create(carpeta);

                using (BinaryWriter lectura = new BinaryWriter(File.Open(carpeta, FileMode.Open)))
                {
                    lectura.Write("hola cele :D");
                }

            }

        }

    }
    public static class ConversorDeMorse
    {
        public static void TextoAMorse(string text)
        {
            string palabras = text;

            Dictionary<string, string> codigos = new Dictionary<string, string>

                        {

                            {"a", ".-   "}, {"b", "-... "}, {"c", "-.-. "}, {"d", "-..  "},

                            {"e", ".    "}, {"f", "..-. "}, {"g", "--.  "}, {"h", ".... "},

                            {"i", "..   "}, {"j", ".--- "}, {"k", "-.-  "}, {"l", ".-.. "},

                            {"m", "--   "}, {"n", "-.   "}, {"o", "---  "}, {"p", ".--. "},

                            {"q", "--.- "}, {"r", ".-.  "}, {"s", "...  "}, {"t", "-"},

                            {"u", "..-  "}, {"v", "...- "}, {"w", ".--  "}, {"x", "-..- "},

                            {"y", "-.-- "}, {"z", "--.. "}, {"0", "-----"}, {"1", ".----"},

                            {"2", "..---"}, {"3", "...--"}, {"4", "....-"}, {"5", "....."},

                            {"6", "-...."}, {"7", "--..."}, {"8", "--..."}, {"9", "----."},

                            {" ", "//// "}, {".",".-.-.-"}, {",","--..--"}, {"?","..--.."},

                            {"!", "-.---"}

                        };
            Console.Write("\n EL TEXTO TRADUCIDO ES: ");
            string traducido = "";

            foreach (char letra in palabras)
            {
                traducido += codigos[letra.ToString()];
                Console.Write(codigos[letra.ToString()] + " ");
            }
            //Guardar el texto traducido a morse a un archivo txt :D

            
            string archivo = @"E:\taller_1\repo9\morse.txt";
            if (!File.Exists(archivo))
            {
                File.Create(archivo);
                Console.Write("\n***** El archivo no exitia y ahora ya se creo :D*******");
                if (!File.Exists(archivo)){ 
                     using (BinaryWriter lectura = new BinaryWriter(File.Open(archivo, FileMode.Open)))
                    {           
                             lectura.Write(text + " = " + traducido);
                    }
                }
            }
            else
            {
                //recuperar lo que ya esta escrito en el archivo
                string[] TXT = File.ReadAllLines(archivo);
                    string existe = "";
                    foreach(string texto in TXT)
                    {
                        existe += texto;
                    }
                    // y finalmente escribo en el archivo
                using (BinaryWriter lectura = new BinaryWriter(File.Open(archivo, FileMode.Open)))
                {
                  
                    lectura.Write(existe);
                    lectura.Write(text + " = "+traducido);

                }
            }
        }
          public static void MorseATexto(string morse)
          {
              string palabras2 = morse;

              Dictionary<string, string> codi = new Dictionary<string, string>
                      {
                            {".-", "a"}, { "-... ", "b"}, {"-.-. ", "c"}, {"-..  ", "d"},

                            {".     ", "e"}, {"..-. ", "f"}, {"--.  ", "g"}, {".... ", "h"},

                            {"..   ", "i"}, {".--- ", "j"}, {"-.-  ", "k"}, {".-.. ", "l"},

                            {"--   ", "m"}, {"-.    ", "n"}, {"---  ", "o"}, {".--. ", "p"},

                            {"--.- ", "q"}, {".-.  ", "r"}, {"...  ", "s"}, {"-    ", "t"},

                            {"..-  ", "u"}, {"...- ", "v"}, {".--  ", "w"}, {"-..-  ", "x"},

                            {"-.-- ", "y"}, {"--.. ", "z"}, {"-----", "0"}, {".----", "1"},

                            {"..---", "2"}, {"...--", "3"}, {"....-", "4"}, {".....", "5"},

                            {"-....", "6"}, {"--...", "7"}, {"---..", "8"}, {"----.", "9"},

                            {"//// ", " "}, {".-.-.-","."}, {"--..--",","}, {"..--..","?"},

                            {"-.---", "!"}

                       };
              Console.Write("\n EL TEXTO TRADUCIDO ES: ");
              foreach (char letr in palabras2)
              {
                  Console.Write(codi[letr.ToString()]);
              }
          }

    }
}
