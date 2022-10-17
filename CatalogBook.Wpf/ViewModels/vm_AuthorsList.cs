using Castle.Core.Internal;
using Castle.Windsor;
using CatalogBook.Models;
using CatalogBook.Services.Abstract;
using CatalogBook.Windsor;
using CatalogBook.Wpf.Infrastructure.Commands;
using CatalogBook.Wpf.Infrastructure.Commands.Base;
using CatalogBook.Wpf.ViewModels.Base;
using CatalogBook.Wpf.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatalogBook.Wpf.ViewModels
{
    public class vm_AuthorsList : vm_Base
    {
        private readonly WindsorContainer _container;

        public vm_AuthorsList()
        {
            CreateContainer createContainer = new CreateContainer();

            _container = createContainer.Container;

            InitializeCommands();

            GetListAuthors();
        }


        private AuthorModel? _selectAuthor;

        public AuthorModel? SelectAuthor
        {
            get => _selectAuthor;

            set => Set(ref _selectAuthor, value);
        }


        private ObservableCollection<AuthorModel>? _listAuthors;

        public ObservableCollection<AuthorModel>? ListAuthors
        {
            get => _listAuthors ?? (_listAuthors = new ObservableCollection<AuthorModel>());

            set => Set(ref _listAuthors, value);
        }


        private void GetListAuthors()
        {
            IServiceManager _serviceManager = _container.Resolve<IServiceManager>();

            Task<List<AuthorModel>> task = Task.Run(() => _serviceManager.AuthorService.GetAllAsync());

            List<AuthorModel> authorsModels = task.Result;

            ListAuthors = new ObservableCollection<AuthorModel>(authorsModels);
        }


        public bool OpenWindowList()
        {
            AuthorsList authorsList = new AuthorsList();

            authorsList.DataContext = this;

            authorsList.ShowDialog();

            if (authorsList.DialogResult == true)
            {
                return true;
            }

            return false;
        }

        #region Команды

        private void InitializeCommands()
        {
            AddAuthorCommand = new ActionCommand(OnAddAuthorCommandExecuted, CanAddAuthorCommandExecute);
            EditAuthorCommand = new ActionCommand(OnEditAuthorCommandExecuted, CanEditAuthorCommandExecute);
            DeleteAuthorCommand = new ActionCommand(OnDeleteAuthorCommandExecuted, CanDeleteAuthorCommandExecute);
        }

        #region Добавить

        public ICommand AddAuthorCommand {get; set;}

        private void OnAddAuthorCommandExecuted(object o)
        {
            vm_AuthorEdit vm_AuthorEdit = new vm_AuthorEdit();

            bool result = vm_AuthorEdit.OpenEditAuthor("");

            if(result == true)
            {
                if(String.IsNullOrEmpty(vm_AuthorEdit.AuthorName))
                {
                    return;
                }

                AuthorModel newAuthorModel = new AuthorModel();

                newAuthorModel.Name = vm_AuthorEdit.AuthorName;

                IServiceManager _serviceManager = _container.Resolve<IServiceManager>();

                Task<AuthorModel> taskModel = Task.Run(() => _serviceManager.AuthorService.AddOrEditAsync(newAuthorModel));

                newAuthorModel = taskModel.Result;

                GetListAuthors();
            }
        }

        private bool CanAddAuthorCommandExecute(object o) => true;

        #endregion

        #region Изменить

        public ICommand EditAuthorCommand { get; set; }

        private void OnEditAuthorCommandExecuted(object o)
        {
            vm_AuthorEdit vm_AuthorEdit = new vm_AuthorEdit();

            bool result = vm_AuthorEdit.OpenEditAuthor(SelectAuthor.Name);

            if (result == true)
            {
                if (String.IsNullOrEmpty(vm_AuthorEdit.AuthorName))
                {
                    return;
                }

                SelectAuthor.Name = vm_AuthorEdit.AuthorName;

                IServiceManager _serviceManager = _container.Resolve<IServiceManager>();

                Task<AuthorModel> taskModel = Task.Run(() => _serviceManager.AuthorService.AddOrEditAsync(SelectAuthor));

                SelectAuthor = taskModel.Result;

                GetListAuthors();
            }
        }

        private bool CanEditAuthorCommandExecute(object o)
        {
            if (SelectAuthor is null)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Удалить

        public ICommand DeleteAuthorCommand { get; set; }

        private void OnDeleteAuthorCommandExecuted(object o)
        {
            IServiceManager _serviceManager = _container.Resolve<IServiceManager>();

            Task<bool> taskBool = Task.Run(() => _serviceManager.AuthorService.RemoveAsync(SelectAuthor));

            if (taskBool.Result)
            {
                GetListAuthors();
            }
        }

        private bool CanDeleteAuthorCommandExecute(object o)
        {
            if (SelectAuthor is null)
            {
                return false;
            }

            return true;
        }


        #endregion

        #endregion

    }
}
