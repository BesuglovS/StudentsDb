using StudentsDb.Database;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace StudentsDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private async void Seed1_Click(object sender, RoutedEventArgs e)
        {
            await DatabaseSeeder.SeedData1();
            FacultiesButton.Command.Execute("faculties");
        }

        private async void Seed2_Click(object sender, RoutedEventArgs e)
        {
            await DatabaseSeeder.SeedData2();
            FacultiesButton.Command.Execute("faculties");
        }

        private async void Seed3_Click(object sender, RoutedEventArgs e)
        {
            await DatabaseSeeder.SeedData3();
            FacultiesButton.Command.Execute("faculties");
        }
    }
}
