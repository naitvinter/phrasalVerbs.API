using Microsoft.EntityFrameworkCore;
using PhrasalVerbs.Application.Data;
using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Database;

public class PhrasalVerbsContext : DbContext
{
    public DbSet<PhrasalVerb> PhrasalVerbs => Set<PhrasalVerb>();
    public DbSet<Translation> Translations => Set<Translation>();

    private IPhrasalVerbsSeeder _seeder;

    public PhrasalVerbsContext(DbContextOptions<PhrasalVerbsContext> options, IPhrasalVerbsSeeder seeder) : base(options) 
    {
        _seeder = seeder;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translation>()
            .HasOne(translation => translation.PhrasalVerb)
            .WithMany(verb => verb.Translations)
            .HasForeignKey(b => b.PhrasalVerbId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PhrasalVerb>().HasData(_seeder.GetPharsalVerbs());
        modelBuilder.Entity<Translation>().HasData(_seeder.GetTranslations());
    }
}
