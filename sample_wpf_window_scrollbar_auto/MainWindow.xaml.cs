using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace sample_wpf_window_scrollbar_auto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class DataGridItem
        {
            public string Item1 { get; set; }
        }

        public class BindingSource : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged実装 
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName = null));
            }
            #endregion

            public BindingSource()
            {
            }

            public ObservableCollection<DataGridItem> Items { get; set; } = new();

            public ObservableCollection<DataGridItem> Items2 { get; set; } = new();

            //string _DUMMY;
            //public string DUMMY
            //{
            //    get => _DUMMY;
            //    set { _DUMMY = value; OnPropertyChanged(); }
            //}

        }

        public BindingSource m_Bind;


        public MainWindow()
        {
            InitializeComponent();

            m_Bind = new BindingSource();

            DataContext = m_Bind;

            //ウインドウサイズの上限は、起動時点のWorkAreaとする
            MaxWidth = SystemParameters.WorkArea.Width;
            MaxHeight = SystemParameters.WorkArea.Height;


            //起動時点では800*600の画面。ただしWorkAreaがそれよりも小さい場合は、WorkAreaのサイズとする。
            //ウインドウサイズの自動変更を止める場合：この処理は不要なので、削除する
            MinWidth = 800;
            MinHeight = 600;
            if (MaxWidth < MinWidth) MinWidth = MaxWidth;
            if (MaxHeight < MinHeight) MinHeight = MaxHeight;

        }

        private void Btn1(object sender, RoutedEventArgs e)
        {
        }

        private void Btn2(object sender, RoutedEventArgs e)
        {

            m_Bind.Items.Add(new DataGridItem
            {
                Item1 = DateTime.Now.ToString(),
            });
        }

        private void DataGridAdd10(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {

                m_Bind.Items.Add(new DataGridItem
                {
                    Item1 = $"{i}_{DateTime.Now}",
                });
            }
        }

        private void DataGrid2Add10(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {

                m_Bind.Items2.Add(new DataGridItem
                {
                    Item1 = $"{i}_{DateTime.Now}",
                });
            }

        }

    }
}
