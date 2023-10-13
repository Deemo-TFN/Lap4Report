using lap4._1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lap4._1
{
    public partial class Form1 : Form
    {
        StudentContextDB db;

        public Form1()
        {
            db = new StudentContextDB();
            InitializeComponent();
        }
        private void initialStudent(List<Student> stuLst)
        {
            dgvStudents.Rows.Clear();
            foreach (var item in stuLst)
            {
                int index = dgvStudents.Rows.Add();
                dgvStudents.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudents.Rows[index].Cells[1].Value = item.FullName;
                dgvStudents.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvStudents.Rows[index].Cells[3].Value = item.AverageScore;
            }

        }
        private void initialKhoa(List<Faculty> facLst)
        {
            cmbKhoa.DataSource = facLst;
            cmbKhoa.DisplayMember = "FacultyName";
            cmbKhoa.ValueMember = "FacultyID";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Student> studentlst = db.Students.ToList();
            List<Faculty> facultyLst = db.Faculties.ToList();


            initialStudent(studentlst);
            initialKhoa(facultyLst);

        }
        private void refresh()
        {
            this.txtMSSV.Clear();
            this.txtTen.Clear();
            this.txtDTB.Clear();
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dgvStudents.Rows.Count; i++)
            {
                if (dgvStudents.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectedRow)
        {
            dgvStudents.Rows[selectedRow].Cells[0].Value = txtMSSV.Text;
            dgvStudents.Rows[selectedRow].Cells[1].Value = txtTen.Text;

            dgvStudents.Rows[selectedRow].Cells[2].Value = float.Parse(txtDTB.Text).ToString();
            dgvStudents.Rows[selectedRow].Cells[3].Value = cmbKhoa.Text;
        }
        private void btnThoat_Click_1(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                Application.Exit();
            }
            else
            {
                this.Show();

            }
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "" || txtTen.Text == "" || txtDTB.Text == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!. ", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                dgvStudents.Rows.Add(txtMSSV.Text, txtTen.Text, cmbKhoa.Text, txtDTB.Text);
                MessageBox.Show("them moi thanh cong ", "thong bao");
                refresh();

            }
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = GetSelectedRow(txtMSSV.Text);
                if (selectedRow == -1)
                {
                    throw new Exception("khong tim thay MSSV can xoa ");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("ban co muon xoa ?", "YES/NO", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        dgvStudents.Rows.RemoveAt(selectedRow);
                        MessageBox.Show("Xoa sinh vien thanh cong!", "thong bao", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMSSV.Text == "" || txtTen.Text == "" || cmbKhoa.Text == "" || txtDTB.Text == "")
                    throw new Exception("vui long nhap day du thong tin sinh vien");
                int selectedRow = GetSelectedRow(txtMSSV.Text);
                if (selectedRow == -1)
                {
                    selectedRow = dgvStudents.Rows.Add();
                    InsertUpdate(selectedRow);
                    MessageBox.Show("them moi du lieu thanh cong ", "Thong bao", MessageBoxButtons.OK);
                }
                else
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("cap nhat du lieu thanh cong", "thong bao ", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}