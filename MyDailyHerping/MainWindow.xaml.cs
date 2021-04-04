using Microsoft.EntityFrameworkCore;
using Microsoft.Maps.MapControl.WPF;
using MyDailyHerping.Models;
using MyDailyHerping.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace MyDailyHerping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();
        AreaVM _areavm = new AreaVM();
        public MainWindow()
        {
            InitializeComponent();
            
            LoadAreas();
        }

        private void LoadAreas()
        {
            var l_observation = _areavm.GetAreas();
            this.listObsSite.ItemsSource = l_observation;

            if (l_observation.Count > 0)
                AddPinToMap(l_observation);
        }

        private void AddPinToMap(List<Area> l_observation)
        {
            for(int i = 0; i < l_observation.Count; i++)
            {
                Pushpin pin = new Pushpin();
                pin.Location = new Location(Convert.ToDouble(l_observation[i].Lat), Convert.ToDouble(l_observation[i].Long));
                myMap.Children.Add(pin);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();
            base.OnClosing(e);
        }

        private void btnAddArea_Click(object sender, RoutedEventArgs e)
        {
            AreaForm areaForm= new AreaForm();
            areaForm.Show();
            this.txtInfo.Text = "Enregistrement du site d'observation effectué avec succès.";
            LoadAreas();
        }

        private void ChangeMapMode(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(myMap is not null)
            {
                if (cmBoxMapStyle.SelectedIndex == 0)
                {
                    myMap.Mode = new RoadMode();
                }
                else if (cmBoxMapStyle.SelectedIndex == 1)
                {
                    myMap.Mode = new AerialMode();
                }
                else if (cmBoxMapStyle.SelectedIndex == 2)
                {
                    myMap.Mode = new AerialMode(true);
                }
            }
        }
    }
}
