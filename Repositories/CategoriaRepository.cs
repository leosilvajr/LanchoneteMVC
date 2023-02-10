﻿using LanchoneteMVC.Context;
using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;

namespace LanchoneteMVC.Repositories
{
    public class CategoriaRepository : ICategoriaRepositoy
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categoras => _context.Categorias;
    }
}
