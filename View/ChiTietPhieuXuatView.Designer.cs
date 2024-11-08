namespace PhanMenBanThucPhamNongNghiep.View
{
    partial class ChiTietPhieuXuatView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            dateTimePickerNgayXuat = new DateTimePicker();
            label5 = new Label();
            comboBoxMaKhachHang = new ComboBox();
            txtMaPhieuXuat = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            label3 = new Label();
            lblTongTien = new Label();
            panel3 = new Panel();
            dataGridViewBanHang = new DataGridView();
            button3 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBanHang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.Location = new Point(110, 15);
            label1.Name = "label1";
            label1.Size = new Size(161, 31);
            label1.TabIndex = 0;
            label1.Text = "Mã phiếu xuất";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.Location = new Point(110, 72);
            label2.Name = "label2";
            label2.Size = new Size(171, 31);
            label2.TabIndex = 1;
            label2.Text = "Mã khách hàng";
            // 
            // panel1
            // 
            panel1.Controls.Add(dateTimePickerNgayXuat);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(comboBoxMaKhachHang);
            panel1.Controls.Add(txtMaPhieuXuat);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1043, 182);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // dateTimePickerNgayXuat
            // 
            dateTimePickerNgayXuat.Location = new Point(389, 129);
            dateTimePickerNgayXuat.Name = "dateTimePickerNgayXuat";
            dateTimePickerNgayXuat.Size = new Size(326, 27);
            dateTimePickerNgayXuat.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(112, 129);
            label5.Name = "label5";
            label5.Size = new Size(121, 31);
            label5.TabIndex = 4;
            label5.Text = "Ngày Xuất";
            // 
            // comboBoxMaKhachHang
            // 
            comboBoxMaKhachHang.FormattingEnabled = true;
            comboBoxMaKhachHang.Location = new Point(389, 72);
            comboBoxMaKhachHang.Name = "comboBoxMaKhachHang";
            comboBoxMaKhachHang.Size = new Size(326, 28);
            comboBoxMaKhachHang.TabIndex = 3;
            // 
            // txtMaPhieuXuat
            // 
            txtMaPhieuXuat.Location = new Point(389, 15);
            txtMaPhieuXuat.Name = "txtMaPhieuXuat";
            txtMaPhieuXuat.ReadOnly = true;
            txtMaPhieuXuat.Size = new Size(326, 27);
            txtMaPhieuXuat.TabIndex = 2;
            txtMaPhieuXuat.TextChanged += txtMaChiTietPhieuXuat_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F);
            button1.Location = new Point(582, 15);
            button1.Name = "button1";
            button1.Size = new Size(131, 40);
            button1.TabIndex = 4;
            button1.Text = "Đóng";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13.8F);
            button2.Location = new Point(816, 15);
            button2.Name = "button2";
            button2.Size = new Size(166, 40);
            button2.TabIndex = 5;
            button2.Text = "Xuất hóa đơn";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(3, 612);
            panel2.Name = "panel2";
            panel2.Size = new Size(1036, 79);
            panel2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F);
            label3.Location = new Point(34, 13);
            label3.Name = "label3";
            label3.Size = new Size(116, 31);
            label3.TabIndex = 8;
            label3.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 13.8F);
            lblTongTien.Location = new Point(159, 13);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(79, 31);
            lblTongTien.TabIndex = 9;
            lblTongTien.Text = "0 VND";
            lblTongTien.Click += label4_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTongTien);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(678, 550);
            panel3.Name = "panel3";
            panel3.Size = new Size(361, 56);
            panel3.TabIndex = 10;
            // 
            // dataGridViewBanHang
            // 
            dataGridViewBanHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBanHang.Location = new Point(1, 190);
            dataGridViewBanHang.Name = "dataGridViewBanHang";
            dataGridViewBanHang.RowHeadersWidth = 51;
            dataGridViewBanHang.Size = new Size(1042, 354);
            dataGridViewBanHang.TabIndex = 11;
            dataGridViewBanHang.CellContentClick += dataGridView1_CellContentClick;
            dataGridViewBanHang.CellValueChanged += dataGridViewBanHang_CellValueChanged;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(337, 18);
            button3.Name = "button3";
            button3.Size = new Size(172, 37);
            button3.TabIndex = 6;
            button3.Text = "Xuất file excel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ChiTietPhieuXuatView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewBanHang);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ChiTietPhieuXuatView";
            Size = new Size(1047, 693);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBanHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;
        private ComboBox comboBoxMaKhachHang;
        private TextBox txtMaPhieuXuat;
        private Button button1;
        private Button button2;
        private Panel panel2;
        private Label label3;
        private Label lblTongTien;
        private Panel panel3;
        private DataGridView dataGridViewBanHang;
        private Label label5;
        private DateTimePicker dateTimePickerNgayXuat;
        private Button button3;
    }
}
