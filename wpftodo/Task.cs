namespace wpftodo {

    public class Task : INotifyPropertyChanged {

        public Task(string title, string description, DateOnly dueDate, bool status) {
            Title = title;
            this.description = description;
            this.dueDate = dueDate;
            this.status = status;
        }


        public string Title { get; init; }

        private string description;
        public string Description {
            get => description;
            set {
                if (description != value) {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private DateOnly dueDate;
        public DateOnly DueDate { 
            get => dueDate;
            set { 
                if ( dueDate != value) {
                    dueDate = value;
                    OnPropertyChanged(nameof(DueDate));
                }
            } 
        }

        private bool status;
        public bool Status { 
            get => status; 
            set { if (status != value) { 
                    status = value;
                    OnPropertyChanged(nameof(Status));
                } 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        

        public override string ToString() => $"{Title} {Description} {DueDate} {(Status ? "Completed":"Incomplete")}";
    }

    public class ViewModel: INotifyPropertyChanged 
    { 
        private ObservableCollection<Task> tasks = new();
        public ObservableCollection<Task> Tasks {
            get => tasks; 
            set {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        public void Dump() {
            foreach (var task in Tasks) {
                Debug.WriteLine(task.ToString());
            }
        }
    }
    

    



 /*   public class Utility {
        // Experimental and untested
        // bear in mind that records _have_ a mechanism for mutation and we may be reinventing the wheel
        // leave this approach for now
        public class MyClass {
            // ... your class properties

            public MyClass Update(string propertyName, object value) {
                var propertyInfo = this.GetType().GetProperty(propertyName);

                if (propertyInfo == null) {
                    throw new ArgumentException($"Property '{propertyName}' not found.");
                }

                if (value == null) {
                    // Handle null values appropriately (assign or throw exception)
                    if (Nullable.GetUnderlyingType(propertyInfo.PropertyType) != null) {
                        propertyInfo.SetValue(this, null);
                    }
                    else {
                        throw new ArgumentException("Cannot assign null to a non-nullable property.");
                    }
                }
                else if (propertyInfo.PropertyType.IsAssignableFrom(value.GetType())) {
                    // Correct type, perform the assignment
                    propertyInfo.SetValue(this, value);
                }
                else {
                    // Incorrect type, try to convert or throw an exception
                    try {
                        var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
                        propertyInfo.SetValue(this, convertedValue);
                    }
                    catch (Exception ex) {
                        throw new ArgumentException($"Invalid value type for property '{propertyName}'.", ex);
                    }
                }

                return this;
            }
        }

    }*/
}