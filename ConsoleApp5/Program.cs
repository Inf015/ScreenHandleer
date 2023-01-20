using Newtonsoft.Json;

namespace ConsoleApp5
{
    class program
    {
        private static string _path = @"C:\Users\olive\Desktop\ScreenHandlerV4\ScreenHandleerV4\ConsoleApp5\Preguntas.json";
        private static string _path2 = @"C:\Users\olive\Desktop\ScreenHandlerV4\ScreenHandleerV4\ConsoleApp5\db.json";
        static void Main(string[] args)
        {
            //var ganador = GetGanadors();

            var verificador = GetVerificadorFromFile();
            DeserializeVerificarorJsonFile(verificador);

            var formulario = GetFormularioFromFile();
            var respuesta = new List<Data>();
            DeserializeFormularioJsonFile(formulario, ref respuesta);

            var guardar = GetGuardarFromFile();
            DeserializeGuardarJsonFile(guardar, respuesta);

        }

        #region "Leer Verificador"
        public static string GetVerificadorFromFile()
        {
            string verificadorJsonFile;
            using (var read = new StreamReader(_path))
            {
                verificadorJsonFile = read.ReadToEnd();
            }
            return verificadorJsonFile;
        }
        
        #endregion

        #region "Verificador"

        public static void DeserializeVerificarorJsonFile(string VerificadorJsonFile)
        {
              List<Data> Respuestas = new List<Data>();

              var verificador = JsonConvert.DeserializeObject<Formulario>(VerificadorJsonFile);
             Console.WriteLine($"{verificador.Contenido.verificador.Texto}");
             var respuesta = Console.ReadLine();

             if (respuesta != "Y")
             {
                Console.WriteLine("Adios!!");
                Environment.Exit(0);
             }
             Console.Clear();
        }


        #endregion

        #region "Leer Formulario"
        public static string GetFormularioFromFile()
        {
            string GanadorJsonFile;
            using (var read = new StreamReader(_path))
            {
                GanadorJsonFile = read.ReadToEnd();
            }
            return GanadorJsonFile;
        }
        #endregion
        
        #region "Formulario"
        public static void DeserializeFormularioJsonFile(string FormularioJsonFile, ref List<Data> Respuestas)
        {
            var formulario = JsonConvert.DeserializeObject<Formulario>(FormularioJsonFile);
            foreach (var Pregunta in formulario.Contenido.Preguntas)
            {
                while (true)
                {
                    Console.WriteLine($"{Pregunta.Texto}");
                    var respuesta = Console.ReadLine();
                    Console.Clear();

                    if (!string.IsNullOrWhiteSpace(respuesta))
                    {
                        Respuestas.Add(new(Pregunta.Texto, respuesta));
                        break;
                    }
                    Console.Clear();
                }
            }
        }
        #endregion

        #region "Leer Guardar"
        public static string GetGuardarFromFile()
        {
            string GuardarJsonFile;
            using (var read = new StreamReader(_path))
            {
                GuardarJsonFile = read.ReadToEnd();
            }
            return GuardarJsonFile;
        }
        #endregion
        #region "Guardar"

        public static void DeserializeGuardarJsonFile(string GuardarJsonFile, List<Data> Respuestas)
        {
            List<Data> Respuesta = new List<Data>();
            var guardar = JsonConvert.DeserializeObject<Formulario>(GuardarJsonFile);
            Console.WriteLine($"{guardar.Contenido.Guardar.Texto}");
            var respuesta = Console.ReadLine();

            if(respuesta != "Y")
            {
                Console.Clear();
                Console.WriteLine("Esta bien, Adios!");
                Environment.Exit(0);
            }
            else{

            serializarJson(Respuestas, _path2);
            Console.Clear();
            System.Console.WriteLine("Gracias, Que disfrute del evento y buena suerte!");

            }
        }
        #endregion

        #region  "Serializar"
        public static void serializarJson(List<Data> data, string path2)
        {

            var x = File.ReadAllText(path2);
            var bk = JsonConvert.DeserializeObject<List<Data>>(x);

            foreach (var b in data)
            {
                bk.Add(b);
            }
            string DataJson = JsonConvert.SerializeObject(bk);
            File.WriteAllText(path2, DataJson);
        }

        #endregion
    }






}
