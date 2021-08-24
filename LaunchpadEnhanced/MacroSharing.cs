using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LauncherEnhanced;
using MySql.Data.MySqlClient;

namespace LaunchpadEnhanced
{
	public class MacroSharing : Form
	{
		private IContainer components;

		private ComboBox characterCombo;

		private ListBox nameListBox;

		private TextBox nameTextBox;

		private TextBox iconTextBox;

		private TextBox bodyTextBox;

		private Button addMacroButton;

		private Button updateButton;

		private Label label1;

		private ComboBox remoteCombo;

		private ListBox remoteListbox;

		private Button mainButton;

		private TextBox textBox1;

		private Button button3;

		private Button oldMacroButton;

		private Button button5;

		private Label creatorLabel;

		private Label ratingLabel;

		private PictureBox macroIconImage;

		private Label dlLabel;

		private RichTextBox commentsTextBox;

		private Label label2;

		private Label label3;

		private Label label4;

		private TextBox usernameTextBox;

		private Button deleteMacroButton;

		private Button button1;

		private string pathToEmu;

		private string pathToOldInstall;

		private string user;

		private ArrayList macroName = new ArrayList();

		private ArrayList macroIcon = new ArrayList();

		private ArrayList macroBody = new ArrayList();

		private ArrayList macroCharacter = new ArrayList();

		private ArrayList oldMacroName = new ArrayList();

		private ArrayList oldMacroIcon = new ArrayList();

		private ArrayList oldMacroBody = new ArrayList();

		private ArrayList oldMacroCharacter = new ArrayList();

		private ArrayList remoteCategories = new ArrayList();

