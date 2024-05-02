using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DBCH38_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DBCH38_SZTGUI_202320242.WpfClient.VMs
{
    public class PrioVM : ObservableRecipient
    {
        public RestCollection<Priority> Prios { get; set; }

        private Priority selectedPrio;

        RestService noncruds;

        public ICommand Create {  get; set; }
        public ICommand Update {  get; set; }
        public ICommand Delete {  get; set; }
        public ICommand GetPriorityWithMostTasks { get; set; }
        public Priority SelectedPrio { get => selectedPrio; set 
            {

                if (value != null)
                {
                    selectedPrio = new Priority()
                    {
                        Id = value.Id,
                        Value = value.Value
                    };
                    OnPropertyChanged();
                    (Delete as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public PrioVM()
        {
            noncruds = new RestService("http://localhost:1542/","swagger");
            Prios = new RestCollection<Priority>("http://localhost:1542/", "priority","hub");
            Create = new RelayCommand(() =>
            {
                Prios.Add(new Priority()
                {
                    Value = SelectedPrio.Value
                });
            });
            Delete = new RelayCommand(() =>
            {
                Prios.Delete(SelectedPrio.Id);

            });
            Update = new RelayCommand(() =>
            {
                Prios.Update(SelectedPrio);
                
            });
            GetPriorityWithMostTasks = new RelayCommand(() =>
            {
                var value = noncruds.Get<Priority>("priority/getprioritywithmosttasks").ToList();
                //NonCrudVM<Priority> nonCrudVM = new NonCrudVM<Priority>() { Message= "GetPriorityWithMostTasks",Values=value };
                NonCrudWindow window = new NonCrudWindow("GetPriorityWithMostTasks",value);
                window.ShowDialog();


            });
            SelectedPrio = new Priority();
            
        }
    }
}
