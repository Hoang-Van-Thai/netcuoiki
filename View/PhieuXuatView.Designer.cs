namespace PhanMenBanThucPhamNongNghiep.View
{
    partial class PhieuXuatView
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
            label3 = new Label();
            textBoxMaPhieuXuat = new TextBox();
            panel1 = new Panel();
            button4 = new Button();
            label4 = new Label();
            comboBoxMaKhachHang = new ComboBox();
            dateTimePickerNgayXuat = new DateTimePicker();
            dataGridViewPhieuXuat = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhieuXuat).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.Location = new Point(90, 25);
            label1.Name = "label1";
            label1.Size = new Size(161, 31);
            label1.TabIndex = 0;
            label1.Text = "Mã phiếu xuất";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.Location = new Point(90, 98);
            label2.Name = "label2";
            label2.Size = new Size(171, 31);
            label2.TabIndex = 1;
            label2.Text = "Mã khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F);
            label3.Location = new Point(90, 169);
            label3.Name = "label3";
            label3.Size = new Size(118, 31);
            label3.TabIndex = 2;
            label3.Text = "Ngày xuất";
            // 
            // textBoxMaPhieuXuat
            // 
            textBoxMaPhieuXuat.Location = new Point(325, 25);
            textBoxMaPhieuXuat.Name = "textBoxMaPhieuXuat";
            textBoxMaPhieuXuat.ReadOnly = true;
            textBoxMaPhieuXuat.Size = new Size(297, 30);
            textBoxMaPhieuXuat.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBoxMaKhachHang);
            panel1.Controls.Add(dateTimePickerNgayXuat);
            panel1.Controls.Add(textBoxMaPhieuXuat);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(3, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1037, 262);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(692, 13);
            button4.Name = "button4";
            button4.Size = new Size(112, 42);
            button4.TabIndex = 9;
            button4.Text = "Làm mới";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(328, 169);
            label4.Name = "label4";
            label4.Size = new Size(0, 23);
            label4.TabIndex = 8;
            // 
            // comboBoxMaKhachHang
            // 
            comboBoxMaKhachHang.FormattingEnabled = true;
            comboBoxMaKhachHang.Location = new Point(325, 104);
            comboBoxMaKhachHang.Name = "comboBoxMaKhachHang";
            comboBoxMaKhachHang.Size = new Size(297, 31);
            comboBoxMaKhachHang.TabIndex = 7;
            comboBoxMaKhachHang.SelectedIndexChanged += comboBoxMaKhachHang_SelectedIndexChanged;
            // 
            // dateTimePickerNgayXuat
            // 
            dateTimePickerNgayXuat.Location = new Point(325, 173);
            dateTimePickerNgayXuat.Name = "dateTimePickerNgayXuat";
            dateTimePickerNgayXuat.Size = new Size(297, 30);
            dateTimePickerNgayXuat.TabIndex = 6;
            // 
            // dataGridViewPhieuXuat
            // 
            dataGridViewPhieuXuat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPhieuXuat.Location = new Point(5, 285);
            dataGridViewPhieuXuat.Name = "dataGridViewPhieuXuat";
            dataGridViewPhieuXuat.RowHeadersWidth = 51;
            dataGridViewPhieuXuat.Size = new Size(1032, 315);
            dataGridViewPhieuXuat.TabIndex = 7;
            dataGridViewPhieuXuat.CellClick += dataGridViewPhieuXuat_CellClick;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F);
            button1.Location = new Point(545, 26);
            button1.Name = "button1";
            button1.Size = new Size(94, 38);
            button1.TabIndex = 8;
            button1.Text = "Xóa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13.8F);
            button2.Location = new Point(714, 26);
            button2.Name = "button2";
            button2.Size = new Size(106, 38);
            button2.TabIndex = 9;
            button2.Text = "Lưu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13.8F);
            button3.Location = new Point(894, 26);
            button3.Name = "button3";
            button3.Size = new Size(115, 38);
            button3.TabIndex = 10;
            button3.Text = "Đóng";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(5, 606);
            panel2.Name = "panel2";
            panel2.Size = new Size(1035, 79);
            panel2.TabIndex = 11;
            // 
            // PhieuXuatView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(dataGridViewPhieuXuat);
            Controls.Add(panel1);
            Name = "PhieuXuatView";
            Size = new Size(1046, 692);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhieuXuat).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxMaPhieuXuat;
        private Panel panel1;
        private DateTimePicker dateTimePickerNgayXuat;
        private DataGridView dataGridViewPhieuXuat;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel2;
        private ComboBox comboBoxMaKhachHang;
        private Label label4;
        private Button button4;
    }
}
