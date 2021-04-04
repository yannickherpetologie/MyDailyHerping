using MyDailyHerping.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyHerping.ViewModels
{
    class AreaVM : PropertyChangedBase
    {
        ApplicationDBContext _context = new ApplicationDBContext();
        private ObservableCollection<Area> _areas { get; set; }
        public ObservableCollection<Area> Areas
        {
            get { return _areas; }
            set
            {
                _areas = value;
                OnPropertyChanged("Areas");
            }
        }

        public List<Area> GetAreas()
        {
            return _context.Areas.OrderBy(o => o.ObjectID).ToList();
        }

        public bool CreateOrUpdateArea(Area area)
        {
            bool success;
            _context.Areas.Add(area);
            try
            {
                _context.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }
    }
}
