public class Pacientes : IComparable<Pacientes>
{
    public int Chave { get; set; }
    public string NomeDoMedico { get; set; }
    public DateTime DataInternacao { get; set; }
    public string TelefoneContato { get; set; }

    public int CompareTo(Pacientes other)
    {
        if (other == null) return 1;
        return this.Chave.CompareTo(other.Chave);
    }
}