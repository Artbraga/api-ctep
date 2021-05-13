using Entities.Base;
using Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Entities.DTOs
{
    public class UsuarioDTO : BaseDTO<Usuario>
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int? AlunoId { get; set; }
        public int? ProfessorId { get; set; }
        public string Tipo { get; set; }
        public PerfilDTO Perfil { get; set; }
        public IEnumerable<string> Permissoes { get; set; }

        public UsuarioDTO() { }

        public UsuarioDTO(Usuario entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Login = entity.Login;
            this.Telefone = entity.Telefone;
            this.Email = entity.Email;
            this.Perfil = new PerfilDTO(entity.Perfil);
            this.Perfil.Usuarios = null;
            this.AlunoId = entity.AlunoId;
            this.ProfessorId = entity.ProfessorId;
            this.Permissoes = entity.Perfil.PerfisPermissao.Select(x => x.Permissao.Nome);
            if (this.AlunoId.HasValue) this.Tipo = "aluno";
            if (this.ProfessorId.HasValue) this.Tipo = "professor";
        }

        public override Usuario ToEntity()
        {
            return new Usuario
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Nome = this.Nome,
                Login = this.Login,
                Telefone = this.Telefone,
                Email = this.Email,
                AlunoId = this.AlunoId,
                ProfessorId = this.ProfessorId,
                PerfilId = this.Perfil.Id.Value
            };
        }
    }
}
