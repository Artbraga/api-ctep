using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.Impl.Mapping;
using log4net;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace CTEP.Repositories.Impl.Context
{
    public class CtepContext : DbContext
    {
        private readonly string _connectionString;
        private static readonly ILog log = LogManager.GetLogger(typeof(CtepContext));

        public CtepContext(IConfiguration configuration) : base()
        {
            _connectionString = configuration.GetSection("CtepContext:ConnectionString").Value;
            log.Debug(_connectionString);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(log.Debug)
                .UseMySql(_connectionString, new MySqlServerVersion(new System.Version(5, 6, 49)), mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend))
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new NotaAlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new PerfilPermissaoMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.ApplyConfiguration(new RegistroAlunoMap());
            modelBuilder.ApplyConfiguration(new RegistroTurmaMap());
            modelBuilder.ApplyConfiguration(new TipoStatusAlunoMap());
            modelBuilder.ApplyConfiguration(new TipoStatusTurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaAlunoMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaProfessorMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
