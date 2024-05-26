using Microsoft.EntityFrameworkCore;

namespace DonutShop.DAL.Contracts;

public interface IConfigureModelBuilder<TContext> where TContext : DbContext
{
    void Configure(ModelBuilder modelBuilder);
}