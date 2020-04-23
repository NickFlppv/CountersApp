using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountersApp.Model
{
    public class CountersConfiguration : IEntityTypeConfiguration<Counter>
    {
        public void Configure(EntityTypeBuilder<Counter> builder)
        {
            builder.HasData(
                    new Counter
                    {
                        Id = 1,
                        Key = 1,
                        Value = 1
                    },
                    new Counter
                    {
                        Id = 2,
                        Key = 1,
                        Value = 2
                    },
                    new Counter
                    {
                        Id = 3,
                        Key = 1,
                        Value = 3
                    },
                    new Counter
                    {
                        Id = 4,
                        Key = 2,
                        Value = 1
                    },
                    new Counter
                    {
                        Id = 5,
                        Key = 2,
                        Value = 1
                    },
                    new Counter
                    {
                        Id = 6,
                        Key = 2,
                        Value = 3
                    },
                    new Counter
                    {
                        Id = 7,
                        Key = 2,
                        Value = 1
                    }
                );
        }
    }
}