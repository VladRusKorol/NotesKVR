using Notes.APL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notes.APL.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DefinitionsWorkSpace.xaml
    /// </summary>
    public partial class DefinitionsWorkSpace : UserControl, INotifyPropertyChanged
    {

        private int _definitionId;
        public int DefinitionId
        {
            get => _definitionId;
            set => SetField(ref _definitionId, value);
        }

        private string _definitionTitle;
        public string DefinitionTitle
        {
            get => _definitionTitle;
            set => SetField(ref _definitionTitle, value);
        }

        private string _definitionCreatedAt;
        public string DefinitionCreatedAt
        {
            get => _definitionCreatedAt;
            set => SetField(ref _definitionCreatedAt, value);
        }

        private string _definitionUpdatedAt;
        public string DefinitionUpdatedAt
        {
            get => _definitionUpdatedAt;
            set => SetField(ref _definitionUpdatedAt, value);
        }

        private string _definitionDesc;
        public string DefinitionDesc
        {
            get => _definitionDesc;
            set => SetField(ref _definitionDesc, value);
        }


        public DefinitionsWorkSpace()
        {
            InitializeComponent();
        }













        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
