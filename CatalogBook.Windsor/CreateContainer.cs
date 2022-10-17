using Castle.Windsor;

namespace CatalogBook.Windsor
{
    public class CreateContainer
    {
        public WindsorContainer Container { get; }

        public CreateContainer()
        {
            Container = new WindsorContainer();

            Container.Install(new RepositoriesInstaller(), new ServicesInstaller());
        }
    }
}
