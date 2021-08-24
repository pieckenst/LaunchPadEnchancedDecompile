using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LaunchpadEnhanced
{
	public class ServerChoose : Form
	{
		private bool bMouseDown;

		private Point pntMousePosition;

		private bool bProcessingEvent;

		private IContainer components;

		private Button editButton;

		private Button addButton;

		private ImageList buttonImages;

		private Button closeButton;

		public ServerChoose()
		{
			InitializeComponent();
		}

		private void ServerChoose_Load(object sender, EventArgs e)
		{
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			GC.Collect();
			Close();
		}

		private void ServerChoose_MouseDown(object sender, MouseEventArgs e)
		{
			bMouseDown = true;
			pntMousePosition.X = e.X;
			pntMousePosition.Y = e.Y;
		}

		private void ServerChoose_MouseUp(object sender, MouseEventArgs e)
		{
			bMouseDown = false;
		}

		private void ServerChoose_MouseMove(object sender, MouseEventArgs e)
		{
			if (!bProcessingEvent && bMouseDown)
			{
				bProcessingEvent = true;
				base.DesktopLocation = new Point(base.Location.X + e.X - pntMousePosition.X, base.Location.Y + e.Y - pntMousePosition.Y);
				bProcessingEvent = false;
			}
		}

		private void addButton_MouseEnter(object sender, EventArgs e)
		{
			addButton.Image = buttonImages.Images[1];
			GC.Collect();
		}

		private void addButton_MouseLeave(object sender, EventArgs e)
		{
			addButton.Image = buttonImages.Images[0];
			GC.Collect();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			bool flag = false;
			if (base.OwnedForms.Length == 0)
			{
				flag = true;
			}
			if (flag)
			{
				AddServer addServer = new AddServer();
				AddOwnedForm(addServer);
				addServer.Show();
				GC.Collect();
			}
		}

		private void editButton_MouseEnter(object sender, EventArgs e)
		{
			editButton.Image = buttonImages.Images[3];
			GC.Collect();
		}

		private void editButton_MouseLeave(object sender, EventArgs e)
		{
			editButton.Image = buttonImages.Images[2];
			GC.Collect();
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			bool flag = false;
			if (base.OwnedForms.Length == 0)
			{
				flag = true;
			}
			if (flag)
			{
				EditServer editServer = new EditServer();
				AddOwnedForm(editServer);
				editServer.Show();
				GC.Collect();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchpadEnhanced.ServerChoose));
			editButton = new System.Windows.Forms.Button();
			buttonImages = new System.Windows.Forms.ImageList(components);
			addButton = new System.Windows.Forms.Button();
			closeButton = new System.Windows.Forms.Button();
			SuspendLayout();
			editButton.BackColor = System.Drawing.Color.Black;
			editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			editButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			editButton.FlatAppearance.BorderSize = 0;
			editButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			editButton.ForeColor = System.Drawing.Color.Black;
			editButton.ImageIndex = 2;
			editButton.ImageList = buttonImages;
			editButton.Location = new System.Drawing.Point(152, 99);
			editButton.Name = "editButton";
			editButton.Size = new System.Drawing.Size(97, 31);
			editButton.TabIndex = 25;
			editButton.TabStop = false;
			editButton.UseVisualStyleBackColor = false;
			editButton.MouseLeave += new System.EventHandler(editButton_MouseLeave);
			editButton.Click += new System.EventHandler(editButton_Click);
			editButton.MouseEnter += new System.EventHandler(editButton_MouseEnter);
			buttonImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("buttonImages.ImageStream");
			buttonImages.TransparentColor = System.Drawing.Color.Transparent;
			buttonImages.Images.SetKeyName(0, "add_base.png");
			buttonImages.Images.SetKeyName(1, "add_mouseover.png");
			buttonImages.Images.SetKeyName(2, "edit_base.png");
			buttonImages.Images.SetKeyName(3, "edit_mouseover.png");
			addButton.BackColor = System.Drawing.Color.Black;
			addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			addButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
			addButton.FlatAppearance.BorderSize = 0;
			addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			addButton.ForeColor = System.Drawing.Color.Black;
			addButton.ImageIndex = 0;
			addButton.ImageList = buttonImages;
			addButton.Location = new System.Drawing.Point(49, 99);
			addButton.Name = "addButton";
			addButton.Size = new System.Drawing.Size(97, 31);
			addButton.TabIndex = 24;
			addButton.UseVisualStyleBackColor = false;
			addButton.MouseLeave += new System.EventHandler(addButton_MouseLeave);
			addButton.Click += new System.EventHandler(addButton_Click);
			addButton.MouseEnter += new System.EventHandler(addButton_MouseEnter);
			closeButton.BackColor = System.Drawing.Color.Transparent;
			closeButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("closeButton.BackgroundImage");
			closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			closeButton.Location = new System.Drawing.Point(263, 27);
			closeButton.Name = "closeButton";
			closeButton.Size = new System.Drawing.Size(16, 14);
			closeButton.TabIndex = 29;
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += new System.EventHandler(closeButton_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.Red;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new System.Drawing.Size(289, 156);
			base.ControlBox = false;
			base.Controls.Add(closeButton);
			base.Controls.Add(editButton);
			base.Controls.Add(addButton);
			ForeColor = System.Drawing.Color.Black;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ServerChoose";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ServerChoose";
			base.TransparencyKey = System.Drawing.Color.Red;
			base.MouseUp += new System.Windows.Forms.MouseEventHandler(ServerChoose_MouseUp);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(ServerChoose_MouseMove);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(ServerChoose_MouseDown);
			base.Load += new System.EventHandler(ServerChoose_Load);
			ResumeLayout(false);
		}
	}
}
