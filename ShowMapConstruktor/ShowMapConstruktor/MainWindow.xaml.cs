using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml.Linq;

namespace ShowMapConstruktor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CMusicShowList showList = new CMusicShowList();
        int selectedIndex;

        public MainWindow()
        {
            InitializeComponent();
            ShowList.ItemsSource = showList.GetListOfMusicShowNames();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "shows";
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {

                string filePath = dlg.FileName;
                showList.SaveToJson(filePath);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "shows";
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;
                showList.LoadFromJson(filePath);
            }
            ShowList.Items.Refresh();
            ShowList.ItemsSource = showList.GetListOfMusicShowNames();
           
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int typeIndex = BT.SelectedIndex;
            showList.AddShow(NameCity.Text, MusicShowName.Text, NameMusicPlase.Text, MusicGroup.Text, DateMusicShow.Text, typeIndex, TypeMusicShowOrOriginOrGenresOfMusic.Text, IsBalletOrForNight.IsEnabled);
            ShowList.ItemsSource = showList.GetListOfMusicShowNames();
            ShowList.Items.Refresh();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if(selectedIndex >= 0)
            {
                int typeIndex = BT.SelectedIndex;
                showList.DeleteMusicShowIndex(ShowList.SelectedIndex);
                showList.AddShow(NameCity.Text, MusicShowName.Text, NameMusicPlase.Text, MusicGroup.Text, DateMusicShow.Text, typeIndex, TypeMusicShowOrOriginOrGenresOfMusic.Text, IsBalletOrForNight.IsEnabled);
                
                ShowList.ItemsSource = showList.GetListOfMusicShowNames();
                ShowList.Items.Refresh();
            }
        }

        private void ShowList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ShowList.SelectedItem;
            selectedIndex = ShowList.SelectedIndex;
            if (selectedItem != null)
            {
                NameCity.Text = (showList.GetMusicShowByName(selectedItem.ToString())).cityName;
                MusicShowName.Text = (showList.GetMusicShowByName(selectedItem.ToString())).misucShowName;
                NameMusicPlase.Text = (showList.GetMusicShowByName(selectedItem.ToString())).nameMisucPlace;
                MusicGroup.Text = (showList.GetMusicShowByName(selectedItem.ToString())).misucGroup;
                DateMusicShow.Text = (showList.GetMusicShowByName(selectedItem.ToString())).dateMisucPlace;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            showList.DeleteMusicShowIndex(ShowList.SelectedIndex);

            ShowList.ItemsSource = showList.GetListOfMusicShowNames();
            ShowList.Items.Refresh();
        }
    }
}
