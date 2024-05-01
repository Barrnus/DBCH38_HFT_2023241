using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DBCH38_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DBCH38_SZTGUI_202320242.WpfClient.VMs
{
    public class WorkerVM : ObservableRecipient
    {
        public RestCollection<Worker> Workers { get; set; }

        public ICommand Create { get; set; }
        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }

        Worker selectedWorker;
        public Worker SelectedWorker
        {
            get => selectedWorker; 
            set
            {

                if (value != null)
                {
                    selectedWorker = new Worker()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Age = value.Age,
                        Position = value.Position,
                    };
                    OnPropertyChanged();
                    (Delete as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }

        public WorkerVM()
        {
            Workers = new RestCollection<Worker>("http://localhost:1542/", "worker", "hub");
            Create = new RelayCommand(() =>
            {
                Workers.Add(new Worker()
                {
                    Name = SelectedWorker.Name,
                    Age = SelectedWorker.Age,
                    Position = SelectedWorker.Position,
                });
            });
            Delete = new RelayCommand(() =>
            {
                Workers.Delete(SelectedWorker.Id);

            });
            Update = new RelayCommand(() =>
            {
                Workers.Update(SelectedWorker);
            });
            SelectedWorker = new Worker();
        }
    }
}
