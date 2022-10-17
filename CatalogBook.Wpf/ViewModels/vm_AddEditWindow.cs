using CatalogBook.Data;
using CatalogBook.Models;
using CatalogBook.Wpf.Infrastructure.Commands;
using CatalogBook.Wpf.Infrastructure.Converts;
using CatalogBook.Wpf.ViewModels.Base;
using CatalogBook.Wpf.Windows;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CatalogBook.Wpf.ViewModels
{
    public class vm_AddEditWindow : vm_Base
    {

        private BookModel _bookModel;

        public BookModel BookModel
        {
            get { return _bookModel; }
        }

        public vm_AddEditWindow()
        {
            _bookModel = new BookModel();
            _bookModel.YearIssue = DateTime.Now;

            InitializeProperty();
            InitializeCommands();
        }

        public vm_AddEditWindow(BookModel bookModel)
        {
            _bookModel = bookModel;

            if(bookModel is null)
            {
                _bookModel = new BookModel();
                _bookModel.YearIssue = DateTime.Now;
            }

            InitializeProperty();
            InitializeCommands();
        }

        private void InitializeProperty()
        {
            ID = _bookModel.ID;

            Title = _bookModel.Title;

            Author = _bookModel.Author;

            YearIssue = _bookModel.YearIssue;

            ISBN = _bookModel.ISBN;

            Description = _bookModel.Description;

            Cover = _bookModel.Cover;
        }

        private void InitializeModel()
        {
            _bookModel.ID = ID;
            
            _bookModel.Title = Title ?? "";
            
            _bookModel.Author = Author;

            _bookModel.AuthorId = Author.ID;

            _bookModel.AuthorName = Author == null ? "" : Author.Name;
            
            _bookModel.YearIssue = YearIssue ?? new DateTime();
            
            _bookModel.ISBN = ISBN ?? "";
            
            _bookModel.Description = Description ?? "";
            
            _bookModel.Cover = Cover;
        }

        #region Представление модели

        private Guid _id;

        public Guid ID
        {
            get => _id;

            set => Set(ref _id, value);
        }


        private string? _title;

        public string? Title
        {
            get => _title ?? "";

            set => Set(ref _title, value);
        }

        private AuthorModel? _author;

        public AuthorModel? Author
        {
            get => _author ?? new AuthorModel(new Guid(), "", false);

            set => Set(ref _author, value);
        }

        private DateTime? _yearIssue;

        public DateTime? YearIssue
        {
            get => _yearIssue ?? new DateTime();

            set => Set(ref _yearIssue, value);
        }


        private string? _isbn;

        public string? ISBN
        {
            get => _isbn ?? "";

            set => Set(ref _isbn, value);
        }

        private string? _description;

        public string? Description
        {
            get => _description ?? "";

            set => Set(ref _description, value);
        }

        private byte[]? _сover;

        public byte[]? Cover
        {
            get => _сover;

            set => Set(ref _сover, value);
        }

        #endregion


        #region Показать окно

        public bool OpenAddEditWindow()
        {
            AddEditWindow addEditWindow = new AddEditWindow();

            addEditWindow.DataContext = this;

            addEditWindow.ShowDialog();

            if (addEditWindow.DialogResult == true)
            {
                InitializeModel();
                return true;
            }

            return false;
        }

        #endregion


        #region Команды

        private void InitializeCommands()
        {
            SelectAuthorCommand = new ActionCommand(OnSelectAuthorCommandExecuted, CanSelectAuthorCommandExecute);
            EditImageCommand = new ActionCommand(OnEditImageCommandExecuted, CanEditImageCommandExecute);
            DeleteImageCommand = new ActionCommand(OnDeleteImageCommandExecuted, CanDeleteImageCommandExecute);
        }

        #region Выбрать автора

        public ICommand SelectAuthorCommand { get; set; }

        private void OnSelectAuthorCommandExecuted(object o)
        {
            vm_AuthorsList vm_authorsList = new vm_AuthorsList();

            bool result = vm_authorsList.OpenWindowList();

            if (result == true)
            {
                if (vm_authorsList.SelectAuthor != null)
                {
                    Author = vm_authorsList.SelectAuthor;
                    InitializeModel();
                }
            }
        }

        private bool CanSelectAuthorCommandExecute(object o) => true;

        #endregion


        #region Загрузить картинку

        public ICommand EditImageCommand { get; set; }

        private void OnEditImageCommandExecuted(object o)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Выберите файл";

            openFileDialog.Filter = "JPEG| *.jpg; *.jpeg";

            openFileDialog.Multiselect = false;

            bool? resultDialog = openFileDialog.ShowDialog();

            if(resultDialog == true)
            {

                byte[] bytesFile = File.ReadAllBytes(openFileDialog.FileName);

                Cover = bytesFile;

            }
            
        }


        private bool CanEditImageCommandExecute(object o) => true;
        #endregion


        #region Удалить картинку

        public ICommand DeleteImageCommand { get; set; }

        private void OnDeleteImageCommandExecuted(object o)
        {
            Cover = null;
            InitializeModel();
        }


        private bool CanDeleteImageCommandExecute(object o)
        {
            if(Cover == null)
            {
                return false;
            }

            if (Cover.Length == 0)
            {
                return false;
            }

            return true;
        }

        #endregion

        #endregion
    }
}
