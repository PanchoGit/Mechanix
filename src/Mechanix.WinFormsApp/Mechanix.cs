using Mechanix.Domain;
using Mechanix.WinFormsApp.Workflows;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Mechanix.WinFormsApp
{
    public partial class Mechanix : Form
    {
        private readonly MechanixWorkflow workflow;

        public Mechanix()
        {
            InitializeComponent();

            workflow = new MechanixWorkflow();

            Setup();
        }

        private void Setup()
        {
            var services = workflow.GetServices();

            ServiceListBox.DataSource = services;
            ServiceListBox.DisplayMember = "Name";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveClickHandler();
        }

        private void SaveClickHandler()
        {
            var result = workflow.Create(GetCarFromControls());

            if (result.HasErrors)
            {
                var errorMessage = string.Join("\n", result.Errors.Select(s => s.ErrorMessage));

                MessageBox.Show(errorMessage, "Error");

                return;
            }

            MessageBox.Show("Auto registrado correctamente.", "Ok");
        }

        private Car GetCarFromControls()
        {
            return new Car
            {
                Brand = BrandTextBox.Text,
                Year = int.Parse(YearTextBox.Text),
                Patent = PatentTextBox.Text,
                Owner = new Owner
                {
                    FirstName = OwnerFirstNameTextBox.Text,
                    LastName = OwnerLastNameTextBox.Text
                },
                Services = ServiceListBox.SelectedItems.Cast<Service>().ToList()
            };
        }
    }
}
