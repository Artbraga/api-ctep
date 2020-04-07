using Entities.Base;
using Entities.Entities;

namespace Entities.DTOs
{
    public class UsuarioDTO : BaseDTO<Usuario>
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int Permissao { get; set; }

        public UsuarioDTO() { }

        public UsuarioDTO(Usuario entity) : base(entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Login = entity.Login;
            this.Senha = entity.Senha;
            this.Telefone = entity.Telefone;
            this.Permissao = entity.Permissao;
        }

        public override Usuario ToEntity()
        {
            return new Usuario
            {
                Id = this.Id,
                Nome = this.Nome,
                Login = this.Login,
                Senha = this.Senha,
                Telefone = this.Telefone,
                Permissao = this.Permissao
            };
        }
    }
}
