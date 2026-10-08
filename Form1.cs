using System;
using System.Windows.Forms;

namespace hoccsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cboLoaiVanChuyen.SelectedIndex = 0;
            timerClock.Start();
            CapNhatThoiGian();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            CapNhatThoiGian();
        }

        private void CapNhatThoiGian()
        {
            lblStatusThoiGian.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void dgvHangHoa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHangHoa.Rows.Count) return;

            DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];

            double.TryParse(Convert.ToString(row.Cells["colSoLuong"].Value), out double soLuong);
            double.TryParse(Convert.ToString(row.Cells["colTrongLuong"].Value), out double trongLuong);
            decimal.TryParse(Convert.ToString(row.Cells["colDonGia"].Value), out decimal donGia);

            if (e.ColumnIndex == row.Cells["colSoLuong"].ColumnIndex)
            {
                if (soLuong <= 0 && row.Cells["colSoLuong"].Value != null)
                    row.Cells["colSoLuong"].ErrorText = "Số lượng phải > 0";
                else
                    row.Cells["colSoLuong"].ErrorText = "";
            }

            if (e.ColumnIndex == row.Cells["colTrongLuong"].ColumnIndex)
            {
                if (trongLuong <= 0 && row.Cells["colTrongLuong"].Value != null)
                    row.Cells["colTrongLuong"].ErrorText = "Trọng lượng phải > 0";
                else
                    row.Cells["colTrongLuong"].ErrorText = "";
            }

            decimal thanhTien = (decimal)soLuong * donGia;
            row.Cells["colThanhTien"].Value = thanhTien;

            CapNhatTong();
        }

        private void dgvHangHoa_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CapNhatTong();
        }

        private void CapNhatTong()
        {
            double tongSoLuong = 0;
            double tongTrongLuong = 0;
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvHangHoa.Rows)
            {
                if (row.IsNewRow) continue;

                double.TryParse(Convert.ToString(row.Cells["colSoLuong"].Value), out double sl);
                double.TryParse(Convert.ToString(row.Cells["colTrongLuong"].Value), out double tl);
                decimal.TryParse(Convert.ToString(row.Cells["colThanhTien"].Value), out decimal tt);

                tongSoLuong += sl;
                tongTrongLuong += tl;
                tongTien += tt;
            }

            lblStatusSoLuong.Text = "Tổng SL: " + tongSoLuong;
            lblStatusTrongLuong.Text = "Tổng TL: " + tongTrongLuong + " kg";
            lblStatusTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                dgvHangHoa.Rows.Add();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete && dgvHangHoa.ContainsFocus)
            {
                if (dgvHangHoa.CurrentRow != null && !dgvHangHoa.CurrentRow.IsNewRow)
                {
                    dgvHangHoa.Rows.Remove(dgvHangHoa.CurrentRow);
                    CapNhatTong();
                    e.Handled = true;
                }
            }
        }
    }
}