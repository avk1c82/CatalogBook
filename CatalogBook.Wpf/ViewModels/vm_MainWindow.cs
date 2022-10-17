using Castle.Windsor;
using CatalogBook.Models;
using CatalogBook.Services.Abstract;
using CatalogBook.Windsor;
using CatalogBook.Wpf.Infrastructure.Commands;
using CatalogBook.Wpf.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatalogBook.Wpf.ViewModels
{
    public class vm_MainWindow : vm_Base
    {
        private readonly WindsorContainer _container;

        public vm_MainWindow()
        {
            CreateContainer createContainer = new CreateContainer();
            
            _container = createContainer.Container;

            GetListBooks();

            InitializeCommands();
        }

        private void GetListBooks()
        {
            IServiceManager _serviceManager = _container.Resolve<IServiceManager>();

            Task<List<BookModel>> task = Task.Run(() => _serviceManager.BookService.GetAllAsync());

            List<BookModel> bookModels = task.Result;

            ListBooks = new ObservableCollection<BookModel>(bookModels);
        }


        private BookModel? _selectBook;

        public BookModel? SelectBook
        {
            get => _selectBook;

            set => Set(ref _selectBook, value);
        }


        private ObservableCollection<BookModel>? _listBooks;

        public ObservableCollection<BookModel>? ListBooks
        {
            get => _listBooks;

            set => Set(ref _listBooks, value);
        }


        #region Команды

        private void InitializeCommands()
        {
            AddBookCommand = new ActionCommand(OnAddBookCommandExecuted, CanAddBookCommandExecute);
            EditBookCommand = new ActionCommand(OnEditBookCommandExecuted, CanEditBookCommandExecute);
            DeleteBookCommand = new ActionCommand(OnDeleteBookCommandExecuted, CanDeleteBookCommandExecute);
        }

        #region Добавить запись

        public ICommand AddBookCommand { get; set; }

        private void OnAddBookCommandExecuted(object o)
        {
            vm_AddEditWindow vm_AddEditWindow = new vm_AddEditWindow();

            bool resultDialog = vm_AddEditWindow.OpenAddEditWindow();

            if (resultDialog)
            {
                BookModel newBookModel = vm_AddEditWindow.BookModel;

                IServiceManager _serviceManager = _container.Resolve<IServiceManager>();

                Task<BookModel> taskAddBookModel = Task.Run(() => _serviceManager.BookService.AddOrEditAsync(newBookModel));

                newBookModel = taskAddBookModel.Result;

                GetListBooks();
            }
        }

        private bool CanAddBookCommandExecute(object o) => true;


        #endregion

        #region Редактировать запись

        public ICommand? EditBookCommand { get; set; }

        private void OnEditBookCommandExecuted(object o)
        {
            vm_AddEditWindow vm_AddEditWindow = new vm_AddEditWindow(SelectBook);

            bool resultDialog = vm_AddEditWindow.OpenAddEditWindow();

            if (resultDialog)
            {
                BookModel newBookModel = vm_AddEditWindow.BookModel;

                IServiceManager _serviceManager = _container.Resolve<IServiceManager>();

                Task<BookModel> taskAddBookModel = Task.Run(() => _serviceManager.BookService.AddOrEditAsync(newBookModel));

                newBookModel = taskAddBookModel.Result;

                GetListBooks();
            }
        }

        private bool CanEditBookCommandExecute(object o)
        {
            if(SelectBook == null)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Удалить запись

        public ICommand DeleteBookCommand { get; set; }

        private void OnDeleteBookCommandExecuted(object o)
        {
            IServiceManager _serviceManager = _container.Resolve<IServiceManager>();

            Task<bool> taskBool = Task.Run(() => _serviceManager.BookService.RemoveAsync(SelectBook));

            if (taskBool.Result)
            {
                {
                    GetListBooks();
                }
            }
        }

        private bool CanDeleteBookCommandExecute(object o)
        {
            if (SelectBook == null)
            {
                return false;
            }

            return true;
        }

        #endregion

        #endregion
    }
}
