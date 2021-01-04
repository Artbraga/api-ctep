using Microsoft.AspNetCore.Http;
using System;
using Unity.Lifetime;

namespace Ioc
{
    /// <summary>
    /// Classe de gerenciamento do tempo de vida das requisições.
    /// </summary>
    public class PerRequestLifetimeManager : LifetimeManager, ITypeLifetimeManager
    {
        /// <summary>
        /// Propriedade que recebe o contexto criado para requisição.
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Propriedade que identifica itens do contexto.
        /// </summary>
        private readonly string _key;

        /// <summary>
        /// Construtor da classe que recebe um IHttpContextAccessor e ajusta parâmetros do contexto.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public PerRequestLifetimeManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _key = $"{nameof(PerRequestLifetimeManager)}_{Guid.NewGuid()}";
        }

        /// <summary>
        /// Sobreescrita do método GetValue. Retorna o item do contexto. Retorna nulo caso o contexto não seja nulo.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public override object GetValue(ILifetimeContainer container = null)
        {
            var result = default(object);
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null
                && httpContext.Items.ContainsKey(_key))
            {
                result = httpContext.Items[_key];
            }
            return result;
        }

        /// <summary>
        /// Sobreescrita do método SetValue. Atribui valor a um item do contexto caso o contexto não seja nulo.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="container"></param>
        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                httpContext.Items[_key] = newValue;
            }
        }

        /// <summary>
        /// Sobreescrita do método RemoveValue. Remove o item do contexto caso contexto não seja nulo. 
        /// </summary>
        /// <param name="container"></param>
        public override void RemoveValue(ILifetimeContainer container = null)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                httpContext.Items.Remove(_key);
            }
        }

        /// <summary>
        /// Sobreescrita do método de criação de um gerente de tempo de vida. Cria uma nova instância da classe PerRequestLifetimeManager.
        /// </summary>
        /// <returns></returns>
        protected override LifetimeManager OnCreateLifetimeManager()
        {
            return new PerRequestLifetimeManager(_httpContextAccessor);
        }
    }
}