using MyDailyHerping.Models;
using MyDailyHerping.ViewModels;
using System;
using System.Windows;

namespace MyDailyHerping
{
    /// <summary>
    /// Logique d'interaction pour AreaForm.xaml
    /// </summary>
    public partial class AreaForm : Window
    {
        AreaVM _areaVM = new AreaVM();
        public AreaForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string _long = txtObjectLong.Text.Replace('.', ',');
            string _lat = txtObjectLat.Text.Replace('.', ',');
            using (ApplicationDBContext _context = new ApplicationDBContext())
            {
                Area _area = new Area
                {
                    ObjectID = txtObjectID.Text,
                    Name = txtObjectName.Text,
                    Long = Convert.ToDouble(_long),
                    Lat = Convert.ToDouble(_lat),
                    Type = cmbBoxType.SelectedItem.ToString()
                };

                if(_areaVM.CreateOrUpdateArea(_area))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problème lors de l'enregistrement, vérifiez les logs", "Erreur d'enregistrement", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
