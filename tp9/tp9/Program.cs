using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using System.IO;

namespace tp9
{
    class Program
    {
        static void Main(string[] args)
        {
            // crear archivo
            string Archivo = SoporteParaConfiguracion.CrearArchivo();
            SoporteParaConfiguracion.LeerConfiguracion();
            string pegar = @"C:\repo9gon\tp9\tp9\bin\Debug";
            string copiar= @"C:\repo9gon\";
            string result;
            string [] mostrar;
            result = Path.GetFileName(pegar);
           // Console.WriteLine("GetFileName('{0}') returns '{1}'",path1, result);

           // copio archivos de tipo mp3 y txt
            try
            { 
               mostrar = Directory.GetFiles(pegar);
                foreach(string leer in  mostrar){
                 Console.Write("\n"+leer);
                }
            
                string[] busque = Directory.GetFiles(pegar, "*.txt");
                foreach(string guarda in busque)
                {         
                    string guardarm =  guarda.Substring(pegar.Length + 1);
                    File.Copy(Path.Combine(pegar, guardarm), Path.Combine(copiar, guardarm));
                }
                busque = Directory.GetFiles(pegar, "*.mp3");
                    
               foreach (string guarda in busque)
                {
                    string guardarm = guarda.Substring(pegar.Length + 1);
                    File.Copy(Path.Combine(pegar, guardarm), Path.Combine(copiar, guardarm));
                }
            }
            catch(Exception ex){
                Console.Write("\n Ya esta copiado los archivos \n");
            }

            //TEXTO a MORSE
            string text;
            Console.Write("\nEscriba un texto para traducirlo: ");
            text = Convert.ToString(Console.ReadLine());
            ConversorDeMorse.TextoAMorse(text);

           // MORSE a TEXTO
            string morse;
            Console.Write("\nEscriba un texto en morse para traducirlo: ");
             morse = Convert.ToString(Console.ReadLine() );
           
            ConversorDeMorse.MorseATexto(morse);
            //----------------------------------------------------------------------------------//
            //archivo MP3//
            concatenar.concatenarmp3();
            Console.ReadKey();

        }
    }
}
