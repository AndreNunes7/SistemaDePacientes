using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CadastroPacientesWEB
{
    public class Serializer
    {
        private const string arquivo = "pacientes.json";

        public void SalvarDados(List<Pacientes> pacientes)
        {
            var json = JsonSerializer.Serialize(pacientes);
            File.WriteAllText(arquivo, json);
        }

        public List<Pacientes> CarregarDados()
        {
            if (!File.Exists(arquivo)) return new List<Pacientes>();
            var json = File.ReadAllText(arquivo);
            return JsonSerializer.Deserialize<List<Pacientes>>(json);
        }
    }
}