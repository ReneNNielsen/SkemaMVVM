using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PersonSelectViewData : BaseViewData
    {
        private ObservableCollection<PersonListItemViewData> persons;
        public ObservableCollection<PersonListItemViewData> Persons
        {
            get
            {
                return persons;
            }
            set
            {
                if (value != persons)
                {
                    persons = value;
                    NotifyPropertyChanged();
                }

            }
        }
    }
}
