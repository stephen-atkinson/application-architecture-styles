using Microsoft.EntityFrameworkCore;

namespace DonutShop.Application.Contracts;

public interface IConfigureModelBuilder<TContext> where TContext : DbContext
{
    void Configure(ModelBuilder modelBuilder);
}