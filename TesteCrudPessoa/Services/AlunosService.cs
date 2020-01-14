using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteCrudPessoa.Data;
using TesteCrudPessoa.Models;
using TesteCrudPessoa.Services.Exceptions;

namespace TesteCrudPessoa.Services
{
    public class AlunosService
    {
        private readonly TesteCrudPessoaContext _context;

        public AlunosService(TesteCrudPessoaContext context)
        {
            _context = context;
        }

        public List<Aluno> FindAll()
        {
            return _context.Aluno.ToList();
        }

        public void Insert(Aluno obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Aluno FindById(int id)
        {
            return _context.Aluno.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int? id)
        {
            var obj = _context.Aluno.Find(id);
            _context.Aluno.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Aluno obj)
        {
            if (!_context.Aluno.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            } 
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

      
    }

}
