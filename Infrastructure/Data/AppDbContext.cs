using DAL.Entities;
using DAL.Entities.Candidates;
using DAL.Entities.Candidates;
using DAL.Entities.JobOffer;
using DAL.Entities.Questions;
using DAL.Entities.Reponse;
using DAL.Entities.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>

    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
                Console.WriteLine(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
            modelBuilder.Entity<Question>()
               .HasOne(d => d.domain);
            modelBuilder.Entity<Question>()
                .HasOne(t => t.type);
            modelBuilder.Entity<Choice>()
                .HasOne(q => q.question);

            modelBuilder.Entity<QcmQuestion>()
                .HasMany<QcmResponse>(q => q.responses);
            modelBuilder.Entity<QcmResponse>()
                .HasNoKey();

            modelBuilder.Entity<QcmQuestion>();
            modelBuilder.Entity<Candidat>()
                .HasMany<Experience>(c => c.experiences);

            modelBuilder.Entity<Postulation>().HasKey(e => new { e.JobOfferId,e.CandidId});

            modelBuilder.Entity<Postulation>()
                .HasOne(sc => sc.Candidat)
                .WithMany(s => s.Postulations)
                .HasForeignKey(sc => sc.CandidId);

            modelBuilder.Entity<Postulation>()
                .HasOne(sc => sc.JobOffer)
                .WithMany(s => s.Postulations)
                .HasForeignKey(sc => sc.JobOfferId);
            /*
             * 
             * modelBuilder.Entity<Postulation>().HasKey(t => new { t.JobOfferId, t.CandidId });

                 modelBuilder.Entity<Postulation>()
                             .HasOne(t => t.Candidat)
                             .WithMany(t => t.Postulations)
                             .HasForeignKey(t => t.CandidId);


                 modelBuilder.Entity<Postulation>()
                             .HasOne(t => t.JobOffer)
                             .WithMany(t => t.Postulations)
                             .HasForeignKey(t => t.JobOfferId);*/

            //modelBuilder.ApplyConfiguration(new PostulationConfiguration());


        }

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Candidat> Candidats { get; set; }
        public virtual DbSet<QcmResponse> QcmResponses { get; set; } 
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Postulation> Postulations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }

    }
}
 