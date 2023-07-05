using Microsoft.EntityFrameworkCore;
using WebApiStudents.Models;

namespace WebApiStudents.Context
{
    public class DbStudentsContext : DbContext
    {
        public DbStudentsContext(DbContextOptions<DbStudentsContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
