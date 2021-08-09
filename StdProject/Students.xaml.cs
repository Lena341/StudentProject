using System.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StdProject
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        private string[] semesters = { "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th" };
        private string[] directions = { "Network Engineering", "Computer Engineering", "Software Engineering", "No direction" };
        private ContextMenu windowContextMenu = null;
        public Students()
        {
            InitializeComponent();
            this.Reset();
            //More ContextMenus for the "Add" and "Clear" buttons.
            MenuItem saveStudentMenuItem = new MenuItem(); //New MenuItem
            saveStudentMenuItem.Header = "Save Student details"; //The header 
            saveStudentMenuItem.Click += new RoutedEventHandler(addStudent_Click); //The RoutedEventHandler() is delegate that reprisents methods of working with events.
                                                                                   //It calls the method addStudent_Click. 

            MenuItem clearFormMenuItem = new MenuItem();
            clearFormMenuItem.Header = "Clear Form";
            clearFormMenuItem.Click += new RoutedEventHandler(clearStudent_Click);

            //Here we create the two ContextMenus
            windowContextMenu = new ContextMenu();
            windowContextMenu.Items.Add(saveStudentMenuItem);
            windowContextMenu.Items.Add(clearFormMenuItem);
        }

        public void Reset()
        {
            firstName.Text = String.Empty; //The two textboxes will be empty.
            lastName.Text = String.Empty;

            studentSemester.Items.Clear();
            foreach (string i in semesters)
                studentSemester.Items.Add(i);
            studentSemester.Text = studentSemester.Items[0] as string; //The choice 1st semester in set as default.

            studentDirection.Items.Clear();
            foreach (string a in directions)
                studentDirection.Items.Add(a);
            studentDirection.Text = studentDirection.Items[0] as string;
        }

        private void clearStudent_Click(object sender, RoutedEventArgs e) //If you double click on the Clear Button in the xaml form it created this method. It creates an event method.
        {
            this.Reset();
        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(firstName.Text) || String.IsNullOrEmpty(lastName.Text))
            {
                MessageBoxResult boxResult = MessageBox.Show("Please enter a name and a last name", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
            else if (studentDirection.Text == "No direction")
            {
                string stdSemDirection = string.Format("Student {0} {1} studies at the {2} semester and hasn't chosen a direction.", firstName.Text, lastName.Text, studentSemester.Text, studentDirection.Text);
                MessageBoxResult messageBoxResult1 = MessageBox.Show(stdSemDirection.ToString(), "Student Information");
            }
            else 
            {
                string studentSemesterDirection = string.Format("Student {0} {1} studies at the {2} semester and has chosen the {3} direction.", firstName.Text, lastName.Text, studentSemester.Text, studentDirection.Text);
                MessageBoxResult messageBoxResult = MessageBox.Show(studentSemesterDirection.ToString(), "Student Information");
            }
        }

       private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Eleni Kartsakli\nBuilt date: August 2021","About",MessageBoxButton.OK);
        }

        private void newMember_Click(object sender, RoutedEventArgs e)
        {
            this.Reset(); //Calls Reset() method so that all the control elements in the form can be in their default state.
            //All the control elements are activated
            saveAsNewMember.IsEnabled = true;
            lastName.IsEnabled = true;
            firstName.IsEnabled = true;
            addStudent.IsEnabled = true;
            clearStudent.IsEnabled = true;
            studentSemester.IsEnabled = true;
            studentDirection.IsEnabled = true;
            this.ContextMenu = windowContextMenu;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.close();

        }

        private void close()
        {
            throw new NotImplementedException();
        }

        private void saveAsNewMember_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt"; //The default extention is .txt
            saveFileDialog.AddExtension = true; //If the users doesn't choose an extent for the file, it chooses the default extent.
            saveFileDialog.FileName = "Students"; //The name of the file.
            //saveFileDialog.InitialDirectory = @"C:\Users\name\Documents\"; This is the path where the file will be saved.
            saveFileDialog.OverwritePrompt = true; //If somebody tries to replace the file the user will be notified.
            saveFileDialog.Title = "Student Information";
            saveFileDialog.ValidateNames = true; //It checks of the name file has valied characters.

            if (String.IsNullOrEmpty(firstName.Text) || String.IsNullOrEmpty(lastName.Text))
            {
                MessageBoxResult boxResult = MessageBox.Show("Please enter a name and a last name", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else if (saveFileDialog.ShowDialog().Value)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("Here are the students' information:");
                    writer.WriteLine("Name: {0}", firstName.Text);
                    writer.WriteLine("Last name: {0}", lastName.Text);
                    writer.WriteLine("Semester: {0}", studentSemester.Text);
                    writer.WriteLine("Direction: {0}", studentDirection.Text);
                    MessageBox.Show("Students' information are saved", "Save");
                }
            }
        }



        private void clearName_Click(object sender, RoutedEventArgs e)
        {
            firstName.Text = String.Empty; //With this code both textboxed will become empty when the user chooses the choice "Clear Name" from the context menu.
            lastName.Text = String.Empty;
        }

        private void saveNewMember_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Students' information are saved", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
