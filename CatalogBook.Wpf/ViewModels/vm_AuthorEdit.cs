using CatalogBook.Wpf.ViewModels.Base;
using CatalogBook.Wpf.Windows;
using System;

namespace CatalogBook.Wpf.ViewModels
{
    public class vm_AuthorEdit : vm_Base
    {
        private string? _authorName;

        public string AuthorName 
        { 
            get => _authorName ?? "";
            set => Set(ref _authorName, value); 
        }


        public bool OpenEditAuthor(string authorName)
        {
            if(String.IsNullOrEmpty(authorName))
            {
                AuthorName = "";
            }

            AuthorName = authorName;

            AuthorEdit authorEdit = new AuthorEdit();

            authorEdit.DataContext = this;

            authorEdit.ShowDialog();

            if(authorEdit.DialogResult == true)
            {
                return true;
            }

            return false;
        }
    }
}
