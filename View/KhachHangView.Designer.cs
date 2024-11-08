namespace PhanMenBanThucPhamNongNghiep.View
{
    partial class KhachHangView
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
            label4 = new Label();
            textBoxMaKhachHang = new TextBox();
            textBoxTenKhachHang = new TextBox();
            textBoxDienThoai = new TextBox();
            textBoxDiaChi = new TextBox();
            panel1 = new Panel();
            dataGridViewKhachHang = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKhachHang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.Location = new Point(61, 33);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(171, 31);
            label1.TabIndex = 0;
            label1.Text = "Mã khách hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.Location = new Point(61, 106);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(173, 31);
            label2.TabIndex = 1;
            label2.Text = "Tên khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F);
            label3.Location = new Point(61, 194);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(148, 31);
            label3.TabIndex = 2;
            label3.Text = "Số diện thoại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F);
            label4.Location = new Point(61, 281);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(84, 31);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ";
            // 
            // textBoxMaKhachHang
            // 
            textBoxMaKhachHang.Location = new Point(278, 26);
            textBoxMaKhachHang.Margin = new Padding(5);
            textBoxMaKhachHang.Name = "textBoxMaKhachHang";
            textBoxMaKhachHang.ReadOnly = true;
            textBoxMaKhachHang.Size = new Size(358, 38);
            textBoxMaKhachHang.TabIndex = 4;
            textBoxMaKhachHang.TextChanged += textBox1_TextChanged;
            // 
            // textBoxTenKhachHang
            // 
            textBoxTenKhachHang.Location = new Point(278, 99);
            textBoxTenKhachHang.Margin = new Padding(5);
            textBoxTenKhachHang.Name = "textBoxTenKhachHang";
            textBoxTenKhachHang.Size = new Size(358, 38);
            textBoxTenKhachHang.TabIndex = 5;
            // 
            // textBoxDienThoai
            // 
            textBoxDienThoai.Location = new Point(278, 194);
            textBoxDienThoai.Margin = new Padding(5);
            textBoxDienThoai.Name = "textBoxDienThoai";
            textBoxDienThoai.Size = new Size(358, 38);
            textBoxDienThoai.TabIndex = 6;
            // 
            // textBoxDiaChi
            // 
            textBoxDiaChi.Location = new Point(278, 281);
            textBoxDiaChi.Margin = new Padding(5);
            textBoxDiaChi.Name = "textBoxDiaChi";
            textBoxDiaChi.Size = new Size(358, 38);
            textBoxDiaChi.TabIndex = 7;
            textBoxDiaChi.TextChanged += textBoxDienThoai_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxDiaChi);
            panel1.Controls.Add(textBoxDienThoai);
            panel1.Controls.Add(textBoxTenKhachHang);
            panel1.Controls.Add(textBoxMaKhachHang);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(1050, 343);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // dataGridViewKhachHang
            // 
            dataGridViewKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKhachHang.Location = new Point(3, 360);
            dataGridViewKhachHang.Name = "dataGridViewKhachHang";
            dataGridViewKhachHang.RowHeadersWidth = 51;
            dataGridViewKhachHang.Size = new Size(1050, 255);
            dataGridViewKhachHang.TabIndex = 9;
            dataGridViewKhachHang.CellClick += dataGridViewKhachHang_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(351, 631);
            button1.Name = "button1";
            button1.Size = new Size(144, 41);
            button1.TabIndex = 10;
            button1.Text = "Xóa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(593, 631);
            button2.Name = "button2";
            button2.Size = new Size(121, 41);
            button2.TabIndex = 11;
            button2.Text = "Lưu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(809, 631);
            button3.Name = "button3";
            button3.Size = new Size(108, 41);
            button3.TabIndex = 12;
            button3.Text = "Thoát";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // KhachHangView
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewKhachHang);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 13.8F);
            Margin = new Padding(5);
            Name = "KhachHangView";
            Size = new Size(1057, 691);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKhachHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxMaKhachHang;
        private TextBox textBoxTenKhachHang;
        private TextBox textBoxDienThoai;
        private TextBox textBoxDiaChi;
        private Panel panel1;
        private DataGridView dataGridViewKhachHang;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
