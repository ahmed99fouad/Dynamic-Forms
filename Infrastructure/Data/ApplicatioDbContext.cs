using Microsoft.EntityFrameworkCore;
using pioneerTask.Entities.Model;

namespace Infrastructure.Data
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext(DbContextOptions<ApplicatioDbContext> options)
      : base(options)
        {
        }
        public DbSet<Form> Forms { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
      //  public DbSet<FormFieldValue> FormFieldValues { get; set; }

    }
}
