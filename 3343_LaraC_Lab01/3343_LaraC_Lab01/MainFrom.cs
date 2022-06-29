//Christian Lara
//000983220
//Feb/09/2020
//Feb/09/2020
/*This program is used to create a list of employees. The employees information is stored in a diferent class clled employees.
 The information is then tranmited to a list to be displayed in the list box. The user can click the name of a employee in the listbox,
 and the user will have displayed a different form with all the datails of the employee. the user can close this from.
 The user can also clar all the employyes from the list and list box, and it can finnaly close the program with te exit button.*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3343_LaraC_Lab01
{
    public partial class MainForm : Form
    {
        List<Employee> employeeList = new List<Employee>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (isNotBlank(nameTextbox,"Name") == true &&
                isNotBlank(idNumberTextbox, "ID Number") == true &&
                isValidInt(idNumberTextbox,"ID Number") != -1 &&
                isNotBlank(departmentTextbox,"Department") == true&&
                isNotBlank(positionTextbox,"Position") == true)
            {
                //create an object of the employee class
                Employee myEmployee = new Employee();

                //use propertis to assign values from textboxes
                myEmployee.Name = nameTextbox.Text;
                myEmployee.IdNumber = Int32.Parse(idNumberTextbox.Text);
                myEmployee.Department = departmentTextbox.Text;
                myEmployee.Position = positionTextbox.Text;

                //add employee object to the list
                employeeList.Add(myEmployee);

                //add name field of myemployee to list box
                employeeListListbox.Items.Add(myEmployee.Name);

                //clear input text boxes
                nameTextbox.Text = "";
                idNumberTextbox.Text = "";
                departmentTextbox.Text = "";
                positionTextbox.Text = "";
                nameTextbox.Focus();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            nameTextbox.Text = "";
            idNumberTextbox.Text = "";
            departmentTextbox.Text = "";
            positionTextbox.Text = "";
            employeeListListbox.Items.Clear();
            employeeList.Clear();
            nameTextbox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int isValidInt(Control ctrl, string controlName)
        {
            int output;
            if (int.TryParse(ctrl.Text, out output))
            {
                if (output > 0)
                {
                    //valid input
                    return output;
                }
                else
                {
                    MessageBox.Show(controlName + " must be grater than 0");
                    ctrl.Text = "";
                    ctrl.Focus();
                    return -1;
                }
            }
            else
            {
                MessageBox.Show(controlName + " must be a whole number.");
                ctrl.Text = "";
                ctrl.Focus();
                return -1;
            }
        }

        private bool isNotBlank(Control ctrl, string controlName)
        {
            if (ctrl.Text != "")
            {
                //valid input
                return true;
            }
            else
            {
                MessageBox.Show(controlName + " cannot be blank.");
                ctrl.Text = "";
                ctrl.Focus();
                return false;
            }
        }

        private void employeeListListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get index of the selected lsit item
            int index = employeeListListbox.SelectedIndex;

            //create an item of the employee list form
            EmployeeDetails detailsForm = new EmployeeDetails();

            //display employee information
            detailsForm.nameLabel.Text = employeeList[index].Name;
            detailsForm.idNumberLabel.Text = employeeList[index].IdNumber.ToString();
            detailsForm.departmentLabel.Text = employeeList[index].Department;
            detailsForm.positionLabel.Text = employeeList[index].Position;

            // show employee form
            detailsForm.ShowDialog();

        }
    }
}
