using Museum.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Museum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        string apiUrl = "http://localhost:5129";

        public MainWindow()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            InitializeComponent();
        }

        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem selectedTab = (TabItem)TabControl.SelectedItem;

            switch (selectedTab.Header.ToString())
            {
                case "Act":
                    {
                        string actUrl = "/act";
                        GetData<Act>(actUrl, dgAct);
                        break;
                    }
                case "Employee":
                    {
                        string employeeUrl = "/employee";
                        GetData<Employee>(employeeUrl, dgEmployee);
                        break;
                    }
                case "Exhibit":
                    {
                        string exhibitUrl = "/exhibit";
                        GetData<Exhibit>(exhibitUrl, dgExhibit);
                        break;
                    }
                case "Exhibition":
                    {
                        string exhibitionUrl = "/exhibition";
                        GetData<Exhibition>(exhibitionUrl, dgExhibition);
                        break;
                    }
                case "MuseumHall":
                    {
                        string museumHallUrl = "/museumHall";
                        GetData<MuseumHall>(museumHallUrl, dgMuseumHall);
                        break;
                    }
                case "Position":
                    {
                        string positionUrl = "/position";
                        GetData<Position>(positionUrl, dgPosition);
                        break;
                    }
                case "ReceptionWay":
                    {
                        string receptWayUrl = "/receptWay";
                        GetData<ReceptionWay>(receptWayUrl, dgReceptionWay);
                        break;
                    }
                case "StoragePlace":
                    {
                        string storageUrl = "/storage";
                        GetData<StoragePlace>(storageUrl, dgStoragePlace);
                        break;
                    }
                case "TypeOfStoring":
                    {
                        string typeOfStoringUrl = "/typeOfStoring";
                        GetData<TypeOfStoring>(typeOfStoringUrl, dgTypeOfStoring);
                        break;
                    }
                case "WorkTechnique":
                    {
                        string workTechUrl = "/workTech";
                        GetData<WorkTechnique>(workTechUrl, dgWorkTechnique);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Choose the tab");
                        break;
                    }
            }
        }

        private async void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem selectedTab = (TabItem)TabControl.SelectedItem;

            switch (selectedTab.Header.ToString())
            {
                case "Act":
                    {
                        string actUrl = "/act";
                        Act selectedAct = dgAct.SelectedItem as Act;

                        Act act = new Act()
                        {
                            DateIssuing = selectedAct.DateIssuing,
                            DateAccepting = selectedAct.DateAccepting,
                            IdExhibit = selectedAct.IdExhibit,
                            IdExhibition = selectedAct.IdExhibition
                        };

                        InsertData<Act>(actUrl, act);
                        break;
                    }
                case "Employee":
                    {
                        string employeeUrl = "/employee";
                        Employee selectedEmployee = dgEmployee.SelectedItem as Employee;

                        Employee employee = new Employee()
                        {
                            Lastname = selectedEmployee.Lastname,
                            Firstname = selectedEmployee.Firstname,
                            Middlename = selectedEmployee.Middlename,
                            DateOfBirth = selectedEmployee.DateOfBirth,
                            Address = selectedEmployee.Address,
                            PhoneNumber = selectedEmployee.PhoneNumber,
                            IdPosition = selectedEmployee.IdPosition
                        };

                        InsertData<Employee>(employeeUrl, employee);
                        break;
                    }
                case "Exhibit":
                    {
                        string exhibitUrl = "/exhibit";
                        Exhibit selectedExhibit = dgExhibit.SelectedItem as Exhibit;

                        Exhibit exhibit = new Exhibit()
                        {
                            NameExhibit = selectedExhibit.NameExhibit,
                            Author = selectedExhibit.Author,
                            DateCreate = selectedExhibit.DateCreate,
                            IdTechnique = selectedExhibit.IdTechnique,
                            IdEmployee = selectedExhibit.IdEmployee,
                            IdStorage = selectedExhibit.IdStorage,
                            IdReceptionWay = selectedExhibit.IdReceptionWay,
                            IdTypeOfStoring = selectedExhibit.IdTypeOfStoring
                        };
                        InsertData<Exhibit>(exhibitUrl, exhibit);
                        break;
                    }
                case "Exhibition":
                    {
                        string exhibitionUrl = "/exhibition";
                        Exhibition selectedExhibition = dgExhibition.SelectedItem as Exhibition;

                        Exhibition exhibition = new Exhibition()
                        {
                            NameExhibition = selectedExhibition.NameExhibition,
                            Arranger = selectedExhibition.Arranger,
                            DateOpen = selectedExhibition.DateOpen,
                            DateClose = selectedExhibition.DateClose
                        };
                        InsertData<Exhibition>(exhibitionUrl, exhibition);
                        break;
                    }
                case "MuseumHall":
                    {
                        string museumHallUrl = "/museumHall";
                        MuseumHall selectedMuseumHall = dgMuseumHall.SelectedItem as MuseumHall;

                        MuseumHall museumHall = new MuseumHall()
                        {
                            AmountOfPlaces = selectedMuseumHall.AmountOfPlaces,
                            IdEmployee = selectedMuseumHall.IdEmployee
                        };
                        InsertData<MuseumHall>(museumHallUrl, museumHall);
                        break;
                    }
                case "Position":
                    {
                        string positionUrl = "/position";
                        Position selectedPosition = dgPosition.SelectedItem as Position;

                        Position position = new Position()
                        {
                            NamePosition = selectedPosition.NamePosition,
                            Salary = selectedPosition.Salary
                        };
                        InsertData<Position>(positionUrl, position);
                        break;
                    }
                case "ReceptionWay":
                    {
                        string receptWayUrl = "/receptWay";
                        ReceptionWay selectedReceptway = dgReceptionWay.SelectedItem as ReceptionWay;

                        ReceptionWay receptWay = new ReceptionWay()
                        {
                            NameReceptionWay = selectedReceptway.NameReceptionWay
                        };
                        InsertData<ReceptionWay>(receptWayUrl, receptWay);
                        break;
                    }
                case "StoragePlace":
                    {
                        string storageUrl = "/storage";
                        StoragePlace selectedStorage = dgStoragePlace.SelectedItem as StoragePlace;

                        StoragePlace storagePlace = new StoragePlace()
                        {
                            AmountOfPlaces = selectedStorage.AmountOfPlaces
                        };
                        InsertData<StoragePlace>(storageUrl, storagePlace);
                        break;
                    }
                case "TypeOfStoring":
                    {
                        string typeOfStoringUrl = "/typeOfStoring";
                        TypeOfStoring selectedTypeOfStoring = dgTypeOfStoring.SelectedItem as TypeOfStoring;

                        TypeOfStoring typeOfStoring = new TypeOfStoring()
                        {
                            NameTypeOfStoring = selectedTypeOfStoring.NameTypeOfStoring
                        };
                        InsertData<TypeOfStoring>(typeOfStoringUrl, typeOfStoring);
                        break;
                    }
                case "WorkTechnique":
                    {
                        string workTechUrl = "/workTech";
                        WorkTechnique selectedWorkTech = dgWorkTechnique.SelectedItem as WorkTechnique;

                        WorkTechnique workTech = new WorkTechnique()
                        {
                            NameTechnique = selectedWorkTech.NameTechnique,
                            Material = selectedWorkTech.Material
                        };
                        InsertData<WorkTechnique>(workTechUrl, workTech);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Choose the tab");
                        break;
                    }
            }
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem selectedTab = (TabItem)TabControl.SelectedItem;

            switch (selectedTab.Header.ToString())
            {
                case "Act":
                    {
                        string actUrl = "/act";
                        Act selectedAct = dgAct.SelectedItem as Act;

                        Act act = new Act()
                        {   
                            Id = selectedAct.Id,
                            DateIssuing = selectedAct.DateIssuing,
                            DateAccepting = selectedAct.DateAccepting,
                            IdExhibit = selectedAct.IdExhibit,
                            IdExhibition = selectedAct.IdExhibition
                        };

                        UpdateData<Act>(actUrl, act.Id, act, dgAct);
                        break;
                    }
                case "Employee":
                    {
                        string employeeUrl = "/employee";
                        Employee selectedEmployee = dgEmployee.SelectedItem as Employee;

                        Employee employee = new Employee()
                        {
                            Id = selectedEmployee.Id,
                            Lastname = selectedEmployee.Lastname,
                            Firstname = selectedEmployee.Firstname,
                            Middlename = selectedEmployee.Middlename,
                            DateOfBirth = selectedEmployee.DateOfBirth,
                            Address = selectedEmployee.Address,
                            PhoneNumber = selectedEmployee.PhoneNumber,
                            IdPosition = selectedEmployee.IdPosition
                        };

                        UpdateData<Employee>(employeeUrl, employee.Id, employee, dgEmployee);
                        break;
                    }
                case "Exhibit":
                    {
                        string exhibitUrl = "/exhibit";
                        Exhibit selectedExhibit = dgExhibit.SelectedItem as Exhibit;

                        Exhibit exhibit = new Exhibit()
                        {
                            Id = selectedExhibit.Id,
                            NameExhibit = selectedExhibit.NameExhibit,
                            Author = selectedExhibit.Author,
                            DateCreate = selectedExhibit.DateCreate,
                            IdTechnique = selectedExhibit.IdTechnique,
                            IdEmployee = selectedExhibit.IdEmployee,
                            IdStorage = selectedExhibit.IdStorage,
                            IdReceptionWay = selectedExhibit.IdReceptionWay,
                            IdTypeOfStoring = selectedExhibit.IdTypeOfStoring
                        };
                        UpdateData<Exhibit>(exhibitUrl, exhibit.Id, exhibit, dgExhibit);
                        break;
                    }
                case "Exhibition":
                    {
                        string exhibitionUrl = "/exhibition";
                        Exhibition selectedExhibition = dgExhibition.SelectedItem as Exhibition;

                        Exhibition exhibition = new Exhibition()
                        {
                            Id = selectedExhibition.Id,
                            NameExhibition = selectedExhibition.NameExhibition,
                            Arranger = selectedExhibition.Arranger,
                            DateOpen = selectedExhibition.DateOpen,
                            DateClose = selectedExhibition.DateClose
                        };
                        UpdateData<Exhibition>(exhibitionUrl, exhibition.Id, exhibition, dgExhibition);
                        break;
                    }
                case "MuseumHall":
                    {
                        string museumHallUrl = "/museumHall";
                        MuseumHall selectedMuseumHall = dgMuseumHall.SelectedItem as MuseumHall;

                        MuseumHall museumHall = new MuseumHall()
                        {
                            Id = selectedMuseumHall.Id,
                            AmountOfPlaces = selectedMuseumHall.AmountOfPlaces,
                            IdEmployee = selectedMuseumHall.IdEmployee
                        };
                        UpdateData<MuseumHall>(museumHallUrl, museumHall.Id, museumHall, dgMuseumHall);
                        break;
                    }
                case "Position":
                    {
                        string positionUrl = "/position";
                        Position selectedPosition = dgPosition.SelectedItem as Position;

                        Position position = new Position()
                        {
                            Id = selectedPosition.Id,
                            NamePosition = selectedPosition.NamePosition,
                            Salary = selectedPosition.Salary
                        };
                        UpdateData<Position>(positionUrl, position.Id, position, dgPosition);
                        break;
                    }
                case "ReceptionWay":
                    {
                        string receptWayUrl = "/receptWay";
                        ReceptionWay selectedReceptway = dgReceptionWay.SelectedItem as ReceptionWay;

                        ReceptionWay receptWay = new ReceptionWay()
                        {
                            Id = selectedReceptway.Id,
                            NameReceptionWay = selectedReceptway.NameReceptionWay
                        };
                        UpdateData<ReceptionWay>(receptWayUrl, receptWay.Id, receptWay, dgReceptionWay);
                        break;
                    }
                case "StoragePlace":
                    {
                        string storageUrl = "/storage";
                        StoragePlace selectedStorage = dgStoragePlace.SelectedItem as StoragePlace;

                        StoragePlace storagePlace = new StoragePlace()
                        {
                            Id = selectedStorage.Id,
                            AmountOfPlaces = selectedStorage.AmountOfPlaces
                        };
                        UpdateData<StoragePlace>(storageUrl, storagePlace.Id, storagePlace, dgStoragePlace);
                        break;
                    }
                case "TypeOfStoring":
                    {
                        string typeOfStoringUrl = "/typeOfStoring";
                        TypeOfStoring selectedTypeOfStoring = dgTypeOfStoring.SelectedItem as TypeOfStoring;

                        TypeOfStoring typeOfStoring = new TypeOfStoring()
                        {
                            Id = selectedTypeOfStoring.Id,
                            NameTypeOfStoring = selectedTypeOfStoring.NameTypeOfStoring
                        };
                        UpdateData<TypeOfStoring>(typeOfStoringUrl, typeOfStoring.Id, typeOfStoring, dgTypeOfStoring);
                        break;
                    }
                case "WorkTechnique":
                    {
                        string workTechUrl = "/workTech";
                        WorkTechnique selectedWorkTech = dgWorkTechnique.SelectedItem as WorkTechnique;

                        WorkTechnique workTech = new WorkTechnique()
                        {
                            Id = selectedWorkTech.Id,
                            NameTechnique = selectedWorkTech.NameTechnique,
                            Material = selectedWorkTech.Material
                        };
                        UpdateData<WorkTechnique>(workTechUrl, workTech.Id, workTech, dgWorkTechnique);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Choose the tab");
                        break;
                    }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem selectedTab = (TabItem)TabControl.SelectedItem;

            switch (selectedTab.Header.ToString())
            {
                case "Act":
                    {
                        string actUrl = "/act";
                        Act selectedAct = (Act)dgAct.SelectedItem;
                        int idAct = selectedAct.Id;
                        DeleteData<Act>(actUrl, idAct, dgAct);
                        break;
                    }
                case "Employee":
                    {
                        string employeeUrl = "/employee";
                        Employee selectedEmployee = (Employee)dgEmployee.SelectedItem;
                        int idEmployee = selectedEmployee.Id;
                        DeleteData<Employee>(employeeUrl, idEmployee, dgEmployee);
                        break;
                    }
                case "Exhibit":
                    {
                        string exhibitUrl = "/exhibit";
                        Exhibit selectedExhibit = (Exhibit)dgExhibit.SelectedItem;
                        int idExhibit = selectedExhibit.Id;
                        DeleteData<Exhibit>(exhibitUrl, idExhibit, dgExhibit);
                        break;
                    }
                case "Exhibition":
                    {
                        string exhibitionUrl = "/exhibition";
                        Exhibition selectedExhibition = (Exhibition)dgExhibition.SelectedItem;
                        int idExhibition = selectedExhibition.Id;
                        DeleteData<Exhibition>(exhibitionUrl, idExhibition, dgExhibition);
                        break;
                    }
                case "MuseumHall":
                    {
                        string museumHallUrl = "/museumHall";
                        MuseumHall selectedMuseumHall = (MuseumHall)dgMuseumHall.SelectedItem;
                        int idMuseumHall = selectedMuseumHall.Id;
                        DeleteData<MuseumHall>(museumHallUrl, idMuseumHall, dgMuseumHall);
                        break;
                    }
                case "Position":
                    {
                        string positionUrl = "/position";
                        Position selectedPosition = (Position)dgPosition.SelectedItem;
                        int idPosition = selectedPosition.Id;
                        DeleteData<Position>(positionUrl, idPosition, dgPosition);
                        break;
                    }
                case "ReceptionWay":
                    {
                        string receptWayUrl = "/receptWay";
                        ReceptionWay selectedReceptWay = (ReceptionWay)dgReceptionWay.SelectedItem;
                        int idReceptWay = selectedReceptWay.Id;
                        DeleteData<ReceptionWay>(receptWayUrl, idReceptWay, dgReceptionWay);
                        break;
                    }
                case "StoragePlace":
                    {
                        string storageUrl = "/storage";
                        StoragePlace selectedStorage = (StoragePlace)dgStoragePlace.SelectedItem;
                        int idStorage = selectedStorage.Id;
                        DeleteData<StoragePlace>(storageUrl, idStorage, dgStoragePlace);
                        break;
                    }
                case "TypeOfStoring":
                    {
                        string typeOfStoringUrl = "/typeOfStoring";
                        TypeOfStoring selectedTypeOfStoring = (TypeOfStoring)dgTypeOfStoring.SelectedItem;
                        int idTypeOfStoring = selectedTypeOfStoring.Id;
                        DeleteData<TypeOfStoring>(typeOfStoringUrl, idTypeOfStoring, dgTypeOfStoring);
                        break;
                    }
                case "WorkTechnique":
                    {
                        string workTechUrl = "/workTech";
                        WorkTechnique selectedWorkTech = (WorkTechnique)dgWorkTechnique.SelectedItem;
                        int idWorkTech = selectedWorkTech.Id;
                        DeleteData<WorkTechnique>(workTechUrl, idWorkTech, dgWorkTechnique);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Choose the tab");
                        break;
                    }
            }
        }


        public async Task GetData<T>(string endpoint, DataGrid dataGrid)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}{endpoint}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<T> items = JsonConvert.DeserializeObject<List<T>>(responseBody);

                    dataGrid.Items.Clear();
                    dataGrid.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Exception");
            }
            
        }

        public async Task<T> InsertData<T>(string endpoint, T item)
        {
            try
            {
                string serializedItem = JsonConvert.SerializeObject(item);
                HttpResponseMessage response = await client.PostAsync($"{apiUrl}{endpoint}", new StringContent(serializedItem, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
                else
                {
                    MessageBox.Show("Error");
                    return default;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Exception");
                return default;
            }  
        }

        public async Task UpdateData<T>(string endpoint, int id, T item, DataGrid dataGrid)
        {
            try
            {
                string serializedItem = JsonConvert.SerializeObject(item);
                HttpResponseMessage response = await client.PutAsync($"{apiUrl}{endpoint}/{id}", new StringContent(serializedItem, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string updatedItemJson = await response.Content.ReadAsStringAsync();
                    T updatedItem = JsonConvert.DeserializeObject<T>(updatedItemJson);

                    if (dataGrid.ItemsSource is ObservableCollection<T> observableCollection)
                    {
                        var itemToUpdate = observableCollection.FirstOrDefault(x => (x as IEntity)?.Id == id);

                        if (itemToUpdate != null)
                        {
                            int index = observableCollection.IndexOf(itemToUpdate);
                            observableCollection[index] = updatedItem;
                        }

                        dataGrid.ItemsSource = null;
                        dataGrid.ItemsSource = observableCollection;
                    }

                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        public async Task<bool> DeleteData<T>(string endpoint, int id, DataGrid dataGrid)
            where T : IEntity
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}{endpoint}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (dataGrid.ItemsSource is ObservableCollection<T> observableCollection)
                    {
                        var itemToRemove = observableCollection.FirstOrDefault(item => item.Id == id);

                        if (itemToRemove != null)
                        {
                            observableCollection.Remove(itemToRemove);
                        }

                        dataGrid.ItemsSource = null;
                        dataGrid.ItemsSource = observableCollection;
                    }
                    MessageBox.Show("Success");
                    return true;
                }
                else
                {
                    MessageBox.Show($"Error");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception");
                return false;
            }
        }
    }
}