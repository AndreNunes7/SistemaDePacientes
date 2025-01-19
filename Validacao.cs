namespace CadastroPacientesWEB
{
    public class Validacao
    {
        public static bool ValidarChave(int chave)
        {
            return chave >= 100000 && chave <= 999999;
        }

        public static bool ValidarNomeMedico(string nome)
        {
            return !string.IsNullOrWhiteSpace(nome);
        }

        public static bool ValidarDataInternacao(DateTime data)
        {
            return data <= DateTime.Now;
        }

        public static bool ValidarTelefoneContato(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            telefone = telefone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            foreach (char c in telefone)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return telefone.Length == 10 || telefone.Length == 11;
        }
    }
}