		private bool buttonGetsLocal = true;

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
			characterCombo = new System.Windows.Forms.ComboBox();
			nameListBox = new System.Windows.Forms.ListBox();
			nameTextBox = new System.Windows.Forms.TextBox();
			iconTextBox = new System.Windows.Forms.TextBox();
			bodyTextBox = new System.Windows.Forms.TextBox();
			addMacroButton = new System.Windows.Forms.Button();
			updateButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			remoteCombo = new System.Windows.Forms.ComboBox();
			remoteListbox = new System.Windows.Forms.ListBox();
			mainButton = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			oldMacroButton = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			creatorLabel = new System.Windows.Forms.Label();
			ratingLabel = new System.Windows.Forms.Label();
			macroIconImage = new System.Windows.Forms.PictureBox();
			dlLabel = new System.Windows.Forms.Label();
			commentsTextBox = new System.Windows.Forms.RichTextBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			usernameTextBox = new System.Windows.Forms.TextBox();
			deleteMacroButton = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)macroIconImage).BeginInit();
			SuspendLayout();
			characterCombo.FormattingEnabled = true;
			characterCombo.Location = new System.Drawing.Point(16, 80);
			characterCombo.Margin = new System.Windows.Forms.Padding(4);
			characterCombo.Name = "characterCombo";
			characterCombo.Size = new System.Drawing.Size(191, 24);
			characterCombo.Sorted = true;
			characterCombo.TabIndex = 0;
			characterCombo.Text = "Accounts";
			characterCombo.SelectedIndexChanged += new System.EventHandler(characterCombo_SelectedIndexChanged);
			nameListBox.FormattingEnabled = true;
			nameListBox.ItemHeight = 16;
			nameListBox.Location = new System.Drawing.Point(16, 123);
			nameListBox.Margin = new System.Windows.Forms.Padding(4);
			nameListBox.Name = "nameListBox";
			nameListBox.Size = new System.Drawing.Size(221, 388);
			nameListBox.TabIndex = 1;
			nameListBox.SelectedIndexChanged += new System.EventHandler(nameListBox_SelectedIndexChanged);
			nameTextBox.Location = new System.Drawing.Point(247, 80);
			nameTextBox.Margin = new System.Windows.Forms.Padding(4);
			nameTextBox.Name = "nameTextBox";
			nameTextBox.Size = new System.Drawing.Size(152, 22);
			nameTextBox.TabIndex = 2;
			iconTextBox.Location = new System.Drawing.Point(379, 96);
			iconTextBox.Margin = new System.Windows.Forms.Padding(4);
			iconTextBox.Name = "iconTextBox";
			iconTextBox.Size = new System.Drawing.Size(131, 22);
			iconTextBox.TabIndex = 3;
			iconTextBox.Visible = false;
			bodyTextBox.Location = new System.Drawing.Point(245, 126);
			bodyTextBox.Margin = new System.Windows.Forms.Padding(4);
			bodyTextBox.Multiline = true;
			bodyTextBox.Name = "bodyTextBox";
			bodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			bodyTextBox.Size = new System.Drawing.Size(256, 150);
			bodyTextBox.TabIndex = 4;
			addMacroButton.Location = new System.Drawing.Point(16, 520);
			addMacroButton.Name = "addMacroButton";
			addMacroButton.Size = new System.Drawing.Size(52, 23);
			addMacroButton.TabIndex = 5;
			addMacroButton.Text = "New";
			addMacroButton.UseVisualStyleBackColor = true;
			addMacroButton.Click += new System.EventHandler(addMacroButton_Click);
			updateButton.Location = new System.Drawing.Point(316, 520);
			updateButton.Name = "updateButton";
			updateButton.Size = new System.Drawing.Size(104, 23);
			updateButton.TabIndex = 6;
			updateButton.Text = "Modify Macro";
			updateButton.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(37, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(687, 17);
			label1.TabIndex = 7;
			label1.Text = "ALMOST \"FUNCTIONAL\", THERE ARE BACKUPS OF THE WORKING ONES IN THE LAUNCHPAD FOLDER";
			remoteCombo.FormattingEnabled = true;
			remoteCombo.Location = new System.Drawing.Point(508, 126);
			remoteCombo.Name = "remoteCombo";
			remoteCombo.Size = new System.Drawing.Size(234, 24);
			remoteCombo.TabIndex = 8;
			remoteCombo.Text = "Download New Macros";
			remoteCombo.SelectedIndexChanged += new System.EventHandler(remoteCombo_SelectedIndexChanged);
			remoteListbox.FormattingEnabled = true;
			remoteListbox.ItemHeight = 16;
			remoteListbox.Location = new System.Drawing.Point(508, 155);
			remoteListbox.Name = "remoteListbox";
			remoteListbox.Size = new System.Drawing.Size(234, 356);
			remoteListbox.TabIndex = 9;
			remoteListbox.SelectedIndexChanged += new System.EventHandler(remoteListBox_SelectedIndexChanged);
			mainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			mainButton.Location = new System.Drawing.Point(299, 294);
			mainButton.Name = "mainButton";
			mainButton.Size = new System.Drawing.Size(151, 41);
			mainButton.TabIndex = 10;
			mainButton.Text = "Choose";
			mainButton.UseVisualStyleBackColor = true;
			mainButton.Click += new System.EventHandler(mainButton_Click);
			textBox1.Location = new System.Drawing.Point(508, 96);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(173, 22);
			textBox1.TabIndex = 12;
			button3.Location = new System.Drawing.Point(683, 95);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(75, 23);
			button3.TabIndex = 13;
			button3.Text = "Search";
			button3.UseVisualStyleBackColor = true;
			oldMacroButton.Location = new System.Drawing.Point(506, 520);
			oldMacroButton.Name = "oldMacroButton";
			oldMacroButton.Size = new System.Drawing.Size(136, 23);
			oldMacroButton.TabIndex = 14;
			oldMacroButton.Text = "Import Old Macro's";
			oldMacroButton.UseVisualStyleBackColor = true;
			oldMacroButton.Click += new System.EventHandler(oldMacroButton_Click);
			button5.Location = new System.Drawing.Point(648, 520);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(110, 23);
			button5.TabIndex = 15;
			button5.Text = "Select Folder";
			button5.UseVisualStyleBackColor = true;
			creatorLabel.AutoSize = true;
			creatorLabel.BackColor = System.Drawing.Color.Transparent;
			creatorLabel.Location = new System.Drawing.Point(243, 466);
			creatorLabel.Name = "creatorLabel";
			creatorLabel.Size = new System.Drawing.Size(125, 17);
			creatorLabel.TabIndex = 16;
			creatorLabel.Text = "Macro Created By:";
			ratingLabel.AutoSize = true;
			ratingLabel.BackColor = System.Drawing.Color.Transparent;
			ratingLabel.Location = new System.Drawing.Point(243, 483);
			ratingLabel.Name = "ratingLabel";
			ratingLabel.Size = new System.Drawing.Size(53, 17);
			ratingLabel.TabIndex = 17;
			ratingLabel.Text = "Rating:";
			macroIconImage.Location = new System.Drawing.Point(415, 62);
			macroIconImage.Name = "macroIconImage";
			macroIconImage.Size = new System.Drawing.Size(70, 57);
			macroIconImage.TabIndex = 18;
			macroIconImage.TabStop = false;
			dlLabel.AutoSize = true;
			dlLabel.BackColor = System.Drawing.Color.Transparent;
			dlLabel.Location = new System.Drawing.Point(356, 483);
			dlLabel.Name = "dlLabel";
			dlLabel.Size = new System.Drawing.Size(81, 17);
			dlLabel.TabIndex = 19;
			dlLabel.Text = "Downloads:";
			commentsTextBox.Location = new System.Drawing.Point(243, 367);
			commentsTextBox.Name = "commentsTextBox";
			commentsTextBox.Size = new System.Drawing.Size(257, 96);
			commentsTextBox.TabIndex = 20;
			commentsTextBox.Text = "";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Location = new System.Drawing.Point(327, 347);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(74, 17);
			label2.TabIndex = 21;
			label2.Text = "Comments";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(45, 47);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(133, 25);
			label3.TabIndex = 22;
			label3.Text = "Local Macro's";
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(545, 47);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(153, 25);
			label4.TabIndex = 23;
			label4.Text = "Remote Macro's";
			usernameTextBox.Location = new System.Drawing.Point(269, 34);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new System.Drawing.Size(100, 22);
			usernameTextBox.TabIndex = 24;
			usernameTextBox.Visible = false;
			deleteMacroButton.Location = new System.Drawing.Point(78, 520);
			deleteMacroButton.Name = "deleteMacroButton";
			deleteMacroButton.Size = new System.Drawing.Size(59, 23);
			deleteMacroButton.TabIndex = 25;
			deleteMacroButton.Text = "Delete";
			deleteMacroButton.UseVisualStyleBackColor = true;
			deleteMacroButton.Click += new System.EventHandler(deleteMacroButton_Click);
			button1.Location = new System.Drawing.Point(146, 520);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 23);
			button1.TabIndex = 26;
			button1.Text = "Copy From";
			button1.UseVisualStyleBackColor = true;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(770, 561);
			base.Controls.Add(button1);
			base.Controls.Add(deleteMacroButton);
			base.Controls.Add(usernameTextBox);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(commentsTextBox);
			base.Controls.Add(dlLabel);
			base.Controls.Add(macroIconImage);
			base.Controls.Add(ratingLabel);
			base.Controls.Add(creatorLabel);
			base.Controls.Add(button5);
			base.Controls.Add(oldMacroButton);
			base.Controls.Add(button3);
			base.Controls.Add(textBox1);
			base.Controls.Add(mainButton);
			base.Controls.Add(remoteListbox);
			base.Controls.Add(remoteCombo);
			base.Controls.Add(label1);
			base.Controls.Add(updateButton);
			base.Controls.Add(addMacroButton);
			base.Controls.Add(bodyTextBox);
			base.Controls.Add(iconTextBox);
			base.Controls.Add(nameTextBox);
			base.Controls.Add(nameListBox);
			base.Controls.Add(characterCombo);
			base.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			base.Name = "MacroSharing";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "My Macros";
			base.Load += new System.EventHandler(MacroSharing_Load);
			((System.ComponentModel.ISupportInitialize)macroIconImage).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public MacroSharing(string inString, string inString2)
		{
			pathToEmu = inString;
			pathToOldInstall = inString2;
			InitializeComponent();
			if (!Directory.Exists(LPE.commonFiles + "Macro Backups"))
			{
				Directory.CreateDirectory(LPE.commonFiles + "Macro Backups");
			}
		}

		private void MacroSharing_Load(object sender, EventArgs e)
		{
			findAllMacroFiles(pathToEmu);
			populateComboBox();
			getMacrosCatagories();
			populateRemoteComboBox();
			MacroLogin macroLogin = new MacroLogin();
			if (string.IsNullOrEmpty(macroLogin.username))
			{
				DialogResult dialogResult = macroLogin.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					user = macroLogin.username;
					usernameTextBox.Text = macroLogin.username;
				}
				else
				{
					Close();
				}
			}
			else
			{
				usernameTextBox.Text = macroLogin.username;
			}
			macroLogin.Dispose();
		}

		private void populateComboBox()
		{
			for (int i = 0; i < macroCharacter.Count; i++)
			{
				if (!characterCombo.Items.Contains(macroCharacter[i].ToString()))
				{
					characterCombo.Items.Add(macroCharacter[i].ToString());
				}
			}
		}

		private void populateRemoteComboBox()
		{
			for (int i = 0; i < remoteCategories.Count; i++)
			{
				if (!remoteCombo.Items.Contains(remoteCategories[i].ToString()))
				{
					remoteCombo.Items.Add(remoteCategories[i].ToString());
				}
			}
		}

		private void populateRemoteComboBoxOldMacros()
		{
			remoteCombo.Items.Clear();
			for (int i = 0; i < oldMacroCharacter.Count; i++)
			{
				if (!remoteCombo.Items.Contains(oldMacroCharacter[i].ToString()))
				{
					remoteCombo.Items.Add(oldMacroCharacter[i].ToString());
				}
			}
		}

		private void populateListBox(string inString)
		{
			nameListBox.Items.Clear();
			for (int i = 0; i < macroCharacter.Count; i++)
			{
				if (macroCharacter[i].ToString().Contains(inString))
				{
					nameListBox.Items.Add(macroName[i].ToString());
				}
			}
		}

		private void populateRemoteListBoxOldMacros(string inString)
		{
			remoteListbox.Items.Clear();
			for (int i = 0; i < oldMacroCharacter.Count; i++)
			{
				if (oldMacroCharacter[i].ToString().Contains(inString))
				{
					remoteListbox.Items.Add(oldMacroName[i].ToString());
				}
			}
		}

		private void populateRemoteListBoxRemoteMacros(string inString, ArrayList theArray)
		{
			remoteListbox.Items.Clear();
			for (int i = 0; i < theArray.Count; i++)
			{
				remoteListbox.Items.Add(theArray[i].ToString());
			}
		}

		private string getName(string inString)
		{
			try
			{
				while (inString.IndexOf("\\") != inString.LastIndexOf("\\"))
				{
					inString = inString.Substring(inString.IndexOf('\\') + 1);
				}
				inString = inString.Substring(0, inString.IndexOf('\\'));
				return inString;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error getting file name: " + ex.Message + "\nClosing Macro Manager, Try again");
				Close();
				return inString;
			}
		}

		private void findAllMacroFiles(string path)
		{
			try
			{
				ArrayList allFilesInDir = new ArrayList();
				ArrayList arrayList = new ArrayList();
				allFilesInDir = isolateMacroFiles(listContents(path, allFilesInDir));
				for (int i = 0; i < allFilesInDir.Count; i++)
				{
					arrayList = readFileToString(allFilesInDir[i].ToString());
					string name = getName(allFilesInDir[i].ToString());
					if (arrayList[0].ToString().Contains("version: 0000"))
					{
						for (int j = 1; j < arrayList.Count; j++)
						{
							string text = arrayList[j].ToString();
							text = text.Substring(text.IndexOf(" ") + 1);
							string value = text.Substring(0, text.IndexOf(" "));
							text = text.Substring(text.IndexOf(" ") + 1);
							string value2 = text.Substring(0, text.IndexOf("/")).Trim();
							string value3 = text.Substring(text.IndexOf("/"));
							macroCharacter.Add(name);
							macroName.Add(value);
							macroIcon.Add(value2);
							macroBody.Add(value3);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error finding macro's: " + ex.Message + "\nClosing Macro Manager");
				Close();
			}
		}

		private void findAllOldMacroFiles(string path)
		{
			try
			{
				ArrayList allFilesInDir = new ArrayList();
				ArrayList arrayList = new ArrayList();
				allFilesInDir = isolateMacroFiles(listContents(path, allFilesInDir));
				for (int i = 0; i < allFilesInDir.Count; i++)
				{
					arrayList = readFileToString(allFilesInDir[i].ToString());
					string name = getName(allFilesInDir[i].ToString());
					if (arrayList[0].ToString().Contains("version: 0000"))
					{
						for (int j = 1; j < arrayList.Count; j++)
						{
							string text = arrayList[j].ToString();
							text = text.Substring(text.IndexOf(" ") + 1);
							string value = text.Substring(0, text.IndexOf(" "));
							text = text.Substring(text.IndexOf(" ") + 1);
							string value2 = text.Substring(0, text.IndexOf("/")).Trim();
							string value3 = text.Substring(text.IndexOf("/"));
							oldMacroCharacter.Add(name);
							oldMacroName.Add(value);
							oldMacroIcon.Add(value2);
							oldMacroBody.Add(value3);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error finding old macro's: " + ex.Message + "\nClosing Macro Manager");
				Close();
			}
		}

		private ArrayList isolateMacroFiles(ArrayList allFiles)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < allFiles.Count; i++)
			{
				if (allFiles[i].ToString().Contains("macros.txt"))
				{
					arrayList.Add(allFiles[i]);
				}
			}
			return arrayList;
		}

		private ArrayList listContents(string dir, ArrayList AllFilesInDir)
		{
			string[] files = Directory.GetFiles(dir);
			string[] directories = Directory.GetDirectories(dir);
			for (int i = 0; i < directories.Length; i++)
			{
				listContents(directories[i], AllFilesInDir);
			}
			for (int j = 0; j < files.Length; j++)
			{
				AllFilesInDir.Add(files[j]);
			}
			return AllFilesInDir;
		}

		private ArrayList readFileToString(string fileName)
		{
			ArrayList arrayList = new ArrayList();
			try
			{
				TextReader textReader = new StreamReader(fileName);
				string text = textReader.ReadLine();
				int num = 0;
				while (text != null)
				{
					if (text.Length > 1)
					{
						arrayList.Add(text);
						num++;
					}
					text = textReader.ReadLine();
				}
				textReader.Close();
				return arrayList;
			}
			catch (Exception)
			{
				return arrayList;
			}
		}

		private void characterCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(characterCombo.Text))
			{
				nameListBox.Items.Clear();
				populateListBox(characterCombo.Text);
			}
		}

		private void remoteCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(remoteCombo.Text))
			{
				if (buttonGetsLocal)
				{
					populateRemoteListBoxRemoteMacros(remoteCombo.Text, getMacroByCategory(remoteCombo.Text));
				}
				else
				{
					populateRemoteListBoxOldMacros(remoteCombo.Text);
				}
			}
		}

		private string[] makeMacroTextBox(string inString)
		{
			string[] array = inString.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] += ";";
			}
			return array;
		}

		private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = ((ListBox)sender).SelectedIndex;
			remoteListbox.ClearSelected();
			nameListBox.SelectedIndex = selectedIndex;
			clearMiddle();
			try
			{
				if (!string.IsNullOrEmpty(nameListBox.SelectedItem.ToString()))
				{
					int index = macroName.IndexOf(nameListBox.SelectedItem.ToString());
					nameTextBox.Text = macroName[index].ToString();
					iconTextBox.Text = macroIcon[index].ToString();
					bodyTextBox.Lines = makeMacroTextBox(macroBody[index].ToString());
					creatorLabel.Text = "Macro Created By: " + usernameTextBox.Text;
					mainButton.Text = "Upload This";
				}
			}
			catch
			{
			}
		}

		private void remoteListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = ((ListBox)sender).SelectedIndex;
			nameListBox.ClearSelected();
			clearMiddle();
			remoteListbox.SelectedIndex = selectedIndex;
			try
			{
				if (!string.IsNullOrEmpty(remoteListbox.SelectedItem.ToString()))
				{
					if (!buttonGetsLocal)
					{
						int index = oldMacroName.IndexOf(remoteListbox.SelectedItem.ToString());
						nameTextBox.Text = oldMacroName[index].ToString();
						iconTextBox.Text = oldMacroIcon[index].ToString();
						bodyTextBox.Lines = makeMacroTextBox(oldMacroBody[index].ToString());
						mainButton.Text = "Download This";
						return;
					}
					ArrayList arrayList = new ArrayList();
					arrayList = getRemoteMacro(remoteListbox.SelectedItem.ToString(), remoteCombo.Text);
					nameTextBox.Text = arrayList[1].ToString();
					iconTextBox.Text = arrayList[2].ToString();
					bodyTextBox.Lines = makeMacroTextBox(arrayList[3].ToString());
					commentsTextBox.Lines = makeMacroTextBox(arrayList[6].ToString());
					creatorLabel.Text = "Macro Created By: " + arrayList[0].ToString();
					ratingLabel.Text = "Rating: " + arrayList[4].ToString();
					dlLabel.Text = "Downloads: " + arrayList[5].ToString();
					mainButton.Text = "Download This";
				}
			}
			catch
			{
			}
		}

		private void deleteThisMacroToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(string.Concat(nameListBox.SelectedItem));
		}

		private void getMacrosCatagories()
		{
			try
			{
				string connectionString = "Server=lpedb.ocdsoft.com;Database=lpedb;Uid=lpeuser;Pwd=lpeuser;";
				MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM categories", mySqlConnection);
				mySqlConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				try
				{
					while (mySqlDataReader.Read())
					{
						remoteCategories.Add(mySqlDataReader.GetString("categories"));
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error Retrieving data, Closing window.\nTry again");
					mainForm.writeCrashLog("Problem: Failed to get Remote macro categories\nSolution: Closing Window\n" + ex.Message, ex.StackTrace, ex.Source);
					Close();
				}
				mySqlDataReader.Close();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
				mainForm.writeCrashLog("Problem: Failed to Update from SQL\nSolution: Bypassed update", ex2.StackTrace, ex2.Source);
			}
		}

		private ArrayList getRemoteMacro(string name, string category)
		{
			ArrayList arrayList = new ArrayList();
			try
			{
				string connectionString = "Server=lpedb.ocdsoft.com;Database=lpedb;Uid=lpeuser;Pwd=lpeuser;";
				MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM macros WHERE name='" + name + "' AND category='" + category + "'", mySqlConnection);
				mySqlConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				try
				{
					while (mySqlDataReader.Read())
					{
						arrayList.Add(mySqlDataReader.GetString("user"));
						arrayList.Add(mySqlDataReader.GetString("name"));
						arrayList.Add(mySqlDataReader.GetString("icon"));
						arrayList.Add(mySqlDataReader.GetString("body"));
						arrayList.Add(mySqlDataReader.GetInt16("rating"));
						arrayList.Add(mySqlDataReader.GetInt16("downloads"));
						arrayList.Add(mySqlDataReader.GetString("summary"));
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error Retrieving data, Closing window.\nTry again");
					mainForm.writeCrashLog("Problem: Failed to get Remote macro categories\nSolution: Closing Window\n" + ex.Message, ex.StackTrace, ex.Source);
					Close();
				}
				mySqlDataReader.Close();
				return arrayList;
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
				mainForm.writeCrashLog("Problem: Failed to Update from SQL\nSolution: Bypassed update", ex2.StackTrace, ex2.Source);
				return arrayList;
			}
		}

		private ArrayList getMacroByCategory(string category)
		{
			ArrayList arrayList = new ArrayList();
			try
			{
				string connectionString = "Server=mysql102.mysite4now.com;Database=macros;Uid=SWGEmu;Pwd=emurocks69;";
				MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM macros WHERE category='" + category + "'", mySqlConnection);
				mySqlConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				try
				{
					while (mySqlDataReader.Read())
					{
						arrayList.Add(mySqlDataReader.GetString("name"));
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error Retrieving data, Closing window.\nTry again");
					mainForm.writeCrashLog("Problem: Failed to get Remote macro categories\nSolution: Closing Window\n" + ex.Message, ex.StackTrace, ex.Source);
					Close();
				}
				mySqlDataReader.Close();
				return arrayList;
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
				mainForm.writeCrashLog("Problem: Failed to Update from SQL\nSolution: Bypassed update", ex2.StackTrace, ex2.Source);
				return arrayList;
			}
		}

		private void writeMacro(string location, string filename)
		{
			try
			{
				StreamWriter streamWriter = File.CreateText(location + "\\" + filename);
				streamWriter.Write("version: 0000\n");
				for (int i = 0; i < macroBody.Count; i++)
				{
					streamWriter.Write(i + 1 + " " + macroName[i].ToString() + " " + macroIcon[i].ToString() + " " + macroBody[i].ToString() + "\n");
				}
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error writing macro File: " + ex.Message + "\nClosing macro manager");
				Close();
			}
		}

		private void clearMiddle()
		{
			bodyTextBox.Clear();
			iconTextBox.Clear();
			nameTextBox.Clear();
			macroIconImage.Image = null;
			commentsTextBox.Clear();
			creatorLabel.Text = "Macro Created By:";
			ratingLabel.Text = "Rating:";
			dlLabel.Text = "Downloads:";
		}

		private void oldMacroButton_Click(object sender, EventArgs e)
		{
			clearMiddle();
			if (buttonGetsLocal)
			{
				remoteListbox.Items.Clear();
				remoteCombo.Items.Clear();
				findAllOldMacroFiles(pathToOldInstall);
				populateRemoteComboBoxOldMacros();
				remoteCombo.Text = "Select Old Character here";
				oldMacroButton.Text = "Download Macro's";
				buttonGetsLocal = false;
			}
			else
			{
				remoteListbox.Items.Clear();
				remoteCombo.Items.Clear();
				getMacrosCatagories();
				populateRemoteComboBox();
				remoteCombo.Text = "Download New Macros";
				oldMacroButton.Text = "Import Old Macro's";
				buttonGetsLocal = true;
			}
		}

		private void mainButton_Click(object sender, EventArgs e)
		{
			if (mainButton.Text.Contains("Upload"))
			{
				if (!string.IsNullOrEmpty(commentsTextBox.Text))
				{
					uploadMacro();
				}
				else
				{
					MessageBox.Show("Please enter comments");
				}
			}
			else if (mainButton.Text.Contains("Download"))
			{
				macroCharacter.Add(characterCombo.Text);
				macroName.Add(nameTextBox.Text);
				macroIcon.Add(iconTextBox.Text);
				macroBody.Add(bodyTextBox.Text.Replace("\r", "").Replace("\n", ""));
				populateListBox(characterCombo.Text);
				backupAndWrite();
			}
		}

		private void uploadMacro()
		{
			try
			{
				string category = getCategory();
				if (!string.IsNullOrEmpty(category))
				{
					string connectionString = "Server=lpedb.ocdsoft.com;Database=lpedb;Uid=lpeuser;Pwd=lpeuser;";
					MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
					MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO macros (user, name, icon, body, rating, downloads, summary, category) VALUES('" + usernameTextBox.Text + "', '" + nameTextBox.Text + "', '" + iconTextBox.Text + "', '" + bodyTextBox.Text.Replace("\r", "").Replace("\n", "") + "', '0', '0', '" + commentsTextBox.Text + "', '" + category + "')", mySqlConnection);
					mySqlConnection.Open();
					try
					{
						mySqlCommand.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error uploading macro, Closing window.\nTry again");
						mainForm.writeCrashLog("Problem: Failed to get Remote macro categories\nSolution: Closing Window\n" + ex.Message, ex.StackTrace, ex.Source);
						Close();
					}
					mySqlConnection.Close();
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
				mainForm.writeCrashLog("Problem: Failed to Update from SQL\nSolution: Bypassed update", ex2.StackTrace, ex2.Source);
			}
		}

		private string getCategory()
		{
			GetCategory getCategory = new GetCategory();
			getCategory.ShowDialog();
			return getCategory.category;
		}

		private void backupAndWrite()
		{
			File.Exists(LPE.commonFiles + "Macro Backups\\" + DateTime.Now.ToShortDateString().Replace("/", "-") + DateTime.Now.ToShortTimeString().Replace(":", "-").Replace(" ", "") + ".txt");
			File.Delete(LPE.commonFiles + "Macro Backups\\" + DateTime.Now.ToShortDateString().Replace("/", "-") + DateTime.Now.ToShortTimeString().Replace(":", "-").Replace(" ", "") + ".txt");
			File.Move(pathToEmu + "\\profiles\\" + characterCombo.Text + "\\macros.txt", LPE.commonFiles + "Macro Backups\\" + DateTime.Now.ToShortDateString().Replace("/", "-") + DateTime.Now.ToShortTimeString().Replace(":", "-").Replace(" ", "") + ".txt");
			writeMacro(pathToEmu + "\\profiles\\" + characterCombo.Text, "macros.txt");
		}

		private void addMacroButton_Click(object sender, EventArgs e)
		{
		}

		private void deleteMacroButton_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(nameListBox.SelectedItem.ToString()))
			{
				int selectedIndex = nameListBox.SelectedIndex;
				macroName.RemoveAt(selectedIndex);
				macroBody.RemoveAt(selectedIndex);
				macroIcon.RemoveAt(selectedIndex);
				macroCharacter.RemoveAt(selectedIndex);
				populateListBox(characterCombo.Text);
				backupAndWrite();
			}
		}
	}
}
