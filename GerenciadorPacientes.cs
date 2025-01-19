using CadastroPacientesWEB;

public class GerenciadorPacientes
{
    private List<Pacientes> pacientes;
    private Serializer serializer;

    public GerenciadorPacientes()
    {
        serializer = new Serializer();
        pacientes = serializer.CarregarDados();
        pacientes.Sort();
    }

    public void AdicionarPaciente(Pacientes paciente)
    {
        pacientes.Add(paciente);
        pacientes.Sort(); 
        serializer.SalvarDados(pacientes);
    }

    public void RemoverPaciente(Pacientes paciente)
    {
        pacientes.Sort(); 
        int index = pacientes.BinarySearch(paciente);
        if (index >= 0)
        {
            pacientes.RemoveAt(index);
            serializer.SalvarDados(pacientes);
        }
        else
        {
            throw new Exception($"Paciente com chave {paciente.Chave} não encontrado.");
        }
    }

    public Pacientes BuscarPaciente(int chave)
    {
        var pacienteBusca = new Pacientes { Chave = chave };
        int index = pacientes.BinarySearch(pacienteBusca);
        return index >= 0 ? pacientes[index] : null;
    }

    public void EditarPaciente(Pacientes pacienteEditado)
    {
        pacientes.Sort(); 
        int index = pacientes.BinarySearch(pacienteEditado);
        if (index >= 0)
        {
            pacientes[index] = pacienteEditado;
            serializer.SalvarDados(pacientes);
        }
        else
        {
            throw new Exception($"Paciente com chave {pacienteEditado.Chave} não encontrado.");
        }
    }

    public List<Pacientes> ObterTodosPacientes()
    {
        return new List<Pacientes>(pacientes);
    }
}
