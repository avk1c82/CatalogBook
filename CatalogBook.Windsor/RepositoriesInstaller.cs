using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CatalogBook.Repositories.Abstracts;
using CatalogBook.Repositories;
using CatalogBook.Data;

namespace CatalogBook.Windsor
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<DataContext>().LifeStyle.Transient,

                Component.For<IAuthorRepository>().ImplementedBy<AuthorRepository>().LifeStyle.Transient,
                Component.For<IBookRepository>().ImplementedBy<BookRepository>().LifeStyle.Transient,

                Component.For<IRepositoryManager>().ImplementedBy<RepositoryManager>().LifeStyle.Transient
                );
        }
    }
}
