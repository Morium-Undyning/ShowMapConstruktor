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
        string[] TypesMusicShow = {"Millitary Parade","Celebration","Astrade Tour" };
        string[] Origrn = { "Classic novel","Moder Novel","Postmodern novel","Mifs","Skazki" };
        string[] GenresOfMusic = { "Metal","Classic rock","Death metal","Pank rock", "New metal", "Alternative metal" };
        int selectedIndex;
        DateTime selectedDate;

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
        public void SelectTypesOfConcert(int index)
        {
            switch (index)
            {
                case 0:
                    ParametrsShow.Items.Clear();
                    foreach (string type in TypesMusicShow) 
                    {
                        ParametrsShow.Items.Add(type);
                    }
                    break;
                case 1:
                    ParametrsShow.Items.Clear();
                    foreach (string type in Origrn)
                    {
                        ParametrsShow.Items.Add(type);
                    }
                    break;
                case 2:
                    ParametrsShow.Items.Clear();
                    foreach (string type in GenresOfMusic)
                    {
                        ParametrsShow.Items.Add(type);
                    }
                    break;
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
            showList.AddShow(NameCity.Text, MusicShowName.Text, NameMusicPlase.Text, MusicGroup.Text, selectedDate.ToShortDateString(),Convert.ToDouble(PosX.Text), Convert.ToDouble(PosY.Text), typeIndex, ParametrsShow.Text, isBallet.IsEnabled, IsForNigth.IsEnabled);
            ShowList.ItemsSource = showList.GetListOfMusicShowNames();
            ShowList.Items.Refresh();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if(selectedIndex >= 0)
            {
                int typeIndex = BT.SelectedIndex;
                showList.DeleteMusicShowIndex(ShowList.SelectedIndex);
                showList.AddShow(NameCity.Text, MusicShowName.Text, NameMusicPlase.Text, MusicGroup.Text, selectedDate.ToShortDateString(), Convert.ToInt32(PosX.Text), Convert.ToInt32(PosY.Text), typeIndex, ParametrsShow.Text, isBallet.IsEnabled, IsForNigth.IsEnabled);
                
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
                if(showList.GetShows() is CDefaultMusicShow)
                {
                    BT.SelectedIndex = 0;
                }else if(showList.GetShows() is CBalletOpera)
                {
                    BT.SelectedIndex = 1;
                }
                else if (showList.GetShows() is CRockConcert)
                {
                    BT.SelectedIndex = 2;
                }

                NameCity.Text = (showList.GetMusicShowByName(selectedItem.ToString())).cityName;
                MusicShowName.Text = (showList.GetMusicShowByName(selectedItem.ToString())).misucShowName;
                NameMusicPlase.Text = (showList.GetMusicShowByName(selectedItem.ToString())).nameMisucPlace;
                MusicGroup.Text = (showList.GetMusicShowByName(selectedItem.ToString())).misucGroup;
                Date.Content = (showList.GetMusicShowByName(selectedItem.ToString())).dateMisucPlace;
                PosX.Text = (showList.GetMusicShowByName(selectedItem.ToString())).posOfMapX.ToString();
                PosY.Text = (showList.GetMusicShowByName(selectedItem.ToString())).posOfMapY.ToString();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            showList.DeleteMusicShowIndex(ShowList.SelectedIndex);

            ShowList.ItemsSource = showList.GetListOfMusicShowNames();
            ShowList.Items.Refresh();
        }

        private void BT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectTypesOfConcert(BT.SelectedIndex);
        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = calendar.SelectedDate.Value;
            
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition((IInputElement)sender);

            PosX.Text = pos.X.ToString();
            PosY.Text = pos.Y.ToString();

        }
    }
}
