using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CatalogBook.Services;
using CatalogBook.Services.Abstract;

namespace CatalogBook.Windsor
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IAuthorService>().ImplementedBy<AuthorService>().LifeStyle.Transient,
                Component.For<IBookService>().ImplementedBy<BookService>().LifeStyle.Transient,

                Component.For<IServiceManager>().ImplementedBy<ServiceManager>().LifeStyle.Transient
                );
        }
    }
}
