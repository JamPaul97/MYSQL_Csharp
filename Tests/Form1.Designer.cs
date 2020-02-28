namespace Tests
{
	partial class Form1
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_login = new MetroFramework.Controls.MetroButton();
			this.username_txt = new MetroFramework.Controls.MetroTextBox();
			this.metroTile1 = new MetroFramework.Controls.MetroTile();
			this.tile = new MetroFramework.Controls.MetroTile();
			this.btn_register = new MetroFramework.Controls.MetroButton();
			this.password_txt = new MetroFramework.Controls.MetroTextBox();
			this.SuspendLayout();
			// 
			// btn_login
			// 
			this.btn_login.Location = new System.Drawing.Point(529, 267);
			this.btn_login.Name = "btn_login";
			this.btn_login.Size = new System.Drawing.Size(162, 55);
			this.btn_login.Style = MetroFramework.MetroColorStyle.Blue;
			this.btn_login.TabIndex = 0;
			this.btn_login.Text = "Login";
			this.btn_login.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.btn_login.UseSelectable = true;
			this.btn_login.Click += new System.EventHandler(this.Btn_login_Click);
			// 
			// username_txt
			// 
			// 
			// 
			// 
			this.username_txt.CustomButton.Image = null;
			this.username_txt.CustomButton.Location = new System.Drawing.Point(206, 1);
			this.username_txt.CustomButton.Name = "";
			this.username_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.username_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.username_txt.CustomButton.TabIndex = 1;
			this.username_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.username_txt.CustomButton.UseSelectable = true;
			this.username_txt.CustomButton.Visible = false;
			this.username_txt.Lines = new string[0];
			this.username_txt.Location = new System.Drawing.Point(316, 124);
			this.username_txt.MaxLength = 32767;
			this.username_txt.Name = "username_txt";
			this.username_txt.PasswordChar = '\0';
			this.username_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.username_txt.SelectedText = "";
			this.username_txt.SelectionLength = 0;
			this.username_txt.SelectionStart = 0;
			this.username_txt.ShortcutsEnabled = true;
			this.username_txt.Size = new System.Drawing.Size(228, 23);
			this.username_txt.TabIndex = 1;
			this.username_txt.UseSelectable = true;
			this.username_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.username_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroTile1
			// 
			this.metroTile1.ActiveControl = null;
			this.metroTile1.Location = new System.Drawing.Point(176, 97);
			this.metroTile1.Name = "metroTile1";
			this.metroTile1.Size = new System.Drawing.Size(515, 79);
			this.metroTile1.TabIndex = 2;
			this.metroTile1.Text = "Username";
			this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
			this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.metroTile1.UseSelectable = true;
			// 
			// tile
			// 
			this.tile.ActiveControl = null;
			this.tile.Location = new System.Drawing.Point(176, 182);
			this.tile.Name = "tile";
			this.tile.Size = new System.Drawing.Size(515, 79);
			this.tile.Style = MetroFramework.MetroColorStyle.Green;
			this.tile.TabIndex = 3;
			this.tile.Text = "Password";
			this.tile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
			this.tile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.tile.UseSelectable = true;
			// 
			// btn_register
			// 
			this.btn_register.Location = new System.Drawing.Point(176, 267);
			this.btn_register.Name = "btn_register";
			this.btn_register.Size = new System.Drawing.Size(162, 55);
			this.btn_register.Style = MetroFramework.MetroColorStyle.Blue;
			this.btn_register.TabIndex = 4;
			this.btn_register.Text = "Register";
			this.btn_register.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.btn_register.UseSelectable = true;
			this.btn_register.Click += new System.EventHandler(this.Btn_register_Click);
			// 
			// password_txt
			// 
			// 
			// 
			// 
			this.password_txt.CustomButton.Image = null;
			this.password_txt.CustomButton.Location = new System.Drawing.Point(206, 1);
			this.password_txt.CustomButton.Name = "";
			this.password_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.password_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.password_txt.CustomButton.TabIndex = 1;
			this.password_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.password_txt.CustomButton.UseSelectable = true;
			this.password_txt.CustomButton.Visible = false;
			this.password_txt.Lines = new string[0];
			this.password_txt.Location = new System.Drawing.Point(317, 214);
			this.password_txt.MaxLength = 32767;
			this.password_txt.Name = "password_txt";
			this.password_txt.PasswordChar = '*';
			this.password_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.password_txt.SelectedText = "";
			this.password_txt.SelectionLength = 0;
			this.password_txt.SelectionStart = 0;
			this.password_txt.ShortcutsEnabled = true;
			this.password_txt.ShowClearButton = true;
			this.password_txt.Size = new System.Drawing.Size(228, 23);
			this.password_txt.TabIndex = 5;
			this.password_txt.UseSelectable = true;
			this.password_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.password_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(873, 385);
			this.Controls.Add(this.password_txt);
			this.Controls.Add(this.btn_register);
			this.Controls.Add(this.tile);
			this.Controls.Add(this.username_txt);
			this.Controls.Add(this.metroTile1);
			this.Controls.Add(this.btn_login);
			this.Name = "Form1";
			this.Text = "Login System - Test";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroButton btn_login;
		private MetroFramework.Controls.MetroTextBox username_txt;
		private MetroFramework.Controls.MetroTile metroTile1;
		private MetroFramework.Controls.MetroTile tile;
		private MetroFramework.Controls.MetroButton btn_register;
		private MetroFramework.Controls.MetroTextBox password_txt;
	}
}

