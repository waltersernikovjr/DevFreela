﻿using DevFreela.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infraestructure.Persistence.Configurations
{
    public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
                .HasKey(u => u.Id);
        }
    }
}
