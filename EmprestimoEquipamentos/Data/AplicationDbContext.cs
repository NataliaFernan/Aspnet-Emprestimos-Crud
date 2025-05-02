using EmprestimoEquipamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoEquipamentos.Data
{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
                    
        }

        public DbSet<EmprestimoModel> Emprestimos { get; set; }
    }
}
