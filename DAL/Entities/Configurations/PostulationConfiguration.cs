using DAL.Entities.JobOffer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Configurations
{
    public class PostulationConfiguration : IEntityTypeConfiguration<Postulation>
    {
        public void Configure(EntityTypeBuilder<Postulation> builder)
        {
            builder.HasKey(b => new { b.JobOfferId, b.CandidId });
            builder.HasOne(p => p.JobOffer).WithMany(p => p.Postulations).HasForeignKey(p => p.JobOfferId);

            builder.HasOne(p => p.Candidat).WithMany(p => p.Postulations).HasForeignKey(p=>p.CandidId);

            
        }
    }
}
