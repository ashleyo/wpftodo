global using System.Collections.ObjectModel;
global using System.Windows;
global using System.ComponentModel;
global using System.Diagnostics; 


namespace wpftodo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {

        private ViewModel vM = new();

        public MainWindow() {

            InitializeComponent();
            vM.Tasks.Add(new Task("Task 1", "Description 1", new DateOnly(2024, 6, 12), true));
            vM.Tasks.Add(new Task("Task 2", "Description 2", new DateOnly(2024, 7, 12), false));
            this.DataContext = vM;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            vM.Dump();
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