namespace hoccsharp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.txtMaDon = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 20), Size = new System.Drawing.Size(150, 23) };
            this.txtTenKhach = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 55), Size = new System.Drawing.Size(150, 23) };
            this.txtDiaChi = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 90), Size = new System.Drawing.Size(150, 23) };
            this.cboLoaiVanChuyen = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(90, 125), Size = new System.Drawing.Size(150, 23), DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.cboLoaiVanChuyen.Items.AddRange(new object[] { "Đường bộ", "Đường hàng không", "Đường biển", "Hỏa tốc" });

            this.dgvHangHoa = new System.Windows.Forms.DataGridView() { 
                Dock = System.Windows.Forms.DockStyle.Fill, 
                AllowUserToAddRows = true, 
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            };
            
            this.colTenHang = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colTenHang", HeaderText = "Tên hàng" };
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colSoLuong", HeaderText = "Số lượng" };
            this.colTrongLuong = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colTrongLuong", HeaderText = "Trọng lượng (kg)" };
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colDonGia", HeaderText = "Đơn giá" };
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colThanhTien", HeaderText = "Thành tiền", ReadOnly = true };

            this.dgvHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colTenHang, this.colSoLuong, this.colTrongLuong, this.colDonGia, this.colThanhTien
            });
            this.dgvHangHoa.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellValueChanged);
            this.dgvHangHoa.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvHangHoa_RowsRemoved);

            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusThoiGian = new System.Windows.Forms.ToolStripStatusLabel() { Text = "Thời gian: " };
            this.lblStatusSoLuong = new System.Windows.Forms.ToolStripStatusLabel() { Text = "Tổng SL: 0" };
            this.lblStatusTrongLuong = new System.Windows.Forms.ToolStripStatusLabel() { Text = "Tổng TL: 0 kg" };
            this.lblStatusTongTien = new System.Windows.Forms.ToolStripStatusLabel() { Text = "Tổng tiền: 0 VNĐ" };

            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblStatusThoiGian, this.lblStatusSoLuong, this.lblStatusTrongLuong, this.lblStatusTongTien
            });

            this.timerClock = new System.Windows.Forms.Timer(this.components) { Interval = 1000 };
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.SplitterDistance = 250;

            this.splitMain.Panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                new System.Windows.Forms.Label { Text = "Mã đơn:", Location = new System.Drawing.Point(10, 23), AutoSize = true }, this.txtMaDon,
                new System.Windows.Forms.Label { Text = "Khách:", Location = new System.Drawing.Point(10, 58), AutoSize = true }, this.txtTenKhach,
                new System.Windows.Forms.Label { Text = "Địa chỉ:", Location = new System.Drawing.Point(10, 93), AutoSize = true }, this.txtDiaChi,
                new System.Windows.Forms.Label { Text = "Vận chuyển:", Location = new System.Drawing.Point(10, 128), AutoSize = true }, this.cboLoaiVanChuyen,
                new System.Windows.Forms.Label { Text = "Phím tắt:\n- F2: Thêm dòng\n- Delete: Xóa dòng", Location = new System.Drawing.Point(10, 180), AutoSize = true, ForeColor = System.Drawing.Color.DarkBlue }
            });

            this.splitMain.Panel2.Controls.Add(this.dgvHangHoa);

            this.ClientSize = new System.Drawing.Size(900, 420);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Text = "Delivery Order Dashboard";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TextBox txtMaDon, txtTenKhach, txtDiaChi;
        private System.Windows.Forms.ComboBox cboLoaiVanChuyen;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHang, colSoLuong, colTrongLuong, colDonGia, colThanhTien;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusThoiGian, lblStatusSoLuong, lblStatusTrongLuong, lblStatusTongTien;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}