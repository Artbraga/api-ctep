namespace Entities.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int? AlunoId { get; set; }
        public int? ProfessorId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
