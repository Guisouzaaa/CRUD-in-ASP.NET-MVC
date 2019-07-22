using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDControleDeEstoque.Models
{
    public class ContextBD : IdentityDbContext<UsuarioModel>
    {
        public ContextBD(DbContextOptions<ContextBD> options)
            :base(options)
        {
            
        }

    }
}
