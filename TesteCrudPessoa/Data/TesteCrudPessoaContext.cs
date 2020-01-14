using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteCrudPessoa.Models;

namespace TesteCrudPessoa.Data
{
    public class TesteCrudPessoaContext : DbContext
    {
        public TesteCrudPessoaContext (DbContextOptions<TesteCrudPessoaContext> options)
            : base(options)
        {
        }

        public DbSet<TesteCrudPessoa.Models.Pessoa> Pessoa { get; set; }
        public DbSet<TesteCrudPessoa.Models.Aluno> Aluno { get; set; }
    }
}
