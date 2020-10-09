using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Repositories.Impl.Mapping;

namespace CTEP.Repositories.Impl.Context
{
    public class CtepContext : DbContext
    {
        private readonly string _connectionString;

        public CtepContext(DbContextOptions<CtepContext> options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetSection("CtepContext:ConnectionString").Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString)
                .UseLazyLoadingProxies();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
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
