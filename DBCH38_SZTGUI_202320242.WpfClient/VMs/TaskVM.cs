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
    public class TaskVM : ObservableRecipient
    {
        public RestCollection<DBCH38_HFT_2023241.Models.Task> Tasks { get; set; }
        DBCH38_HFT_2023241.Models.Task selectedTask;
        RestService noncrud;
        public DBCH38_HFT_2023241.Models.Task SelectedTask { get => selectedTask; 
            set 
            {
                if (value != null)
                {
                    selectedTask = new DBCH38_HFT_2023241.Models.Task()
                    {
                        Id= value.Id,
                        Description = value.Description,
                        Type = value.Type,
                    };
                    OnPropertyChanged();
                    (Delete as RelayCommand).NotifyCanExecuteChanged();

                }
        }   }

        public ICommand Create { get; set; }
        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }
        public ICommand GetTaskWithManyWorkers { get; set; }
        public ICommand GetTaskWithManyWorkersUrgent { get; set; }

        public TaskVM()
        {
            noncrud = new RestService("http://localhost:1542/","swagger");
            Tasks = new RestCollection<DBCH38_HFT_2023241.Models.Task>("http://localhost:1542/", "task", "hub");
            Create = new RelayCommand(() =>
            {
                Tasks.Add(new DBCH38_HFT_2023241.Models.Task()
                {
                    Description = SelectedTask.Description,
                    Type = SelectedTask.Type,
                });
            });
            Delete = new RelayCommand(() =>
            {
                Tasks.Delete(SelectedTask.Id);

            });
            Update = new RelayCommand(() =>
            {
                Tasks.Update(SelectedTask);
            });
            GetTaskWithManyWorkers = new RelayCommand(() =>
            {
                var values = noncrud.Get<DBCH38_HFT_2023241.Models.Task>("task/gettaskwithmanyworkers").ToList();
                NonCrudWindow window = new NonCrudWindow("GetTaskWithManyWorkers", values);
                window.ShowDialog();
            });
            GetTaskWithManyWorkersUrgent = new RelayCommand(() =>
            {
                var values = noncrud.Get<DBCH38_HFT_2023241.Models.Task>("task/gettaskwithmanyworkersurgent").ToList();
                NonCrudWindow window = new NonCrudWindow("GetTaskWithManyWorkers", values);
                window.ShowDialog();

            });
            SelectedTask = new DBCH38_HFT_2023241.Models.Task();
        }

    }
}
