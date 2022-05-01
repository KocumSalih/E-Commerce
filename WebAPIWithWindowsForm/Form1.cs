using ECommerceProjectWithWebAPI.Entities.Dtos.UserDtos;
using ECommerceProjectWithWebAPI.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebAPIWithWindowsForm
{
    public partial class Form1 : Form
    {
        #region Defines
        private readonly string apiGetListUrl = "http://localhost:62853/api/Users/GetList";
        private readonly string apiAddUrl = "http://localhost:62853/api/Users/Add";
        private readonly string apiGetByIdUrl = "http://localhost:62853/api/Users/GetById/";
        private readonly string apiUpdateUrl = "http://localhost:62853/api/Users/Update";
        private readonly string apiDeleteUrl = "http://localhost:62853/api/Users/Delete/";
        private int selectedId = 0;
        #endregion

        #region Form1

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await FillDataGridView();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        #endregion

        #region Events
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserAddDto userAddDto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Email = txtEmail.Text,
                    Gender = cmbGender.Text == "Erkek" ? true : false
                };
                HttpResponseMessage message = await httpClient.PostAsJsonAsync(new Uri(apiAddUrl), userAddDto);
                if (message.IsSuccessStatusCode)
                {
                    await FillDataGridView();
                    MessageBox.Show("Ekleme işlemi başarılı");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Ekleme işlemi başarısız...");
                }
            }
        }

        private async void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            using (HttpClient httpClient = new HttpClient())
            {

                var user = await httpClient.GetFromJsonAsync<UserDto>(new Uri(apiGetByIdUrl + selectedId));

                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtUserName.Text = user.UserName;
                txtAddress.Text = user.Address;
                dtpDateOfBirth.Value = user.DateOfBirth;
                txtEmail.Text = user.Email;
                cmbGender.SelectedItem = user.Gender == true ? "Erkek" : "Kadın";
            }
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserUpdateDto userUpdateDto = new UserUpdateDto()
                {
                    UserId = selectedId,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Email = txtEmail.Text,
                    Gender = cmbGender.Text == "Erkek" ? true : false
                };
                HttpResponseMessage message = await httpClient.PutAsJsonAsync(new Uri(apiUpdateUrl), userUpdateDto);
                if (message.IsSuccessStatusCode)
                {
                    await FillDataGridView();
                    MessageBox.Show("Düzenleme işlemi başarılı");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Düzenleme işlemi başarısız...");
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage message = await httpClient.DeleteAsync(new Uri(apiDeleteUrl + selectedId));
                if (message.IsSuccessStatusCode)
                {
                    await FillDataGridView();
                    MessageBox.Show("Silme işlemi başarılı...");
                    ClearForm();
                }
                else
                    MessageBox.Show("Silme işlemi başarısız...");
            }
        }

        #endregion

        #region Methods
        private async Task FillDataGridView()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(new Uri(apiGetListUrl));
                dataGridView1.DataSource = users;
            }
        }

        private void ClearForm()
        {
            foreach (var item in this.Controls)
                if (item is TextBox)
                    (item as TextBox).Clear();
            cmbGender.SelectedIndex = -1;
        }

        #endregion       
    }
}
