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
            string carpeta = @"C:\repo9gon\";
            string NombreArch = "prueba";
            string RutarArch = carpeta + NombreArch + ".DAT";
            File.Create(RutarArch); // Crea un archivo Prueba .dat

            if (File.Exists(RutarArch)) // Crea un Comprueba si existe el archivo
            {
                Console.WriteLine("Existe " + NombreArch + ".DAT");
            }

            return RutarArch;
        }
        public static void LeerConfiguracion()
        {
            string carpeta = @"C:\repo9gon\prub.dat";
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
                Console.Write(codigos[letra.ToString()]);
            }
            //Guardar el texto traducido a morse a un archivo txt :D


            string archivo = @"C:\repo9gon\TextoAmorse.txt";
            if (!File.Exists(archivo))
            {
                File.Create(archivo);
                Console.Write("\n***** El archivo no exitia y ahora ya se creo :D*******");
                if (!File.Exists(archivo)) {
                    using (StreamWriter lectura = new StreamWriter(File.Open(archivo, FileMode.Open)))
                    {
                        lectura.Write( traducido);
                    }
                }
            }
            else
            {
                //recuperar lo que ya esta escrito en el archivo
                string[] TXT = File.ReadAllLines(archivo);
                string existe = "";
                foreach (string texto in TXT)
                {
                    existe = existe+texto;
                }
                // y finalmente escribo en el archivo
                using (StreamWriter lectura = new StreamWriter(File.Open(archivo, FileMode.Open)))
                {

                    lectura.Write(existe + traducido);

                }
            }
        }
        public static void MorseATexto(string morse)
        {
            string palabras2 = morse;

            Dictionary<string, string> codi = new Dictionary<string, string>
                      {
                            {".-   ", "a"}, { "-... ", "b"}, {"-.-. ", "c"}, {"-..  ", "d"},

                            {".    ", "e"}, {"..-. ", "f"}, {"--.  ", "g"}, {".... ", "h"},

                            {"..   ", "i"}, {".--- ", "j"}, {"-.-  ", "k"}, {".-.. ", "l"},

                            {"--   ", "m"}, {"-.   ", "n"}, {"---  ", "o"}, {".--. ", "p"},

                            {"--.- ", "q"}, {".-.  ", "r"}, {"...  ", "s"}, {"-    ", "t"},

                            {"..-  ", "u"}, {"...- ", "v"}, {".--  ", "w"}, {"-..- ", "x"},

                            {"-.-- ", "y"}, {"--.. ", "z"}, {"-----", "0"}, {".----", "1"},

                            {"..---", "2"}, {"...--", "3"}, {"....-", "4"}, {".....", "5"},

                            {"-....", "6"}, {"--...", "7"}, {"---..", "8"}, {"----.", "9"},

                            {"//// ", " "}, {".-.-.-","."}, {"--..--",","}, {"..--..","?"},

                            {"-.---", "!"}

                       };
            Console.Write("\n EL TEXTO TRADUCIDO ES: ");
            string cuatrobist = "";
            int cont = 0;//es un contador 
            string traducido = "";// concatena cada letra para guardar en el archivo
            foreach (char letr in palabras2)
            {
                cont++;
                cuatrobist += letr.ToString();//concatena cada letra en un string
                if (cont % 5 == 0)
                {
                    Console.Write(codi[cuatrobist]);
                    traducido += cuatrobist;
                    cuatrobist = "";
                }
            }
            string archivo = @"C:\repo9gon\MorseAtexto.txt";
            if (!File.Exists(archivo))
            {
                File.Create(archivo);
                Console.Write("\n***** El archivo no exitia y ahora ya se creo :D*******");
                if (!File.Exists(archivo))
                {
                    using (BinaryWriter lectura = new BinaryWriter(File.Open(archivo, FileMode.Open)))
                    {
                        lectura.Write(traducido);
                    }
                }
            }
            else
            {
                //recupera lo que ya estaba escrito en el archivo 
                string[] TXT = File.ReadAllLines(archivo);
                string existe = "";
                foreach (string texto in TXT)
                {
                    existe += texto;
                }
                // escribo en el archivo 
                using (BinaryWriter lectura = new BinaryWriter(File.Open(archivo, FileMode.Open)))
                {

                    lectura.Write(existe);
                    lectura.Write(traducido);

                }
            }
        }
    }

    public static class concatenar
    {
        public static void concatenarmp3() {
            string carpetaPunto = @"C:\repo9gon\punto.mp3";
            string CarpetaRaya= @"C:\repo9gon\raya.mp3";
            string carpetaMorse= @"C:\repo9gon\morse.mp3";
            Byte[] bufferP;
            Byte[] bufferR;
            FileStream punto = new FileStream(carpetaPunto, FileMode.Open);
            FileStream raya = new FileStream(CarpetaRaya, FileMode.Open);
            FileStream morse = new FileStream(carpetaMorse, FileMode.Create);
            string textoAmorse = @"C:\repo9gon\TextoAmorse.txt";
            string mors;
            using ( StreamReader lectura = new StreamReader(File.Open(textoAmorse, FileMode.OpenOrCreate)))
               {
                  mors = lectura.ReadLine();
                  char[] guardar = mors.ToArray();
                  byte[] bufferM = new byte[40000000];
                  for(int i=0; i<mors.Length; i++)
                  {
                    Console.Write(guardar[i]);
                      if (guardar[i] == '.')
                      {
                       bufferP = LectorCompletoDeBinario(punto);
                       morse.Write(bufferP, 0, bufferP.Length);
                      }
                      if(guardar[i]== '-')
                      {
                       bufferR = LectorCompletoDeBinario(raya);
                       morse.Write(bufferR, 0, bufferR.Length);
                      }                
                  }

                }
                morse.Flush();
                morse.Close();
                punto.Close();
                raya.Close();

        }
        public static Byte[] LectorCompletoDeBinario(Stream archivo)
        {
            byte[] buffer = new byte[3276];
            using (MemoryStream cont = new MemoryStream()) // creando un memory stream 
            {
                while (true)
                {
                    int read = archivo.Read(buffer, 0, buffer.Length); // lee desde la última posición hasta el tamaño del buffer
                    if (read <= 0)
                        return cont.ToArray(); // convierte el stream en array 
                    cont.Write(buffer, 0, read); // graba en el stream 
                }
            }
        }




    }
}
